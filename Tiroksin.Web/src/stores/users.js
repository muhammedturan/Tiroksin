import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { authService } from '../services/authService'
import signalrService from '../services/signalrService'
import { useThemeStore } from './theme'

export const useUsersStore = defineStore('users', () => {
  const users = ref([])
  const currentUser = ref(null) // Aktif kullanıcı

  // LocalStorage'dan verileri yükle
  const loadFromStorage = () => {
    const storedCurrentUser = localStorage.getItem('currentUser')

    if (storedCurrentUser) {
      currentUser.value = JSON.parse(storedCurrentUser)
    }
  }

  // LocalStorage'a kaydet
  const saveToStorage = () => {
    if (currentUser.value) {
      localStorage.setItem('currentUser', JSON.stringify(currentUser.value))
      // Multiplayer components için gerekli alanları ayrı ayrı kaydet
      localStorage.setItem('userId', currentUser.value.id)
      localStorage.setItem('username', currentUser.value.username)
      localStorage.setItem('avatar', currentUser.value.avatar)
    }
  }

  // Kullanıcı oluştur (API)
  const createUser = async (userData) => {
    try {
      const response = await authService.register({
        username: userData.username.toLowerCase(),
        displayName: userData.displayName || userData.username,
        email: userData.email,
        password: userData.password,
        theme: userData.theme || 'dark'
      })

      // Token'ı kaydet
      localStorage.setItem('token', response.token)

      const newUser = {
        id: response.id,
        username: response.username,
        displayName: response.displayName,
        avatar: response.avatar,
        theme: response.theme
      }

      currentUser.value = newUser
      saveToStorage()

      // Kullanıcının tema tercihini uygula
      const themeStore = useThemeStore()
      themeStore.setTheme(response.theme || 'dark')

      // SignalR'a bağlan
      try {
        await signalrService.connect(response.token)
        console.log('SignalR connected after registration')
      } catch (signalrError) {
        console.error('SignalR connection failed:', signalrError)
      }

      return newUser
    } catch (error) {
      const errorMsg = error.response?.data?.error || 'Kayıt başarısız!'
      throw new Error(errorMsg)
    }
  }

  // Giriş yap (API)
  const login = async (username, password = '123456') => {
    try {
      const response = await authService.login({
        username: username.toLowerCase(),
        password: password
      })

      // Token'ı kaydet
      localStorage.setItem('token', response.token)

      const user = {
        id: response.id,
        username: response.username,
        displayName: response.displayName,
        avatar: response.avatar,
        theme: response.theme
      }

      currentUser.value = user
      saveToStorage()

      // Kullanıcının tema tercihini uygula
      const themeStore = useThemeStore()
      themeStore.setTheme(response.theme || 'dark')

      // SignalR'a bağlan
      try {
        await signalrService.connect(response.token)
        console.log('SignalR connected after login')
      } catch (signalrError) {
        console.error('SignalR connection failed:', signalrError)
      }

      return user
    } catch (error) {
      const errorMsg = error.response?.data?.error || 'Giriş başarısız!'
      throw new Error(errorMsg)
    }
  }

  // Çıkış yap
  const logout = () => {
    currentUser.value = null
    localStorage.removeItem('currentUser')
    localStorage.removeItem('token')
    localStorage.removeItem('userId')
    localStorage.removeItem('username')
    localStorage.removeItem('avatar')
  }

  // Kullanıcı ara (username ile)
  const searchUsers = (query) => {
    if (!query) return []
    const lowerQuery = query.toLowerCase()
    return users.value.filter(u =>
      u.username.toLowerCase().includes(lowerQuery) &&
      u.id !== currentUser.value?.id // Kendini gösterme
    )
  }

  // ID ile kullanıcı bul
  const getUserById = (userId) => {
    return users.value.find(u => u.id === userId)
  }

  // Username ile kullanıcı bul
  const getUserByUsername = (username) => {
    return users.value.find(u => u.username.toLowerCase() === username.toLowerCase())
  }

  // Kullanıcıları API'den çek
  const fetchUsers = async () => {
    try {
      const response = await authService.getUsers()
      users.value = response
      return response
    } catch (error) {
      console.error('Kullanıcılar yüklenirken hata:', error)
      throw error
    }
  }

  // Getters
  const allUsers = computed(() => users.value)
  const isLoggedIn = computed(() => currentUser.value !== null)
  const otherUsers = computed(() =>
    users.value.filter(u => u.id !== currentUser.value?.id)
  )

  // İlk yüklemede localStorage'dan oku
  loadFromStorage()

  return {
    users,
    currentUser,
    allUsers,
    otherUsers,
    isLoggedIn,
    createUser,
    login,
    logout,
    fetchUsers,
    searchUsers,
    getUserById,
    getUserByUsername
  }
})

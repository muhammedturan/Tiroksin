<template>
  <nav style="position: sticky; top: 0; z-index: 1000; background: white; border-bottom: 1px solid #ddd; padding: 1rem 2rem; box-shadow: 0 2px 4px rgba(0,0,0,0.05);">
    <div style="max-width: 1200px; margin: 0 auto; display: flex; justify-content: space-between; align-items: center;">
      <router-link to="/" style="text-decoration: none; font-size: 1.5rem; font-weight: bold; color: #333;">
        🧬 Tiroksin
      </router-link>

      <!-- Giriş yapılmamışsa -->
      <div v-if="!currentUser" style="display: flex; gap: 1rem; align-items: center;">
        <div style="position: relative;">
          <button @click="showLoginModal = !showLoginModal" style="background: none; border: none; color: #666; padding: 0.5rem 1rem; cursor: pointer; font-size: 1rem;">Giriş Yap</button>

          <!-- Login Dropdown -->
          <div v-if="showLoginModal" style="position: absolute; top: 100%; right: 0; margin-top: 0.5rem; background: white; border-radius: 8px; padding: 1.5rem; width: 320px; box-shadow: 0 4px 12px rgba(0,0,0,0.15); border: 1px solid #ddd;">
            <!-- Arrow pointing up to button -->
            <div style="position: absolute; top: -8px; right: 20px; width: 0; height: 0; border-left: 8px solid transparent; border-right: 8px solid transparent; border-bottom: 8px solid white;"></div>
            <div style="position: absolute; top: -9px; right: 20px; width: 0; height: 0; border-left: 8px solid transparent; border-right: 8px solid transparent; border-bottom: 8px solid #ddd;"></div>

            <div style="margin-bottom: 1.5rem;">
              <h3 style="margin: 0 0 0.5rem 0; font-size: 1.25rem;">Giriş Yap</h3>
            </div>

            <form @submit.prevent="handleLogin">
              <div style="margin-bottom: 1rem;">
                <label style="display: block; margin-bottom: 0.5rem; font-weight: 500; font-size: 0.9rem;">Email veya Kullanıcı Adı</label>
                <input v-model="loginForm.email" type="text" required style="width: 100%; padding: 0.75rem; border: 1px solid #ddd; border-radius: 6px; font-size: 1rem; box-sizing: border-box;" placeholder="Email veya kullanıcı adınız" />
              </div>

              <div style="margin-bottom: 1.5rem;">
                <label style="display: block; margin-bottom: 0.5rem; font-weight: 500; font-size: 0.9rem;">Şifre</label>
                <input v-model="loginForm.password" type="password" required style="width: 100%; padding: 0.75rem; border: 1px solid #ddd; border-radius: 6px; font-size: 1rem; box-sizing: border-box;" placeholder="••••••••" />
              </div>

              <button type="submit" style="width: 100%; padding: 0.75rem; background: #333; color: white; border: none; border-radius: 6px; font-size: 1rem; font-weight: 500; cursor: pointer;">
                Giriş Yap
              </button>
            </form>

            <div style="text-align: center; margin-top: 1rem; color: #666; font-size: 0.85rem;">
              Hesabın yok mu? <router-link to="/register" @click="showLoginModal = false" style="color: #333; font-weight: 500;">Üye Ol</router-link>
            </div>
          </div>
        </div>

        <router-link to="/register" style="text-decoration: none; background: #333; color: white; padding: 0.5rem 1.5rem; border-radius: 6px; font-weight: 500;">Üye Ol</router-link>
      </div>

      <!-- Giriş yapılmışsa -->
      <div v-else style="display: flex; gap: 1.5rem; align-items: center;">
        <router-link to="/create-question" style="text-decoration: none; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 0.5rem 1.25rem; border-radius: 8px; font-weight: 600; font-size: 0.95rem; display: flex; align-items: center; gap: 0.5rem; transition: all 0.2s; box-shadow: 0 2px 6px rgba(102, 126, 234, 0.3);" @mouseover="$event.target.style.transform = 'translateY(-2px)'; $event.target.style.boxShadow = '0 4px 12px rgba(102, 126, 234, 0.4)'" @mouseleave="$event.target.style.transform = 'translateY(0)'; $event.target.style.boxShadow = '0 2px 6px rgba(102, 126, 234, 0.3)'">
          ➕ Soru Ekle
        </router-link>

        <div style="position: relative;">
          <button @click="showProfileMenu = !showProfileMenu" style="display: flex; align-items: center; gap: 0.75rem; background: none; border: 1px solid #e0e0e0; padding: 0.5rem 1rem; border-radius: 8px; cursor: pointer; transition: background 0.2s;" @mouseover="$event.target.style.background = '#f5f5f5'" @mouseleave="$event.target.style.background = 'none'">
          <div style="font-size: 1.5rem;">{{ currentUser.avatar }}</div>
          <div style="text-align: left;">
            <div style="font-weight: 600; font-size: 0.95rem; color: #333;">{{ currentUser.displayName }}</div>
            <div style="font-size: 0.8rem; color: #666;">@{{ currentUser.username }}</div>
          </div>
        </button>

        <!-- Profile Dropdown -->
        <div v-if="showProfileMenu" style="position: absolute; top: 100%; right: 0; margin-top: 0.5rem; background: white; border-radius: 8px; padding: 0.5rem; width: 200px; box-shadow: 0 4px 12px rgba(0,0,0,0.15); border: 1px solid #ddd;">
          <!-- Arrow pointing up to button -->
          <div style="position: absolute; top: -8px; right: 20px; width: 0; height: 0; border-left: 8px solid transparent; border-right: 8px solid transparent; border-bottom: 8px solid white;"></div>
          <div style="position: absolute; top: -9px; right: 20px; width: 0; height: 0; border-left: 8px solid transparent; border-right: 8px solid transparent; border-bottom: 8px solid #ddd;"></div>

          <button @click="handleLogout" style="width: 100%; text-align: left; padding: 0.75rem 1rem; background: none; border: none; cursor: pointer; border-radius: 6px; font-size: 0.95rem; color: #d32f2f; font-weight: 500; transition: background 0.2s;" @mouseover="$event.target.style.background = '#ffebee'" @mouseleave="$event.target.style.background = 'none'">
            🚪 Çıkış Yap
          </button>
        </div>
        </div>
      </div>
    </div>
  </nav>

  <!-- Backdrop to close dropdown when clicking outside -->
  <div v-if="showLoginModal || showProfileMenu" @click="showLoginModal = false; showProfileMenu = false" style="position: fixed; top: 0; left: 0; right: 0; bottom: 0; z-index: 999;"></div>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue'
import { useRouter } from 'vue-router'
import api from '../services/api'

const router = useRouter()
const showLoginModal = ref(false)
const showProfileMenu = ref(false)
const loginForm = ref({
  email: '',
  password: ''
})

// currentUser'ı computed olarak tanımla
const currentUser = computed(() => {
  const userStr = localStorage.getItem('user')
  if (userStr) {
    try {
      return JSON.parse(userStr)
    } catch (e) {
      console.error('Error parsing user from localStorage:', e)
      return null
    }
  }
  return null
})

onMounted(() => {
  console.log('Navbar mounted, currentUser:', currentUser.value)
})

const handleLogin = async () => {
  try {
    const response = await api.post('/auth/login', {
      username: loginForm.value.email,
      password: loginForm.value.password
    })

    // Token'ı localStorage'a kaydet
    localStorage.setItem('token', response.data.token)
    localStorage.setItem('user', JSON.stringify(response.data))

    // Formu temizle ve modal'ı kapat
    loginForm.value = { email: '', password: '' }
    showLoginModal.value = false

    // Ana sayfaya yönlendir
    router.push('/')

    alert(`Hoş geldin, ${response.data.displayName}!`)
  } catch (error) {
    const errorMessage = error.response?.data?.error || 'Giriş başarısız oldu'
    alert(errorMessage)
  }
}

const handleLogout = () => {
  // localStorage'ı temizle
  localStorage.removeItem('token')
  localStorage.removeItem('user')

  // State'i güncelle
  showProfileMenu.value = false

  // Ana sayfaya yönlendir
  router.push('/')

  alert('Çıkış yapıldı!')
}
</script>

import { defineStore } from 'pinia'
import { ref, watch } from 'vue'
import { authService } from '../services/authService'

export const useThemeStore = defineStore('theme', () => {
  // State - localStorage'dan oku veya 'dark' varsayilan
  const theme = ref(localStorage.getItem('theme') || 'dark')

  // Theme degistiginde localStorage'a kaydet ve body'ye uygula
  watch(theme, (newTheme) => {
    localStorage.setItem('theme', newTheme)
    applyTheme(newTheme)
  }, { immediate: true })

  function applyTheme(themeName) {
    document.documentElement.setAttribute('data-theme', themeName)
  }

  // Temayı ayarla (sadece local, API'ye gonderme)
  function setTheme(themeName) {
    theme.value = themeName
  }

  // Temayı degistir ve API'ye gonder (kullanici manuel degistirdiginde)
  async function setThemeAndSync(themeName) {
    theme.value = themeName

    // Kullanici giris yapmissa API'ye gonder
    const token = localStorage.getItem('token')
    if (token) {
      try {
        await authService.updateTheme(themeName)
      } catch (error) {
        console.error('Tema guncellenirken hata:', error)
      }
    }
  }

  // Toggle ve API'ye sync
  async function toggleTheme() {
    const newTheme = theme.value === 'dark' ? 'light' : 'dark'
    await setThemeAndSync(newTheme)
  }

  return {
    theme,
    setTheme,
    setThemeAndSync,
    toggleTheme,
    applyTheme
  }
})

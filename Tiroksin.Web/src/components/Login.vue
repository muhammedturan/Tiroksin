<template>
  <div class="login-page">
    <div class="login-card">
      <div class="logo">
        <span class="logo-icon">🎮</span>
        <h1>Tiroksin</h1>
        <p>Bilgi Yarismasina Hosgeldin!</p>
      </div>

      <div class="tabs">
        <button :class="{ active: mode === 'login' }" @click="mode = 'login'">Giris</button>
        <button :class="{ active: mode === 'register' }" @click="mode = 'register'">Kayit</button>
      </div>

      <form @submit.prevent="handleSubmit">
        <div class="input-group">
          <label>Kullanici Adi</label>
          <input v-model="username" type="text" placeholder="kullanici_adi" required />
        </div>

        <div class="input-group">
          <label>Sifre</label>
          <input v-model="password" type="password" placeholder="******" required minlength="6" />
        </div>

        <template v-if="mode === 'register'">
          <div class="input-group">
            <label>Isim</label>
            <input v-model="displayName" type="text" placeholder="Adiniz" required />
          </div>
          <div class="input-group">
            <label>Email</label>
            <input v-model="email" type="email" placeholder="email@example.com" required />
          </div>
          <div class="input-group">
            <label>Tema Secimi</label>
            <div class="theme-selector">
              <button
                type="button"
                :class="['theme-btn', { active: selectedTheme === 'dark' }]"
                @click="selectedTheme = 'dark'"
              >
                <span class="theme-icon">🌙</span>
                <span class="theme-name">Koyu</span>
              </button>
              <button
                type="button"
                :class="['theme-btn', { active: selectedTheme === 'light' }]"
                @click="selectedTheme = 'light'"
              >
                <span class="theme-icon">☀️</span>
                <span class="theme-name">Acik</span>
              </button>
            </div>
          </div>
        </template>

        <p v-if="error" class="error">{{ error }}</p>

        <button type="submit" class="btn-submit" :disabled="loading">
          {{ loading ? 'Yukleniyor...' : (mode === 'login' ? 'Giris Yap' : 'Kayit Ol') }}
        </button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref, watch } from 'vue'
import { useUsersStore } from '../stores/users'
import { useThemeStore } from '../stores/theme'
import { useRouter } from 'vue-router'

const usersStore = useUsersStore()
const themeStore = useThemeStore()
const router = useRouter()

const mode = ref('login')
const username = ref('')
const password = ref('')
const displayName = ref('')
const email = ref('')
const error = ref('')
const loading = ref(false)
const selectedTheme = ref('dark')

// Sadece register modunda tema secildiginde preview uygula
watch(selectedTheme, (newTheme) => {
  if (mode.value === 'register') {
    themeStore.setTheme(newTheme)
  }
})

// Login moduna gecildiginde default temaya don
watch(mode, (newMode) => {
  if (newMode === 'login') {
    themeStore.setTheme('dark')
  }
})

const handleSubmit = async () => {
  error.value = ''
  loading.value = true

  try {
    if (mode.value === 'login') {
      await usersStore.login(username.value, password.value)
      router.push('/')
    } else {
      if (!displayName.value || !email.value) {
        error.value = 'Tum alanlari doldurun'
        loading.value = false
        return
      }
      await usersStore.createUser({
        username: username.value,
        displayName: displayName.value,
        email: email.value,
        password: password.value,
        theme: selectedTheme.value
      })
      router.push('/')
    }
  } catch (err) {
    error.value = err.message
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.login-page {
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  background: var(--bg-gradient);
  padding: 20px;
}

.login-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 20px;
  padding: 40px;
  width: 100%;
  max-width: 400px;
  box-shadow: 0 8px 40px rgba(0, 0, 0, 0.4);
}

.logo {
  text-align: center;
  margin-bottom: 32px;
}

.logo-icon {
  font-size: 3rem;
  display: block;
  margin-bottom: 12px;
}

.logo h1 {
  font-size: 2rem;
  font-weight: 800;
  background: linear-gradient(135deg, var(--primary-light) 0%, var(--accent) 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  margin: 0 0 8px 0;
}

.logo p {
  color: var(--text-muted);
  font-size: 0.95rem;
  margin: 0;
}

.tabs {
  display: flex;
  gap: 8px;
  margin-bottom: 28px;
  background: var(--bg-card-light);
  padding: 6px;
  border-radius: 12px;
}

.tabs button {
  flex: 1;
  padding: 12px;
  border: none;
  background: transparent;
  color: var(--text-muted);
  font-size: 0.95rem;
  font-weight: 600;
  border-radius: 8px;
  cursor: pointer;
  transition: all 0.2s;
}

.tabs button.active {
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  box-shadow: 0 4px 16px var(--glow-blue);
}

.tabs button:not(.active):hover {
  color: var(--text);
}

form {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

.input-group {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.input-group label {
  font-size: 0.85rem;
  font-weight: 600;
  color: var(--text-muted);
}

.input-group input {
  padding: 14px 16px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 10px;
  font-size: 1rem;
  color: var(--text);
  transition: all 0.2s;
}

.input-group input::placeholder {
  color: var(--text-muted);
  opacity: 0.6;
}

.input-group input:focus {
  outline: none;
  border-color: var(--primary);
  box-shadow: 0 0 0 3px var(--glow-blue);
}

.error {
  color: var(--error);
  font-size: 0.9rem;
  text-align: center;
  padding: 10px;
  background: rgba(239, 68, 68, 0.1);
  border-radius: 8px;
  margin: 0;
}

.btn-submit {
  padding: 16px;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  border: none;
  border-radius: 12px;
  color: white;
  font-size: 1rem;
  font-weight: 700;
  cursor: pointer;
  transition: all 0.2s;
  box-shadow: 0 4px 20px var(--glow-blue);
  text-transform: uppercase;
  letter-spacing: 1px;
}

.btn-submit:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 8px 30px var(--glow-blue);
}

.btn-submit:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}

/* Theme Selector */
.theme-selector {
  display: flex;
  gap: 10px;
}

.theme-btn {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 8px;
  padding: 16px 12px;
  background: var(--bg-card-light);
  border: 2px solid var(--border);
  border-radius: 12px;
  cursor: pointer;
  transition: all 0.2s;
}

.theme-btn:hover {
  border-color: var(--primary);
  background: rgba(59, 130, 246, 0.1);
}

.theme-btn.active {
  border-color: var(--primary);
  background: linear-gradient(135deg, rgba(59, 130, 246, 0.2) 0%, rgba(6, 182, 212, 0.2) 100%);
  box-shadow: 0 0 0 3px var(--glow-blue);
}

.theme-icon {
  font-size: 1.8rem;
}

.theme-name {
  font-size: 0.9rem;
  font-weight: 600;
  color: var(--text);
}
</style>

<template>
  <div class="auth-page">
    <!-- Animated Background -->
    <div class="bg-shapes">
      <div class="shape shape-1"></div>
      <div class="shape shape-2"></div>
      <div class="shape shape-3"></div>
    </div>

    <div class="auth-container">
      <!-- Logo & Title -->
      <div class="auth-header">
        <div class="logo-wrapper animate-glow">
          <span class="logo-icon">🧬</span>
        </div>
        <h1 class="auth-title">Tiroksin'e Katıl</h1>
        <p class="auth-subtitle">Hesap oluştur ve yarışmaya başla!</p>
      </div>

      <!-- Auth Card -->
      <div class="auth-card">
        <form @submit.prevent="handleRegister" class="auth-form">
          <div class="form-group">
            <label>Kullanıcı Adı</label>
            <div class="input-wrapper">
              <span class="input-icon">👤</span>
              <input
                v-model="form.username"
                type="text"
                required
                placeholder="kullaniciadi"
                autocomplete="username"
              />
            </div>
          </div>

          <div class="form-group">
            <label>E-posta</label>
            <div class="input-wrapper">
              <span class="input-icon">📧</span>
              <input
                v-model="form.email"
                type="email"
                required
                placeholder="ornek@email.com"
                autocomplete="email"
              />
            </div>
          </div>

          <div class="form-group">
            <label>Ad Soyad</label>
            <div class="input-wrapper">
              <span class="input-icon">✨</span>
              <input
                v-model="form.displayName"
                type="text"
                required
                placeholder="Adınız Soyadınız"
                autocomplete="name"
              />
            </div>
          </div>

          <div class="form-group">
            <label>Şifre</label>
            <div class="input-wrapper">
              <span class="input-icon">🔒</span>
              <input
                v-model="form.password"
                type="password"
                required
                minlength="6"
                placeholder="En az 6 karakter"
                autocomplete="new-password"
              />
            </div>
          </div>

          <div class="form-group">
            <label>Şifre Tekrar</label>
            <div class="input-wrapper">
              <span class="input-icon">🔐</span>
              <input
                v-model="form.confirmPassword"
                type="password"
                required
                minlength="6"
                placeholder="Şifrenizi tekrar girin"
                autocomplete="new-password"
              />
            </div>
          </div>

          <div v-if="error" class="error-message">
            {{ error }}
          </div>

          <button type="submit" class="btn-primary w-full" :disabled="loading">
            <span v-if="loading" class="spinner spinner-sm"></span>
            <span v-else>🚀</span>
            {{ loading ? 'Kaydediliyor...' : 'Hesap Oluştur' }}
          </button>
        </form>

        <div class="auth-footer">
          <span>Zaten hesabın var mı?</span>
          <router-link to="/login" class="auth-link">Giriş Yap</router-link>
        </div>
      </div>

      <!-- Features -->
      <div class="features">
        <div class="feature">
          <span class="feature-icon">🏆</span>
          <span>Arkadaşlarınla yarış</span>
        </div>
        <div class="feature">
          <span class="feature-icon">🎯</span>
          <span>Bilgini test et</span>
        </div>
        <div class="feature">
          <span class="feature-icon">⚡</span>
          <span>Anlık sıralama</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useToastStore } from '../stores/toast'
import api from '../services/api'

const router = useRouter()
const toastStore = useToastStore()
const loading = ref(false)
const error = ref('')

const form = ref({
  username: '',
  email: '',
  displayName: '',
  password: '',
  confirmPassword: ''
})

const handleRegister = async () => {
  error.value = ''

  if (form.value.password !== form.value.confirmPassword) {
    error.value = 'Şifreler eşleşmiyor!'
    return
  }

  if (form.value.password.length < 6) {
    error.value = 'Şifre en az 6 karakter olmalıdır!'
    return
  }

  try {
    loading.value = true

    const response = await api.post('/auth/register', {
      username: form.value.username,
      email: form.value.email,
      displayName: form.value.displayName,
      password: form.value.password
    })

    localStorage.setItem('token', response.data.token)
    localStorage.setItem('user', JSON.stringify(response.data))

    toastStore.success(`Hoş geldin, ${response.data.displayName}!`)
    router.push('/')
  } catch (err) {
    error.value = err.response?.data?.error || 'Kayıt başarısız oldu'
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.auth-page {
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 24px;
  position: relative;
  overflow: hidden;
}

/* Animated Background Shapes */
.bg-shapes {
  position: fixed;
  inset: 0;
  pointer-events: none;
  overflow: hidden;
}

.shape {
  position: absolute;
  border-radius: 50%;
  filter: blur(80px);
  opacity: 0.5;
  animation: float 20s ease-in-out infinite;
}

.shape-1 {
  width: 400px;
  height: 400px;
  background: var(--primary);
  top: -100px;
  left: -100px;
  animation-delay: 0s;
}

.shape-2 {
  width: 300px;
  height: 300px;
  background: var(--accent);
  bottom: -50px;
  right: -50px;
  animation-delay: -7s;
}

.shape-3 {
  width: 250px;
  height: 250px;
  background: var(--success);
  top: 50%;
  left: 50%;
  animation-delay: -14s;
}

@keyframes float {
  0%, 100% { transform: translate(0, 0) scale(1); }
  25% { transform: translate(50px, -50px) scale(1.1); }
  50% { transform: translate(-30px, 30px) scale(0.9); }
  75% { transform: translate(-50px, -30px) scale(1.05); }
}

.auth-container {
  width: 100%;
  max-width: 420px;
  position: relative;
  z-index: 1;
  animation: slideUp 0.5s ease;
}

/* Logo & Title */
.auth-header {
  text-align: center;
  margin-bottom: 32px;
}

.logo-wrapper {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 80px;
  height: 80px;
  background: var(--mario-red);
  border-radius: var(--radius-xl);
  margin-bottom: 20px;
  box-shadow: 0 4px 0 #a31b18;
}

.logo-icon {
  font-size: 2.5rem;
}

.auth-title {
  font-size: 2rem;
  font-weight: 800;
  color: var(--text);
  margin: 0 0 8px 0;
}

.auth-subtitle {
  font-size: 1rem;
  color: var(--text-secondary);
  margin: 0;
}

/* Auth Card */
.auth-card {
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-xl);
  padding: 32px;
  box-shadow: var(--shadow-lg);
}

.auth-form {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

/* Input Wrapper */
.input-wrapper {
  position: relative;
  display: flex;
  align-items: center;
}

.input-wrapper .input-icon {
  position: absolute;
  left: 16px;
  font-size: 1.1rem;
  pointer-events: none;
  z-index: 1;
}

.input-wrapper input {
  padding-left: 48px;
}

/* Auth Footer */
.auth-footer {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
  margin-top: 24px;
  padding-top: 24px;
  border-top: 1px solid var(--border);
  font-size: 0.95rem;
  color: var(--text-secondary);
}

.auth-link {
  color: var(--primary);
  font-weight: 700;
  text-decoration: none;
  transition: all 0.2s ease;
}

.auth-link:hover {
  color: var(--primary-hover);
  text-decoration: underline;
}

/* Features */
.features {
  display: flex;
  justify-content: center;
  gap: 24px;
  margin-top: 32px;
  flex-wrap: wrap;
}

.feature {
  display: flex;
  align-items: center;
  gap: 8px;
  color: var(--text-secondary);
  font-size: 0.85rem;
  font-weight: 500;
}

.feature-icon {
  font-size: 1.1rem;
}

/* Responsive */
@media (max-width: 480px) {
  .auth-page {
    padding: 16px;
  }

  .auth-card {
    padding: 24px 20px;
  }

  .auth-title {
    font-size: 1.75rem;
  }

  .features {
    flex-direction: column;
    align-items: center;
    gap: 12px;
  }
}
</style>

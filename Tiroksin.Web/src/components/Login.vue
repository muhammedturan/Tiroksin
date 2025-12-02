<template>
  <div class="login-page">
    <!-- Left Side: Branding / Hero -->
    <div class="hero-side">
      <div class="hero-content">
        <div class="hero-icon">🎮</div>
        <h1 class="hero-title">Tiroksin</h1>
        <p class="hero-subtitle">Bilgi Yarışması Platformu</p>

        <div class="hero-features">
          <div class="feature-item">
            <span class="feature-icon">⚡</span>
            <span>Gerçek zamanlı yarışmalar</span>
          </div>
          <div class="feature-item">
            <span class="feature-icon">🏆</span>
            <span>Eleme modu ile rekabet</span>
          </div>
          <div class="feature-item">
            <span class="feature-icon">👥</span>
            <span>Arkadaşlarınla yarış</span>
          </div>
        </div>

        <!-- Mario-style decorative blocks -->
        <div class="deco-blocks">
          <div class="block block-1">?</div>
          <div class="block block-2">?</div>
          <div class="block block-3">!</div>
        </div>
      </div>
    </div>

    <!-- Right Side: Form -->
    <div class="form-side">
      <div class="form-container">
        <div class="tabs">
          <button :class="{ active: mode === 'login' }" @click="mode = 'login'">Giriş</button>
          <button :class="{ active: mode === 'register' }" @click="mode = 'register'">Kayıt</button>
        </div>

        <form @submit.prevent="handleSubmit">
          <MarioInput
            v-model="username"
            label="Kullanıcı Adı"
            placeholder="kullanici_adi"
            prefix="👤"
            @enter="handleSubmit"
          />

          <MarioInput
            v-model="password"
            type="password"
            label="Şifre"
            placeholder="******"
            prefix="🔒"
          />

          <template v-if="mode === 'register'">
            <MarioInput
              v-model="displayName"
              label="İsim"
              placeholder="Adınız"
              prefix="✨"
            />

            <MarioInput
              v-model="email"
              type="email"
              label="Email"
              placeholder="email@example.com"
              prefix="📧"
            />

            <div class="input-group">
              <label class="theme-label">Tema Seçimi</label>
              <div class="theme-selector">
                <MarioButton
                  type="button"
                  :color="selectedTheme === 'dark' ? 'blue' : 'gray'"
                  size="sm"
                  @click="selectedTheme = 'dark'"
                >
                  <template #icon>🌙</template>
                  Koyu
                </MarioButton>
                <MarioButton
                  type="button"
                  :color="selectedTheme === 'light' ? 'orange' : 'gray'"
                  size="sm"
                  @click="selectedTheme = 'light'"
                >
                  <template #icon>☀️</template>
                  Açık
                </MarioButton>
              </div>
            </div>
          </template>

          <p v-if="error" class="error">{{ error }}</p>

          <MarioButton
            type="submit"
            color="green"
            block
            :loading="loading"
            class="submit-btn"
          >
            {{ mode === 'login' ? 'Giriş Yap' : 'Kayıt Ol' }}
          </MarioButton>
        </form>

        <!-- Mobile Logo (hidden on desktop) -->
        <div class="mobile-branding">
          <span class="mobile-icon">🎮</span>
          <span class="mobile-title">Tiroksin</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, watch } from 'vue'
import { useUsersStore } from '../stores/users'
import { useThemeStore } from '../stores/theme'
import { useRouter } from 'vue-router'
import MarioInput from './MarioInput.vue'
import MarioButton from './MarioButton.vue'

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
        error.value = 'Tüm alanları doldurun'
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
/* ==========================================
   SPLIT LAYOUT LOGIN PAGE - COMPACT
   ========================================== */

.login-page {
  min-height: 100vh;
  min-height: 100dvh;
  display: grid;
  grid-template-columns: 1.2fr 1fr;
  background: var(--bg-main);
}

/* ==========================================
   LEFT SIDE: HERO / BRANDING - COMPACT
   ========================================== */

.hero-side {
  background: var(--mario-red);
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 32px;
  position: relative;
  overflow: hidden;
}

.hero-side::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: radial-gradient(circle at 80% 20%, rgba(255,255,255,0.1) 0%, transparent 50%);
  pointer-events: none;
}

.hero-content {
  position: relative;
  z-index: 1;
  text-align: center;
  color: white;
  max-width: 320px;
}

.hero-icon {
  font-size: 3rem;
  margin-bottom: 16px;
  display: inline-block;
  animation: heroFloat 3s ease-in-out infinite;
}

@keyframes heroFloat {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-8px); }
}

.hero-title {
  font-size: 2.5rem;
  font-weight: 800;
  margin: 0 0 8px 0;
  letter-spacing: -1px;
}

.hero-subtitle {
  font-size: 0.95rem;
  opacity: 0.9;
  margin: 0 0 28px 0;
  font-weight: 500;
}

/* Features List - Compact */
.hero-features {
  display: flex;
  flex-direction: column;
  gap: 10px;
  text-align: left;
}

.feature-item {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 10px 14px;
  background: rgba(255, 255, 255, 0.12);
  border-radius: var(--radius-md);
  font-weight: 600;
  font-size: 0.85rem;
}

.feature-icon {
  font-size: 1.1rem;
}

/* Mario-style Decorative Blocks - Smaller */
.deco-blocks {
  position: absolute;
  bottom: 20px;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  gap: 10px;
  opacity: 0.7;
}

.block {
  width: 32px;
  height: 32px;
  background: #fbbf24;
  border-radius: 4px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.9rem;
  font-weight: 800;
  color: #92400e;
  box-shadow: 0 2px 0 #d97706;
  animation: blockBounce 2s ease-in-out infinite;
}

.block-1 { animation-delay: 0s; }
.block-2 { animation-delay: 0.2s; }
.block-3 {
  animation-delay: 0.4s;
  background: #f472b6;
  box-shadow: 0 2px 0 #db2777;
  color: white;
}

@keyframes blockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-4px); }
}

/* ==========================================
   RIGHT SIDE: FORM - COMPACT
   ========================================== */

.form-side {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 32px 24px;
  background: var(--bg-card);
}

.form-container {
  width: 100%;
  max-width: 340px;
}

/* Tabs - Compact */
.tabs {
  display: flex;
  gap: 4px;
  margin-bottom: 24px;
  background: var(--bg-input);
  padding: 4px;
  border-radius: var(--radius-md);
  border: 1px solid var(--border);
}

.tabs button {
  flex: 1;
  padding: 10px;
  border: none;
  background: transparent;
  color: var(--text-muted);
  font-size: 0.9rem;
  font-weight: 600;
  border-radius: var(--radius-sm);
  cursor: pointer;
  transition: all 0.15s ease;
}

.tabs button.active {
  background: #10b981;
  color: white;
  box-shadow: 0 2px 0 #059669;
}

.tabs button:not(.active):hover {
  color: var(--text);
  background: var(--bg-card-hover);
}

/* Form - Compact */
form {
  display: flex;
  flex-direction: column;
  gap: 14px;
}

.input-group {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.theme-label {
  font-size: 0.75rem;
  font-weight: 700;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.submit-btn {
  margin-top: 8px;
}

/* Error Message - Compact */
.error {
  color: white;
  font-size: 0.8rem;
  font-weight: 600;
  text-align: center;
  padding: 10px 14px;
  background: #ef4444;
  border-radius: var(--radius-md);
  margin: 0;
  box-shadow: 0 2px 0 #dc2626;
}


/* Theme Selector */
.theme-selector {
  display: flex;
  gap: 8px;
}

.theme-selector > * {
  flex: 1;
}

/* Mobile Branding (hidden on desktop) - Compact */
.mobile-branding {
  display: none;
  align-items: center;
  justify-content: center;
  gap: 10px;
  margin-top: 24px;
  padding-top: 20px;
  border-top: 1px solid var(--border);
}

.mobile-icon {
  font-size: 1.5rem;
}

.mobile-title {
  font-size: 1.2rem;
  font-weight: 800;
  color: var(--text);
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */

@media (max-width: 900px) {
  .login-page {
    grid-template-columns: 1fr;
    grid-template-rows: 1fr;
  }

  .hero-side {
    display: none;
  }

  .form-side {
    padding: 24px 20px;
  }

  .mobile-branding {
    display: flex;
  }
}

@media (max-width: 480px) {
  .form-container {
    max-width: none;
  }

  .tabs button {
    padding: 8px;
    font-size: 0.85rem;
  }

  .input-group input {
    padding: 10px 12px;
  }

  .btn-submit {
    padding: 12px;
    font-size: 0.9rem;
  }
}
</style>

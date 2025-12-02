<template>
  <header class="header">
    <div class="header-inner">
      <!-- Logo - Mario Style -->
      <router-link to="/" class="logo">
        <div class="logo-icon-wrapper">
          <span class="logo-icon">🍄</span>
        </div>
        <span class="logo-text">Tiroksin</span>
        <div class="logo-deco">
          <span class="logo-star">⭐</span>
        </div>
      </router-link>

      <!-- Actions -->
      <div class="header-actions">
        <!-- Add Question Button -->
        <MarioButton to="/create-question" color="green" size="sm">
          <template #icon>+</template>
          <span class="btn-text">Soru Ekle</span>
        </MarioButton>

        <!-- Theme Toggle -->
        <MarioButton
          color="blue"
          size="sm"
          iconOnly
          :icon="themeStore.theme === 'dark' ? '☀️' : '🌙'"
          @click="toggleTheme"
        />

        <!-- Profile -->
        <div class="profile-wrapper">
          <MarioButton color="orange" size="sm" @click="toggleMenu">
            <template #icon>{{ userAvatar }}</template>
            <span class="btn-text">{{ userName }}</span>
          </MarioButton>

          <!-- Dropdown Menu -->
          <Transition name="dropdown">
            <div v-if="showMenu" class="dropdown">
              <div class="dropdown-header">
                <span class="dropdown-avatar">{{ userAvatar }}</span>
                <div class="dropdown-info">
                  <span class="dropdown-name">{{ userName }}</span>
                  <span class="dropdown-role">Oyuncu</span>
                </div>
              </div>
              <div class="dropdown-divider"></div>
              <MarioButton color="red" size="sm" block @click="logout">
                <template #icon>🚪</template>
                Çıkış Yap
              </MarioButton>
            </div>
          </Transition>
        </div>
      </div>
    </div>
  </header>
</template>

<script setup>
import { ref, computed } from 'vue'
import { useUsersStore } from '../stores/users'
import { useThemeStore } from '../stores/theme'
import { useRouter } from 'vue-router'
import MarioButton from './MarioButton.vue'

const usersStore = useUsersStore()
const themeStore = useThemeStore()
const router = useRouter()
const showMenu = ref(false)

const userName = computed(() => usersStore.currentUser?.displayName || usersStore.currentUser?.username || 'Oyuncu')
const userAvatar = computed(() => usersStore.currentUser?.avatar || '🎯')

const toggleMenu = () => showMenu.value = !showMenu.value

const toggleTheme = async () => {
  try {
    await themeStore.toggleTheme()
  } catch (error) {
    console.error('Tema degistirilemedi:', error)
  }
}

const logout = () => {
  showMenu.value = false
  usersStore.logout()
  router.push('/login')
}

if (typeof window !== 'undefined') {
  window.addEventListener('click', (e) => {
    if (!e.target.closest('.profile-wrapper')) {
      showMenu.value = false
    }
  })
}
</script>

<style scoped>
.header {
  background: var(--bg-header);
  backdrop-filter: blur(12px);
  border-bottom: 1px solid var(--border);
  position: sticky;
  top: 0;
  z-index: 100;
}

.header-inner {
  max-width: 1000px;
  margin: 0 auto;
  padding: 12px 20px;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

/* Logo */
.logo {
  display: flex;
  align-items: center;
  gap: 10px;
  text-decoration: none;
  transition: transform 0.2s ease;
}

.logo:hover {
  transform: scale(1.02);
}

.logo-icon-wrapper {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
  background: var(--mario-red);
  border-radius: var(--radius-md);
  box-shadow: 0 3px 0 #a31b18;
  transition: all 0.15s ease;
}

.logo:hover .logo-icon-wrapper {
  transform: translateY(-2px);
  box-shadow: 0 5px 0 #a31b18;
}

.logo-icon {
  font-size: 1.3rem;
  animation: marioBlockBounce 2s ease-in-out infinite;
}

.logo-text {
  font-size: 1.3rem;
  font-weight: 800;
  color: var(--text);
  letter-spacing: -0.5px;
}

.logo-deco {
  display: flex;
  align-items: center;
}

.logo-star {
  font-size: 0.9rem;
  animation: starPulse 1.5s ease-in-out infinite;
}

@keyframes marioBlockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-2px); }
}

@keyframes starPulse {
  0%, 100% { transform: scale(1) rotate(0deg); }
  50% { transform: scale(1.15) rotate(10deg); }
}

/* Header Actions */
.header-actions {
  display: flex;
  align-items: center;
  gap: 10px;
}


/* Profile */
.profile-wrapper {
  position: relative;
}

/* Dropdown */
.dropdown {
  position: absolute;
  top: calc(100% + 8px);
  right: 0;
  min-width: 200px;
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-lg);
  overflow: hidden;
  box-shadow: var(--shadow-lg);
  z-index: 200;
}

.dropdown-header {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 16px;
}

.dropdown-avatar {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 44px;
  height: 44px;
  background: var(--mario-red);
  border-radius: var(--radius-md);
  font-size: 1.4rem;
}

.dropdown-info {
  display: flex;
  flex-direction: column;
  gap: 2px;
}

.dropdown-name {
  font-weight: 700;
  font-size: 0.95rem;
  color: var(--text);
}

.dropdown-role {
  font-size: 0.8rem;
  color: var(--text-muted);
}

.dropdown-divider {
  height: 1px;
  background: var(--border);
}

.dropdown :deep(.mario-button) {
  margin: 12px;
  width: calc(100% - 24px);
}

/* Dropdown Animation */
.dropdown-enter-active,
.dropdown-leave-active {
  transition: all 0.2s ease;
}

.dropdown-enter-from,
.dropdown-leave-to {
  opacity: 0;
  transform: translateY(-10px) scale(0.95);
}

/* Responsive */
@media (max-width: 600px) {
  .header-inner {
    padding: 10px 16px;
  }

  .btn-text {
    display: none;
  }
}
</style>

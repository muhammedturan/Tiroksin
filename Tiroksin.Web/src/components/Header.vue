<template>
  <header class="header">
    <div class="header-inner">
      <router-link to="/" class="logo">
        <span class="logo-icon">🎮</span>
        <span class="logo-text">Tiroksin</span>
      </router-link>

      <div class="header-actions">
        <router-link to="/create-question" class="btn-add">
          <span>+</span> Soru Ekle
        </router-link>

        <button @click="toggleTheme" class="theme-toggle" :title="themeStore.theme === 'dark' ? 'Acik temaya gec' : 'Koyu temaya gec'">
          {{ themeStore.theme === 'dark' ? '☀️' : '🌙' }}
        </button>

        <div class="profile" @click="toggleMenu">
          <span class="avatar">{{ userAvatar }}</span>
          <span class="username">{{ userName }}</span>
          <svg class="chevron" :class="{ open: showMenu }" viewBox="0 0 20 20" fill="currentColor">
            <path d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z"/>
          </svg>
        </div>

        <div v-if="showMenu" class="dropdown">
          <button @click="logout" class="dropdown-item logout">
            Cikis Yap
          </button>
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
    if (!e.target.closest('.profile') && !e.target.closest('.dropdown')) {
      showMenu.value = false
    }
  })
}
</script>

<style scoped>
.header {
  background: linear-gradient(135deg, var(--bg-card) 0%, var(--bg-card-light) 100%);
  border-bottom: 1px solid var(--border);
  position: sticky;
  top: 0;
  z-index: 100;
}

.header-inner {
  max-width: 1100px;
  margin: 0 auto;
  padding: 12px 24px;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.logo {
  display: flex;
  align-items: center;
  gap: 10px;
  text-decoration: none;
  color: var(--text);
}

.logo-icon {
  font-size: 1.8rem;
}

.logo-text {
  font-size: 1.4rem;
  font-weight: 800;
  background: linear-gradient(135deg, var(--primary-light) 0%, var(--accent) 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.header-actions {
  display: flex;
  align-items: center;
  gap: 16px;
  position: relative;
}

.btn-add {
  display: flex;
  align-items: center;
  gap: 6px;
  padding: 8px 16px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 20px;
  color: var(--text);
  text-decoration: none;
  font-weight: 600;
  font-size: 0.9rem;
  transition: all 0.2s;
}

.btn-add:hover {
  background: var(--primary);
  border-color: var(--primary);
}

.btn-add span {
  font-size: 1.1rem;
  color: var(--accent);
}

.btn-add:hover span {
  color: white;
}

.theme-toggle {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 50%;
  cursor: pointer;
  font-size: 1.2rem;
  transition: all 0.2s;
}

.theme-toggle:hover {
  background: var(--primary);
  border-color: var(--primary);
  transform: rotate(15deg);
}

.profile {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 6px 12px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 20px;
  cursor: pointer;
  transition: all 0.2s;
}

.profile:hover {
  border-color: var(--primary);
}

.avatar {
  font-size: 1.4rem;
}

.username {
  font-weight: 600;
  font-size: 0.9rem;
  color: var(--text);
}

.chevron {
  width: 16px;
  height: 16px;
  color: var(--text-muted);
  transition: transform 0.2s;
}

.chevron.open {
  transform: rotate(180deg);
}

.dropdown {
  position: absolute;
  top: 100%;
  right: 0;
  margin-top: 8px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 12px;
  overflow: hidden;
  min-width: 160px;
  box-shadow: 0 8px 32px rgba(0,0,0,0.4);
}

.dropdown-item {
  display: block;
  width: 100%;
  padding: 12px 16px;
  background: none;
  border: none;
  text-align: left;
  color: var(--text);
  font-size: 0.9rem;
  cursor: pointer;
  transition: background 0.2s;
}

.dropdown-item:hover {
  background: var(--bg-card-light);
}

.dropdown-item.logout {
  color: var(--error);
}

@media (max-width: 600px) {
  .username {
    display: none;
  }

  .btn-add {
    padding: 8px 12px;
  }
}
</style>

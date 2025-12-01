<script setup>
import { onMounted, onUnmounted, computed } from 'vue'
import { useRoute } from 'vue-router'
import Header from './components/Header.vue'
import signalrService from './services/signalrService'
import { useRoomStore } from './stores/room'
import { useGameStore } from './stores/game'
import { useThemeStore } from './stores/theme'

const route = useRoute()
const roomStore = useRoomStore()
const gameStore = useGameStore()
const themeStore = useThemeStore()

// Header'ı login sayfasında gösterme
const showHeader = computed(() => {
  return route.path !== '/login'
})

onMounted(async () => {
  // Connect to SignalR when app loads
  const token = localStorage.getItem('token')
  if (token) {
    await signalrService.connect(token)
    setupSignalRListeners()
  }
})

onUnmounted(async () => {
  await signalrService.disconnect()
})

function setupSignalRListeners() {
  // Room events
  signalrService.on('RoomPlayersInitialized', (data) => {
    console.log('🎯 RoomPlayersInitialized EVENT RECEIVED:', data)
    console.log('🎯 Players in data:', data.players)
    console.log('🎯 Players count:', data.players?.length)

    // Clear existing players and set from backend
    if (data.players && Array.isArray(data.players)) {
      // Clear and repopulate
      roomStore.players.length = 0
      data.players.forEach(player => {
        roomStore.players.push(player)
      })
      console.log('✅ Players set in store:', roomStore.players)
    } else {
      console.error('❌ Invalid players data:', data)
    }
  })

  signalrService.on('PlayerJoined', (data) => {
    console.log('🔔 PlayerJoined EVENT RECEIVED:', data)
    console.log('🔔 Adding player:', data.username, data.avatar)
    roomStore.addPlayer({
      username: data.username,
      avatar: data.avatar,
      isReady: false
    })
    console.log('🔔 Players after add:', roomStore.players)
  })

  signalrService.on('PlayerLeft', (data) => {
    console.log('Player left:', data)
    roomStore.removePlayer(data.username)
  })

  signalrService.on('PlayerReadyStatusChanged', (data) => {
    console.log('Player ready status:', data)
    roomStore.updatePlayerStatus(data.username, data.isReady)
  })

  // Game events
  signalrService.on('GameStarting', (data) => {
    console.log('🎮 Game starting:', data)

    // Set game data in store
    gameStore.gameSessionId = data.gameSessionId
    gameStore.questions = data.questions
    gameStore.gameStatus = 'playing'

    // Navigate to game arena
    import('./router').then(({ default: router }) => {
      router.push(`/game/${data.gameSessionId}`)
    })
  })

  signalrService.on('QuestionReceived', (data) => {
    console.log('Question received:', data)
    gameStore.receiveQuestion(data)
  })

  signalrService.on('ScoreboardUpdated', (data) => {
    console.log('Scoreboard updated:', data)
    gameStore.updateScoreboard(data.scores)
  })

  signalrService.on('GameFinished', (data) => {
    console.log('Game finished:', data)
  })
}
</script>

<template>
  <div id="app">
    <Header v-if="showHeader" />
    <div class="app-content">
      <router-view />
    </div>
  </div>
</template>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: 'Nunito', -apple-system, BlinkMacSystemFont, sans-serif;
  background: var(--bg-gradient);
  min-height: 100vh;
  color: var(--text);
  transition: background 0.3s, color 0.3s;
}

#app {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.app-content {
  flex: 1;
  padding: 24px;
  max-width: 1100px;
  margin: 0 auto;
  width: 100%;
}

/* Dark Theme (Default) */
:root,
[data-theme="dark"] {
  --primary: #3b82f6;
  --primary-light: #60a5fa;
  --primary-dark: #1d4ed8;
  --accent: #06b6d4;
  --accent-light: #22d3ee;
  --success: #22c55e;
  --error: #ef4444;
  --warning: #f59e0b;
  --bg-dark: #0c1929;
  --bg-gradient: linear-gradient(180deg, #0c1929 0%, #152238 100%);
  --bg-card: #1a2942;
  --bg-card-light: #243552;
  --text: #f1f5f9;
  --text-muted: #94a3b8;
  --border: #2d3f59;
  --glow-blue: rgba(59, 130, 246, 0.4);
  --glow-cyan: rgba(6, 182, 212, 0.4);
  --input-bg: #243552;
  --shadow: rgba(0, 0, 0, 0.4);
}

/* Light Theme */
[data-theme="light"] {
  --primary: #2563eb;
  --primary-light: #3b82f6;
  --primary-dark: #1d4ed8;
  --accent: #0891b2;
  --accent-light: #06b6d4;
  --success: #16a34a;
  --error: #dc2626;
  --warning: #d97706;
  --bg-dark: #f8fafc;
  --bg-gradient: linear-gradient(180deg, #f1f5f9 0%, #e2e8f0 100%);
  --bg-card: #ffffff;
  --bg-card-light: #f1f5f9;
  --text: #1e293b;
  --text-muted: #64748b;
  --border: #cbd5e1;
  --glow-blue: rgba(37, 99, 235, 0.25);
  --glow-cyan: rgba(8, 145, 178, 0.25);
  --input-bg: #f1f5f9;
  --shadow: rgba(0, 0, 0, 0.1);
}

.card {
  background: var(--bg-card);
  border-radius: 16px;
  padding: 20px;
  border: 1px solid var(--border);
}

.btn-game {
  padding: 14px 32px;
  font-size: 1rem;
  font-weight: 700;
  border: none;
  border-radius: 12px;
  cursor: pointer;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  transition: all 0.2s;
  box-shadow: 0 4px 20px var(--glow-blue);
  text-transform: uppercase;
  letter-spacing: 1px;
}

.btn-game:hover:not(:disabled) {
  transform: translateY(-3px);
  box-shadow: 0 8px 30px var(--glow-blue);
}

.btn-game:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.modal-overlay {
  position: fixed;
  inset: 0;
  background: rgba(12, 25, 41, 0.9);
  backdrop-filter: blur(8px);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 2000;
}

@keyframes fadeIn {
  from { opacity: 0; }
}

@keyframes slideUp {
  from { transform: translateY(20px); opacity: 0; }
}

@keyframes pulse {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.6; }
}

@keyframes glow {
  0%, 100% { box-shadow: 0 0 20px var(--glow-blue); }
  50% { box-shadow: 0 0 40px var(--glow-cyan); }
}

@keyframes float {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-6px); }
}
</style>

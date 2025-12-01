<template>
  <div class="room-waiting">
    <div class="room-card card">
      <div class="room-header">
        <div class="room-title">
          <span class="room-icon">🎮</span>
          <h1>{{ roomStore.currentRoom?.name }}</h1>
        </div>
        <button @click="handleLeaveRoom" class="btn-leave">Cikis</button>
      </div>

      <div class="room-code-section">
        <span class="code-label">Oda Kodu</span>
        <div class="code-box">
          <span class="code-value">{{ roomStore.currentRoom?.roomCode }}</span>
          <button @click="copyRoomCode" class="copy-btn">Kopyala</button>
        </div>
      </div>

      <div class="game-stats">
        <div class="stat-item">
          <span class="stat-icon">⚔️</span>
          <span class="stat-value">Eleme</span>
          <span class="stat-label">Mod</span>
        </div>
        <div class="stat-item">
          <span class="stat-icon">❓</span>
          <span class="stat-value">{{ roomStore.currentRoom?.questionCount }}</span>
          <span class="stat-label">Soru</span>
        </div>
        <div class="stat-item">
          <span class="stat-icon">👥</span>
          <span class="stat-value">{{ roomStore.players.length }}/{{ roomStore.currentRoom?.maxPlayers }}</span>
          <span class="stat-label">Oyuncu</span>
        </div>
      </div>
    </div>

    <div class="players-card card">
      <div class="players-header">
        <span>Oyuncular</span>
        <span class="player-count">{{ roomStore.players.length }}</span>
      </div>
      <div class="players-list">
        <div v-if="roomStore.players.length === 0" class="empty">
          <span class="empty-icon">⏳</span>
          <span>Oyuncu bekleniyor...</span>
        </div>
        <div v-for="player in roomStore.players" :key="player.username" class="player">
          <span class="avatar">{{ player.avatar }}</span>
          <span class="name">{{ player.username }}</span>
          <span class="ready-badge">Hazir</span>
        </div>
      </div>
    </div>

    <div class="action-section">
      <button
        v-if="roomStore.isHost"
        @click="handleStartGame"
        :disabled="!canStart"
        class="btn-start"
      >
        {{ canStart ? 'Oyunu Baslat' : `${roomStore.players.length}/${roomStore.currentRoom?.minPlayers || 2} oyuncu gerekli` }}
      </button>
      <div v-else class="waiting-text">
        <span class="pulse-dot"></span>
        Host oyunu baslatmasini bekliyor...
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted, onUnmounted } from 'vue'
import { useRouter } from 'vue-router'
import { useRoomStore } from '../stores/room'
import { useGameStore } from '../stores/game'
import signalrService from '../services/signalrService'

const router = useRouter()
const roomStore = useRoomStore()
const gameStore = useGameStore()

const canStart = computed(() => {
  const minPlayers = roomStore.currentRoom?.minPlayers || 2
  return roomStore.players.length >= minPlayers
})

onMounted(async () => {
  // Setup GameStarting listener for navigation
  setupGameStartingListener()

  // If we already have a room in store, use it (came from create/join)
  if (roomStore.currentRoom) {
    console.log('✅ Room already in store:', roomStore.currentRoom.roomCode)
    return
  }

  // Only try to rejoin from localStorage if no room in store (page refresh case)
  const savedRoomCode = localStorage.getItem('currentRoomCode')
  if (savedRoomCode) {
    try {
      console.log('🔄 Rejoining room from localStorage:', savedRoomCode)
      await roomStore.joinRoom(savedRoomCode)
    } catch (error) {
      console.error('❌ Failed to rejoin room:', error)
      localStorage.removeItem('currentRoomCode')
      router.push('/')
    }
  } else {
    // No room in store and no saved room code - go home
    console.warn('⚠️ No room data found, redirecting to home')
    router.push('/')
  }
})

onUnmounted(() => {
  // Only clean up GameStarting listener (room events are handled by store)
  signalrService.offAll('GameStarting')
})

function setupGameStartingListener() {
  console.log('🔌 Setting up GameStarting listener...')

  signalrService.on('GameStarting', (data) => {
    console.log('🚀 GameStarting event received:', data)
    if (data.gameSessionId) {
      // Store game session ID
      gameStore.gameSessionId = data.gameSessionId

      // Store questions (first question)
      if (data.questions && data.questions.length > 0) {
        gameStore.questions = data.questions
        gameStore.currentQuestionIndex = 0
      }

      // Store players in roomStore for GameArena
      if (data.players && data.players.length > 0) {
        roomStore.players = data.players.map(p => ({
          userId: p.userId,
          username: p.username,
          avatar: p.avatar || '👤',
          score: p.score || 0,
          isEliminated: p.isEliminated || false
        }))
        console.log('👥 Players stored:', roomStore.players)
      }

      router.push(`/game/${data.gameSessionId}`)
    }
  })
}

async function handleStartGame() {
  if (!canStart.value) return
  try {
    const data = await gameStore.startGame(roomStore.currentRoom.roomId)
    // Host için de store'u güncelle (GameStarting eventi zaten gelecek ama güvenlik için)
    if (data.gameSessionId) {
      gameStore.gameSessionId = data.gameSessionId
      if (data.questions && data.questions.length > 0) {
        gameStore.questions = data.questions
        gameStore.currentQuestionIndex = 0
      }
    }
    // Router push yapmıyoruz - GameStarting eventi yönlendirecek
  } catch (error) {
    alert(error.message || 'Hata')
  }
}

async function handleLeaveRoom() {
  await roomStore.leaveRoom()
  router.push('/')
}

function copyRoomCode() {
  const code = roomStore.currentRoom?.roomCode
  if (code) {
    navigator.clipboard.writeText(code)
    alert(`Kod kopyalandı: ${code}`)
  }
}
</script>

<style scoped>
.room-waiting {
  max-width: 500px;
  margin: 0 auto;
}

.room-card {
  margin-bottom: 20px;
}

.room-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
}

.room-title {
  display: flex;
  align-items: center;
  gap: 12px;
}

.room-icon {
  font-size: 1.8rem;
}

.room-title h1 {
  font-size: 1.4rem;
  font-weight: 700;
  color: var(--text);
  margin: 0;
}

.btn-leave {
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  padding: 10px 18px;
  border-radius: 10px;
  cursor: pointer;
  font-size: 0.9rem;
  font-weight: 600;
  color: var(--text-muted);
  transition: all 0.2s;
}

.btn-leave:hover {
  background: var(--error);
  border-color: var(--error);
  color: white;
}

.room-code-section {
  text-align: center;
  padding: 20px;
  background: var(--bg-card-light);
  border-radius: 12px;
  margin-bottom: 20px;
}

.code-label {
  display: block;
  font-size: 0.8rem;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 1px;
  margin-bottom: 10px;
}

.code-box {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 12px;
}

.code-value {
  font-family: 'Courier New', monospace;
  font-size: 2rem;
  font-weight: 800;
  letter-spacing: 6px;
  background: linear-gradient(135deg, var(--primary-light) 0%, var(--accent) 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.copy-btn {
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  border: none;
  cursor: pointer;
  font-size: 0.85rem;
  font-weight: 600;
  padding: 10px 16px;
  color: white;
  border-radius: 8px;
  transition: all 0.2s;
}

.copy-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 16px var(--glow-blue);
}

.game-stats {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 12px;
}

.stat-item {
  text-align: center;
  padding: 16px 12px;
  background: var(--bg-card-light);
  border-radius: 10px;
  border: 1px solid var(--border);
}

.stat-icon {
  font-size: 1.5rem;
  display: block;
  margin-bottom: 8px;
}

.stat-value {
  display: block;
  font-size: 1.1rem;
  font-weight: 700;
  color: var(--text);
  margin-bottom: 4px;
}

.stat-label {
  display: block;
  font-size: 0.7rem;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.players-card {
  margin-bottom: 20px;
}

.players-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-size: 1rem;
  font-weight: 700;
  color: var(--text);
  margin-bottom: 16px;
}

.player-count {
  background: var(--primary);
  color: white;
  padding: 4px 12px;
  border-radius: 20px;
  font-size: 0.85rem;
}

.players-list {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.players-list .empty {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 10px;
  padding: 30px;
  color: var(--text-muted);
  font-size: 0.9rem;
}

.empty-icon {
  font-size: 2rem;
}

.player {
  display: flex;
  align-items: center;
  gap: 14px;
  padding: 14px;
  background: var(--bg-card-light);
  border-radius: 10px;
  border: 1px solid var(--border);
}

.player .avatar {
  font-size: 1.8rem;
}

.player .name {
  flex: 1;
  font-weight: 600;
  font-size: 1rem;
  color: var(--text);
}

.ready-badge {
  background: var(--success);
  color: white;
  padding: 4px 10px;
  border-radius: 6px;
  font-size: 0.75rem;
  font-weight: 600;
}

.action-section {
  text-align: center;
  padding: 10px 0;
}

.btn-start {
  width: 100%;
  padding: 18px;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  border: none;
  border-radius: 12px;
  font-size: 1.1rem;
  font-weight: 700;
  cursor: pointer;
  transition: all 0.2s;
  box-shadow: 0 4px 20px var(--glow-blue);
}

.btn-start:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 8px 30px var(--glow-blue);
}

.btn-start:disabled {
  background: var(--bg-card-light);
  color: var(--text-muted);
  cursor: not-allowed;
  box-shadow: none;
}

.waiting-text {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  color: var(--text-muted);
  font-size: 0.95rem;
}

.pulse-dot {
  width: 10px;
  height: 10px;
  background: var(--primary);
  border-radius: 50%;
  animation: pulse 1.5s ease-in-out infinite;
}

@keyframes pulse {
  0%, 100% { opacity: 1; transform: scale(1); }
  50% { opacity: 0.5; transform: scale(1.2); }
}

@media (max-width: 480px) {
  .code-value {
    font-size: 1.5rem;
    letter-spacing: 4px;
  }

  .game-stats {
    gap: 8px;
  }

  .stat-item {
    padding: 12px 8px;
  }
}
</style>

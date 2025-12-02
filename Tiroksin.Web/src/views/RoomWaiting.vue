<template>
  <div class="room-waiting">
    <!-- Two Column Layout -->
    <div class="waiting-grid">
      <!-- LEFT COLUMN: Room Info -->
      <div class="left-column">
        <!-- Room Header -->
        <MarioHeader
          :title="roomStore.currentRoom?.name || 'Oda'"
          subtitle="⚔️ Eleme Modu"
          icon="🎮"
          color="blue"
        >
          <template #action>
            <MarioButton color="red" size="sm" @click="handleLeaveRoom">
              🚪 Ayrıl
            </MarioButton>
          </template>
        </MarioHeader>

        <!-- Room Code (Big & Prominent) -->
        <MarioCard color="yellow" class="room-code-card">
          <span class="code-label">ODA KODU</span>
          <div class="code-display">
            <span class="code-value">{{ roomStore.currentRoom?.roomCode }}</span>
          </div>
          <MarioButton color="blue" size="sm" @click="copyRoomCode">
            📋 Kodu Kopyala
          </MarioButton>
          <p class="code-hint">Bu kodu arkadaşlarınla paylaş!</p>
        </MarioCard>

        <!-- Game Stats -->
        <div class="stats-row">
          <MarioCard color="blue" class="stat-card">
            <span class="stat-number">{{ roomStore.currentRoom?.questionCount }}</span>
            <span class="stat-label">Soru</span>
          </MarioCard>
          <MarioCard color="green" class="stat-card">
            <span class="stat-number">{{ roomStore.players.length }}/{{ roomStore.currentRoom?.maxPlayers }}</span>
            <span class="stat-label">Oyuncu</span>
          </MarioCard>
          <MarioCard color="orange" class="stat-card">
            <span class="stat-number">{{ roomStore.currentRoom?.minPlayers || 2 }}</span>
            <span class="stat-label">Min</span>
          </MarioCard>
        </div>

        <!-- Start Button (Host Only) -->
        <div class="action-area">
          <MarioButton
            v-if="roomStore.isHost"
            :color="canStart ? 'green' : 'gray'"
            size="lg"
            block
            :disabled="!canStart"
            @click="handleStartGame"
          >
            <template #icon>{{ canStart ? '🚀' : '⏳' }}</template>
            {{ canStart ? 'OYUNU BAŞLAT' : `${roomStore.players.length}/${roomStore.currentRoom?.minPlayers || 2} oyuncu gerekli` }}
          </MarioButton>

          <MarioCard v-else color="gray" class="waiting-host-card">
            <div class="waiting-host">
              <div class="pulse-dot"></div>
              <span>Host oyunu başlatmasını bekliyor...</span>
            </div>
          </MarioCard>
        </div>
      </div>

      <!-- RIGHT COLUMN: Players List -->
      <div class="right-column">
        <MarioCard color="gray" class="players-card">
          <div class="players-header">
            <h2>👥 Oyuncular</h2>
            <span class="player-count">{{ roomStore.players.length }}</span>
          </div>

          <div class="players-list">
            <!-- Empty State -->
            <div v-if="roomStore.players.length === 0" class="empty-state">
              <div class="empty-icon">⏳</div>
              <span>Oyuncu bekleniyor...</span>
            </div>

            <!-- Player Items -->
            <div
              v-for="(player, index) in roomStore.players"
              :key="player.username"
              class="player-item"
              :class="getPlayerColorClass(index)"
            >
              <div class="player-avatar">{{ player.avatar }}</div>
              <span class="player-name">{{ player.username }}</span>
              <span class="ready-badge">✓ Hazır</span>
            </div>
          </div>
        </MarioCard>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted, onUnmounted } from 'vue'
import { useRouter } from 'vue-router'
import { useRoomStore } from '../stores/room'
import { useGameStore } from '../stores/game'
import { useToastStore } from '../stores/toast'
import signalrService from '../services/signalrService'
import MarioCard from '../components/MarioCard.vue'
import MarioButton from '../components/MarioButton.vue'
import MarioHeader from '../components/MarioHeader.vue'

const router = useRouter()
const roomStore = useRoomStore()
const gameStore = useGameStore()
const toastStore = useToastStore()

const canStart = computed(() => {
  const minPlayers = roomStore.currentRoom?.minPlayers || 2
  return roomStore.players.length >= minPlayers
})

const playerColors = ['red', 'blue', 'green', 'orange']

function getPlayerColorClass(index) {
  return `color-${playerColors[index % playerColors.length]}`
}

onMounted(async () => {
  setupGameStartingListener()

  if (roomStore.currentRoom) {
    console.log('Room already in store:', roomStore.currentRoom.roomCode)
    return
  }

  const savedRoomCode = localStorage.getItem('currentRoomCode')
  if (savedRoomCode) {
    try {
      console.log('Rejoining room:', savedRoomCode)
      await roomStore.joinRoom(savedRoomCode)
    } catch (error) {
      console.error('Failed to rejoin room:', error)
      localStorage.removeItem('currentRoomCode')
      router.push('/')
    }
  } else {
    console.warn('No room data found, redirecting to home')
    router.push('/')
  }
})

onUnmounted(() => {
  signalrService.offAll('GameStarting')
})

function setupGameStartingListener() {
  console.log('Setting up GameStarting listener...')

  signalrService.on('GameStarting', (data) => {
    console.log('GameStarting event received:', data)
    if (data.gameSessionId) {
      gameStore.gameSessionId = data.gameSessionId

      if (data.questions && data.questions.length > 0) {
        gameStore.questions = data.questions
        gameStore.currentQuestionIndex = 0
      }

      if (data.players && data.players.length > 0) {
        roomStore.players = data.players.map(p => ({
          userId: p.userId,
          username: p.username,
          avatar: p.avatar || '👤',
          score: p.score || 0,
          isEliminated: p.isEliminated || false
        }))
      }

      router.push(`/game/${data.gameSessionId}`)
    }
  })
}

async function handleStartGame() {
  if (!canStart.value) return
  try {
    const data = await gameStore.startGame(roomStore.currentRoom.roomId)
    if (data.gameSessionId) {
      gameStore.gameSessionId = data.gameSessionId
      if (data.questions && data.questions.length > 0) {
        gameStore.questions = data.questions
        gameStore.currentQuestionIndex = 0
      }
    }
  } catch (error) {
    toastStore.error(error.message || 'Hata')
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
    toastStore.success(`Kod kopyalandı: ${code}`)
  }
}
</script>

<style scoped>
/* ==========================================
   ROOM WAITING - COMPACT & WIDE LAYOUT
   ========================================== */

.room-waiting {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0;
}

.waiting-grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 20px;
}

/* ==========================================
   LEFT COLUMN: ROOM INFO
   ========================================== */

.left-column {
  display: flex;
  flex-direction: column;
  gap: 16px;
}

/* Room Code Card - Uses MarioCard */
.room-code-card {
  text-align: center;
}

.code-label {
  display: block;
  font-size: 0.65rem;
  font-weight: 700;
  color: #92400e;
  text-transform: uppercase;
  letter-spacing: 1.5px;
  margin-bottom: 10px;
}

.code-display {
  margin-bottom: 14px;
  position: relative;
}

.code-value {
  font-family: 'JetBrains Mono', monospace;
  font-size: 2rem;
  font-weight: 800;
  letter-spacing: 6px;
  color: #92400e;
}

.code-hint {
  font-size: 0.75rem;
  color: rgba(146, 64, 14, 0.8);
  margin: 12px 0 0 0;
}

/* Stats Row - Using MarioCards */
.stats-row {
  display: flex;
  gap: 10px;
}

.stat-card {
  flex: 1;
  text-align: center;
  padding: 12px 8px !important;
}

.stat-card .stat-number {
  display: block;
  font-size: 1.3rem;
  font-weight: 800;
  color: white;
  line-height: 1;
}

.stat-card .stat-label {
  display: block;
  font-size: 0.65rem;
  color: rgba(255, 255, 255, 0.85);
  text-transform: uppercase;
  font-weight: 600;
  margin-top: 4px;
}

/* Action Area */
.action-area {
  margin-top: auto;
}

/* Waiting Host Card */
.waiting-host-card {
  padding: 12px !important;
}

.waiting-host {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  color: var(--text);
  font-size: 0.85rem;
  font-weight: 500;
}

.pulse-dot {
  width: 10px;
  height: 10px;
  background: var(--mario-blue);
  border-radius: 50%;
  animation: pulse 1.5s ease-in-out infinite;
}

@keyframes pulse {
  0%, 100% { transform: scale(1); opacity: 1; }
  50% { transform: scale(1.2); opacity: 0.7; }
}

/* ==========================================
   RIGHT COLUMN: PLAYERS LIST
   ========================================== */

.right-column {
  display: flex;
  flex-direction: column;
}

.players-card {
  flex: 1;
  display: flex;
  flex-direction: column;
  max-height: 450px;
  overflow: hidden;
}

.players-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding-bottom: 12px;
  border-bottom: 2px solid var(--border);
  margin-bottom: 12px;
}

.players-header h2 {
  font-size: 1rem;
  font-weight: 700;
  color: var(--text);
  margin: 0;
}

.player-count {
  width: 28px;
  height: 28px;
  background: var(--mario-green);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.85rem;
  font-weight: 700;
  color: white;
  box-shadow: 0 2px 0 #15803d;
}

.players-list {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 8px;
  overflow-y: auto;
}

/* Empty State */
.empty-state {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 10px;
  color: var(--text-muted);
  font-size: 0.85rem;
  padding: 30px;
}

.empty-state .empty-icon {
  font-size: 2rem;
  animation: bounce 2s ease-in-out infinite;
}

@keyframes bounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-6px); }
}

/* Player Item - Compact */
.player-item {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 10px 12px;
  background: var(--bg-input);
  border-radius: var(--radius-md);
  border-left: 4px solid transparent;
  transition: all 0.2s ease;
}

.player-item:hover {
  transform: translateX(4px);
}

.player-item.color-red { border-left-color: var(--mario-red); }
.player-item.color-blue { border-left-color: var(--mario-blue); }
.player-item.color-green { border-left-color: var(--mario-green); }
.player-item.color-orange { border-left-color: var(--mario-yellow); }

.player-avatar {
  width: 32px;
  height: 32px;
  border-radius: var(--radius-sm);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1rem;
  flex-shrink: 0;
  color: white;
}

.player-item.color-red .player-avatar { background: var(--mario-red); box-shadow: 0 2px 0 #b91c1c; }
.player-item.color-blue .player-avatar { background: var(--mario-blue); box-shadow: 0 2px 0 #037bb5; }
.player-item.color-green .player-avatar { background: var(--mario-green); box-shadow: 0 2px 0 #15803d; }
.player-item.color-orange .player-avatar { background: var(--mario-yellow); box-shadow: 0 2px 0 #c9a000; }

.player-name {
  flex: 1;
  font-weight: 600;
  font-size: 0.9rem;
  color: var(--text);
}

.ready-badge {
  padding: 4px 10px;
  background: var(--mario-green);
  border-radius: var(--radius-full);
  font-size: 0.7rem;
  font-weight: 600;
  color: white;
  box-shadow: 0 2px 0 #15803d;
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */

@media (max-width: 900px) {
  .waiting-grid {
    grid-template-columns: 1fr;
  }

  .players-card {
    max-height: 350px;
  }
}

@media (max-width: 600px) {
  .room-header-content {
    flex-wrap: wrap;
    gap: 10px;
  }

  .code-value {
    font-size: 1.6rem;
    letter-spacing: 4px;
  }

  .stats-row {
    flex-direction: column;
    gap: 8px;
  }

  .stat-card {
    flex-direction: row !important;
    justify-content: center;
    gap: 8px;
  }

  .stat-card .stat-number {
    font-size: 1.1rem;
  }
}
</style>

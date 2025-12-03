<template>
  <div class="room-waiting">
    <!-- Floating decorations -->
    <div class="floating-decorations">
      <span class="float-item coin" v-for="n in 5" :key="'coin-'+n">🪙</span>
      <span class="float-item star" v-for="n in 3" :key="'star-'+n">⭐</span>
      <span class="float-item mushroom">🍄</span>
    </div>

    <!-- Two Column Layout -->
    <div class="waiting-grid">
      <!-- LEFT COLUMN: Room Info -->
      <div class="left-column">
        <!-- Room Header Card -->
        <div class="room-header-card">
          <div class="room-icon">🎮</div>
          <div class="room-info">
            <h1 class="room-name">{{ roomStore.currentRoom?.name || 'Oda' }}</h1>
            <span class="room-mode">⚔️ Eleme Modu</span>
          </div>
          <MarioButton color="red" size="sm" @click="handleLeaveRoom">
            🚪 Ayrıl
          </MarioButton>
        </div>

        <!-- Room Code (Big & Prominent) -->
        <div class="room-code-card">
          <div class="code-decoration left">?</div>
          <div class="code-decoration right">!</div>
          <span class="code-label">ODA KODU</span>
          <div class="code-display">
            <span
              v-for="(char, i) in (roomStore.currentRoom?.roomCode || '').split('')"
              :key="i"
              class="code-char"
              :style="{ animationDelay: `${i * 0.1}s` }"
            >{{ char }}</span>
          </div>
          <MarioButton color="blue" size="sm" @click="copyRoomCode">
            📋 Kodu Kopyala
          </MarioButton>
          <p class="code-hint">Bu kodu arkadaşlarınla paylaş!</p>
        </div>

        <!-- Game Stats -->
        <div class="stats-row">
          <div class="stat-block blue">
            <span class="stat-number">{{ roomStore.currentRoom?.questionCount }}</span>
            <span class="stat-label">SORU</span>
          </div>
          <div class="stat-block green">
            <span class="stat-number">{{ roomStore.players.length }}/{{ roomStore.currentRoom?.maxPlayers }}</span>
            <span class="stat-label">OYUNCU</span>
          </div>
          <div class="stat-block orange">
            <span class="stat-number">{{ estimatedTime }}</span>
            <span class="stat-label">MIN</span>
          </div>
        </div>

        <!-- Minimum Players Notice -->
        <div class="min-players-notice" v-if="!canStart">
          <span class="notice-icon">⏳</span>
          <span>{{ roomStore.players.length }}/{{ roomStore.currentRoom?.minPlayers || 2 }} oyuncu gerekli</span>
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
            class="start-button"
            :class="{ ready: canStart }"
          >
            <template #icon>{{ canStart ? '🚀' : '⏳' }}</template>
            {{ canStart ? 'OYUNU BAŞLAT!' : 'OYUNCU BEKLENİYOR...' }}
          </MarioButton>

          <div v-else class="waiting-host-card">
            <div class="waiting-animation">
              <span class="dot"></span>
              <span class="dot"></span>
              <span class="dot"></span>
            </div>
            <span>Host oyunu başlatmasını bekliyor...</span>
          </div>
        </div>
      </div>

      <!-- RIGHT COLUMN: Players List -->
      <div class="right-column">
        <div class="players-card">
          <div class="players-header">
            <div class="header-left">
              <span class="header-icon">👥</span>
              <h2>Oyuncular</h2>
            </div>
            <div class="player-count-badge">{{ roomStore.players.length }}</div>
          </div>

          <div class="players-list">
            <!-- Empty State -->
            <div v-if="roomStore.players.length === 0" class="empty-state">
              <div class="empty-animation">
                <span class="mario-jump">🏃</span>
              </div>
              <span>Oyuncu bekleniyor...</span>
            </div>

            <!-- Player Items -->
            <div
              v-for="(player, index) in roomStore.players"
              :key="player.username"
              class="player-item"
              :class="getPlayerColorClass(index)"
              :style="{ animationDelay: `${index * 0.1}s` }"
            >
              <div class="player-rank">#{{ index + 1 }}</div>
              <div class="player-avatar-wrapper">
                <div class="player-avatar">{{ player.avatar }}</div>
                <div class="avatar-glow"></div>
              </div>
              <div class="player-info">
                <span class="player-name">{{ player.username }}</span>
                <span class="player-status">Hazır</span>
              </div>
              <div class="ready-badge">
                <span class="check-icon">✓</span>
                Hazır
              </div>
            </div>
          </div>

          <!-- Player slots remaining -->
          <div class="slots-remaining" v-if="slotsRemaining > 0">
            <span>{{ slotsRemaining }} oyuncu daha katılabilir</span>
          </div>
        </div>
      </div>
    </div>

    <!-- Bottom Mario decoration -->
    <div class="bottom-decoration">
      <div class="ground">
        <div class="brick" v-for="n in 20" :key="n"></div>
      </div>
      <div class="pipe pipe-left">
        <div class="pipe-top"></div>
        <div class="pipe-body"></div>
      </div>
      <div class="pipe pipe-right">
        <div class="pipe-top"></div>
        <div class="pipe-body"></div>
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
import MarioButton from '../components/MarioButton.vue'
import { playPipe } from '../services/soundService'

const router = useRouter()
const roomStore = useRoomStore()
const gameStore = useGameStore()
const toastStore = useToastStore()

const canStart = computed(() => {
  const minPlayers = roomStore.currentRoom?.minPlayers || 2
  return roomStore.players.length >= minPlayers
})

const slotsRemaining = computed(() => {
  const max = roomStore.currentRoom?.maxPlayers || 10
  return max - roomStore.players.length
})

const estimatedTime = computed(() => {
  const questions = roomStore.currentRoom?.questionCount || 10
  return Math.ceil(questions * 60 / 60) // 60 seconds per question
})

const playerColors = ['red', 'blue', 'green', 'orange', 'pink', 'purple']

function getPlayerColorClass(index) {
  return `color-${playerColors[index % playerColors.length]}`
}

onMounted(async () => {
  setupGameStartingListener()

  if (roomStore.currentRoom) {
    console.log('Room already in store:', roomStore.currentRoom.roomCode)
    playPipe() // Mario pipe sound - odaya katılma
    return
  }

  const savedRoomCode = localStorage.getItem('currentRoomCode')
  if (savedRoomCode) {
    try {
      console.log('Rejoining room:', savedRoomCode)
      await roomStore.joinRoom(savedRoomCode)
      playPipe() // Mario pipe sound - odaya katılma
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
   ROOM WAITING - MARIO STYLE
   ========================================== */

.room-waiting {
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
  position: relative;
  min-height: calc(100vh - 100px);
}

/* Floating Decorations */
.floating-decorations {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  pointer-events: none;
  z-index: 0;
  overflow: hidden;
}

.float-item {
  position: absolute;
  font-size: 1.5rem;
  opacity: 0.3;
}

.float-item.coin {
  animation: floatCoin 6s ease-in-out infinite;
}

.float-item.coin:nth-child(1) { left: 5%; top: 20%; animation-delay: 0s; }
.float-item.coin:nth-child(2) { left: 15%; top: 50%; animation-delay: 1s; }
.float-item.coin:nth-child(3) { left: 85%; top: 30%; animation-delay: 2s; }
.float-item.coin:nth-child(4) { left: 90%; top: 60%; animation-delay: 3s; }
.float-item.coin:nth-child(5) { left: 50%; top: 15%; animation-delay: 4s; }

.float-item.star {
  animation: floatStar 8s ease-in-out infinite;
}

.float-item.star:nth-child(6) { left: 10%; top: 70%; animation-delay: 0.5s; }
.float-item.star:nth-child(7) { left: 80%; top: 80%; animation-delay: 2s; }
.float-item.star:nth-child(8) { left: 70%; top: 10%; animation-delay: 3.5s; }

.float-item.mushroom {
  left: 95%;
  top: 40%;
  animation: floatMushroom 10s ease-in-out infinite;
}

@keyframes floatCoin {
  0%, 100% { transform: translateY(0) rotate(0deg); }
  50% { transform: translateY(-20px) rotate(180deg); }
}

@keyframes floatStar {
  0%, 100% { transform: translateY(0) scale(1); }
  50% { transform: translateY(-15px) scale(1.2); }
}

@keyframes floatMushroom {
  0%, 100% { transform: translateY(0) translateX(0); }
  25% { transform: translateY(-10px) translateX(-5px); }
  75% { transform: translateY(-10px) translateX(5px); }
}

.waiting-grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 24px;
  position: relative;
  z-index: 1;
}

/* ==========================================
   LEFT COLUMN: ROOM INFO
   ========================================== */

.left-column {
  display: flex;
  flex-direction: column;
  gap: 16px;
}

/* Room Header Card */
.room-header-card {
  display: flex;
  align-items: center;
  gap: 16px;
  padding: 16px 20px;
  background: var(--bg-card);
  border: 3px solid var(--mario-blue);
  border-radius: var(--radius-xl);
  box-shadow: 0 6px 0 rgba(3, 123, 181, 0.4);
}

.room-icon {
  width: 56px;
  height: 56px;
  background: linear-gradient(135deg, var(--mario-blue), #0369a1);
  border-radius: var(--radius-lg);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.8rem;
  box-shadow: 0 4px 0 #037bb5;
}

.room-info {
  flex: 1;
}

.room-name {
  font-size: 1.3rem;
  font-weight: 800;
  color: var(--text);
  margin: 0 0 4px 0;
  text-transform: uppercase;
  letter-spacing: 1px;
}

.room-mode {
  font-size: 0.8rem;
  color: var(--text-muted);
  font-weight: 600;
}

/* Room Code Card */
.room-code-card {
  text-align: center;
  padding: 24px 20px;
  background: linear-gradient(135deg, var(--mario-yellow), #fbbf24);
  border-radius: var(--radius-xl);
  box-shadow: 0 6px 0 #d97706;
  position: relative;
  overflow: hidden;
}

.code-decoration {
  position: absolute;
  top: 12px;
  width: 32px;
  height: 32px;
  background: rgba(255, 255, 255, 0.3);
  border-radius: 6px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.2rem;
  font-weight: 900;
  color: #92400e;
  animation: blockBounce 2s ease-in-out infinite;
}

.code-decoration.left { left: 12px; }
.code-decoration.right { right: 12px; animation-delay: 0.3s; }

@keyframes blockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-5px); }
}

.code-label {
  display: block;
  font-size: 0.7rem;
  font-weight: 800;
  color: #92400e;
  text-transform: uppercase;
  letter-spacing: 2px;
  margin-bottom: 12px;
}

.code-display {
  margin-bottom: 16px;
  display: flex;
  justify-content: center;
  gap: 8px;
}

.code-char {
  font-family: 'JetBrains Mono', monospace;
  font-size: 2.2rem;
  font-weight: 900;
  color: #78350f;
  background: rgba(255, 255, 255, 0.5);
  padding: 8px 12px;
  border-radius: 8px;
  box-shadow: 0 3px 0 rgba(120, 53, 15, 0.3);
  animation: charPop 0.5s ease-out forwards;
  opacity: 0;
  transform: scale(0.5);
}

@keyframes charPop {
  0% { opacity: 0; transform: scale(0.5) translateY(-10px); }
  60% { transform: scale(1.1) translateY(2px); }
  100% { opacity: 1; transform: scale(1) translateY(0); }
}

.code-hint {
  font-size: 0.8rem;
  color: rgba(146, 64, 14, 0.9);
  margin: 14px 0 0 0;
  font-weight: 600;
}

/* Stats Row */
.stats-row {
  display: flex;
  gap: 12px;
}

.stat-block {
  flex: 1;
  text-align: center;
  padding: 16px 12px;
  border-radius: var(--radius-lg);
  color: white;
  position: relative;
  overflow: hidden;
}

.stat-block::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  height: 6px;
  background: rgba(255, 255, 255, 0.3);
  border-radius: var(--radius-lg) var(--radius-lg) 0 0;
}

.stat-block.blue {
  background: linear-gradient(135deg, var(--mario-blue), #0369a1);
  box-shadow: 0 5px 0 #037bb5;
}

.stat-block.green {
  background: linear-gradient(135deg, var(--mario-green), #15803d);
  box-shadow: 0 5px 0 #166534;
}

.stat-block.orange {
  background: linear-gradient(135deg, #f97316, #ea580c);
  box-shadow: 0 5px 0 #c2410c;
}

.stat-block .stat-number {
  display: block;
  font-size: 1.6rem;
  font-weight: 900;
  line-height: 1;
  text-shadow: 2px 2px 0 rgba(0, 0, 0, 0.2);
}

.stat-block .stat-label {
  display: block;
  font-size: 0.65rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 1px;
  margin-top: 6px;
  opacity: 0.9;
}

/* Min Players Notice */
.min-players-notice {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  padding: 12px 16px;
  background: var(--bg-card);
  border: 2px dashed var(--border);
  border-radius: var(--radius-lg);
  color: var(--text-muted);
  font-size: 0.9rem;
  font-weight: 600;
}

.notice-icon {
  font-size: 1.2rem;
  animation: pulse 1.5s ease-in-out infinite;
}

@keyframes pulse {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.2); }
}

/* Action Area */
.action-area {
  margin-top: auto;
}

.start-button.ready {
  animation: readyPulse 2s ease-in-out infinite;
}

@keyframes readyPulse {
  0%, 100% { box-shadow: 0 6px 0 #15803d, 0 0 0 0 rgba(34, 197, 94, 0.4); }
  50% { box-shadow: 0 6px 0 #15803d, 0 0 20px 10px rgba(34, 197, 94, 0.2); }
}

.waiting-host-card {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 12px;
  padding: 20px;
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-lg);
  color: var(--text-muted);
  font-size: 0.9rem;
  font-weight: 600;
}

.waiting-animation {
  display: flex;
  gap: 6px;
}

.waiting-animation .dot {
  width: 10px;
  height: 10px;
  background: var(--mario-blue);
  border-radius: 50%;
  animation: dotBounce 1.4s ease-in-out infinite;
}

.waiting-animation .dot:nth-child(2) { animation-delay: 0.2s; }
.waiting-animation .dot:nth-child(3) { animation-delay: 0.4s; }

@keyframes dotBounce {
  0%, 80%, 100% { transform: translateY(0); }
  40% { transform: translateY(-10px); }
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
  background: var(--bg-card);
  border: 3px solid var(--border);
  border-radius: var(--radius-xl);
  padding: 20px;
  box-shadow: 0 6px 0 var(--border);
  max-height: 500px;
}

.players-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding-bottom: 16px;
  border-bottom: 3px solid var(--border);
  margin-bottom: 16px;
}

.header-left {
  display: flex;
  align-items: center;
  gap: 10px;
}

.header-icon {
  font-size: 1.4rem;
}

.players-header h2 {
  font-size: 1.1rem;
  font-weight: 800;
  color: var(--text);
  margin: 0;
  text-transform: uppercase;
  letter-spacing: 1px;
}

.player-count-badge {
  width: 36px;
  height: 36px;
  background: linear-gradient(135deg, var(--mario-green), #15803d);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1rem;
  font-weight: 800;
  color: white;
  box-shadow: 0 3px 0 #166534;
  animation: countPulse 2s ease-in-out infinite;
}

@keyframes countPulse {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.05); }
}

.players-list {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 10px;
  overflow-y: auto;
  padding-right: 4px;
}

/* Empty State */
.empty-state {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 16px;
  color: var(--text-muted);
  font-size: 0.9rem;
  font-weight: 600;
  padding: 40px;
}

.empty-animation {
  font-size: 2.5rem;
}

.mario-jump {
  display: inline-block;
  animation: marioJump 1s ease-in-out infinite;
}

@keyframes marioJump {
  0%, 100% { transform: translateY(0) scaleX(1); }
  50% { transform: translateY(-15px) scaleX(1); }
}

/* Player Item */
.player-item {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 12px 14px;
  background: var(--bg-input);
  border-radius: var(--radius-lg);
  border: 2px solid transparent;
  transition: all 0.2s ease;
  animation: slideIn 0.4s ease-out forwards;
  opacity: 0;
  transform: translateX(-20px);
}

@keyframes slideIn {
  to {
    opacity: 1;
    transform: translateX(0);
  }
}

.player-item:hover {
  transform: translateX(6px);
  border-color: var(--border);
}

.player-rank {
  font-size: 0.75rem;
  font-weight: 800;
  color: var(--text-muted);
  min-width: 24px;
}

.player-avatar-wrapper {
  position: relative;
}

.player-avatar {
  width: 40px;
  height: 40px;
  border-radius: var(--radius-md);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.3rem;
  color: white;
  position: relative;
  z-index: 1;
}

.avatar-glow {
  position: absolute;
  inset: -2px;
  border-radius: var(--radius-md);
  opacity: 0.5;
  z-index: 0;
}

.player-item.color-red .player-avatar { background: linear-gradient(135deg, var(--mario-red), #b91c1c); box-shadow: 0 3px 0 #991b1b; }
.player-item.color-blue .player-avatar { background: linear-gradient(135deg, var(--mario-blue), #0369a1); box-shadow: 0 3px 0 #075985; }
.player-item.color-green .player-avatar { background: linear-gradient(135deg, var(--mario-green), #15803d); box-shadow: 0 3px 0 #166534; }
.player-item.color-orange .player-avatar { background: linear-gradient(135deg, #f97316, #ea580c); box-shadow: 0 3px 0 #c2410c; }
.player-item.color-pink .player-avatar { background: linear-gradient(135deg, #ec4899, #db2777); box-shadow: 0 3px 0 #be185d; }
.player-item.color-purple .player-avatar { background: linear-gradient(135deg, #8b5cf6, #7c3aed); box-shadow: 0 3px 0 #6d28d9; }

.player-info {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 2px;
}

.player-name {
  font-weight: 700;
  font-size: 0.95rem;
  color: var(--text);
}

.player-status {
  font-size: 0.7rem;
  color: var(--mario-green);
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.ready-badge {
  display: flex;
  align-items: center;
  gap: 4px;
  padding: 6px 12px;
  background: linear-gradient(135deg, var(--mario-green), #15803d);
  border-radius: var(--radius-full);
  font-size: 0.7rem;
  font-weight: 700;
  color: white;
  box-shadow: 0 3px 0 #166534;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.check-icon {
  font-size: 0.8rem;
}

/* Slots Remaining */
.slots-remaining {
  margin-top: 12px;
  padding-top: 12px;
  border-top: 2px dashed var(--border);
  text-align: center;
  font-size: 0.8rem;
  color: var(--text-muted);
  font-weight: 600;
}

/* ==========================================
   BOTTOM DECORATION
   ========================================== */

.bottom-decoration {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  height: 60px;
  pointer-events: none;
  z-index: 0;
}

.ground {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  gap: 2px;
  opacity: 0.3;
}

.brick {
  width: 30px;
  height: 15px;
  background: linear-gradient(180deg, #c2410c, #9a3412);
  border-radius: 2px;
}

.pipe {
  position: absolute;
  bottom: 15px;
  opacity: 0.25;
}

.pipe.pipe-left { left: 30px; }
.pipe.pipe-right { right: 30px; }

.pipe-top {
  width: 44px;
  height: 14px;
  background: linear-gradient(180deg, #22c55e, #16a34a);
  border-radius: 4px 4px 0 0;
}

.pipe-body {
  width: 36px;
  height: 30px;
  background: linear-gradient(90deg, #22c55e, #16a34a);
  margin: 0 auto;
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */

@media (max-width: 900px) {
  .waiting-grid {
    grid-template-columns: 1fr;
  }

  .players-card {
    max-height: 400px;
  }

  .floating-decorations {
    display: none;
  }
}

@media (max-width: 600px) {
  .room-waiting {
    padding: 12px;
  }

  .room-header-card {
    flex-wrap: wrap;
    gap: 12px;
  }

  .room-icon {
    width: 48px;
    height: 48px;
    font-size: 1.5rem;
  }

  .room-name {
    font-size: 1.1rem;
  }

  .code-display {
    gap: 4px;
  }

  .code-char {
    font-size: 1.6rem;
    padding: 6px 10px;
  }

  .stats-row {
    gap: 8px;
  }

  .stat-block {
    padding: 12px 8px;
  }

  .stat-block .stat-number {
    font-size: 1.3rem;
  }

  .bottom-decoration {
    display: none;
  }

  .code-decoration {
    display: none;
  }
}
</style>

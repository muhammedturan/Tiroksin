<template>
  <div class="spectator-container">
    <!-- Header -->
    <div class="spectator-header">
      <div class="header-left">
        <span class="spectator-badge">
          <span class="badge-icon">👀</span>
          <span class="badge-text">İzleme Modu</span>
        </span>
        <span class="question-info">Soru {{ gameStore.currentQuestionIndex + 1 }}</span>
      </div>
      <div class="header-right">
        <span class="timer" :class="{ warning: timeLeft <= 10 }">⏱️ {{ timeLeft }}s</span>
      </div>
    </div>

    <!-- Main Content -->
    <div class="spectator-content">
      <!-- Left Side: Question Display -->
      <div class="question-section">
        <MarioCard color="red" class="eliminated-banner">
          <span class="banner-icon">💀</span>
          <span class="banner-text">Oyundan Elendin - Sadece İzleyebilirsin</span>
        </MarioCard>

        <!-- Waiting for next question (sync with active players) -->
        <div v-if="waitingForNextQuestion" class="waiting-state">
          <div class="waiting-icon">⏳</div>
          <h3>Sonraki soru: {{ nextQuestionCountdown }}</h3>
          <p>Hazirlan!</p>
        </div>

        <QuestionDisplay
          v-else-if="gameStore.currentQuestion"
          :question="gameStore.currentQuestion"
          :show-options="true"
          :interactive="false"
        />

        <div v-else class="waiting-state">
          <div class="waiting-icon">⏳</div>
          <h3>Soru Bekleniyor...</h3>
          <p>Diğer oyuncular cevap veriyor</p>
        </div>
      </div>

      <!-- Right Side: Players Panel -->
      <div class="players-section">
        <div class="players-header">
          <h3>Oyuncular</h3>
          <span class="active-count">{{ activePlayersCount }} aktif</span>
        </div>

        <div class="players-list">
          <div
            v-for="player in sortedPlayers"
            :key="player.userId"
            class="player-card"
            :class="{
              eliminated: player.isEliminated,
              me: isMe(player.userId)
            }"
          >
            <div class="player-avatar">
              {{ player.username?.charAt(0)?.toUpperCase() || '?' }}
            </div>
            <div class="player-info">
              <div class="player-name">
                {{ player.username }}
                <span v-if="isMe(player.userId)" class="me-badge">Sen</span>
              </div>
              <div class="player-score">{{ player.score || 0 }} puan</div>
            </div>
            <div class="player-status">
              <span v-if="player.isEliminated" class="status-eliminated">💀</span>
              <span v-else class="status-active">✅</span>
            </div>
          </div>
        </div>

        <div class="spectator-stats">
          <div class="stat-item">
            <span class="stat-label">Elenen</span>
            <span class="stat-value">{{ eliminatedCount }}</span>
          </div>
          <div class="stat-item">
            <span class="stat-label">Kalan</span>
            <span class="stat-value">{{ activePlayersCount }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, onMounted, onUnmounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { useGameStore } from '../stores/game'
import { useRoomStore } from '../stores/room'
import signalrService from '../services/signalrService'
import api from '../services/api'
import MarioCard from '../components/MarioCard.vue'
import QuestionDisplay from '../components/QuestionDisplay.vue'

const router = useRouter()
const route = useRoute()
const gameStore = useGameStore()
const roomStore = useRoomStore()

const players = ref([])
const timeLeft = ref(60)
const waitingForNextQuestion = ref(false) // Waiting state while active players see results
const nextQuestionCountdown = ref(0) // Countdown to sync with active players
let timer = null
let countdownTimer = null

// Store remaining time from API for recovery on refresh
let initialRemainingTime = null

const activePlayersCount = computed(() => {
  return players.value.filter(p => !p.isEliminated).length
})

const eliminatedCount = computed(() => {
  return players.value.filter(p => p.isEliminated).length
})

const sortedPlayers = computed(() => {
  return [...players.value].sort((a, b) => {
    // Active players first
    if (a.isEliminated && !b.isEliminated) return 1
    if (!a.isEliminated && b.isEliminated) return -1
    // Then by score
    return (b.score || 0) - (a.score || 0)
  })
})

onMounted(async () => {
  console.log('👀 GameSpectator mounted')

  const sessionId = route.params.sessionId

  // Set gameSessionId if not set
  if (!gameStore.gameSessionId && sessionId) {
    gameStore.gameSessionId = sessionId
  }

  // Initialize players from roomStore
  if (roomStore.players && roomStore.players.length > 0) {
    players.value = roomStore.players.map(p => ({
      userId: p.userId,
      username: p.username,
      avatar: p.avatar || '👤',
      score: p.score || 0,
      isEliminated: p.isEliminated || false
    }))
  }

  // Load game data from API
  if (sessionId) {
    try {
      const response = await api.get(`/game/${sessionId}`)
      const gameData = response.data
      console.log('📥 Spectator game data:', gameData)

      if (gameData.status === 'Finished') {
        console.log('🏁 Game finished, redirecting to results...')
        router.replace(`/game-result/${sessionId}`)
        return
      }

      // Load questions if not available
      if (gameData.questions && gameData.questions.length > 0) {
        gameStore.questions = gameData.questions
      }

      // Load players if not available
      if (gameData.scoreboard) {
        players.value = gameData.scoreboard.map(p => ({
          userId: p.odaPlayerId || p.userId,
          username: p.username,
          avatar: p.avatar || '👤',
          score: p.score || 0,
          isEliminated: p.isEliminated || false
        }))
      }

      // Set current question index
      if (gameData.currentQuestionIndex !== undefined) {
        gameStore.currentQuestionIndex = gameData.currentQuestionIndex
      }

      // Load remaining time from API for timer synchronization
      if (gameData.remainingTimeSeconds !== undefined && gameData.remainingTimeSeconds !== null) {
        initialRemainingTime = gameData.remainingTimeSeconds
        timeLeft.value = initialRemainingTime
        console.log('✅ Spectator RemainingTime from API:', initialRemainingTime)
      }
    } catch (error) {
      console.error('❌ Error loading game data:', error)
    }
  }

  setupListeners()
  startTimer()
})

onUnmounted(() => {
  stopTimer()
  cleanupListeners()
})

function setupListeners() {
  console.log('🎧 Setting up spectator listeners...')

  cleanupListeners()

  // GameFinished - go to results
  signalrService.on('GameFinished', (data) => {
    console.log('🏁 GameFinished event received')
    stopTimer()
    gameStore.setGameResults(data)
    router.push(`/game-result/${gameStore.gameSessionId}`)
  })

  // NextQuestion - update question display with delay to sync with active players
  signalrService.on('NextQuestion', (data) => {
    console.log('⏭️ NextQuestion event received:', data)

    // Update players immediately
    if (data.players) {
      players.value = data.players
    }

    // Store the pending question data
    const pendingQuestion = data.question
    const pendingQuestionIndex = data.questionIndex
    const pendingTimeLimit = data.timeLimit || 60

    // Show waiting state with 3-second countdown (same as active players)
    waitingForNextQuestion.value = true
    nextQuestionCountdown.value = 3
    if (countdownTimer) clearInterval(countdownTimer)

    countdownTimer = setInterval(() => {
      nextQuestionCountdown.value--
      if (nextQuestionCountdown.value <= 0) {
        clearInterval(countdownTimer)
        countdownTimer = null

        // Now show the question (synced with active players)
        waitingForNextQuestion.value = false

        if (pendingQuestion) {
          const idx = pendingQuestionIndex
          if (idx >= gameStore.questions.length) {
            gameStore.questions.push(pendingQuestion)
          } else {
            gameStore.questions[idx] = pendingQuestion
          }
          gameStore.currentQuestionIndex = idx
        }

        // Reset timer with backend's timeLimit for synchronization
        timeLeft.value = pendingTimeLimit
        console.log('⏱️ Spectator timer reset to:', pendingTimeLimit)
      }
    }, 1000)
  })

  // PlayerEliminated - update player status
  signalrService.on('PlayerEliminated', (data) => {
    console.log('💀 PlayerEliminated event:', data)
    if (data.userId) {
      const player = players.value.find(p => p.userId === data.userId)
      if (player) {
        player.isEliminated = true
      }
    }
  })

  console.log('✅ Spectator listeners ready')
}

function cleanupListeners() {
  signalrService.offAll('GameFinished')
  signalrService.offAll('NextQuestion')
  signalrService.offAll('PlayerEliminated')
}

function startTimer() {
  stopTimer()
  timer = setInterval(() => {
    if (timeLeft.value > 0) {
      timeLeft.value--
    }
  }, 1000)
}

function stopTimer() {
  if (timer) {
    clearInterval(timer)
    timer = null
  }
}

function isMe(userId) {
  return userId === localStorage.getItem('userId')
}

</script>

<style scoped>
.spectator-container {
  min-height: calc(100vh - 80px);
  max-width: 1000px;
  margin: 0 auto;
}

/* Header */
.spectator-header {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 12px;
  padding: 12px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 16px;
}

.header-left {
  display: flex;
  align-items: center;
  gap: 14px;
}

.spectator-badge {
  display: flex;
  align-items: center;
  gap: 6px;
  background: var(--mario-orange);
  padding: 6px 14px;
  border-radius: 20px;
  font-weight: 600;
  font-size: 0.85rem;
  color: white;
  box-shadow: 0 2px 0 #c46a19;
}

.badge-icon {
  font-size: 1rem;
}

.question-info {
  color: var(--text);
  font-size: 1rem;
  font-weight: 700;
}

.timer {
  font-size: 1.1rem;
  font-weight: 700;
  color: var(--success);
  font-variant-numeric: tabular-nums;
  padding: 6px 12px;
  background: rgba(34, 197, 94, 0.15);
  border-radius: 8px;
}

.timer.warning {
  color: var(--error);
  background: rgba(239, 68, 68, 0.15);
  animation: pulse 1s infinite;
}

@keyframes pulse {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.5; }
}

/* Main Content */
.spectator-content {
  display: grid;
  grid-template-columns: 1fr 260px;
  gap: 16px;
}

/* Question Section */
.question-section {
  display: flex;
  flex-direction: column;
  gap: 12px;
}

.eliminated-banner {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  font-size: 0.9rem;
  font-weight: 600;
}

.banner-icon {
  font-size: 1.2rem;
}

/* Waiting State */
.waiting-state {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 40px 24px;
  text-align: center;
}

.waiting-icon {
  font-size: 3rem;
  margin-bottom: 16px;
}

.waiting-state h3 {
  font-size: 1.4rem;
  font-weight: 700;
  color: var(--text);
  margin: 0 0 8px 0;
}

.waiting-state p {
  font-size: 0.95rem;
  color: var(--text-muted);
  margin: 0;
}

/* Players Section */
.players-section {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 12px;
  padding: 16px;
  height: fit-content;
  position: sticky;
  top: 16px;
}

.players-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 14px;
}

.players-header h3 {
  margin: 0;
  font-size: 1rem;
  font-weight: 700;
  color: var(--text);
}

.active-count {
  background: var(--success);
  color: white;
  padding: 4px 10px;
  border-radius: 12px;
  font-size: 0.8rem;
  font-weight: 600;
}

.players-list {
  display: flex;
  flex-direction: column;
  gap: 8px;
  max-height: 320px;
  overflow-y: auto;
}

.player-card {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 10px;
  background: var(--bg-card-light);
  border-radius: 10px;
  border: 2px solid transparent;
}

.player-card.me {
  background: rgba(59, 130, 246, 0.15);
  border-color: var(--primary);
}

.player-card.eliminated {
  background: rgba(239, 68, 68, 0.1);
  border-color: rgba(239, 68, 68, 0.3);
  opacity: 0.6;
}

.player-avatar {
  width: 32px;
  height: 32px;
  background: var(--mario-blue);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  color: white;
  font-weight: 700;
  font-size: 0.85rem;
  flex-shrink: 0;
}

.player-card.eliminated .player-avatar {
  background: #6b7280;
}

.player-info {
  flex: 1;
  overflow: hidden;
}

.player-name {
  font-size: 0.85rem;
  font-weight: 600;
  color: var(--text);
  display: flex;
  align-items: center;
  gap: 6px;
}

.player-card.eliminated .player-name {
  color: var(--text-muted);
  text-decoration: line-through;
}

.me-badge {
  background: var(--primary);
  color: white;
  padding: 2px 6px;
  border-radius: 4px;
  font-size: 0.65rem;
  font-weight: 600;
}

.player-score {
  font-size: 0.75rem;
  color: var(--text-muted);
}

.player-status {
  font-size: 1.1rem;
}

/* Stats */
.spectator-stats {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 8px;
  margin-top: 14px;
  padding-top: 14px;
  border-top: 1px solid var(--border);
}

.stat-item {
  text-align: center;
  padding: 10px;
  background: var(--bg-card-light);
  border-radius: 8px;
}

.stat-label {
  display: block;
  font-size: 0.7rem;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
  margin-bottom: 4px;
}

.stat-value {
  display: block;
  font-size: 1.2rem;
  font-weight: 700;
  color: var(--text);
}

/* Responsive */
@media (max-width: 900px) {
  .spectator-content {
    grid-template-columns: 1fr;
  }

  .players-section {
    position: static;
  }
}

@media (max-width: 600px) {
  .spectator-header {
    flex-direction: column;
    gap: 12px;
  }
}

/* Support for HTML content */
:deep(img) {
  max-width: 100%;
  height: auto;
  border-radius: 8px;
  margin: 0.5rem 0;
}

:deep(p) {
  margin: 0;
  line-height: 1.6;
}
</style>

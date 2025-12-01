<template>
  <div class="game-arena">
    <!-- Top Bar: Question Number, Timer, Score -->
    <div class="top-bar">
      <div class="question-section">
        <span class="question-number">Soru {{ gameStore.currentQuestionIndex + 1 }}</span>
        <span class="active-players">{{ activePlayersCount }} oyuncu kaldı</span>
      </div>

      <div class="stats">
        <span class="timer" :class="{ warning: timeLeft <= 10 }">
          ⏱️ {{ timeLeft }}s
        </span>
        <span class="score">💯 {{ gameStore.myScore }}</span>
      </div>
    </div>

    <!-- Main Game Area -->
    <div class="game-container">
      <!-- Waiting for Others Screen -->
      <div v-if="waitingForOthers && !waitingForResults" class="state-card waiting">
        <div class="state-icon">⏳</div>
        <h2>Cevabın Alındı!</h2>
        <p>Diğer oyuncular bekleniyor...</p>
      </div>

      <!-- Results Screen (After Everyone Answers) -->
      <div v-else-if="waitingForResults && currentAnswer" class="state-card results">
        <div class="results-header">
          <div v-if="currentAnswer.isCorrect" class="result-badge correct">
            <span class="badge-icon">✅</span>
            <span class="badge-text">Doğru!</span>
          </div>
          <div v-else class="result-badge wrong">
            <span class="badge-icon">❌</span>
            <span class="badge-text">Yanlış!</span>
          </div>
        </div>

        <div class="correct-answer-box">
          <div class="answer-label">Doğru Cevap:</div>
          <div class="answer-content">
            <span class="answer-key">{{ getCorrectOptionKey() }}</span>
            <span class="answer-text" v-html="getCorrectOptionText()"></span>
          </div>
        </div>

        <div v-if="currentAnswer.isEliminated" class="elimination-alert">
          <span class="alert-icon">⚠️</span>
          <span class="alert-text">Oyundan Elendin!</span>
        </div>

        <div v-if="currentAnswer.pointsEarned > 0" class="points-earned">
          +{{ currentAnswer.pointsEarned }} puan kazandın!
        </div>

        <div v-if="nextQuestionCountdown > 0" class="countdown">
          Sonraki soru: {{ nextQuestionCountdown }}
        </div>
      </div>

      <!-- Question Display (Active Question) -->
      <div v-else-if="gameStore.currentQuestion" class="question-area">
        <div class="question-card">
          <!-- Question Text -->
          <div class="question-header">
            <div class="question-text" v-html="gameStore.currentQuestion.text"></div>
          </div>

          <!-- Question Image (if exists) -->
          <div v-if="gameStore.currentQuestion.imageUrl" class="question-image-container">
            <img :src="gameStore.currentQuestion.imageUrl" alt="Question Image" class="question-image" />
          </div>

          <!-- Options -->
          <div :class="getOptionsLayoutClass()">
            <button
              v-for="option in gameStore.currentQuestion.options"
              :key="option.id"
              @click="handleOptionClick(option.id)"
              class="option-btn"
              :class="{ selected: selectedOption === option.id }"
              :disabled="waitingForOthers || waitingForResults || answerSubmitted"
            >
              <span class="option-key">{{ option.optionKey }}</span>
              <span class="option-text" v-html="option.text"></span>
            </button>
          </div>

          <!-- Submit Button -->
          <div class="submit-section" v-if="!waitingForOthers && !waitingForResults && !answerSubmitted">
            <button
              class="btn-submit"
              :disabled="!selectedOption"
              @click="submitAnswer"
            >
              Cevabi Gonder
            </button>
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

const router = useRouter()
const route = useRoute()
const gameStore = useGameStore()
const roomStore = useRoomStore()

// Player status tracking - synced from backend via NextQuestion event only
const players = ref([]) // Full player list from backend

const selectedOption = ref(null)
const currentAnswer = ref(null)
const timeLeft = ref(60)
const isEliminated = ref(false)
const waitingForOthers = ref(false)
const waitingForResults = ref(false)
const nextQuestionCountdown = ref(0)
const answerSubmitted = ref(false) // Cevap gönderildi mi?

// Track processed question IDs to prevent duplicate handling
const lastProcessedQuestionIndex = ref(-1)

// Store remaining time from API for recovery on refresh
let initialRemainingTime = null

let timer = null
let countdownTimer = null

const activePlayersCount = computed(() => {
  return players.value.filter(p => !p.isEliminated).length
})

const sortedScoreboard = computed(() => {
  // Use players from backend state
  return players.value
    .map(player => ({
      odaPlayerId: player.odaPlayerId || player.odaPlayerİd || player.userId,
      username: player.username,
      userId: player.userId,
      score: player.score || 0,
      isEliminated: player.isEliminated || false,
      rank: player.isEliminated ? 999 : 0
    }))
    .sort((a, b) => {
      // Active players first, then eliminated
      if (a.isEliminated && !b.isEliminated) return 1
      if (!a.isEliminated && b.isEliminated) return -1
      // Then by score
      return b.score - a.score
    })
})

onMounted(async () => {
  console.log('🎮 Game Mode: Survival (Elimination)')
  console.log('📊 GameStore state:', {
    gameSessionId: gameStore.gameSessionId,
    questions: gameStore.questions,
    currentQuestionIndex: gameStore.currentQuestionIndex,
    currentQuestion: gameStore.currentQuestion
  })
  console.log('👥 RoomStore players:', roomStore.players)

  // Initialize players from roomStore
  if (roomStore.players && roomStore.players.length > 0) {
    players.value = roomStore.players.map(p => ({
      userId: p.userId,
      username: p.username,
      avatar: p.avatar || '👤',
      score: p.score || 0,
      isEliminated: p.isEliminated || false
    }))
    console.log('✅ Players initialized:', players.value.length)
  } else {
    console.warn('⚠️ No players in roomStore')
  }

  // Check if game is already finished, redirect to results
  const sessionId = route.params.sessionId
  if (sessionId) {
    // Set gameSessionId if not set
    if (!gameStore.gameSessionId) {
      gameStore.gameSessionId = sessionId
    }

    try {
      const response = await api.get(`/game/${sessionId}`)
      const gameData = response.data
      console.log('📥 Game data from API:', gameData)

      if (gameData.status === 'Finished') {
        console.log('🏁 Game already finished, redirecting to results...')
        router.replace(`/game-result/${sessionId}`)
        return
      }

      // Load questions from API response
      if (gameData.questions && gameData.questions.length > 0) {
        gameStore.questions = gameData.questions
        console.log('✅ Questions loaded from API:', gameStore.questions.length)
      }

      // Load currentQuestionIndex from API response
      if (gameData.currentQuestionIndex !== undefined) {
        gameStore.currentQuestionIndex = gameData.currentQuestionIndex
        lastProcessedQuestionIndex.value = gameData.currentQuestionIndex
        console.log('✅ CurrentQuestionIndex from API:', gameData.currentQuestionIndex)
      }

      // Load players from API response
      if (gameData.scoreboard && gameData.scoreboard.length > 0) {
        players.value = gameData.scoreboard.map(p => ({
          userId: p.userId,
          username: p.username,
          avatar: p.avatar || '👤',
          score: p.score || 0,
          isEliminated: p.isEliminated || false
        }))
        console.log('✅ Players loaded from API:', players.value.length)
      }

      // Load remaining time from API for timer recovery
      if (gameData.remainingTimeSeconds !== undefined && gameData.remainingTimeSeconds !== null) {
        initialRemainingTime = gameData.remainingTimeSeconds
        console.log('✅ RemainingTime from API:', initialRemainingTime)
      }

      // CRITICAL: Join SignalR room group to receive game events (NextQuestion, GameFinished, etc.)
      if (gameData.roomId) {
        const username = localStorage.getItem('username') || 'Unknown'
        console.log('🔗 Joining SignalR room:', gameData.roomId)
        await signalrService.joinRoom(gameData.roomId, username)
        console.log('✅ Joined SignalR room successfully')
      } else {
        console.warn('⚠️ No roomId in game data - SignalR events may not work!')
      }

      // Check if user already answered current question
      const currentQ = gameStore.questions[gameStore.currentQuestionIndex]
      if (currentQ && gameData.userAnswers && gameData.userAnswers[currentQ.id]) {
        console.log('⚠️ User already answered this question, waiting for others')
        waitingForOthers.value = true
      }
    } catch (error) {
      console.error('❌ Error checking game status:', error)
    }
  }

  console.log('🎯 Final state - Questions:', gameStore.questions?.length, 'Players:', players.value.length, 'Index:', gameStore.currentQuestionIndex)

  initQuestion()
  setupGameListeners()
})

onUnmounted(() => {
  stopTimer()
  stopCountdown()
  cleanupGameListeners()
})

function cleanupGameListeners() {
  console.log('🧹 Cleaning up game listeners...')
  signalrService.offAll('GameFinished')
  signalrService.offAll('NextQuestion')
}

function setupGameListeners() {
  console.log('🎧 Setting up game listeners...')

  // First clean up any existing listeners to prevent duplicates
  cleanupGameListeners()

  // GameFinished listener
  signalrService.on('GameFinished', async (data) => {
    console.log('🏁 GameFinished event received:', data)
    stopTimer()
    stopCountdown()
    gameStore.setGameResults(data)
    router.push(`/game-result/${gameStore.gameSessionId}`)
  })

  // NextQuestion listener - receives full game state from backend
  signalrService.on('NextQuestion', (data) => {
    console.log('⏭️ NextQuestion event received:', data)
    handleNextQuestion(data)
  })

  // Note: PlayerEliminated event is NOT listened here
  // All player status updates come through NextQuestion event with full player list
  // This simplifies the flow and ensures consistency

  console.log('✅ Listeners set up complete')
}

function handleNextQuestion(data) {
  console.log('📦 Processing NextQuestion data:', data)

  // CRITICAL: Prevent duplicate processing
  if (data.questionIndex !== undefined && data.questionIndex <= lastProcessedQuestionIndex.value) {
    console.log('⚠️ Ignoring duplicate NextQuestion event. Current:', lastProcessedQuestionIndex.value, 'Received:', data.questionIndex)
    return
  }

  // Update players from backend state
  if (data.players) {
    players.value = data.players
    console.log('👥 Updated players:', players.value)
  }

  // Check if current user is eliminated
  const myUserId = localStorage.getItem('userId')
  const myPlayer = players.value.find(p => p.userId === myUserId)
  if (myPlayer?.isEliminated) {
    isEliminated.value = true
  }

  // Store new question in gameStore (without changing index yet)
  if (data.question) {
    // Add question to the store at the correct index
    const idx = data.questionIndex
    if (idx >= gameStore.questions.length) {
      gameStore.questions.push(data.question)
    } else {
      gameStore.questions[idx] = data.question
    }
  }

  // Show results screen then move to next question
  showResultsAndMoveToNext(data.questionIndex)
}

function showResultsAndMoveToNext(nextIndex) {
  console.log('📺 showResultsAndMoveToNext called, nextIndex:', nextIndex, 'isEliminated:', isEliminated.value, 'hasCurrentAnswer:', !!currentAnswer.value)

  stopTimer()

  // CRITICAL: Clear waitingForOthers first
  waitingForOthers.value = false

  // For active players, show results screen and start countdown
  waitingForResults.value = true
  nextQuestionCountdown.value = 3
  countdownTimer = setInterval(() => {
    nextQuestionCountdown.value--
    if (nextQuestionCountdown.value <= 0) {
      stopCountdown()
      waitingForResults.value = false
      moveToQuestion(nextIndex)
    }
  }, 1000)
}

function moveToQuestion(index) {
  console.log('⏭️ moveToQuestion called with index:', index, 'isEliminated:', isEliminated.value)

  // If player is eliminated, redirect to spectator after seeing results
  if (isEliminated.value) {
    console.log('💀 Eliminated player - redirecting to spectator after results')
    router.replace(`/game-spectator/${gameStore.gameSessionId}`)
    return
  }

  // Update the processed index BEFORE changing currentQuestionIndex
  lastProcessedQuestionIndex.value = index

  // Update store index
  gameStore.currentQuestionIndex = index
  gameStore.questionStartTime = Date.now()

  // Reset question state
  initQuestion()
}

function initQuestion() {
  console.log('🔄 initQuestion called for index:', gameStore.currentQuestionIndex)
  selectedOption.value = null
  currentAnswer.value = null
  waitingForOthers.value = false
  waitingForResults.value = false
  nextQuestionCountdown.value = 0
  answerSubmitted.value = false

  // Use remaining time from API if available (for refresh recovery), otherwise use default
  if (initialRemainingTime !== null && initialRemainingTime !== undefined) {
    timeLeft.value = initialRemainingTime
    console.log('⏱️ Timer restored from API:', initialRemainingTime)
    initialRemainingTime = null // Reset after using
  } else {
    const currentQ = gameStore.questions[gameStore.currentQuestionIndex]
    timeLeft.value = currentQ?.timePerQuestion || 60
  }

  startTimer()
}

function startTimer() {
  stopTimer()
  timer = setInterval(() => {
    timeLeft.value--
    if (timeLeft.value <= 0) {
      stopTimer()
      if (!waitingForOthers.value && !waitingForResults.value && !isEliminated.value) {
        autoSubmitOnTimeout() // Auto-submit as timeout
      }
    }
  }, 1000)
}

function stopTimer() {
  if (timer) {
    clearInterval(timer)
    timer = null
  }
}

function stopCountdown() {
  if (countdownTimer) {
    clearInterval(countdownTimer)
    countdownTimer = null
  }
}

// Şıkka tıklandığında sadece seç (göndermez)
function handleOptionClick(optionId) {
  if (isEliminated.value || waitingForOthers.value || waitingForResults.value || answerSubmitted.value) {
    return
  }
  selectedOption.value = optionId
  console.log('🎯 Option selected:', optionId)
}

// Cevabı Gönder butonuna basıldığında
async function submitAnswer() {
  console.log('📤 submitAnswer called with optionId:', selectedOption.value)

  if (isEliminated.value) {
    console.log('❌ You are eliminated, cannot answer')
    return
  }

  if (waitingForOthers.value || waitingForResults.value || answerSubmitted.value) {
    console.log('⏸️ Already waiting or submitted, ignoring')
    return
  }

  if (!selectedOption.value) {
    console.log('⚠️ No option selected')
    return
  }

  answerSubmitted.value = true
  stopTimer()

  const timeSpent = (gameStore.currentQuestion?.timePerQuestion || 60) - timeLeft.value
  console.log('⏱️ Time spent:', timeSpent)

  try {
    console.log('📤 Calling gameStore.submitAnswer...')
    const result = await gameStore.submitAnswer(selectedOption.value)
    console.log('📥 Received result:', result)
    currentAnswer.value = result

    if (result.isEliminated) {
      console.log('💀 Player eliminated! Will redirect to spectator after results shown')
      isEliminated.value = true
    }

    waitingForOthers.value = true
    console.log('⏳ Now waiting for others')
  } catch (error) {
    console.error('❌ Error submitting answer:', error)
    answerSubmitted.value = false // Hata olursa tekrar denesin
  }
}

// Süre dolduğunda otomatik gönder (seçim yapılmamışsa null olarak)
async function autoSubmitOnTimeout() {
  console.log('⏰ Auto-submit on timeout, selectedOption:', selectedOption.value)

  if (isEliminated.value || waitingForOthers.value || waitingForResults.value || answerSubmitted.value) {
    return
  }

  answerSubmitted.value = true
  stopTimer()

  try {
    const result = await gameStore.submitAnswer(selectedOption.value) // null olabilir
    console.log('📥 Timeout result:', result)
    currentAnswer.value = result

    if (result.isEliminated) {
      isEliminated.value = true
    }

    waitingForOthers.value = true
  } catch (error) {
    console.error('❌ Error submitting timeout answer:', error)
  }
}

function isMe(userId) {
  return userId === localStorage.getItem('userId')
}

function getCorrectOptionKey() {
  if (!currentAnswer.value || !gameStore.currentQuestion) return ''
  const correctOption = gameStore.currentQuestion.options.find(o => o.id === currentAnswer.value.correctOptionId)
  return correctOption?.optionKey || ''
}

function getCorrectOptionText() {
  if (!currentAnswer.value || !gameStore.currentQuestion) return ''
  const correctOption = gameStore.currentQuestion.options.find(o => o.id === currentAnswer.value.correctOptionId)
  return correctOption?.text || ''
}

function getOptionsLayoutClass() {
  const layout = gameStore.currentQuestion?.optionsLayout || 'Vertical'

  switch (layout) {
    case 'Grid':
      return 'options-grid'
    case 'Horizontal':
      return 'options-horizontal'
    case 'Vertical':
    default:
      return 'options-vertical'
  }
}
</script>

<style scoped>
.game-arena {
  display: flex;
  flex-direction: column;
  gap: 16px;
  max-width: 700px;
  margin: 0 auto;
  min-height: calc(100vh - 100px);
}

/* Top Bar */
.top-bar {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 12px;
  padding: 14px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 12px;
}

.question-section {
  display: flex;
  align-items: center;
  gap: 12px;
}

.question-number {
  font-size: 1rem;
  font-weight: 700;
  color: var(--text);
}

.active-players {
  font-size: 0.8rem;
  font-weight: 600;
  color: var(--success);
  padding: 4px 10px;
  background: rgba(34, 197, 94, 0.15);
  border-radius: 20px;
}

.stats {
  display: flex;
  gap: 16px;
  align-items: center;
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

.score {
  font-size: 1rem;
  font-weight: 700;
  color: var(--primary-light);
  padding: 6px 12px;
  background: var(--bg-card-light);
  border-radius: 8px;
}

/* Game Container */
.game-container {
  flex: 1;
}

/* State Cards (Waiting, Eliminated, Results) */
.state-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 40px 24px;
  text-align: center;
}

.state-icon {
  font-size: 3.5rem;
  margin-bottom: 16px;
}

.state-card h2 {
  font-size: 1.4rem;
  font-weight: 700;
  margin: 0 0 10px 0;
  color: var(--text);
}

.state-card p {
  font-size: 0.95rem;
  color: var(--text-muted);
  margin: 0 0 8px 0;
}

.state-card.waiting {
  background: linear-gradient(135deg, rgba(59, 130, 246, 0.1) 0%, rgba(6, 182, 212, 0.1) 100%);
  border: 2px solid var(--primary);
}

.state-card.results {
  background: var(--bg-card);
}

.sub-info {
  font-size: 0.85rem;
  color: var(--text-muted);
  font-style: italic;
}

/* Results Screen */
.results-header {
  margin-bottom: 20px;
}

.result-badge {
  display: inline-flex;
  align-items: center;
  gap: 10px;
  padding: 12px 24px;
  border-radius: 30px;
  font-size: 1.1rem;
  font-weight: 700;
  margin-bottom: 16px;
}

.result-badge.correct {
  background: rgba(34, 197, 94, 0.2);
  color: var(--success);
  border: 2px solid var(--success);
}

.result-badge.wrong {
  background: rgba(239, 68, 68, 0.2);
  color: var(--error);
  border: 2px solid var(--error);
}

.badge-icon {
  font-size: 1.3rem;
}

.correct-answer-box {
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 12px;
  padding: 16px;
  margin: 16px 0;
}

.answer-label {
  font-size: 0.75rem;
  font-weight: 600;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
  margin-bottom: 10px;
}

.answer-content {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 12px;
  background: var(--bg-card);
  border-radius: 10px;
}

.answer-key {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 36px;
  height: 36px;
  background: var(--success);
  color: white;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: 700;
  flex-shrink: 0;
}

.answer-text {
  flex: 1;
  font-size: 0.95rem;
  font-weight: 600;
  color: var(--text);
  text-align: left;
}

.elimination-alert {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  background: rgba(239, 68, 68, 0.15);
  border: 2px solid var(--error);
  border-radius: 10px;
  padding: 14px;
  margin: 16px 0;
  font-size: 1rem;
  font-weight: 700;
  color: var(--error);
}

.alert-icon {
  font-size: 1.3rem;
}

.points-earned {
  font-size: 1.2rem;
  font-weight: 700;
  color: var(--success);
  margin: 16px 0;
}

.countdown {
  font-size: 2rem;
  font-weight: 800;
  background: linear-gradient(135deg, var(--primary-light) 0%, var(--accent) 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  margin-top: 20px;
  animation: countdownPulse 1s infinite;
}

@keyframes countdownPulse {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.08); }
}

/* Question Area */
.question-area {
  width: 100%;
}

.question-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 24px;
}

.question-header {
  margin-bottom: 20px;
}

.question-text {
  font-size: 1.15rem;
  font-weight: 600;
  line-height: 1.6;
  color: var(--text);
}

.question-image-container {
  margin: 16px 0;
  text-align: center;
}

.question-image {
  max-width: 100%;
  max-height: 220px;
  border-radius: 12px;
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.2);
}

/* Options Layouts */
.options-vertical {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.options-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 10px;
}

.options-horizontal {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
  gap: 10px;
}

.option-btn {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px 16px;
  background: var(--bg-card-light);
  border: none;
  border-radius: 8px;
  cursor: pointer;
  text-align: left;
  font-size: 0.95rem;
}

.option-btn:hover:not(:disabled) {
  background: rgba(59, 130, 246, 0.1);
}

.option-btn.selected {
  background: rgba(59, 130, 246, 0.2);
}

.option-btn:disabled {
  cursor: not-allowed;
  opacity: 0.5;
}

.option-key {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 32px;
  height: 32px;
  background: var(--primary);
  border: none;
  border-radius: 50%;
  font-weight: 700;
  font-size: 0.9rem;
  color: white;
  flex-shrink: 0;
}

.option-btn.selected .option-key {
  background: var(--success);
}

.option-text {
  flex: 1;
  font-weight: 500;
  font-size: 0.95rem;
  color: var(--text);
}

/* Submit Button Section */
.submit-section {
  margin-top: 20px;
  text-align: center;
}

.btn-submit {
  width: 100%;
  padding: 16px 24px;
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

.btn-submit:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 8px 30px var(--glow-blue);
}

.btn-submit:disabled {
  background: var(--bg-card-light);
  color: var(--text-muted);
  cursor: not-allowed;
  box-shadow: none;
}

/* Player Status Panel */
.player-status-panel {
  grid-column: 2 / 3;
  grid-row: 1 / 3;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 24px;
  height: fit-content;
  position: sticky;
  top: 20px;
}

.player-status-panel h3 {
  margin: 0 0 20px 0;
  font-size: 1.3rem;
  font-weight: 700;
  color: var(--text);
}

.player-list {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.player-item {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px;
  background: var(--bg-card-light);
  border-radius: 12px;
  border: 2px solid transparent;
  transition: all 0.2s;
}

.player-item.me {
  background: rgba(59, 130, 246, 0.1);
  border-color: var(--primary);
}

.player-item.eliminated {
  background: rgba(239, 68, 68, 0.1);
  border-color: rgba(239, 68, 68, 0.3);
}

.player-avatar {
  width: 40px;
  height: 40px;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  color: white;
  font-weight: 700;
  font-size: 1.1rem;
  flex-shrink: 0;
}

.player-item.eliminated .player-avatar {
  background: linear-gradient(135deg, #6b7280 0%, #4b5563 100%);
}

.player-info {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 4px;
  overflow: hidden;
}

.player-name {
  font-size: 0.95rem;
  font-weight: 600;
  color: var(--text);
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.player-item.eliminated .player-name {
  color: var(--text-muted);
  text-decoration: line-through;
}

.player-status-badge {
  font-size: 0.75rem;
  font-weight: 600;
  padding: 2px 8px;
  border-radius: 10px;
  width: fit-content;
}

.player-status-badge.status-active {
  background: rgba(34, 197, 94, 0.2);
  color: var(--success);
}

.player-status-badge.status-eliminated {
  background: rgba(239, 68, 68, 0.2);
  color: var(--error);
}

.player-status-icon {
  font-size: 1.5rem;
  flex-shrink: 0;
}

/* Responsive Design */
@media (max-width: 1200px) {
  .player-status-panel {
    position: static;
  }

  .top-bar {
    flex-wrap: wrap;
  }
}

@media (max-width: 768px) {
  .top-bar {
    padding: 12px 16px;
  }

  .question-text {
    font-size: 1.1rem;
  }

  .options-grid {
    grid-template-columns: 1fr;
  }

  .state-card {
    padding: 30px 20px;
  }

  .state-icon {
    font-size: 3rem;
  }

  .state-card h2 {
    font-size: 1.3rem;
  }
}

/* Support for HTML content (from Quill editor) */
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

:deep(ul), :deep(ol) {
  margin: 0.5rem 0;
  padding-left: 1.5rem;
}
</style>

<template>
  <div class="game-arena">
    <!-- Kahoot-Style Full Screen Layout -->

    <!-- Waiting for Others Screen -->
    <div v-if="waitingForOthers && !waitingForResults" class="fullscreen-state">
      <div class="state-content">
        <div class="state-icon-large">⏳</div>
        <h1>Cevabın Alındı!</h1>
        <p>Diğer oyuncular bekleniyor...</p>
        <div class="mini-stats">
          <span class="mini-stat">🎯 Soru {{ gameStore.currentQuestionIndex + 1 }}</span>
          <span class="mini-stat">💯 {{ gameStore.myScore }} puan</span>
        </div>
      </div>
    </div>

    <!-- Results Screen (After Everyone Answers) -->
    <div v-else-if="waitingForResults && currentAnswer" class="fullscreen-state results-state">
      <div class="state-content">
        <div v-if="currentAnswer.isCorrect" class="result-icon correct">✅</div>
        <div v-else class="result-icon wrong">❌</div>

        <h1 :class="currentAnswer.isCorrect ? 'text-correct' : 'text-wrong'">
          {{ currentAnswer.isCorrect ? 'Doğru!' : 'Yanlış!' }}
        </h1>

        <div class="correct-answer-display">
          <span class="answer-label">Doğru Cevap:</span>
          <div class="answer-box">
            <span class="answer-key-badge">{{ getCorrectOptionKey() }}</span>
            <span class="answer-text-content" v-html="getCorrectOptionText()"></span>
          </div>
        </div>

        <MarioCard v-if="currentAnswer.isEliminated" color="red" class="elimination-banner">
          <span>Oyundan Elendin!</span>
        </MarioCard>

        <div v-if="currentAnswer.pointsEarned > 0" class="points-display">
          +{{ currentAnswer.pointsEarned }} puan
        </div>

        <div v-if="nextQuestionCountdown > 0" class="next-countdown">
          <div class="countdown-number">{{ nextQuestionCountdown }}</div>
          <span>Sonraki soru</span>
        </div>
      </div>
    </div>

    <!-- Active Question - Kahoot Full Screen Layout -->
    <div v-else-if="gameStore.currentQuestion" class="kahoot-layout">
      <!-- Top Section: Timer + Question -->
      <div class="top-section">
        <!-- Timer Circle (Left) -->
        <div class="timer-circle" :class="{ warning: timeLeft <= 10 }">
          <span class="timer-value">{{ timeLeft }}</span>
        </div>

        <!-- Question Box (Center) -->
        <div class="question-box">
          <div class="question-text" v-html="getSafeQuestionText()"></div>
          <!-- Question Image (if exists) -->
          <img
            v-if="gameStore.currentQuestion.imageUrl"
            :src="gameStore.currentQuestion.imageUrl"
            alt="Question Image"
            class="question-image"
          />
        </div>

        <!-- Stats (Right) -->
        <div class="stats-column">
          <div class="stat-badge question-badge">
            <span class="stat-number">{{ gameStore.currentQuestionIndex + 1 }}</span>
            <span class="stat-label">SORU</span>
          </div>
          <div class="stat-badge score-badge">
            <span class="stat-number">{{ gameStore.myScore }}</span>
            <span class="stat-label">PUAN</span>
          </div>
          <div class="stat-badge players-badge">
            <span class="stat-number">{{ activePlayersCount }}</span>
            <span class="stat-label">OYUNCU</span>
          </div>
        </div>
      </div>

      <!-- Bottom Section: 2x2 Options Grid -->
      <div class="options-section">
        <div class="options-grid-2x2">
          <button
            v-for="(option, index) in gameStore.currentQuestion.options"
            :key="option.id"
            @click="handleOptionClick(option.id)"
            class="kahoot-option"
            :class="[
              getOptionColorClass(index),
              { selected: selectedOption === option.id }
            ]"
            :disabled="waitingForOthers || waitingForResults || answerSubmitted"
          >
            <span class="option-shape">{{ getOptionIcon(index) }}</span>
            <span class="option-content" v-html="getSafeOptionText(option.text)"></span>
          </button>
        </div>

        <!-- Submit Button (Floating) -->
        <button
          v-if="!waitingForOthers && !waitingForResults && !answerSubmitted && selectedOption"
          class="floating-submit"
          @click="submitAnswer"
        >
          <span>GÖNDER</span>
          <span class="submit-arrow">→</span>
        </button>
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
import { sanitizeHtml } from '../utils/sanitize'
import { playSelect, playCorrect, playWrong, playVictory, playFireball, preloadSounds } from '../services/soundService'
import MarioCard from '../components/MarioCard.vue'

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
  // Preload sounds for better performance
  preloadSounds()

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
    playVictory() // Mario powerup sound for game finish
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

  // NOW play the correct/wrong sound - this is when everyone has answered
  if (currentAnswer.value) {
    if (currentAnswer.value.isCorrect) {
      playCorrect() // Mario coin sound for correct answer
    } else {
      playWrong() // Mario bump sound for wrong answer
    }
  }

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
  playSelect() // Mario jump sound on selection
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

  // Calculate timeSpent from the local timer (more accurate than store's questionStartTime)
  const timeSpent = Math.max(0, (gameStore.currentQuestion?.timePerQuestion || 60) - timeLeft.value)
  console.log('⏱️ Time spent:', timeSpent)

  try {
    console.log('📤 Calling gameStore.submitAnswer...')
    const result = await gameStore.submitAnswer(selectedOption.value, timeSpent)
    console.log('📥 Received result:', result)
    currentAnswer.value = result

    // Play neutral "pipe" sound - don't reveal correct/wrong yet!
    playFireball() // Nötr ses - cevap alındı

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

  // Timeout = full question time
  const timeSpent = gameStore.currentQuestion?.timePerQuestion || 60

  try {
    const result = await gameStore.submitAnswer(selectedOption.value, timeSpent) // null olabilir
    console.log('📥 Timeout result:', result)
    currentAnswer.value = result

    // Play neutral sound - don't reveal correct/wrong yet!
    playFireball() // Nötr ses - süre doldu

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
  return sanitizeHtml(correctOption?.text || '')
}

// Soru metnini güvenli hale getir
function getSafeQuestionText() {
  return sanitizeHtml(gameStore.currentQuestion?.text || '')
}

// Seçenek metnini güvenli hale getir
function getSafeOptionText(text) {
  return sanitizeHtml(text || '')
}

// Kahoot-style option colors
function getOptionColorClass(index) {
  const colors = ['option-red', 'option-blue', 'option-yellow', 'option-green']
  return colors[index % colors.length]
}

// Kahoot-style option icons
function getOptionIcon(index) {
  const icons = ['▲', '◆', '●', '■']
  return icons[index % icons.length]
}
</script>

<style scoped>
/* ==========================================
   GAME ARENA - WIDE HORIZONTAL LAYOUT
   ========================================== */

.game-arena {
  min-height: 100vh;
  min-height: 100dvh;
  display: flex;
  flex-direction: column;
  background: var(--bg-main);
  overflow: hidden;
  max-width: 1400px;
  margin: 0 auto;
  padding: 12px;
}

/* ==========================================
   FULLSCREEN STATE SCREENS - COMPACT
   ========================================== */

.fullscreen-state {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 40px 16px;
  background: var(--bg-card);
  border-radius: var(--radius-lg);
  border: 1px solid var(--border);
  margin-top: 12px;
}

.fullscreen-state.results-state {
  background: var(--bg-card);
  border-radius: var(--radius-lg);
}

.state-content {
  text-align: center;
  max-width: 320px;
  animation: fadeInUp 0.3s ease;
}

@keyframes fadeInUp {
  from { opacity: 0; transform: translateY(15px); }
  to { opacity: 1; transform: translateY(0); }
}

.state-icon-large {
  font-size: 2.5rem;
  margin-bottom: 12px;
  animation: bounce 1.5s infinite;
}

@keyframes bounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-6px); }
}

.state-content h1 {
  font-size: 1.4rem;
  font-weight: 700;
  color: var(--text);
  margin: 0 0 6px 0;
}

.state-content p {
  font-size: 0.9rem;
  color: var(--text-muted);
  margin: 0 0 12px 0;
}

.mini-stats {
  display: flex;
  justify-content: center;
  gap: 10px;
}

.mini-stat {
  padding: 6px 12px;
  background: var(--bg-input);
  border-radius: var(--radius-full);
  font-weight: 600;
  font-size: 0.8rem;
  color: var(--text);
}

/* Result Icons */
.result-icon {
  font-size: 3rem;
  margin-bottom: 10px;
  animation: resultPop 0.4s ease;
}

@keyframes resultPop {
  0% { transform: scale(0); }
  50% { transform: scale(1.2); }
  100% { transform: scale(1); }
}

.result-icon.correct { filter: drop-shadow(0 0 15px rgba(16, 185, 129, 0.5)); }
.result-icon.wrong { filter: drop-shadow(0 0 15px rgba(239, 68, 68, 0.5)); }

.text-correct { color: #10b981 !important; }
.text-wrong { color: #ef4444 !important; }

/* Correct Answer Display */
.correct-answer-display {
  margin: 12px 0;
}

.correct-answer-display .answer-label {
  font-size: 0.65rem;
  font-weight: 600;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
  margin-bottom: 6px;
  display: block;
}

.answer-box {
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 10px 14px;
  background: #10b981;
  border-radius: var(--radius-md);
  box-shadow: 0 2px 0 #059669;
}

.answer-key-badge {
  width: 28px;
  height: 28px;
  background: rgba(255, 255, 255, 0.25);
  border-radius: 4px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.85rem;
  font-weight: 700;
  color: white;
  flex-shrink: 0;
}

.answer-text-content {
  flex: 1;
  font-size: 0.85rem;
  font-weight: 600;
  color: white;
  text-align: left;
}

/* Elimination Banner */
.elimination-banner {
  text-align: center;
  font-size: 1rem;
  font-weight: 700;
  margin: 10px 0;
  animation: shake 0.4s ease;
}

@keyframes shake {
  0%, 100% { transform: translateX(0); }
  25% { transform: translateX(-4px); }
  75% { transform: translateX(4px); }
}

/* Points Display */
.points-display {
  font-size: 1.2rem;
  font-weight: 800;
  color: #10b981;
  margin: 10px 0;
}

/* Next Question Countdown */
.next-countdown {
  margin-top: 14px;
}

.countdown-number {
  font-size: 2rem;
  font-weight: 900;
  color: var(--primary);
  line-height: 1;
  animation: countdownPulse 1s infinite;
}

@keyframes countdownPulse {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.1); }
}

.next-countdown span {
  display: block;
  font-size: 0.75rem;
  color: var(--text-muted);
  margin-top: 4px;
}

/* ==========================================
   KAHOOT LAYOUT - HORIZONTAL WIDE
   ========================================== */

.kahoot-layout {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 12px;
}

/* TOP SECTION - Horizontal Bar */
.top-section {
  display: flex;
  align-items: center;
  gap: 14px;
  padding: 12px 16px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: var(--radius-lg);
}

/* Timer Circle - Small */
.timer-circle {
  width: 48px;
  height: 48px;
  background: #3b82f6;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  box-shadow: 0 2px 0 #2563eb;
  flex-shrink: 0;
}

.timer-circle.warning {
  background: #ef4444;
  box-shadow: 0 2px 0 #dc2626;
  animation: timerShake 0.3s infinite;
}

@keyframes timerShake {
  0%, 100% { transform: rotate(-2deg); }
  50% { transform: rotate(2deg); }
}

.timer-value {
  font-size: 1.2rem;
  font-weight: 800;
  color: white;
  font-family: 'JetBrains Mono', monospace;
}

/* Question Box - Wide Horizontal */
.question-box {
  flex: 1;
  background: var(--bg-input);
  border-radius: var(--radius-md);
  padding: 12px 16px;
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 60px;
}

.question-text {
  font-size: 1rem;
  font-weight: 600;
  line-height: 1.4;
  color: var(--text);
  text-align: center;
}

.question-image {
  max-width: 120px;
  max-height: 60px;
  border-radius: 4px;
  margin-left: 12px;
}

/* Stats Row - Horizontal Badges */
.stats-column {
  display: flex;
  gap: 6px;
  flex-shrink: 0;
}

.stat-badge {
  display: flex;
  align-items: center;
  gap: 4px;
  padding: 6px 10px;
  border-radius: var(--radius-md);
}

.stat-badge .stat-number {
  font-size: 0.9rem;
  font-weight: 700;
  color: white;
}

.stat-badge .stat-label {
  font-size: 0.6rem;
  color: rgba(255, 255, 255, 0.8);
  text-transform: uppercase;
  font-weight: 600;
}

.question-badge {
  background: var(--mario-blue);
  box-shadow: 0 2px 0 #037bb5;
}

.score-badge {
  background: #f59e0b;
  box-shadow: 0 2px 0 #d97706;
}

.players-badge {
  background: #10b981;
  box-shadow: 0 2px 0 #059669;
}

/* ==========================================
   OPTIONS SECTION - COMPACT HORIZONTAL
   ========================================== */

.options-section {
  display: flex;
  flex-direction: column;
  gap: 6px;
  padding-bottom: 50px; /* Space for submit button */
}

/* 2x2 Grid */
.options-grid-2x2 {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-auto-rows: 1fr;
  gap: 6px;
}

/* Tüm seçenekler aynı yükseklikte */
.options-grid-2x2 .kahoot-option {
  min-height: 48px;
  height: 100%;
}

/* Tek sayıda seçenek varsa son elemanı ortala */
.options-grid-2x2 .kahoot-option:last-child:nth-child(odd) {
  grid-column: 1 / -1;
  width: calc(50% - 3px);
  justify-self: center;
}

/* Option Buttons - SLIM */
.kahoot-option {
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 14px 16px;
  border: none;
  border-radius: var(--radius-md);
  cursor: pointer;
  font-size: 0.85rem;
  font-weight: 600;
  color: white;
  transition: all 0.15s ease;
  position: relative;
  overflow: hidden;
}

.kahoot-option.option-red {
  background: #ef4444;
  box-shadow: 0 3px 0 #dc2626;
}

.kahoot-option.option-blue {
  background: #3b82f6;
  box-shadow: 0 3px 0 #2563eb;
}

.kahoot-option.option-yellow {
  background: #f59e0b;
  box-shadow: 0 3px 0 #d97706;
}

.kahoot-option.option-green {
  background: #10b981;
  box-shadow: 0 3px 0 #059669;
}

.kahoot-option:hover:not(:disabled) {
  transform: translateY(-2px);
  filter: brightness(1.05);
}

.kahoot-option:hover:not(:disabled).option-red { box-shadow: 0 5px 0 #dc2626; }
.kahoot-option:hover:not(:disabled).option-blue { box-shadow: 0 5px 0 #2563eb; }
.kahoot-option:hover:not(:disabled).option-yellow { box-shadow: 0 5px 0 #d97706; }
.kahoot-option:hover:not(:disabled).option-green { box-shadow: 0 5px 0 #059669; }

.kahoot-option:active:not(:disabled) {
  transform: translateY(1px);
}

.kahoot-option:active:not(:disabled).option-red { box-shadow: 0 1px 0 #dc2626; }
.kahoot-option:active:not(:disabled).option-blue { box-shadow: 0 1px 0 #2563eb; }
.kahoot-option:active:not(:disabled).option-yellow { box-shadow: 0 1px 0 #d97706; }
.kahoot-option:active:not(:disabled).option-green { box-shadow: 0 1px 0 #059669; }

.kahoot-option.selected {
  transform: translateY(1px) scale(0.99);
  box-shadow: 0 1px 0 rgba(0, 0, 0, 0.4) !important;
}

.kahoot-option.selected::after {
  content: '✓';
  position: absolute;
  top: 6px;
  right: 6px;
  width: 20px;
  height: 20px;
  background: white;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.75rem;
  color: var(--bg-main);
  font-weight: 800;
  animation: checkPop 0.25s ease;
}

@keyframes checkPop {
  0% { transform: scale(0); }
  50% { transform: scale(1.2); }
  100% { transform: scale(1); }
}

.kahoot-option:disabled {
  cursor: not-allowed;
  opacity: 0.7;
}

.option-shape {
  font-size: 1.1rem;
  opacity: 0.9;
  flex-shrink: 0;
}

.option-content {
  flex: 1;
  font-size: 0.85rem;
  font-weight: 600;
  line-height: 1.3;
  text-align: left;
}

/* Floating Submit Button */
.floating-submit {
  position: fixed;
  bottom: 12px;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 10px 28px;
  background: #10b981;
  border: none;
  border-radius: var(--radius-full);
  color: white;
  font-size: 0.9rem;
  font-weight: 700;
  cursor: pointer;
  box-shadow: 0 3px 0 #059669;
  z-index: 100;
  animation: submitAppear 0.25s ease;
}

@keyframes submitAppear {
  from { opacity: 0; transform: translateX(-50%) translateY(10px); }
  to { opacity: 1; transform: translateX(-50%) translateY(0); }
}

.floating-submit:hover {
  transform: translateX(-50%) translateY(-2px);
  box-shadow: 0 5px 0 #059669;
}

.floating-submit:active {
  transform: translateX(-50%) translateY(1px);
  box-shadow: 0 1px 0 #059669;
}

.submit-arrow {
  font-size: 1rem;
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */

@media (max-width: 800px) {
  .game-arena {
    padding: 8px;
  }

  .top-section {
    flex-wrap: wrap;
    gap: 10px;
    padding: 10px 12px;
  }

  .question-box {
    order: 3;
    width: 100%;
    min-height: 50px;
  }

  .timer-circle {
    width: 42px;
    height: 42px;
  }

  .timer-value {
    font-size: 1rem;
  }

  .stats-column {
    margin-left: auto;
  }

  .options-grid-2x2 {
    gap: 6px;
  }

  .kahoot-option {
    padding: 10px 12px;
  }
}

@media (max-width: 500px) {
  .options-grid-2x2 {
    grid-template-columns: 1fr;
    grid-template-rows: repeat(4, 1fr);
    gap: 6px;
  }

  .kahoot-option {
    padding: 10px 12px;
  }

  .option-shape {
    font-size: 1rem;
  }

  .option-content {
    font-size: 0.8rem;
  }

  .floating-submit {
    bottom: 8px;
    padding: 8px 24px;
    font-size: 0.85rem;
  }

  .state-content h1 {
    font-size: 1.2rem;
  }

  .state-icon-large {
    font-size: 2rem;
  }

  .result-icon {
    font-size: 2.5rem;
  }

  .countdown-number {
    font-size: 1.6rem;
  }
}

/* ==========================================
   HTML CONTENT SUPPORT (Quill editor)
   ========================================== */

:deep(img) {
  max-width: 100%;
  height: auto;
  border-radius: 4px;
  margin: 0.3rem 0;
}

:deep(p) {
  margin: 0;
  line-height: 1.4;
}

:deep(ul), :deep(ol) {
  margin: 0.3rem 0;
  padding-left: 1rem;
}
</style>

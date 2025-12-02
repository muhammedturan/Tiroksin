import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { gameService } from '../services/gameService'

export const useGameStore = defineStore('game', () => {
  // State
  const gameSessionId = ref(null)
  const questions = ref([])
  const currentQuestionIndex = ref(0)
  const answers = ref({}) // { questionId: { selectedOptionId, timeSpent, isCorrect } }
  const scoreboard = ref([])
  const gameStatus = ref('waiting') // waiting, playing, finished
  const countdown = ref(null)
  const questionStartTime = ref(null)
  const loading = ref(false)
  const error = ref(null)
  const results = ref([]) // Game results for review
  const allPlayersAnswers = ref({}) // All players' answers grouped by questionId
  const gameMode = ref(null) // 1 = Classic, 2 = Survival

  // Computed
  const currentQuestion = computed(() => {
    return questions.value[currentQuestionIndex.value] || null
  })

  const totalQuestions = computed(() => questions.value.length)

  const answeredCount = computed(() => Object.keys(answers.value).length)

  const myScore = computed(() => {
    const userId = localStorage.getItem('userId')
    const player = scoreboard.value.find(p => p.userId === userId)
    return player?.score || 0
  })

  const myRank = computed(() => {
    const userId = localStorage.getItem('userId')
    const player = scoreboard.value.find(p => p.userId === userId)
    return player?.rank || 0
  })

  // Actions
  async function startGame(roomId) {
    loading.value = true
    error.value = null

    try {
      const data = await gameService.startGame(roomId)
      gameSessionId.value = data.gameSessionId
      questions.value = data.questions
      currentQuestionIndex.value = 0
      gameStatus.value = 'playing'
      questionStartTime.value = Date.now()

      return data
    } catch (err) {
      error.value = err.message
      throw err
    } finally {
      loading.value = false
    }
  }

  async function submitAnswer(selectedOptionId, providedTimeSpent = null) {
    if (!currentQuestion.value || !gameSessionId.value) return

    // Use provided timeSpent if available, otherwise calculate from questionStartTime
    const timeSpent = providedTimeSpent !== null
      ? providedTimeSpent
      : Math.max(0, Math.floor((Date.now() - (questionStartTime.value || Date.now())) / 1000))

    try {
      const data = await gameService.submitAnswer(
        gameSessionId.value,
        currentQuestion.value.id,
        selectedOptionId,
        timeSpent
      )

      // Save answer
      answers.value[currentQuestion.value.id] = {
        selectedOptionId,
        timeSpent,
        isCorrect: data.isCorrect,
        pointsEarned: data.pointsEarned
      }

      return data
    } catch (err) {
      error.value = err.message
      throw err
    }
  }

  function nextQuestion() {
    if (currentQuestionIndex.value < questions.value.length - 1) {
      currentQuestionIndex.value++
      questionStartTime.value = Date.now()
      return true
    }
    return false
  }

  function previousQuestion() {
    if (currentQuestionIndex.value > 0) {
      currentQuestionIndex.value--
      return true
    }
    return false
  }

  function updateScoreboard(scores) {
    scoreboard.value = scores
  }

  function setGameStarting(countdown) {
    gameStatus.value = 'starting'
    countdown.value = countdown
  }

  function receiveQuestion(questionData) {
    // Add new question from SignalR and set as current
    if (questionData.question) {
      // Check if question already exists
      const existingIndex = questions.value.findIndex(q => q.id === questionData.question.id)
      if (existingIndex === -1) {
        // Add new question
        questions.value.push(questionData.question)
      }
      // Set current index to this question
      currentQuestionIndex.value = questionData.questionIndex || questions.value.length - 1
      questionStartTime.value = Date.now()
    }
  }

  function setCurrentQuestion(question, index) {
    // Replace or add the question at the specified index
    if (index >= questions.value.length) {
      questions.value.push(question)
    } else {
      questions.value[index] = question
    }
    currentQuestionIndex.value = index
    questionStartTime.value = Date.now()
  }

  function setGameResults(gameResults) {
    results.value = gameResults.results || []
    allPlayersAnswers.value = gameResults.allPlayersAnswers || {}
  }

  function reset() {
    gameSessionId.value = null
    questions.value = []
    currentQuestionIndex.value = 0
    answers.value = {}
    scoreboard.value = []
    gameStatus.value = 'waiting'
    countdown.value = null
    questionStartTime.value = null
    loading.value = false
    error.value = null
    results.value = []
    allPlayersAnswers.value = {}
    gameMode.value = null
  }

  return {
    // State
    gameSessionId,
    questions,
    currentQuestionIndex,
    answers,
    scoreboard,
    gameStatus,
    countdown,
    loading,
    error,
    results,
    allPlayersAnswers,
    gameMode,

    // Computed
    currentQuestion,
    totalQuestions,
    answeredCount,
    myScore,
    myRank,

    // Actions
    startGame,
    submitAnswer,
    nextQuestion,
    previousQuestion,
    updateScoreboard,
    setGameStarting,
    receiveQuestion,
    setCurrentQuestion,
    setGameResults,
    reset
  }
})

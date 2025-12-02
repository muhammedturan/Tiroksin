import api from './api'

export const gameService = {
  // Start the game (host only)
  async startGame(roomId) {
    const response = await api.post('/game/start', { roomId })
    return response.data
  },

  // Submit an answer (Survival mode)
  async submitAnswer(gameSessionId, questionId, selectedOptionId, timeSpent) {
    console.log('🎯 Submitting answer:', { gameSessionId, questionId, selectedOptionId, timeSpent })
    const response = await api.post('/game/submit-answer', {
      gameSessionId,
      questionId,
      selectedOptionId,
      timeSpent
    })
    console.log('✅ Answer submitted successfully:', response.data)
    return response.data
  },

  // Get game session state (for recovery on page refresh)
  async getGameSession(gameSessionId) {
    const response = await api.get(`/game/${gameSessionId}`)
    return response.data
  },

  // Finish the game and get final results
  async finishGame(gameSessionId, roomId) {
    console.log('🏁 Finishing game:', { gameSessionId, roomId })
    const response = await api.post('/game/finish', {
      gameSessionId,
      roomId
    })
    console.log('✅ Game finished successfully:', response.data)
    return response.data
  }
}

import api from './api'

export const roomService = {
  // Get all active rooms
  async getRooms(filters = {}) {
    const params = new URLSearchParams()
    if (filters.isPublic !== undefined) params.append('isPublic', filters.isPublic)
    if (filters.status !== undefined) params.append('status', filters.status)
    if (filters.gameMode !== undefined) params.append('gameMode', filters.gameMode)

    const response = await api.get(`/rooms?${params.toString()}`)
    return response.data
  },

  // Create a new room
  async createRoom(roomData) {
    const response = await api.post('/rooms', roomData)
    return response.data
  },

  // Join a room
  async joinRoom(roomCode, password = null) {
    const response = await api.post('/rooms/join', {
      roomCode,
      password
    })
    return response.data
  }
}

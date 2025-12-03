import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { roomService } from '../services/roomService'
import signalrService from '../services/signalrService'

// Sound for player join
const pipeSound = new Audio('/sounds/pipe.wav')
pipeSound.volume = 0.5

export const useRoomStore = defineStore('room', () => {
  // State
  const rooms = ref([])
  const currentRoom = ref(null)
  const players = ref([])
  const loading = ref(false)
  const error = ref(null)
  const listenersInitialized = ref(false)

  // Note: Don't load from localStorage here
  // We'll rejoin via backend on page load to get fresh data

  // Setup global SignalR listeners for room events
  function setupGlobalListeners() {
    if (listenersInitialized.value) return

    console.log('🔧 Setting up global room listeners in store...')

    // Listen for RoomPlayersInitialized - this comes right after joining a room
    signalrService.on('RoomPlayersInitialized', (data) => {
      console.log('📋 [Store] RoomPlayersInitialized received:', data)
      if (data.players && Array.isArray(data.players)) {
        const currentUsername = localStorage.getItem('username')
        const currentUserId = localStorage.getItem('userId')
        const currentAvatar = localStorage.getItem('avatar') || '👤'

        const mappedPlayers = data.players.map(p => ({
          userId: p.userId,
          username: p.username,
          avatar: p.avatar || '👤',
          isReady: p.isReady || false
        }))

        // Make sure current user is in the list
        if (currentUsername && !mappedPlayers.find(p => p.username === currentUsername)) {
          mappedPlayers.push({
            userId: currentUserId,
            username: currentUsername,
            avatar: currentAvatar,
            isReady: false
          })
        }

        players.value = mappedPlayers
        console.log('✅ [Store] Players list set:', players.value.length)
      }
    })

    // Listen for PlayerJoined
    signalrService.on('PlayerJoined', (data) => {
      console.log('👋 [Store] PlayerJoined received:', data)
      if (data.username) {
        const currentUsername = localStorage.getItem('username')
        const exists = players.value.find(p => p.username === data.username)
        if (!exists) {
          players.value.push({
            userId: data.userId,
            username: data.username,
            avatar: data.avatar || '👤',
            isReady: false
          })
          console.log('✅ [Store] Player added:', data.username, 'Total:', players.value.length)

          // Play pipe sound when someone else joins (not yourself)
          if (data.username !== currentUsername) {
            pipeSound.currentTime = 0
            pipeSound.play().catch(err => console.log('Sound play failed:', err))
          }
        }
      }
    })

    // Listen for PlayerLeft
    signalrService.on('PlayerLeft', (data) => {
      console.log('👋 [Store] PlayerLeft received:', data)
      if (data.username) {
        players.value = players.value.filter(p => p.username !== data.username)
        console.log('❌ [Store] Player removed:', data.username)
      }
    })

    listenersInitialized.value = true
  }

  // Computed
  const currentPlayerCount = computed(() => players.value.length)
  const isHost = computed(() => {
    if (!currentRoom.value) return false
    const userId = localStorage.getItem('userId')
    return currentRoom.value.hostUserId === userId
  })

  // Actions
  async function fetchRooms(filters = {}) {
    loading.value = true
    error.value = null

    try {
      const data = await roomService.getRooms(filters)
      rooms.value = data
      return data
    } catch (err) {
      error.value = err.message
      throw err
    } finally {
      loading.value = false
    }
  }

  async function createRoom(roomData) {
    loading.value = true
    error.value = null

    try {
      // Clear any existing room data first
      currentRoom.value = null
      players.value = []
      localStorage.removeItem('currentRoomCode')

      // Ensure SignalR is connected before proceeding
      const connected = await signalrService.ensureConnected()
      if (!connected) {
        throw new Error('SignalR bağlantısı kurulamadı')
      }

      // Setup global listeners BEFORE joining room to catch RoomPlayersInitialized
      setupGlobalListeners()

      const data = await roomService.createRoom(roomData)
      currentRoom.value = data
      // Save room code for page refresh
      localStorage.setItem('currentRoomCode', data.roomCode)

      // Join SignalR room
      const username = localStorage.getItem('username') || 'Player'
      const avatar = localStorage.getItem('avatar') || '👤'
      await signalrService.joinRoom(data.roomId, username, avatar)

      return data
    } catch (err) {
      error.value = err.message
      throw err
    } finally {
      loading.value = false
    }
  }

  async function joinRoom(roomCode, password = null) {
    loading.value = true
    error.value = null

    try {
      // Clear any existing room data first
      currentRoom.value = null
      players.value = []
      localStorage.removeItem('currentRoomCode')

      // Ensure SignalR is connected before proceeding
      const connected = await signalrService.ensureConnected()
      if (!connected) {
        throw new Error('SignalR bağlantısı kurulamadı')
      }

      // Setup global listeners BEFORE joining room to catch RoomPlayersInitialized
      setupGlobalListeners()

      const data = await roomService.joinRoom(roomCode, password)
      currentRoom.value = data
      // Save room code for page refresh
      localStorage.setItem('currentRoomCode', data.roomCode)

      // Join SignalR room
      const username = localStorage.getItem('username') || 'Player'
      const avatar = localStorage.getItem('avatar') || '👤'
      await signalrService.joinRoom(data.roomId, username, avatar)

      return data
    } catch (err) {
      error.value = err.message
      throw err
    } finally {
      loading.value = false
    }
  }

  async function leaveRoom() {
    if (!currentRoom.value) return

    try {
      const username = localStorage.getItem('username') || 'Player'
      await signalrService.leaveRoom(currentRoom.value.roomId, username)

      currentRoom.value = null
      players.value = []
      localStorage.removeItem('currentRoomCode')
    } catch (err) {
      error.value = err.message
      throw err
    }
  }

  async function toggleReady(isReady) {
    if (!currentRoom.value) return

    try {
      const username = localStorage.getItem('username') || 'Player'
      await signalrService.playerReady(currentRoom.value.roomId, username, isReady)
    } catch (err) {
      error.value = err.message
      throw err
    }
  }

  function addPlayer(player) {
    const existingPlayer = players.value.find(p => p.username === player.username)
    if (!existingPlayer) {
      players.value.push(player)
    }
  }

  function removePlayer(username) {
    players.value = players.value.filter(p => p.username !== username)
  }

  function updatePlayerStatus(username, isReady) {
    const player = players.value.find(p => p.username === username)
    if (player) {
      player.isReady = isReady
    }
  }

  function cleanupGlobalListeners() {
    console.log('🧹 Cleaning up global room listeners...')
    signalrService.offAll('RoomPlayersInitialized')
    signalrService.offAll('PlayerJoined')
    signalrService.offAll('PlayerLeft')
    listenersInitialized.value = false
  }

  function reset() {
    rooms.value = []
    currentRoom.value = null
    players.value = []
    loading.value = false
    error.value = null
    cleanupGlobalListeners()
    localStorage.removeItem('currentRoomCode')
  }

  return {
    // State
    rooms,
    currentRoom,
    players,
    loading,
    error,

    // Computed
    currentPlayerCount,
    isHost,

    // Actions
    fetchRooms,
    createRoom,
    joinRoom,
    leaveRoom,
    toggleReady,
    addPlayer,
    removePlayer,
    updatePlayerStatus,
    reset
  }
})

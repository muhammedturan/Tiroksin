import * as signalR from '@microsoft/signalr'

// Environment variable'dan API URL'ini al, yoksa default kullan
const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5000'
const HUB_URL = `${API_URL}/gamehub`

class SignalRService {
  constructor() {
    this.connection = null
    this.callbacks = {}
    this.connectionPromise = null
  }

  async connect(token) {
    // If already connected, return immediately
    if (this.connection?.state === signalR.HubConnectionState.Connected) {
      console.log('✅ SignalR already connected')
      return true
    }

    // If connection is in progress, wait for it
    if (this.connectionPromise) {
      console.log('⏳ Connection in progress, waiting...')
      return this.connectionPromise
    }

    // If there's an existing connection in a different state, disconnect first
    if (this.connection) {
      await this.disconnect()
    }

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(HUB_URL, {
        accessTokenFactory: () => token,
        transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling
      })
      .withAutomaticReconnect([0, 1000, 2000, 5000, 10000])
      .configureLogging(signalR.LogLevel.Information)
      .build()

    // Setup event listeners
    this.setupEventListeners()

    // Store promise to prevent concurrent connections
    this.connectionPromise = this.connection.start()
      .then(() => {
        console.log('✅ SignalR Connected')
        this.connectionPromise = null
        return true
      })
      .catch((err) => {
        console.error('❌ SignalR Connection Error:', err)
        this.connectionPromise = null
        return false
      })

    return this.connectionPromise
  }

  async ensureConnected() {
    if (this.connection?.state === signalR.HubConnectionState.Connected) {
      return true
    }

    // Wait for any in-progress connection
    if (this.connectionPromise) {
      return this.connectionPromise
    }

    // Try to reconnect with existing token
    const token = localStorage.getItem('token')
    if (token) {
      return this.connect(token)
    }

    return false
  }

  async disconnect() {
    if (this.connection) {
      await this.connection.stop()
      this.connection = null
      console.log('🔌 SignalR Disconnected')
    }
  }

  setupEventListeners() {
    console.log('🔧 Setting up SignalR event listeners...')
    // Room events
    this.connection.on('RoomPlayersInitialized', (data) => {
      console.log('📥 SignalR received RoomPlayersInitialized:', data)
      this.emit('RoomPlayersInitialized', data)
    })
    this.connection.on('PlayerJoined', (data) => {
      console.log('📥 SignalR received PlayerJoined:', data)
      this.emit('PlayerJoined', data)
    })
    this.connection.on('PlayerLeft', (data) => this.emit('PlayerLeft', data))
    this.connection.on('PlayerReadyStatusChanged', (data) => this.emit('PlayerReadyStatusChanged', data))

    // Game events
    this.connection.on('GameStarting', (data) => this.emit('GameStarting', data))
    this.connection.on('QuestionReceived', (data) => this.emit('QuestionReceived', data))
    this.connection.on('PlayerAnswered', (data) => this.emit('PlayerAnswered', data))
    this.connection.on('NextQuestion', (data) => this.emit('NextQuestion', data))
    this.connection.on('AnswerRevealed', (data) => this.emit('AnswerRevealed', data))
    this.connection.on('ScoreboardUpdated', (data) => this.emit('ScoreboardUpdated', data))
    this.connection.on('GameFinished', (data) => this.emit('GameFinished', data))
    this.connection.on('PlayerEliminated', (data) => this.emit('PlayerEliminated', data))

    // Chat events
    this.connection.on('MessageReceived', (data) => this.emit('MessageReceived', data))
    this.connection.on('ReactionReceived', (data) => this.emit('ReactionReceived', data))

    // Rejoin events
    this.connection.on('RejoinSuccess', (data) => this.emit('RejoinSuccess', data))
    this.connection.on('RejoinFailed', (data) => this.emit('RejoinFailed', data))
    this.connection.on('PlayerReconnected', (data) => this.emit('PlayerReconnected', data))
    this.connection.on('GameError', (data) => this.emit('GameError', data))

    // Connection events
    this.connection.onreconnecting((error) => {
      console.log('🔄 SignalR Reconnecting...', error)
      this.emit('Reconnecting', { error })
    })

    this.connection.onreconnected((connectionId) => {
      console.log('✅ SignalR Reconnected:', connectionId)
      this.emit('Reconnected', { connectionId })
    })

    this.connection.onclose((error) => {
      console.log('❌ SignalR Connection Closed', error)
      this.emit('Closed', { error })
    })
  }

  // Event emitter
  on(event, callback) {
    if (!this.callbacks[event]) {
      this.callbacks[event] = []
    }
    // Prevent duplicate callbacks
    if (!this.callbacks[event].includes(callback)) {
      this.callbacks[event].push(callback)
      console.log(`🎯 Registered callback for ${event}, total: ${this.callbacks[event].length}`)
    }
  }

  off(event, callback) {
    if (this.callbacks[event]) {
      this.callbacks[event] = this.callbacks[event].filter(cb => cb !== callback)
    }
  }

  // Remove all callbacks for an event
  offAll(event) {
    if (event) {
      this.callbacks[event] = []
    } else {
      this.callbacks = {}
    }
  }

  emit(event, data) {
    const callbackCount = this.callbacks[event]?.length || 0
    console.log(`📤 Emitting ${event} to ${callbackCount} callbacks`)
    if (this.callbacks[event]) {
      this.callbacks[event].forEach(callback => callback(data))
    }
  }

  // Helper to ensure connection before invoking
  async invokeWithRetry(method, ...args) {
    // Wait for connection if in progress
    if (this.connectionPromise) {
      await this.connectionPromise
    }

    // Check if connected
    if (!this.isConnected) {
      // Try to reconnect
      const connected = await this.ensureConnected()
      if (!connected) {
        throw new Error('SignalR bağlantısı kurulamadı')
      }
    }

    try {
      return await this.connection.invoke(method, ...args)
    } catch (err) {
      console.error(`❌ SignalR invoke error (${method}):`, err)
      throw err
    }
  }

  // Room methods
  async joinRoom(roomId, username, avatar) {
    return this.invokeWithRetry('JoinRoom', roomId, username, avatar)
  }

  async leaveRoom(roomId, username) {
    return this.invokeWithRetry('LeaveRoom', roomId, username)
  }

  async playerReady(roomId, username, isReady) {
    return this.invokeWithRetry('PlayerReady', roomId, username, isReady)
  }

  async rejoinGame(roomId) {
    return this.invokeWithRetry('RejoinGame', roomId)
  }

  get isConnected() {
    return this.connection?.state === signalR.HubConnectionState.Connected
  }
}

export default new SignalRService()

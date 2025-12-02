<script setup>
import { onMounted, onUnmounted, computed } from 'vue'
import { useRoute } from 'vue-router'
import Header from './components/Header.vue'
import ToastContainer from './components/ToastContainer.vue'
import signalrService from './services/signalrService'
import { useRoomStore } from './stores/room'
import { useGameStore } from './stores/game'
import { useThemeStore } from './stores/theme'
import { useToastStore } from './stores/toast'

const route = useRoute()
const roomStore = useRoomStore()
const gameStore = useGameStore()
const themeStore = useThemeStore()
const toastStore = useToastStore()

// Header'ı login sayfasında gösterme
const showHeader = computed(() => {
  return route.path !== '/login'
})

onMounted(async () => {
  // Connect to SignalR when app loads
  const token = localStorage.getItem('token')
  if (token) {
    await signalrService.connect(token)
    setupSignalRListeners()
  }
})

onUnmounted(async () => {
  await signalrService.disconnect()
})

function setupSignalRListeners() {
  // Room events
  signalrService.on('RoomPlayersInitialized', (data) => {
    console.log('🎯 RoomPlayersInitialized EVENT RECEIVED:', data)
    console.log('🎯 Players in data:', data.players)
    console.log('🎯 Players count:', data.players?.length)

    // Clear existing players and set from backend
    if (data.players && Array.isArray(data.players)) {
      // Clear and repopulate
      roomStore.players.length = 0
      data.players.forEach(player => {
        roomStore.players.push(player)
      })
      console.log('✅ Players set in store:', roomStore.players)
    } else {
      console.error('❌ Invalid players data:', data)
    }
  })

  signalrService.on('PlayerJoined', (data) => {
    console.log('🔔 PlayerJoined EVENT RECEIVED:', data)
    console.log('🔔 Adding player:', data.username, data.avatar)
    roomStore.addPlayer({
      username: data.username,
      avatar: data.avatar,
      isReady: false
    })
    console.log('🔔 Players after add:', roomStore.players)
  })

  signalrService.on('PlayerLeft', (data) => {
    console.log('Player left:', data)
    roomStore.removePlayer(data.username)
  })

  signalrService.on('PlayerReadyStatusChanged', (data) => {
    console.log('Player ready status:', data)
    roomStore.updatePlayerStatus(data.username, data.isReady)
  })

  // Game events
  signalrService.on('GameStarting', (data) => {
    console.log('🎮 Game starting:', data)

    // Set game data in store
    gameStore.gameSessionId = data.gameSessionId
    gameStore.questions = data.questions
    gameStore.gameStatus = 'playing'

    // Navigate to game arena
    import('./router').then(({ default: router }) => {
      router.push(`/game/${data.gameSessionId}`)
    })
  })

  signalrService.on('QuestionReceived', (data) => {
    console.log('Question received:', data)
    gameStore.receiveQuestion(data)
  })

  signalrService.on('ScoreboardUpdated', (data) => {
    console.log('Scoreboard updated:', data)
    gameStore.updateScoreboard(data.scores)
  })

  signalrService.on('GameFinished', (data) => {
    console.log('Game finished:', data)
  })
}
</script>

<template>
  <div id="app">
    <Header v-if="showHeader" />
    <div class="app-content">
      <router-view />
    </div>
    <ToastContainer />
  </div>
</template>

<style>
/* ══════════════════════════════════════════════════════════════════════════════
   🍄 TIROKSIN - MARIO-STYLE GAMING UI THEME
   Super Mario Bros inspired - Fun, Colorful, Retro Gaming
   ══════════════════════════════════════════════════════════════════════════════ */

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

/* ═══════════════════════ DARK THEME (Default) ═══════════════════════ */
:root,
[data-theme="dark"] {
  /* 🍄 Mario Color Palette */
  --primary: #e52521;
  --primary-hover: #ff3d3d;
  --primary-soft: rgba(229, 37, 33, 0.2);
  --primary-glow: rgba(229, 37, 33, 0.5);

  /* 🎯 Mario-style Option Colors */
  --option-red: #e52521;
  --option-red-hover: #ff3d3d;
  --option-blue: #049cd8;
  --option-blue-hover: #1ab4f0;
  --option-yellow: #fbd000;
  --option-yellow-hover: #ffe033;
  --option-green: #43b047;
  --option-green-hover: #5fd462;

  /* 🍄 Mario Special Colors */
  --mario-red: #e52521;
  --mario-blue: #049cd8;
  --mario-yellow: #fbd000;
  --mario-green: #43b047;
  --mario-orange: #f5821f;
  --mario-pink: #f472b6;
  --mario-brown: #8b4513;
  --question-block: #fbbf24;
  --question-block-shadow: #d97706;
  --coin-gold: #fcd34d;

  /* ⚡ Accent Colors */
  --accent: #049cd8;
  --accent-soft: rgba(4, 156, 216, 0.2);
  --gold: #fbd000;
  --silver: #9ca3af;
  --bronze: #d97706;

  /* ✅ Semantic Colors */
  --success: #22c55e;
  --success-soft: rgba(34, 197, 94, 0.2);
  --error: #ef4444;
  --error-soft: rgba(239, 68, 68, 0.2);
  --warning: #f59e0b;
  --warning-soft: rgba(245, 158, 11, 0.2);

  /* 🌙 Dark Backgrounds - Mario Tunnel Style */
  --bg-main: #000020;
  --bg-elevated: #0a0a30;
  --bg-card: #101040;
  --bg-card-hover: #181850;
  --bg-input: #0a0a30;
  --bg-header: rgba(0, 0, 32, 0.95);

  /* ✏️ Text Colors */
  --text: #ffffff;
  --text-secondary: #b4b4c7;
  --text-muted: #6b6b80;

  /* 🔲 Borders - Mario Tunnel Style */
  --border: #1a1a50;
  --border-light: #2a2a60;
  --border-glow: rgba(4, 156, 216, 0.4);

  /* 💫 Effects */
  --shadow-sm: 0 2px 4px rgba(0, 0, 0, 0.3);
  --shadow-md: 0 4px 16px rgba(0, 0, 0, 0.4);
  --shadow-lg: 0 8px 32px rgba(0, 0, 0, 0.5);
  --shadow-glow: 0 0 30px var(--primary-glow);
  --shadow-option: 0 6px 0 rgba(0, 0, 0, 0.3);

  /* 📐 Radius */
  --radius-sm: 8px;
  --radius-md: 12px;
  --radius-lg: 16px;
  --radius-xl: 24px;
  --radius-full: 9999px;

  /* 🔤 Typography */
  --font-primary: 'JetBrains Mono', 'Fira Code', monospace;

  /* 🎬 Gradients */
  --gradient-primary: linear-gradient(135deg, #e52521 0%, #ff5252 100%);
  --gradient-card: linear-gradient(180deg, rgba(255,255,255,0.05) 0%, transparent 100%);
  --gradient-success: linear-gradient(135deg, #43b047 0%, #2d8a31 100%);
  --gradient-error: linear-gradient(135deg, #e52521 0%, #c91f1c 100%);
  --gradient-gold: linear-gradient(135deg, #fbd000 0%, #f5821f 100%);
  --gradient-mario-sky: linear-gradient(180deg, #5c94fc 0%, #049cd8 100%);
  --gradient-mario-ground: linear-gradient(180deg, #e4a672 0%, #8b4513 100%);
}

/* ═══════════════════════ LIGHT THEME ═══════════════════════ */
[data-theme="light"] {
  /* 🍄 Mario Color Palette - Light */
  --primary: #e52521;
  --primary-hover: #c91f1c;
  --primary-soft: rgba(229, 37, 33, 0.12);
  --primary-glow: rgba(229, 37, 33, 0.3);

  /* 🎯 Mario-style Option Colors */
  --option-red: #e52521;
  --option-red-hover: #c91f1c;
  --option-blue: #049cd8;
  --option-blue-hover: #0380b0;
  --option-yellow: #fbd000;
  --option-yellow-hover: #d9b300;
  --option-green: #43b047;
  --option-green-hover: #38903c;

  /* 🍄 Mario Special Colors */
  --mario-red: #e52521;
  --mario-blue: #049cd8;
  --mario-yellow: #fbd000;
  --mario-green: #43b047;
  --mario-orange: #f5821f;
  --mario-pink: #f472b6;
  --mario-brown: #8b4513;
  --question-block: #fbbf24;
  --question-block-shadow: #d97706;
  --coin-gold: #fcd34d;

  /* ⚡ Accent Colors */
  --accent: #049cd8;
  --accent-soft: rgba(4, 156, 216, 0.12);
  --gold: #fbd000;
  --silver: #6b7280;
  --bronze: #b45309;

  /* ✅ Semantic Colors */
  --success: #16a34a;
  --success-soft: rgba(22, 163, 74, 0.12);
  --error: #dc2626;
  --error-soft: rgba(220, 38, 38, 0.12);
  --warning: #d97706;
  --warning-soft: rgba(217, 119, 6, 0.12);

  /* ☀️ Light Backgrounds */
  --bg-main: #f0f0f8;
  --bg-elevated: #ffffff;
  --bg-card: #ffffff;
  --bg-card-hover: #f8f7ff;
  --bg-input: #f5f5fa;
  --bg-header: rgba(255, 255, 255, 0.95);

  /* ✏️ Text Colors */
  --text: #1a1a2e;
  --text-secondary: #4b5563;
  --text-muted: #9ca3af;

  /* 🔲 Borders */
  --border: #e5e5ef;
  --border-light: #d1d5db;
  --border-glow: rgba(124, 58, 237, 0.3);

  /* 💫 Effects */
  --shadow-sm: 0 1px 3px rgba(0, 0, 0, 0.08);
  --shadow-md: 0 4px 12px rgba(0, 0, 0, 0.1);
  --shadow-lg: 0 8px 24px rgba(0, 0, 0, 0.12);
  --shadow-glow: 0 0 20px var(--primary-glow);
  --shadow-option: 0 6px 0 rgba(0, 0, 0, 0.15);

  /* 🎬 Gradients */
  --gradient-primary: linear-gradient(135deg, #e52521 0%, #ff5252 100%);
  --gradient-card: linear-gradient(180deg, rgba(255,255,255,1) 0%, rgba(250,250,255,1) 100%);
}

/* ═══════════════════════ BASE STYLES ═══════════════════════ */
body {
  font-family: var(--font-primary);
  background: var(--bg-main);
  min-height: 100vh;
  color: var(--text);
  transition: background 0.3s ease, color 0.3s ease;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

/* Global input/button/select font */
input, button, select, textarea {
  font-family: var(--font-primary);
}

#app {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.app-content {
  flex: 1;
  padding: 24px 20px;
  max-width: 1000px;
  margin: 0 auto;
  width: 100%;
}

/* ═══════════════════════ 🎴 CARD COMPONENT ═══════════════════════ */
.card {
  background: var(--bg-card);
  background-image: var(--gradient-card);
  border-radius: var(--radius-lg);
  padding: 24px;
  border: 1px solid var(--border);
  box-shadow: var(--shadow-md);
  transition: all 0.25s cubic-bezier(0.4, 0, 0.2, 1);
}

.card:hover {
  border-color: var(--border-light);
  transform: translateY(-2px);
  box-shadow: var(--shadow-lg);
}

.card-glow {
  border-color: var(--border-glow);
  box-shadow: var(--shadow-glow);
}

/* ═══════════════════════ 🔘 BUTTON COMPONENTS ═══════════════════════ */

/* Primary Button - Mario Style */
.btn-primary {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  padding: 14px 28px;
  font-size: 1rem;
  font-weight: 700;
  letter-spacing: 0.5px;
  border: none;
  border-radius: var(--radius-md);
  cursor: pointer;
  background: var(--gradient-primary);
  color: white;
  text-transform: uppercase;
  box-shadow: 0 4px 0 #a31b18, var(--shadow-md);
  transition: all 0.15s ease;
  position: relative;
  overflow: hidden;
}

.btn-primary::before {
  content: '';
  position: absolute;
  top: 0;
  left: -100%;
  width: 100%;
  height: 100%;
  background: linear-gradient(90deg, transparent, rgba(255,255,255,0.2), transparent);
  transition: left 0.5s ease;
}

.btn-primary:hover:not(:disabled)::before {
  left: 100%;
}

.btn-primary:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #a31b18, var(--shadow-lg);
}

.btn-primary:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 2px 0 #a31b18, var(--shadow-sm);
}

.btn-primary:disabled {
  opacity: 0.5;
  cursor: not-allowed;
  transform: none;
}

/* Secondary Button */
.btn-secondary {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  padding: 14px 28px;
  font-size: 1rem;
  font-weight: 600;
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  cursor: pointer;
  background: var(--bg-elevated);
  color: var(--text);
  transition: all 0.2s ease;
}

.btn-secondary:hover:not(:disabled) {
  background: var(--bg-card-hover);
  border-color: var(--primary);
  color: var(--primary);
  transform: translateY(-2px);
}

/* Ghost Button */
.btn-ghost {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  padding: 14px 28px;
  font-size: 1rem;
  font-weight: 600;
  border: none;
  border-radius: var(--radius-md);
  cursor: pointer;
  background: transparent;
  color: var(--text-secondary);
  transition: all 0.2s ease;
}

.btn-ghost:hover:not(:disabled) {
  background: var(--primary-soft);
  color: var(--primary);
}

/* Success Button */
.btn-success {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  padding: 14px 28px;
  font-size: 1rem;
  font-weight: 700;
  letter-spacing: 0.5px;
  border: none;
  border-radius: var(--radius-md);
  cursor: pointer;
  background: var(--gradient-success);
  color: white;
  text-transform: uppercase;
  box-shadow: 0 4px 0 rgba(21, 128, 61, 0.8), var(--shadow-md);
  transition: all 0.15s ease;
}

.btn-success:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 rgba(21, 128, 61, 0.8), var(--shadow-lg);
}

.btn-success:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 2px 0 rgba(21, 128, 61, 0.8);
}

/* Danger Button */
.btn-danger {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  padding: 14px 28px;
  font-size: 1rem;
  font-weight: 700;
  letter-spacing: 0.5px;
  border: none;
  border-radius: var(--radius-md);
  cursor: pointer;
  background: var(--gradient-error);
  color: white;
  text-transform: uppercase;
  box-shadow: 0 4px 0 rgba(185, 28, 28, 0.8), var(--shadow-md);
  transition: all 0.15s ease;
}

.btn-danger:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 rgba(185, 28, 28, 0.8), var(--shadow-lg);
}

/* ═══════════════════════ 🎯 KAHOOT OPTION BUTTONS ═══════════════════════ */
.option-btn {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 12px;
  width: 100%;
  min-height: 80px;
  padding: 20px 24px;
  font-size: 1.1rem;
  font-weight: 700;
  border: none;
  border-radius: var(--radius-lg);
  cursor: pointer;
  color: white;
  text-shadow: 0 2px 4px rgba(0,0,0,0.3);
  transition: all 0.15s cubic-bezier(0.4, 0, 0.2, 1);
  position: relative;
  overflow: hidden;
}

.option-btn::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  height: 50%;
  background: linear-gradient(180deg, rgba(255,255,255,0.15) 0%, transparent 100%);
  pointer-events: none;
}

.option-btn:hover:not(:disabled) {
  transform: translateY(-4px) scale(1.02);
}

.option-btn:active:not(:disabled) {
  transform: translateY(2px) scale(0.98);
}

.option-btn:disabled {
  opacity: 0.6;
  cursor: not-allowed;
  transform: none;
}

/* Option Color Variants */
.option-red {
  background: var(--option-red);
  box-shadow: 0 6px 0 #a31529, var(--shadow-md);
}
.option-red:hover:not(:disabled) {
  background: var(--option-red-hover);
  box-shadow: 0 8px 0 #a31529, var(--shadow-lg);
}
.option-red:active:not(:disabled) {
  box-shadow: 0 2px 0 #a31529;
}

.option-blue {
  background: var(--option-blue);
  box-shadow: 0 6px 0 #0d4a94, var(--shadow-md);
}
.option-blue:hover:not(:disabled) {
  background: var(--option-blue-hover);
  box-shadow: 0 8px 0 #0d4a94, var(--shadow-lg);
}
.option-blue:active:not(:disabled) {
  box-shadow: 0 2px 0 #0d4a94;
}

.option-yellow {
  background: var(--option-yellow);
  box-shadow: 0 6px 0 #9a7100, var(--shadow-md);
}
.option-yellow:hover:not(:disabled) {
  background: var(--option-yellow-hover);
  box-shadow: 0 8px 0 #9a7100, var(--shadow-lg);
}
.option-yellow:active:not(:disabled) {
  box-shadow: 0 2px 0 #9a7100;
}

.option-green {
  background: var(--option-green);
  box-shadow: 0 6px 0 #1a6008, var(--shadow-md);
}
.option-green:hover:not(:disabled) {
  background: var(--option-green-hover);
  box-shadow: 0 8px 0 #1a6008, var(--shadow-lg);
}
.option-green:active:not(:disabled) {
  box-shadow: 0 2px 0 #1a6008;
}

/* Option Selected State */
.option-btn.selected {
  transform: scale(0.98);
  box-shadow: 0 2px 0 rgba(0,0,0,0.3), inset 0 0 0 4px rgba(255,255,255,0.5);
}

/* Option Correct/Wrong States */
.option-btn.correct {
  background: var(--success) !important;
  box-shadow: 0 0 30px var(--success), 0 4px 0 rgba(21,128,61,0.8);
  animation: correctPulse 0.5s ease;
}

.option-btn.wrong {
  background: var(--error) !important;
  box-shadow: 0 0 30px var(--error), 0 4px 0 rgba(185,28,28,0.8);
  animation: wrongShake 0.5s ease;
}

/* ═══════════════════════ 📝 INPUT COMPONENTS ═══════════════════════ */
input, select, textarea {
  width: 100%;
  padding: 14px 18px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  font-size: 1rem;
  font-family: inherit;
  color: var(--text);
  transition: all 0.2s ease;
}

input::placeholder,
textarea::placeholder {
  color: var(--text-muted);
}

input:focus,
select:focus,
textarea:focus {
  outline: none;
  border-color: var(--primary);
  box-shadow: 0 0 0 4px var(--primary-soft), var(--shadow-sm);
}

input:hover:not(:focus),
select:hover:not(:focus),
textarea:hover:not(:focus) {
  border-color: var(--border-light);
}

/* ═══════════════════════ 🪟 MODAL COMPONENT ═══════════════════════ */
.modal-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.75);
  backdrop-filter: blur(8px);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 2000;
  animation: fadeIn 0.2s ease;
  padding: 20px;
}

.modal {
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-xl);
  max-width: 440px;
  width: 100%;
  max-height: 90vh;
  overflow-y: auto;
  box-shadow: var(--shadow-lg), 0 0 60px rgba(124, 58, 237, 0.2);
  animation: modalSlideUp 0.3s cubic-bezier(0.34, 1.56, 0.64, 1);
}

.modal-header {
  padding: 20px 24px;
  border-bottom: 1px solid var(--border);
  display: flex;
  align-items: center;
  gap: 12px;
}

.modal-header h2 {
  margin: 0;
  flex: 1;
  font-size: 1.2rem;
  font-weight: 700;
  color: var(--text);
}

.modal-body {
  padding: 24px;
}

.modal-footer {
  padding: 16px 24px;
  border-top: 1px solid var(--border);
  display: flex;
  justify-content: flex-end;
  gap: 12px;
}

/* ═══════════════════════ 🏷️ BADGE COMPONENT ═══════════════════════ */
.badge {
  display: inline-flex;
  align-items: center;
  gap: 6px;
  padding: 6px 14px;
  font-size: 0.8rem;
  font-weight: 700;
  border-radius: var(--radius-full);
  background: var(--primary-soft);
  color: var(--primary);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.badge-success {
  background: var(--success-soft);
  color: var(--success);
}

.badge-error {
  background: var(--error-soft);
  color: var(--error);
}

.badge-warning {
  background: var(--warning-soft);
  color: var(--warning);
}

.badge-gold {
  background: linear-gradient(135deg, #fef3c7 0%, #fde68a 100%);
  color: #92400e;
}

/* ═══════════════════════ ⏱️ TIMER COMPONENT ═══════════════════════ */
.timer-circle {
  position: relative;
  width: 80px;
  height: 80px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.timer-circle svg {
  position: absolute;
  width: 100%;
  height: 100%;
  transform: rotate(-90deg);
}

.timer-circle .timer-bg {
  fill: none;
  stroke: var(--border);
  stroke-width: 6;
}

.timer-circle .timer-progress {
  fill: none;
  stroke: var(--primary);
  stroke-width: 6;
  stroke-linecap: round;
  transition: stroke-dashoffset 1s linear, stroke 0.3s ease;
}

.timer-circle.warning .timer-progress {
  stroke: var(--warning);
}

.timer-circle.danger .timer-progress {
  stroke: var(--error);
  animation: timerPulse 0.5s ease infinite;
}

.timer-text {
  font-size: 1.5rem;
  font-weight: 800;
  color: var(--text);
}

/* ═══════════════════════ 🏆 LEADERBOARD COMPONENT ═══════════════════════ */
.leaderboard-item {
  display: flex;
  align-items: center;
  gap: 16px;
  padding: 16px;
  background: var(--bg-input);
  border-radius: var(--radius-md);
  transition: all 0.2s ease;
}

.leaderboard-item:hover {
  background: var(--bg-card-hover);
  transform: translateX(4px);
}

.leaderboard-item.rank-1 {
  background: linear-gradient(135deg, rgba(251, 191, 36, 0.2) 0%, rgba(245, 158, 11, 0.1) 100%);
  border: 2px solid var(--gold);
}

.leaderboard-item.rank-2 {
  background: linear-gradient(135deg, rgba(156, 163, 175, 0.2) 0%, rgba(107, 114, 128, 0.1) 100%);
  border: 2px solid var(--silver);
}

.leaderboard-item.rank-3 {
  background: linear-gradient(135deg, rgba(217, 119, 6, 0.2) 0%, rgba(180, 83, 9, 0.1) 100%);
  border: 2px solid var(--bronze);
}

.rank-badge {
  width: 36px;
  height: 36px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1rem;
  font-weight: 800;
  border-radius: var(--radius-sm);
  background: var(--bg-card);
  color: var(--text-muted);
}

.rank-1 .rank-badge {
  background: var(--gradient-gold);
  color: #78350f;
}

.rank-2 .rank-badge {
  background: linear-gradient(135deg, #e5e7eb 0%, #9ca3af 100%);
  color: #374151;
}

.rank-3 .rank-badge {
  background: linear-gradient(135deg, #fcd34d 0%, #d97706 100%);
  color: #78350f;
}

/* ═══════════════════════ 👤 AVATAR COMPONENT ═══════════════════════ */
.avatar {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 48px;
  height: 48px;
  font-size: 1.5rem;
  background: var(--primary-soft);
  border-radius: var(--radius-full);
  border: 3px solid var(--border);
  transition: all 0.2s ease;
}

.avatar-sm {
  width: 36px;
  height: 36px;
  font-size: 1.1rem;
  border-width: 2px;
}

.avatar-lg {
  width: 64px;
  height: 64px;
  font-size: 2rem;
  border-width: 4px;
}

.avatar.eliminated {
  filter: grayscale(1);
  opacity: 0.5;
}

.avatar.active {
  border-color: var(--success);
  box-shadow: 0 0 15px var(--success-soft);
}

/* ═══════════════════════ 📊 PROGRESS BAR ═══════════════════════ */
.progress-bar {
  width: 100%;
  height: 8px;
  background: var(--bg-input);
  border-radius: var(--radius-full);
  overflow: hidden;
}

.progress-bar-fill {
  height: 100%;
  background: var(--gradient-primary);
  border-radius: var(--radius-full);
  transition: width 0.3s ease;
}

.progress-bar-fill.success {
  background: var(--gradient-success);
}

.progress-bar-fill.warning {
  background: linear-gradient(135deg, var(--warning) 0%, #ea580c 100%);
}

.progress-bar-fill.error {
  background: var(--gradient-error);
}

/* ═══════════════════════ 🔔 FORM COMPONENTS ═══════════════════════ */
.form-group {
  margin-bottom: 20px;
}

.form-group label {
  display: block;
  margin-bottom: 8px;
  font-size: 0.9rem;
  font-weight: 600;
  color: var(--text-secondary);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.form-group .hint {
  display: block;
  margin-top: 6px;
  font-size: 0.8rem;
  color: var(--text-muted);
}

.error-message {
  padding: 12px 16px;
  background: var(--error-soft);
  border: 1px solid var(--error);
  border-radius: var(--radius-md);
  color: var(--error);
  font-size: 0.9rem;
  font-weight: 500;
  margin-top: 16px;
}

/* ═══════════════════════ 🎪 TOGGLE GROUP ═══════════════════════ */
.toggle-group {
  display: flex;
  gap: 8px;
}

.toggle-btn {
  flex: 1;
  padding: 14px 18px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  font-size: 0.95rem;
  font-weight: 600;
  color: var(--text-muted);
  cursor: pointer;
  transition: all 0.2s ease;
}

.toggle-btn:hover {
  background: var(--bg-card-hover);
  color: var(--text);
  border-color: var(--border-light);
}

.toggle-btn.active {
  background: var(--primary);
  border-color: var(--primary);
  color: white;
  box-shadow: 0 4px 0 #a31b18;
}

/* ═══════════════════════ 🌀 LOADING SPINNER ═══════════════════════ */
.spinner {
  width: 40px;
  height: 40px;
  border: 4px solid var(--border);
  border-top-color: var(--primary);
  border-radius: 50%;
  animation: spin 0.8s linear infinite;
}

.spinner-sm {
  width: 20px;
  height: 20px;
  border-width: 2px;
}

.spinner-lg {
  width: 60px;
  height: 60px;
  border-width: 5px;
}

/* ═══════════════════════ 🎬 ANIMATIONS ═══════════════════════ */
@keyframes fadeIn {
  from { opacity: 0; }
  to { opacity: 1; }
}

@keyframes slideUp {
  from {
    transform: translateY(20px);
    opacity: 0;
  }
  to {
    transform: translateY(0);
    opacity: 1;
  }
}

@keyframes modalSlideUp {
  from {
    transform: translateY(30px) scale(0.95);
    opacity: 0;
  }
  to {
    transform: translateY(0) scale(1);
    opacity: 1;
  }
}

@keyframes pulse {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.5; }
}

@keyframes spin {
  to { transform: rotate(360deg); }
}

@keyframes bounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-8px); }
}

@keyframes timerPulse {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.6; }
}

@keyframes correctPulse {
  0% { transform: scale(1); }
  50% { transform: scale(1.05); }
  100% { transform: scale(1); }
}

@keyframes wrongShake {
  0%, 100% { transform: translateX(0); }
  20% { transform: translateX(-10px); }
  40% { transform: translateX(10px); }
  60% { transform: translateX(-10px); }
  80% { transform: translateX(10px); }
}

@keyframes scorePopup {
  0% {
    transform: translateY(0) scale(0);
    opacity: 0;
  }
  50% {
    transform: translateY(-20px) scale(1.2);
    opacity: 1;
  }
  100% {
    transform: translateY(-40px) scale(1);
    opacity: 0;
  }
}

@keyframes confetti {
  0% { transform: translateY(0) rotate(0deg); opacity: 1; }
  100% { transform: translateY(100vh) rotate(720deg); opacity: 0; }
}

@keyframes glow {
  0%, 100% { box-shadow: 0 0 20px var(--primary-glow); }
  50% { box-shadow: 0 0 40px var(--primary-glow), 0 0 60px var(--primary-soft); }
}

/* ═══════════════════════ 📜 SCROLLBAR ═══════════════════════ */
::-webkit-scrollbar {
  width: 10px;
  height: 10px;
}

::-webkit-scrollbar-track {
  background: var(--bg-main);
}

::-webkit-scrollbar-thumb {
  background: var(--border);
  border-radius: 5px;
  border: 2px solid var(--bg-main);
}

::-webkit-scrollbar-thumb:hover {
  background: var(--border-light);
}

/* ═══════════════════════ 🛠️ UTILITIES ═══════════════════════ */
.text-muted { color: var(--text-muted); }
.text-secondary { color: var(--text-secondary); }
.text-success { color: var(--success); }
.text-error { color: var(--error); }
.text-warning { color: var(--warning); }
.text-primary { color: var(--primary); }
.text-gold { color: var(--gold); }

.font-mono { font-family: var(--font-primary); }
.font-bold { font-weight: 700; }
.font-black { font-weight: 900; }

.text-center { text-align: center; }
.text-uppercase { text-transform: uppercase; letter-spacing: 1px; }

.flex { display: flex; }
.flex-col { flex-direction: column; }
.items-center { align-items: center; }
.justify-center { justify-content: center; }
.justify-between { justify-content: space-between; }
.gap-sm { gap: 8px; }
.gap-md { gap: 16px; }
.gap-lg { gap: 24px; }

.w-full { width: 100%; }
.h-full { height: 100%; }

.animate-pulse { animation: pulse 2s ease-in-out infinite; }
.animate-bounce { animation: bounce 1s ease-in-out infinite; }
.animate-glow { animation: glow 2s ease-in-out infinite; }
.animate-spin { animation: spin 1s linear infinite; }

/* ═══════════════════════ 📱 RESPONSIVE ═══════════════════════ */
@media (max-width: 640px) {
  .app-content {
    padding: 16px 12px;
  }

  .card {
    padding: 18px;
    border-radius: var(--radius-md);
  }

  .btn-primary,
  .btn-secondary,
  .btn-success,
  .btn-danger {
    padding: 12px 20px;
    font-size: 0.9rem;
  }

  .option-btn {
    min-height: 70px;
    padding: 16px 20px;
    font-size: 1rem;
  }

  .modal {
    margin: 16px;
    border-radius: var(--radius-lg);
  }

  .modal-header,
  .modal-body,
  .modal-footer {
    padding: 16px 20px;
  }
}

/* ══════════════════════════════════════════════════════════════════════════════
   🍄 MARIO-STYLE COMPONENTS
   ══════════════════════════════════════════════════════════════════════════════ */

/* Question Block (?) */
.mario-block {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
  background: var(--question-block);
  border-radius: 6px;
  font-size: 1.2rem;
  font-weight: 900;
  color: #92400e;
  box-shadow: 0 3px 0 var(--question-block-shadow);
  animation: marioBlockBounce 2s ease-in-out infinite;
}

.mario-block-sm {
  width: 28px;
  height: 28px;
  font-size: 0.85rem;
  box-shadow: 0 2px 0 var(--question-block-shadow);
}

.mario-block-lg {
  width: 56px;
  height: 56px;
  font-size: 1.8rem;
  box-shadow: 0 4px 0 var(--question-block-shadow);
}

.mario-block.pink {
  background: var(--mario-pink);
  box-shadow: 0 3px 0 #db2777;
  color: white;
}

/* Coin */
.mario-coin {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 32px;
  height: 32px;
  background: var(--coin-gold);
  border-radius: 50%;
  font-size: 1rem;
  box-shadow: 0 2px 0 #d97706, inset 0 -3px 0 rgba(0,0,0,0.15);
  animation: coinSpin 2s linear infinite;
}

/* Star */
.mario-star {
  display: inline-block;
  font-size: 1.5rem;
  animation: starPulse 1s ease-in-out infinite;
}

/* Pipe (decorative) */
.mario-pipe {
  width: 60px;
  height: 80px;
  background: linear-gradient(90deg, #1a8f1a 0%, #43b047 30%, #43b047 70%, #1a8f1a 100%);
  border-radius: 8px 8px 0 0;
  position: relative;
}

.mario-pipe::before {
  content: '';
  position: absolute;
  top: 0;
  left: -8px;
  right: -8px;
  height: 24px;
  background: linear-gradient(90deg, #1a8f1a 0%, #43b047 30%, #43b047 70%, #1a8f1a 100%);
  border-radius: 8px;
}

/* Mario Button Styles */
.btn-mario-red {
  background: var(--mario-red);
  box-shadow: 0 4px 0 #a31b18;
}

.btn-mario-red:hover { box-shadow: 0 6px 0 #a31b18; }
.btn-mario-red:active { box-shadow: 0 2px 0 #a31b18; }

.btn-mario-green {
  background: var(--mario-green);
  box-shadow: 0 4px 0 #2d8a31;
}

.btn-mario-green:hover { box-shadow: 0 6px 0 #2d8a31; }
.btn-mario-green:active { box-shadow: 0 2px 0 #2d8a31; }

.btn-mario-blue {
  background: var(--mario-blue);
  box-shadow: 0 4px 0 #0378a6;
}

.btn-mario-blue:hover { box-shadow: 0 6px 0 #0378a6; }
.btn-mario-blue:active { box-shadow: 0 2px 0 #0378a6; }

.btn-mario-yellow {
  background: var(--mario-yellow);
  color: #92400e;
  box-shadow: 0 4px 0 #d9b300;
}

.btn-mario-yellow:hover { box-shadow: 0 6px 0 #d9b300; }
.btn-mario-yellow:active { box-shadow: 0 2px 0 #d9b300; }

/* ═══════════════════════ 🍄 MARIO ANIMATIONS ═══════════════════════ */

@keyframes marioBlockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-4px); }
}

@keyframes marioBlockHit {
  0% { transform: translateY(0); }
  25% { transform: translateY(-12px); }
  50% { transform: translateY(0); }
  100% { transform: translateY(0); }
}

@keyframes coinCollect {
  0% {
    transform: translateY(0) scale(1);
    opacity: 1;
  }
  50% {
    transform: translateY(-30px) scale(1.2);
    opacity: 1;
  }
  100% {
    transform: translateY(-50px) scale(0.8);
    opacity: 0;
  }
}

@keyframes coinSpin {
  0% { transform: rotateY(0deg); }
  100% { transform: rotateY(360deg); }
}

@keyframes starPulse {
  0%, 100% {
    transform: scale(1) rotate(0deg);
    filter: brightness(1);
  }
  50% {
    transform: scale(1.1) rotate(5deg);
    filter: brightness(1.2);
  }
}

@keyframes starCollect {
  0% {
    transform: scale(1) rotate(0deg);
    opacity: 1;
  }
  100% {
    transform: scale(2) rotate(360deg);
    opacity: 0;
  }
}

@keyframes marioJump {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-20px); }
}

@keyframes powerUp {
  0% {
    transform: scale(0);
    opacity: 0;
  }
  50% {
    transform: scale(1.3);
    opacity: 1;
  }
  100% {
    transform: scale(1);
    opacity: 1;
  }
}

@keyframes fireball {
  0% { transform: translateX(0) rotate(0deg); }
  100% { transform: translateX(100px) rotate(720deg); }
}

/* Utility animation classes */
.animate-block-bounce { animation: marioBlockBounce 2s ease-in-out infinite; }
.animate-block-hit { animation: marioBlockHit 0.4s ease; }
.animate-coin-collect { animation: coinCollect 0.6s ease forwards; }
.animate-coin-spin { animation: coinSpin 2s linear infinite; }
.animate-star-pulse { animation: starPulse 1s ease-in-out infinite; }
.animate-star-collect { animation: starCollect 0.5s ease forwards; }
.animate-mario-jump { animation: marioJump 0.5s ease; }
.animate-power-up { animation: powerUp 0.4s ease; }

/* ═══════════════════════ 🍄 MARIO COLORS UTILITY ═══════════════════════ */
.text-mario-red { color: var(--mario-red); }
.text-mario-blue { color: var(--mario-blue); }
.text-mario-yellow { color: var(--mario-yellow); }
.text-mario-green { color: var(--mario-green); }
.text-mario-orange { color: var(--mario-orange); }
.text-mario-pink { color: var(--mario-pink); }

.bg-mario-red { background: var(--mario-red); }
.bg-mario-blue { background: var(--mario-blue); }
.bg-mario-yellow { background: var(--mario-yellow); }
.bg-mario-green { background: var(--mario-green); }
.bg-mario-orange { background: var(--mario-orange); }
.bg-mario-pink { background: var(--mario-pink); }
</style>

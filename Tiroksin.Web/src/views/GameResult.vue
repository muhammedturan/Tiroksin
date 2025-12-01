<template>
  <div v-if="loading" class="loading">
    Yükleniyor...
  </div>
  <div v-else class="survival-result-page">
    <!-- Confetti celebration -->
    <div class="confetti-container" v-if="showConfetti">
      <div class="confetti" v-for="n in 50" :key="n"></div>
    </div>

    <!-- Winner Banner -->
    <div class="winner-banner" v-if="isWinner">
      <div class="trophy-icon">🏆</div>
      <div class="winner-text">KAZANDIN!</div>
      <div class="winner-subtext">Tebrikler! Eleme turlarını geçtin!</div>
    </div>

    <!-- Results Header -->
    <div class="results-header">
      <h1>🏁 Oyun Sonuçları</h1>
      <p class="game-mode-badge">Eleme Modu</p>
    </div>

    <!-- Final Standings -->
    <div class="final-standings">
      <h2>📊 Final Sıralaması</h2>
      <div class="standings-list">
        <div
          v-for="result in sortedResults"
          :key="result.userId"
          class="standing-item"
          :class="{
            winner: result.isWinner,
            me: isMe(result.userId),
            eliminated: result.rank === 999
          }"
        >
          <div class="standing-rank">
            <span v-if="result.isWinner" class="trophy">🏆</span>
            <span v-else-if="result.rank === 999" class="skull">💀</span>
            <span v-else class="rank-number">{{ result.rank }}</span>
          </div>
          <div class="standing-avatar">{{ result.avatar || '👤' }}</div>
          <div class="standing-info">
            <div class="standing-name">
              {{ result.username }}
              <span v-if="isMe(result.userId)" class="you-badge">SEN</span>
            </div>
            <div class="standing-stats">
              <span class="stat correct">✅ {{ result.correctAnswers }}</span>
              <span class="stat wrong">❌ {{ result.wrongAnswers }}</span>
              <span class="stat score">💯 {{ result.score }} puan</span>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Actions -->
    <div class="result-actions">
      <button @click="handleClose" class="btn-primary">
        🏠 Ana Sayfaya Dön
      </button>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { useGameStore } from '../stores/game'
import api from '../services/api'

const router = useRouter()
const route = useRoute()
const gameStore = useGameStore()

const loading = ref(true)
const showConfetti = ref(false)
const userId = localStorage.getItem('userId')

const results = ref([])

const myResult = computed(() => {
  return results.value.find(r => r.userId === userId)
})

const isWinner = computed(() => {
  return myResult.value?.isWinner || false
})

const sortedResults = computed(() => {
  return [...results.value].sort((a, b) => {
    // Eliminated players go to bottom
    if (a.rank === 999 && b.rank !== 999) return 1
    if (a.rank !== 999 && b.rank === 999) return -1
    // Sort by rank
    if (a.rank !== b.rank) return a.rank - b.rank
    // If same rank, sort by score
    return b.score - a.score
  })
})

onMounted(async () => {
  const sessionId = route.params.sessionId

  // Replace current history entry to prevent going back to game
  window.history.replaceState({}, '', `/game-result/${sessionId}`)

  // Push home to history so back button goes to home
  window.history.pushState({}, '', `/game-result/${sessionId}`)
  window.addEventListener('popstate', handleBackButton)

  // Check if data exists in store
  if (gameStore.results?.length > 0) {
    console.log('📦 Loading results from store')
    results.value = gameStore.results
    loading.value = false
  } else {
    // Fetch from backend
    console.log('🌐 Fetching game results from backend for session:', sessionId)
    try {
      const response = await api.get(`/game/${sessionId}`)
      const gameData = response.data

      results.value = gameData.results || []
      gameStore.results = results.value
      gameStore.gameSessionId = sessionId

      loading.value = false
      console.log('✅ Game results loaded successfully')
    } catch (error) {
      console.error('❌ Error fetching game results:', error)
      loading.value = false
    }
  }

  // Show confetti if winner
  if (isWinner.value) {
    showConfetti.value = true
    setTimeout(() => {
      showConfetti.value = false
    }, 5000)
  }
})

function handleBackButton() {
  window.removeEventListener('popstate', handleBackButton)
  router.push('/')
}

function handleClose() {
  router.push('/')
}

function isMe(playerId) {
  return playerId === userId
}
</script>

<style scoped>
.loading {
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
  font-size: 1rem;
  color: var(--text-muted);
}

.survival-result-page {
  max-width: 550px;
  margin: 0 auto;
  min-height: calc(100vh - 100px);
}

.confetti-container {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  pointer-events: none;
  z-index: 1000;
  overflow: hidden;
}

.confetti {
  position: absolute;
  width: 10px;
  height: 10px;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  top: -10px;
  animation: confetti-fall 3s linear forwards;
  opacity: 0;
}

.confetti:nth-child(odd) { background: var(--error); }
.confetti:nth-child(3n) { background: var(--success); }
.confetti:nth-child(5n) { background: var(--warning); }

@keyframes confetti-fall {
  0% {
    top: -10px;
    opacity: 1;
  }
  100% {
    top: 100vh;
    opacity: 0;
    transform: translateX(100px) rotate(720deg);
  }
}

.confetti:nth-child(1) { left: 5%; animation-delay: 0s; }
.confetti:nth-child(2) { left: 10%; animation-delay: 0.1s; }
.confetti:nth-child(3) { left: 15%; animation-delay: 0.2s; }
.confetti:nth-child(4) { left: 20%; animation-delay: 0.3s; }
.confetti:nth-child(5) { left: 25%; animation-delay: 0.4s; }
.confetti:nth-child(6) { left: 30%; animation-delay: 0.5s; }
.confetti:nth-child(7) { left: 35%; animation-delay: 0.6s; }
.confetti:nth-child(8) { left: 40%; animation-delay: 0.7s; }
.confetti:nth-child(9) { left: 45%; animation-delay: 0.8s; }
.confetti:nth-child(10) { left: 50%; animation-delay: 0.9s; }

.winner-banner {
  background: linear-gradient(135deg, var(--warning) 0%, #d97706 100%);
  color: white;
  text-align: center;
  padding: 24px 20px;
  border-radius: 16px;
  margin-bottom: 20px;
  box-shadow: 0 8px 30px rgba(245, 158, 11, 0.3);
  animation: winner-pulse 2s ease-in-out infinite;
}

@keyframes winner-pulse {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.01); }
}

.trophy-icon {
  font-size: 3.5rem;
  margin-bottom: 12px;
  animation: trophy-bounce 1s ease-in-out infinite;
}

@keyframes trophy-bounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-10px); }
}

.winner-text {
  font-size: 1.6rem;
  font-weight: 800;
  text-transform: uppercase;
  letter-spacing: 3px;
  text-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
}

.winner-subtext {
  font-size: 0.9rem;
  margin-top: 8px;
  opacity: 0.95;
}

.results-header {
  text-align: center;
  margin-bottom: 20px;
}

.results-header h1 {
  font-size: 1.5rem;
  font-weight: 700;
  color: var(--text);
  margin-bottom: 10px;
}

.game-mode-badge {
  display: inline-block;
  background: var(--error);
  color: white;
  padding: 6px 16px;
  border-radius: 20px;
  font-weight: 600;
  font-size: 0.8rem;
}

.final-standings {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 20px;
  margin-bottom: 20px;
}

.final-standings h2 {
  font-size: 1.1rem;
  font-weight: 700;
  margin-bottom: 16px;
  color: var(--text);
}

.standings-list {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.standing-item {
  display: grid;
  grid-template-columns: 40px 40px 1fr;
  gap: 12px;
  align-items: center;
  padding: 14px;
  background: var(--bg-card-light);
  border-radius: 12px;
  border: 2px solid transparent;
  transition: all 0.2s;
}

.standing-item.winner {
  background: linear-gradient(135deg, rgba(245, 158, 11, 0.2) 0%, rgba(217, 119, 6, 0.2) 100%);
  border-color: var(--warning);
  box-shadow: 0 4px 16px rgba(245, 158, 11, 0.2);
}

.standing-item.me {
  border-color: var(--primary);
  background: rgba(59, 130, 246, 0.15);
}

.standing-item.eliminated {
  opacity: 0.5;
  background: var(--bg-card-light);
}

.standing-rank {
  font-size: 1.1rem;
  font-weight: 700;
  text-align: center;
}

.trophy {
  font-size: 1.5rem;
}

.skull {
  font-size: 1.3rem;
}

.rank-number {
  color: var(--primary-light);
}

.standing-avatar {
  font-size: 1.5rem;
  text-align: center;
}

.standing-info {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.standing-name {
  font-size: 0.95rem;
  font-weight: 600;
  color: var(--text);
  display: flex;
  align-items: center;
  gap: 8px;
}

.you-badge {
  background: var(--primary);
  color: white;
  padding: 2px 8px;
  border-radius: 6px;
  font-size: 0.65rem;
  font-weight: 600;
}

.standing-stats {
  display: flex;
  gap: 12px;
  flex-wrap: wrap;
}

.stat {
  font-size: 0.8rem;
  font-weight: 500;
}

.stat.correct {
  color: var(--success);
}

.stat.wrong {
  color: var(--error);
}

.stat.score {
  color: var(--primary-light);
}

.result-actions {
  display: flex;
  justify-content: center;
  gap: 12px;
  margin: 24px 0;
}

.btn-primary {
  padding: 14px 32px;
  font-size: 1rem;
  font-weight: 700;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  border: none;
  border-radius: 12px;
  cursor: pointer;
  transition: all 0.2s;
  box-shadow: 0 4px 20px var(--glow-blue);
}

.btn-primary:hover {
  transform: translateY(-2px);
  box-shadow: 0 8px 30px var(--glow-blue);
}

.btn-primary:active {
  transform: scale(0.98);
}

@media (max-width: 768px) {
  .standing-item {
    grid-template-columns: 36px 36px 1fr;
    gap: 10px;
    padding: 12px;
  }

  .results-header h1 {
    font-size: 1.3rem;
  }

  .winner-text {
    font-size: 1.4rem;
  }
}

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

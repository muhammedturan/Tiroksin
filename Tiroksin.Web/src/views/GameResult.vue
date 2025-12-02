<template>
  <div v-if="loading" class="loading">
    <div class="loading-spinner"></div>
    <span>Yükleniyor...</span>
  </div>
  <div v-else class="result-page">
    <!-- Confetti celebration -->
    <div class="confetti-container" v-if="showConfetti">
      <div class="confetti" v-for="n in 50" :key="n"></div>
    </div>

    <!-- Winner Banner -->
    <MarioCard v-if="isWinner" color="yellow" showDeco class="winner-banner">
      <div class="winner-content">
        <div class="trophy-icon">🏆</div>
        <div class="winner-info">
          <div class="winner-text">KAZANDIN!</div>
          <div class="winner-subtext">Tebrikler! Eleme turlarını geçtin!</div>
        </div>
      </div>
    </MarioCard>

    <!-- Results Header -->
    <div class="results-header">
      <h1>🏁 Oyun Sonuçları</h1>
    </div>

    <!-- Final Standings -->
    <div class="final-standings">
      <div class="standings-header">
        <h2>📊 Final Sıralaması</h2>
        <span class="player-count">{{ results.length }} Oyuncu</span>
      </div>
      <div class="standings-list">
        <div
          v-for="(result, index) in sortedResults"
          :key="result.userId"
          class="standing-item"
          :class="{
            winner: result.isWinner,
            me: isMe(result.userId),
            eliminated: result.rank === 999,
            'top-3': result.rank <= 3 && result.rank !== 999
          }"
        >
          <div class="standing-rank">
            <span v-if="result.isWinner" class="trophy">🏆</span>
            <span v-else-if="result.rank === 2" class="medal">🥈</span>
            <span v-else-if="result.rank === 3" class="medal">🥉</span>
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
              <span class="mini-stat correct">✅ {{ result.correctAnswers }}</span>
              <span class="mini-stat wrong">❌ {{ result.wrongAnswers }}</span>
              <span class="mini-stat score">{{ result.score }} puan</span>
            </div>
          </div>
          <div class="standing-score">{{ result.score }}</div>
        </div>
      </div>
    </div>

    <!-- Actions -->
    <div class="result-actions">
      <MarioButton color="green" size="lg" @click="handleClose">
        <template #icon>🏠</template>
        Ana Sayfaya Dön
      </MarioButton>
    </div>

    <!-- Mario-style decorative blocks -->
    <div class="page-deco">
      <div class="deco-block block-1">?</div>
      <div class="deco-block block-2">!</div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { useGameStore } from '../stores/game'
import api from '../services/api'
import { playVictory } from '../services/soundService'
import MarioCard from '../components/MarioCard.vue'
import MarioButton from '../components/MarioButton.vue'

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

  // Show confetti and play victory sound if winner
  if (isWinner.value) {
    showConfetti.value = true
    playVictory() // Mario powerup sound for victory
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
/* ==========================================
   LOADING STATE
   ========================================== */
.loading {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 12px;
  min-height: 60vh;
  font-size: 0.9rem;
  font-weight: 600;
  color: var(--text-muted);
}

.loading-spinner {
  width: 32px;
  height: 32px;
  border: 3px solid var(--border);
  border-top-color: var(--primary);
  border-radius: 50%;
  animation: spin 0.8s linear infinite;
}

@keyframes spin {
  to { transform: rotate(360deg); }
}

/* ==========================================
   PAGE LAYOUT
   ========================================== */
.result-page {
  max-width: 700px;
  margin: 0 auto;
  position: relative;
}

/* ==========================================
   CONFETTI
   ========================================== */
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
  background: var(--primary);
  top: -10px;
  animation: confetti-fall 3s linear forwards;
  opacity: 0;
}

.confetti:nth-child(odd) { background: #ef4444; }
.confetti:nth-child(3n) { background: #10b981; }
.confetti:nth-child(5n) { background: #f59e0b; }
.confetti:nth-child(7n) { background: #8b5cf6; }

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
.confetti:nth-child(11) { left: 55%; animation-delay: 0.15s; }
.confetti:nth-child(12) { left: 60%; animation-delay: 0.25s; }
.confetti:nth-child(13) { left: 65%; animation-delay: 0.35s; }
.confetti:nth-child(14) { left: 70%; animation-delay: 0.45s; }
.confetti:nth-child(15) { left: 75%; animation-delay: 0.55s; }
.confetti:nth-child(16) { left: 80%; animation-delay: 0.65s; }
.confetti:nth-child(17) { left: 85%; animation-delay: 0.75s; }
.confetti:nth-child(18) { left: 90%; animation-delay: 0.85s; }
.confetti:nth-child(19) { left: 95%; animation-delay: 0.95s; }
.confetti:nth-child(20) { left: 8%; animation-delay: 0.05s; }

/* ==========================================
   WINNER BANNER - Uses MarioCard
   ========================================== */
.winner-banner {
  margin-bottom: 16px;
}

.winner-content {
  display: flex;
  align-items: center;
  gap: 16px;
  position: relative;
  z-index: 1;
}

.trophy-icon {
  font-size: 2.5rem;
  animation: trophy-bounce 1s ease-in-out infinite;
}

@keyframes trophy-bounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-6px); }
}

.winner-info {
  flex: 1;
}

.winner-text {
  font-size: 1.3rem;
  font-weight: 800;
  color: #92400e;
  text-transform: uppercase;
  letter-spacing: 2px;
}

.winner-subtext {
  font-size: 0.85rem;
  color: rgba(146, 64, 14, 0.8);
  margin-top: 2px;
  font-weight: 500;
}

.deco-star {
  font-size: 1.2rem;
  animation: starSpin 3s linear infinite;
  opacity: 0.6;
}

.deco-star.star-2 {
  animation-delay: -1.5s;
  font-size: 0.9rem;
}

@keyframes starSpin {
  0% { transform: rotate(0deg) scale(1); }
  50% { transform: rotate(180deg) scale(1.1); }
  100% { transform: rotate(360deg) scale(1); }
}

/* ==========================================
   RESULTS HEADER - Compact
   ========================================== */
.results-header {
  margin-bottom: 16px;
}

.results-header h1 {
  font-size: 1.2rem;
  font-weight: 700;
  color: var(--text);
  margin: 0;
}

/* ==========================================
   FINAL STANDINGS - Compact
   ========================================== */
.final-standings {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: var(--radius-lg);
  padding: 16px;
  margin-bottom: 16px;
}

.standings-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 12px;
}

.standings-header h2 {
  font-size: 1rem;
  font-weight: 700;
  margin: 0;
  color: var(--text);
}

.player-count {
  font-size: 0.75rem;
  font-weight: 600;
  color: var(--text-muted);
  padding: 3px 10px;
  background: var(--bg-input);
  border: 1px solid var(--border);
  border-radius: var(--radius-full);
}

.standings-list {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.standing-item {
  display: grid;
  grid-template-columns: 36px 36px 1fr auto;
  gap: 10px;
  align-items: center;
  padding: 10px 12px;
  background: var(--bg-input);
  border-radius: var(--radius-md);
  border: 2px solid transparent;
  transition: all 0.15s ease;
}

.standing-item:hover {
  background: var(--bg-card-hover);
}

.standing-item.winner {
  background: rgba(245, 158, 11, 0.15);
  border-color: #f59e0b;
}

.standing-item.top-3:not(.winner) {
  background: rgba(139, 92, 246, 0.1);
  border-color: rgba(139, 92, 246, 0.3);
}

.standing-item.me:not(.winner) {
  border-color: var(--primary);
  background: rgba(59, 130, 246, 0.1);
}

.standing-item.eliminated {
  opacity: 0.5;
}

.standing-rank {
  font-size: 1rem;
  font-weight: 700;
  text-align: center;
}

.trophy, .medal {
  font-size: 1.3rem;
}

.skull {
  font-size: 1.1rem;
}

.rank-number {
  color: var(--text-muted);
}

.standing-avatar {
  font-size: 1.3rem;
  text-align: center;
}

.standing-info {
  display: flex;
  flex-direction: column;
  gap: 2px;
  min-width: 0;
}

.standing-name {
  font-size: 0.9rem;
  font-weight: 600;
  color: var(--text);
  display: flex;
  align-items: center;
  gap: 6px;
}

.you-badge {
  background: var(--primary);
  color: white;
  padding: 1px 6px;
  border-radius: 4px;
  font-size: 0.6rem;
  font-weight: 700;
}

.standing-stats {
  display: flex;
  gap: 8px;
}

.mini-stat {
  font-size: 0.7rem;
  font-weight: 500;
  color: var(--text-muted);
}

.mini-stat.correct { color: #10b981; }
.mini-stat.wrong { color: #ef4444; }
.mini-stat.score { color: var(--text-muted); }

.standing-score {
  font-size: 0.85rem;
  font-weight: 700;
  color: white;
  padding: 4px 10px;
  background: #10b981;
  border-radius: var(--radius-sm);
  box-shadow: 0 2px 0 #059669;
}

/* ==========================================
   ACTIONS - Compact Button
   ========================================== */
.result-actions {
  display: flex;
  justify-content: center;
  margin-bottom: 24px;
}


/* ==========================================
   PAGE DECORATIONS - Mario Style
   ========================================== */
.page-deco {
  position: fixed;
  bottom: 20px;
  right: 20px;
  display: flex;
  gap: 8px;
  opacity: 0.4;
  z-index: 0;
}

.deco-block {
  width: 28px;
  height: 28px;
  background: #fbbf24;
  border-radius: 4px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.8rem;
  font-weight: 800;
  color: #92400e;
  box-shadow: 0 2px 0 #d97706;
  animation: blockBounce 2s ease-in-out infinite;
}

.deco-block.block-2 {
  animation-delay: 0.3s;
  background: #f472b6;
  box-shadow: 0 2px 0 #db2777;
  color: white;
}

@keyframes blockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-4px); }
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */
@media (max-width: 600px) {
  .standing-item {
    grid-template-columns: 32px 32px 1fr auto;
    gap: 8px;
    padding: 8px 10px;
  }

  .standing-stats {
    display: none;
  }

  .winner-content {
    gap: 12px;
  }

  .trophy-icon {
    font-size: 2rem;
  }

  .winner-text {
    font-size: 1.1rem;
  }

  .page-deco {
    display: none;
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

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

    <!-- Floating coins animation -->
    <div class="floating-coins">
      <span class="coin" v-for="n in 8" :key="n">🪙</span>
    </div>

    <!-- Game Over Title -->
    <div class="game-over-header">
      <div class="game-over-text">
        <span class="letter" v-for="(letter, i) in 'OYUN BİTTİ!'" :key="i" :style="{ animationDelay: `${i * 0.05}s` }">
          {{ letter === ' ' ? '\u00A0' : letter }}
        </span>
      </div>
      <div class="game-over-subtitle">{{ results.length }} oyuncu yarıştı</div>
    </div>

    <!-- Your Result Banner (if you're in top 3) -->
    <MarioCard v-if="isWinner" color="yellow" showDeco class="winner-banner">
      <div class="winner-content">
        <div class="trophy-icon">🏆</div>
        <div class="winner-info">
          <div class="winner-text">KAZANDIN!</div>
          <div class="winner-subtext">Tebrikler! Eleme turlarını geçtin!</div>
        </div>
      </div>
    </MarioCard>

    <!-- Full Leaderboard -->
    <div class="leaderboard-section">
      <div class="section-header">
        <div class="section-title">
          <span class="title-icon">📊</span>
          <span>Skor Tablosu</span>
        </div>
      </div>

      <div class="leaderboard-list">
        <div
          v-for="(result, index) in sortedResults"
          :key="result.userId"
          class="leaderboard-item"
          :class="{
            winner: result.isWinner,
            me: isMe(result.userId),
            eliminated: result.rank === 999,
            'top-3': result.rank <= 3 && result.rank !== 999
          }"
        >
          <div class="item-rank">
            <div v-if="result.isWinner || result.rank === 1" class="rank-medal gold">
              <span class="medal-crown">👑</span>
              <span class="medal-icon">🏆</span>
            </div>
            <div v-else-if="result.rank === 2" class="rank-medal silver">
              <span class="medal-icon">🥈</span>
            </div>
            <div v-else-if="result.rank === 3" class="rank-medal bronze">
              <span class="medal-icon">🥉</span>
            </div>
            <span v-else-if="result.rank === 999" class="rank-icon skull">💀</span>
            <span v-else class="rank-number">{{ result.rank }}</span>
          </div>
          <div class="item-avatar">{{ result.avatar || '👤' }}</div>
          <div class="item-info">
            <div class="item-name">
              {{ result.username }}
              <span v-if="isMe(result.userId)" class="you-tag">SEN</span>
            </div>
          </div>
          <div class="item-badges">
            <div class="stat-badge correct-badge">
              <div class="badge-value">{{ result.correctAnswers }}</div>
              <div class="badge-label">doğru</div>
            </div>
            <div class="stat-badge wrong-badge">
              <div class="badge-value">{{ result.wrongAnswers }}</div>
              <div class="badge-label">yanlış</div>
            </div>
            <div class="stat-badge score-badge">
              <div class="badge-value">{{ result.score }}</div>
              <div class="badge-label">puan</div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Actions -->
    <div class="action-section">
      <MarioButton color="green" size="lg" @click="handleClose" class="home-button">
        <template #icon>🏠</template>
        Ana Sayfaya Dön
      </MarioButton>
    </div>

    <!-- Mario Decorations - Full Width Ground -->
    <div class="mario-ground">
      <!-- Question blocks row -->
      <div class="question-blocks-row">
        <div class="q-block" v-for="n in 20" :key="n">?</div>
      </div>
      <!-- Brick row -->
      <div class="brick-row">
        <div class="brick" v-for="n in 50" :key="n"></div>
      </div>
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
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
  position: relative;
  overflow: hidden;
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
   FLOATING COINS
   ========================================== */
.floating-coins {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  pointer-events: none;
  z-index: 0;
  overflow: hidden;
}

.coin {
  position: absolute;
  font-size: 1.5rem;
  animation: float-coin 8s ease-in-out infinite;
  opacity: 0.4;
}

.coin:nth-child(1) { left: 10%; animation-delay: 0s; top: 20%; }
.coin:nth-child(2) { left: 25%; animation-delay: 1s; top: 40%; }
.coin:nth-child(3) { left: 40%; animation-delay: 2s; top: 60%; }
.coin:nth-child(4) { left: 55%; animation-delay: 3s; top: 30%; }
.coin:nth-child(5) { left: 70%; animation-delay: 4s; top: 50%; }
.coin:nth-child(6) { left: 85%; animation-delay: 5s; top: 70%; }
.coin:nth-child(7) { left: 15%; animation-delay: 6s; top: 80%; }
.coin:nth-child(8) { left: 90%; animation-delay: 7s; top: 15%; }

@keyframes float-coin {
  0%, 100% { transform: translateY(0) rotate(0deg); }
  50% { transform: translateY(-30px) rotate(180deg); }
}

/* ==========================================
   GAME OVER HEADER
   ========================================== */
.game-over-header {
  text-align: center;
  margin-bottom: 32px;
  position: relative;
  z-index: 1;
}

.game-over-text {
  font-size: clamp(1.8rem, 6vw, 2.5rem);
  font-weight: 900;
  color: var(--mario-red);
  text-shadow:
    3px 3px 0 var(--mario-yellow),
    -1px -1px 0 #000,
    1px -1px 0 #000,
    -1px 1px 0 #000,
    1px 1px 0 #000;
  letter-spacing: 4px;
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}

.letter {
  display: inline-block;
  animation: letterBounce 0.5s ease-out forwards;
  opacity: 0;
  transform: translateY(-20px);
}

@keyframes letterBounce {
  0% { opacity: 0; transform: translateY(-20px) scale(0.5); }
  60% { transform: translateY(5px) scale(1.1); }
  100% { opacity: 1; transform: translateY(0) scale(1); }
}

.game-over-subtitle {
  font-size: 1rem;
  color: var(--text-muted);
  margin-top: 8px;
  font-weight: 600;
}

/* ==========================================
   WINNER BANNER
   ========================================== */
.winner-banner {
  margin-bottom: 20px;
  position: relative;
  z-index: 1;
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

/* ==========================================
   LEADERBOARD SECTION
   ========================================== */
.leaderboard-section {
  background: var(--bg-card);
  border: 3px solid var(--border);
  border-radius: var(--radius-xl);
  padding: 20px;
  margin-bottom: 24px;
  position: relative;
  z-index: 1;
  box-shadow: 0 6px 0 var(--border);
}

.section-header {
  margin-bottom: 16px;
}

.section-title {
  display: flex;
  align-items: center;
  gap: 10px;
  font-size: 1.1rem;
  font-weight: 800;
  color: var(--text);
}

.title-icon {
  font-size: 1.3rem;
}

.leaderboard-list {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.leaderboard-item {
  display: grid;
  grid-template-columns: 48px 44px 1fr auto;
  gap: 12px;
  align-items: center;
  padding: 12px 14px;
  background: var(--bg-input);
  border-radius: var(--radius-lg);
  border: 2px solid transparent;
  transition: all 0.2s ease;
}

.leaderboard-item:hover {
  transform: translateX(4px);
  background: var(--bg-card-hover);
}

.leaderboard-item.winner {
  background: linear-gradient(135deg, rgba(245, 158, 11, 0.2), rgba(245, 158, 11, 0.1));
  border-color: #f59e0b;
  box-shadow: 0 4px 0 rgba(245, 158, 11, 0.3);
}

.leaderboard-item.top-3:not(.winner) {
  background: rgba(139, 92, 246, 0.1);
  border-color: rgba(139, 92, 246, 0.4);
}

.leaderboard-item.me:not(.winner):not(.top-3) {
  border-color: var(--primary);
  background: rgba(59, 130, 246, 0.1);
}

.leaderboard-item.eliminated {
  opacity: 0.5;
}

.item-rank {
  display: flex;
  align-items: center;
  justify-content: center;
}

.rank-medal {
  display: flex;
  flex-direction: column;
  align-items: center;
  position: relative;
}

.medal-crown {
  font-size: 1rem;
  position: absolute;
  top: -14px;
  animation: crownFloat 1.5s ease-in-out infinite;
}

@keyframes crownFloat {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-3px); }
}

.medal-icon {
  font-size: 1.5rem;
}

.rank-medal.gold {
  filter: drop-shadow(0 0 8px rgba(245, 158, 11, 0.5));
}

.rank-medal.silver {
  filter: drop-shadow(0 0 6px rgba(156, 163, 175, 0.5));
}

.rank-medal.bronze {
  filter: drop-shadow(0 0 6px rgba(217, 119, 6, 0.5));
}

.rank-icon {
  font-size: 1.5rem;
}

.rank-icon.skull {
  font-size: 1.3rem;
}

.rank-number {
  font-size: 1.1rem;
  font-weight: 800;
  color: var(--text-muted);
  background: var(--bg-card);
  width: 32px;
  height: 32px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 50%;
  border: 2px solid var(--border);
}

.item-avatar {
  font-size: 1.6rem;
  text-align: center;
}

.item-info {
  display: flex;
  flex-direction: column;
  gap: 4px;
  min-width: 0;
}

.item-name {
  font-size: 0.95rem;
  font-weight: 700;
  color: var(--text);
  display: flex;
  align-items: center;
  gap: 8px;
}

.you-tag {
  background: var(--mario-blue);
  color: white;
  padding: 2px 8px;
  border-radius: 6px;
  font-size: 0.65rem;
  font-weight: 800;
  letter-spacing: 0.5px;
  box-shadow: 0 2px 0 #037bb5;
}

/* Item Badges - Correct/Wrong/Score */
.item-badges {
  display: flex;
  gap: 6px;
  align-items: center;
}

.stat-badge {
  text-align: center;
  padding: 6px 10px;
  border-radius: var(--radius-md);
  min-width: 44px;
}

.stat-badge .badge-value {
  font-size: 0.95rem;
  font-weight: 800;
  color: white;
  line-height: 1;
}

.stat-badge .badge-label {
  font-size: 0.5rem;
  font-weight: 600;
  color: rgba(255,255,255,0.85);
  text-transform: uppercase;
  letter-spacing: 0.3px;
  margin-top: 2px;
}

.correct-badge {
  background: linear-gradient(135deg, #10b981, #059669);
  box-shadow: 0 2px 0 #047857;
}

.wrong-badge {
  background: linear-gradient(135deg, #ef4444, #dc2626);
  box-shadow: 0 2px 0 #b91c1c;
}

.score-badge {
  background: linear-gradient(135deg, #f59e0b, #d97706);
  box-shadow: 0 2px 0 #b45309;
}

/* ==========================================
   ACTION SECTION
   ========================================== */
.action-section {
  display: flex;
  justify-content: center;
  margin-bottom: 40px;
  position: relative;
  z-index: 1;
}

.home-button {
  min-width: 200px;
}

/* ==========================================
   MARIO GROUND DECORATIONS - FULL WIDTH
   ========================================== */
.mario-ground {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  pointer-events: none;
  z-index: 0;
}

.question-blocks-row {
  display: flex;
  justify-content: center;
  gap: 4px;
  margin-bottom: 4px;
  flex-wrap: nowrap;
  overflow: hidden;
}

.q-block {
  width: 28px;
  height: 28px;
  min-width: 28px;
  background: linear-gradient(180deg, #fef3c7, #fbbf24);
  border-radius: 4px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1rem;
  font-weight: 900;
  color: #92400e;
  box-shadow: 0 2px 0 #b45309, inset 0 -2px 0 rgba(0,0,0,0.1);
  animation: qBlockBounce 2s ease-in-out infinite;
  opacity: 0.85;
}

.q-block:nth-child(2n) { animation-delay: 0.2s; }
.q-block:nth-child(3n) { animation-delay: 0.4s; }
.q-block:nth-child(5n) { animation-delay: 0.6s; }
.q-block:nth-child(7n) { animation-delay: 0.8s; }

@keyframes qBlockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-3px); }
}

.brick-row {
  display: flex;
  justify-content: center;
  gap: 2px;
  flex-wrap: nowrap;
  overflow: hidden;
}

.brick {
  width: 28px;
  height: 14px;
  min-width: 28px;
  background: linear-gradient(180deg, #c2410c, #9a3412);
  border-radius: 2px;
  box-shadow: inset 0 -2px 0 rgba(0,0,0,0.2), inset 0 2px 0 rgba(255,255,255,0.1);
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */
@media (max-width: 600px) {
  .leaderboard-item {
    grid-template-columns: 36px 32px 1fr;
    gap: 8px;
    padding: 10px 12px;
  }

  .item-badges {
    grid-column: 1 / -1;
    justify-content: flex-end;
    margin-top: 4px;
  }

  .stat-badge {
    padding: 4px 8px;
    min-width: 38px;
  }

  .stat-badge .badge-value {
    font-size: 0.85rem;
  }

  .stat-badge .badge-label {
    font-size: 0.45rem;
  }

  .game-over-text {
    letter-spacing: 2px;
  }

  .q-block {
    width: 24px;
    height: 24px;
    min-width: 24px;
    font-size: 0.85rem;
  }

  .brick {
    width: 24px;
    height: 12px;
    min-width: 24px;
  }

  .medal-crown {
    font-size: 0.85rem;
    top: -12px;
  }

  .medal-icon {
    font-size: 1.3rem;
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

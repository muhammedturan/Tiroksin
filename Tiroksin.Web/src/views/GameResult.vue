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

    <!-- Podium for Top 3 -->
    <div class="podium-section" v-if="topThree.length > 0">
      <div class="podium-container">
        <!-- 2nd Place -->
        <div class="podium-spot second" v-if="topThree[1]">
          <div class="podium-player">
            <div class="player-crown">🥈</div>
            <div class="player-avatar-large">{{ topThree[1].avatar || '👤' }}</div>
            <div class="player-name">{{ topThree[1].username }}</div>
            <div class="player-score-badge">{{ topThree[1].score }} puan</div>
          </div>
          <div class="podium-block silver">
            <span class="podium-rank">2</span>
          </div>
        </div>

        <!-- 1st Place (Winner) -->
        <div class="podium-spot first" v-if="topThree[0]">
          <div class="podium-player winner-glow">
            <div class="player-crown">👑</div>
            <div class="player-avatar-large">{{ topThree[0].avatar || '🏆' }}</div>
            <div class="player-name">{{ topThree[0].username }}</div>
            <div class="player-score-badge gold">{{ topThree[0].score }} puan</div>
            <div class="winner-sparkles">
              <span class="sparkle" v-for="n in 6" :key="n">✨</span>
            </div>
          </div>
          <div class="podium-block gold">
            <span class="podium-rank">1</span>
          </div>
        </div>

        <!-- 3rd Place -->
        <div class="podium-spot third" v-if="topThree[2]">
          <div class="podium-player">
            <div class="player-crown">🥉</div>
            <div class="player-avatar-large">{{ topThree[2].avatar || '👤' }}</div>
            <div class="player-name">{{ topThree[2].username }}</div>
            <div class="player-score-badge">{{ topThree[2].score }} puan</div>
          </div>
          <div class="podium-block bronze">
            <span class="podium-rank">3</span>
          </div>
        </div>
      </div>
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

    <!-- Your Stats Card (if not winner) -->
    <MarioCard v-else-if="myResult" :color="myResult.rank <= 3 ? 'green' : 'blue'" class="my-stats-card">
      <div class="my-stats-content">
        <div class="my-stats-rank">
          <span v-if="myResult.rank === 999">💀</span>
          <span v-else>#{{ myResult.rank }}</span>
        </div>
        <div class="my-stats-info">
          <div class="my-stats-title">Senin Sonucun</div>
          <div class="my-stats-details">
            <span class="stat-item">✅ {{ myResult.correctAnswers }} Doğru</span>
            <span class="stat-item">❌ {{ myResult.wrongAnswers }} Yanlış</span>
            <span class="stat-item">⭐ {{ myResult.score }} Puan</span>
          </div>
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
            <span v-if="result.isWinner" class="rank-icon">🏆</span>
            <span v-else-if="result.rank === 2" class="rank-icon">🥈</span>
            <span v-else-if="result.rank === 3" class="rank-icon">🥉</span>
            <span v-else-if="result.rank === 999" class="rank-icon skull">💀</span>
            <span v-else class="rank-number">{{ result.rank }}</span>
          </div>
          <div class="item-avatar">{{ result.avatar || '👤' }}</div>
          <div class="item-info">
            <div class="item-name">
              {{ result.username }}
              <span v-if="isMe(result.userId)" class="you-tag">SEN</span>
            </div>
            <div class="item-stats">
              <span class="mini-stat correct">✅ {{ result.correctAnswers }}</span>
              <span class="mini-stat wrong">❌ {{ result.wrongAnswers }}</span>
            </div>
          </div>
          <div class="item-score">
            <div class="score-value">{{ result.score }}</div>
            <div class="score-label">puan</div>
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

    <!-- Mario Decorations -->
    <div class="mario-decorations">
      <div class="brick-row top">
        <div class="brick" v-for="n in 10" :key="n"></div>
      </div>
      <div class="question-blocks">
        <div class="q-block" v-for="n in 3" :key="n">?</div>
      </div>
      <div class="pipe left">
        <div class="pipe-top"></div>
        <div class="pipe-body"></div>
      </div>
      <div class="pipe right">
        <div class="pipe-top"></div>
        <div class="pipe-body"></div>
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

const topThree = computed(() => {
  return [...results.value]
    .filter(r => r.rank !== 999 && r.rank <= 3)
    .sort((a, b) => a.rank - b.rank)
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
   PODIUM SECTION
   ========================================== */
.podium-section {
  margin-bottom: 32px;
  position: relative;
  z-index: 1;
}

.podium-container {
  display: flex;
  justify-content: center;
  align-items: flex-end;
  gap: 8px;
  padding: 20px;
}

.podium-spot {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.podium-player {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 12px;
  position: relative;
}

.winner-glow {
  animation: winnerPulse 2s ease-in-out infinite;
}

@keyframes winnerPulse {
  0%, 100% { filter: drop-shadow(0 0 10px rgba(245, 158, 11, 0.5)); }
  50% { filter: drop-shadow(0 0 25px rgba(245, 158, 11, 0.8)); }
}

.player-crown {
  font-size: 2rem;
  margin-bottom: 4px;
  animation: crownBounce 1s ease-in-out infinite;
}

@keyframes crownBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-5px); }
}

.player-avatar-large {
  font-size: 2.5rem;
  background: var(--bg-card);
  border: 3px solid var(--border);
  border-radius: 50%;
  width: 64px;
  height: 64px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.first .player-avatar-large {
  width: 80px;
  height: 80px;
  font-size: 3rem;
  border-color: #f59e0b;
  box-shadow: 0 0 20px rgba(245, 158, 11, 0.4);
}

.player-name {
  font-size: 0.9rem;
  font-weight: 700;
  color: var(--text);
  margin-top: 8px;
  max-width: 100px;
  text-overflow: ellipsis;
  overflow: hidden;
  white-space: nowrap;
  text-align: center;
}

.player-score-badge {
  font-size: 0.75rem;
  font-weight: 700;
  padding: 4px 10px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: 12px;
  color: var(--text);
  margin-top: 4px;
}

.player-score-badge.gold {
  background: linear-gradient(135deg, #fbbf24, #f59e0b);
  border-color: #d97706;
  color: #78350f;
}

.winner-sparkles {
  position: absolute;
  top: 0;
  left: 50%;
  transform: translateX(-50%);
  width: 120px;
  height: 120px;
  pointer-events: none;
}

.sparkle {
  position: absolute;
  font-size: 0.8rem;
  animation: sparkle 1.5s ease-in-out infinite;
}

.sparkle:nth-child(1) { top: 0; left: 50%; animation-delay: 0s; }
.sparkle:nth-child(2) { top: 20%; right: 0; animation-delay: 0.2s; }
.sparkle:nth-child(3) { bottom: 20%; right: 0; animation-delay: 0.4s; }
.sparkle:nth-child(4) { bottom: 0; left: 50%; animation-delay: 0.6s; }
.sparkle:nth-child(5) { bottom: 20%; left: 0; animation-delay: 0.8s; }
.sparkle:nth-child(6) { top: 20%; left: 0; animation-delay: 1s; }

@keyframes sparkle {
  0%, 100% { opacity: 0; transform: scale(0); }
  50% { opacity: 1; transform: scale(1); }
}

.podium-block {
  width: 90px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 8px 8px 0 0;
  font-size: 1.5rem;
  font-weight: 900;
  color: white;
  text-shadow: 2px 2px 0 rgba(0,0,0,0.2);
  position: relative;
}

.first .podium-block { width: 100px; }

.podium-block::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  height: 8px;
  background: rgba(255,255,255,0.3);
  border-radius: 8px 8px 0 0;
}

.podium-block.gold {
  height: 120px;
  background: linear-gradient(180deg, #fbbf24, #f59e0b);
  box-shadow: 0 4px 0 #b45309;
}

.podium-block.silver {
  height: 90px;
  background: linear-gradient(180deg, #d1d5db, #9ca3af);
  box-shadow: 0 4px 0 #6b7280;
}

.podium-block.bronze {
  height: 70px;
  background: linear-gradient(180deg, #f59e0b, #d97706);
  box-shadow: 0 4px 0 #92400e;
}

.podium-rank {
  font-size: 2rem;
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
   MY STATS CARD
   ========================================== */
.my-stats-card {
  margin-bottom: 20px;
  position: relative;
  z-index: 1;
}

.my-stats-content {
  display: flex;
  align-items: center;
  gap: 16px;
}

.my-stats-rank {
  font-size: 1.8rem;
  font-weight: 900;
  min-width: 60px;
  text-align: center;
}

.my-stats-info {
  flex: 1;
}

.my-stats-title {
  font-size: 1rem;
  font-weight: 700;
  color: var(--text);
  margin-bottom: 4px;
}

.my-stats-details {
  display: flex;
  gap: 12px;
  flex-wrap: wrap;
}

.stat-item {
  font-size: 0.85rem;
  font-weight: 600;
  color: var(--text-muted);
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

.item-stats {
  display: flex;
  gap: 10px;
}

.mini-stat {
  font-size: 0.75rem;
  font-weight: 600;
  color: var(--text-muted);
}

.mini-stat.correct { color: #10b981; }
.mini-stat.wrong { color: #ef4444; }

.item-score {
  text-align: center;
  padding: 8px 14px;
  background: linear-gradient(135deg, #10b981, #059669);
  border-radius: var(--radius-md);
  box-shadow: 0 3px 0 #047857;
}

.score-value {
  font-size: 1.1rem;
  font-weight: 800;
  color: white;
  line-height: 1;
}

.score-label {
  font-size: 0.6rem;
  font-weight: 600;
  color: rgba(255,255,255,0.8);
  text-transform: uppercase;
  letter-spacing: 0.5px;
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
   MARIO DECORATIONS
   ========================================== */
.mario-decorations {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  height: 100px;
  pointer-events: none;
  z-index: 0;
  overflow: hidden;
}

.brick-row {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  gap: 2px;
}

.brick {
  width: 32px;
  height: 16px;
  background: linear-gradient(180deg, #c2410c, #9a3412);
  border-radius: 2px;
  box-shadow: inset 0 -2px 0 rgba(0,0,0,0.2), inset 0 2px 0 rgba(255,255,255,0.1);
}

.question-blocks {
  position: absolute;
  bottom: 20px;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  gap: 60px;
  opacity: 0.3;
}

.q-block {
  width: 32px;
  height: 32px;
  background: linear-gradient(180deg, #fbbf24, #f59e0b);
  border-radius: 4px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.2rem;
  font-weight: 900;
  color: #78350f;
  box-shadow: 0 3px 0 #b45309;
  animation: qBlockBounce 2s ease-in-out infinite;
}

.q-block:nth-child(2) { animation-delay: 0.3s; }
.q-block:nth-child(3) { animation-delay: 0.6s; }

@keyframes qBlockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-5px); }
}

.pipe {
  position: absolute;
  bottom: 16px;
  opacity: 0.3;
}

.pipe.left { left: 20px; }
.pipe.right { right: 20px; }

.pipe-top {
  width: 48px;
  height: 16px;
  background: linear-gradient(180deg, #22c55e, #16a34a);
  border-radius: 4px 4px 0 0;
  box-shadow: inset 0 -2px 0 rgba(0,0,0,0.2);
}

.pipe-body {
  width: 40px;
  height: 40px;
  background: linear-gradient(90deg, #22c55e, #16a34a);
  margin: 0 auto;
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */
@media (max-width: 600px) {
  .podium-container {
    gap: 4px;
    padding: 10px;
  }

  .podium-block {
    width: 70px;
  }

  .first .podium-block {
    width: 80px;
  }

  .podium-block.gold { height: 100px; }
  .podium-block.silver { height: 75px; }
  .podium-block.bronze { height: 55px; }

  .player-avatar-large {
    width: 50px;
    height: 50px;
    font-size: 1.8rem;
  }

  .first .player-avatar-large {
    width: 64px;
    height: 64px;
    font-size: 2.2rem;
  }

  .player-name {
    font-size: 0.75rem;
    max-width: 70px;
  }

  .player-score-badge {
    font-size: 0.65rem;
    padding: 3px 8px;
  }

  .leaderboard-item {
    grid-template-columns: 40px 36px 1fr auto;
    gap: 8px;
    padding: 10px 12px;
  }

  .item-stats {
    display: none;
  }

  .game-over-text {
    letter-spacing: 2px;
  }

  .mario-decorations {
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

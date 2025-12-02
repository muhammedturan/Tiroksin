<template>
  <div class="home-page">
    <!-- FULL-WIDTH HERO SECTION -->
    <MarioCard color="red" hero showDeco class="hero-section">
      <div class="hero-badge">
        <span>🧬</span>
        <span>Quiz Platform</span>
      </div>
      <h1 class="hero-title">Tiroksin</h1>
      <p class="hero-subtitle">Öğrenmenin Katalizörü - Arkadaşlarınla yarış, bilgini test et!</p>

      <MarioButton color="green" size="lg" @click="goToMultiplayer" class="btn-play">
        <template #icon>🎮</template>
        OYUNA BAŞLA
      </MarioButton>
      <p class="btn-play-sub">Çok oyunculu yarışma</p>

      <!-- Stats Row -->
      <div class="hero-stats">
        <div class="stat-box stat-categories">
          <span class="stat-value">{{ categories.length }}</span>
          <span class="stat-label">Kategori</span>
        </div>
        <div class="stat-box stat-questions">
          <span class="stat-value">∞</span>
          <span class="stat-label">Soru</span>
        </div>
        <div class="stat-box stat-compete">
          <span class="stat-value">🏆</span>
          <span class="stat-label">Yarış</span>
        </div>
      </div>
    </MarioCard>

    <!-- CATEGORIES SECTION -->
    <div class="categories-section">
      <div class="section-header">
        <h2 class="section-title">📚 Kategoriler</h2>
        <span class="category-count">{{ categories.length }} Kategori</span>
      </div>

      <!-- Loading Skeleton -->
      <div v-if="loading" class="categories-grid">
        <div v-for="i in 8" :key="i" class="category-skeleton">
          <div class="skeleton-icon"></div>
          <div class="skeleton-content">
            <div class="skeleton-title"></div>
            <div class="skeleton-desc"></div>
          </div>
        </div>
      </div>

      <!-- Categories 2x4 Grid -->
      <div v-else class="categories-grid">
        <div
          v-for="(category, index) in categories"
          :key="category.id"
          @click="goToExams(category.id)"
          class="category-card"
          :class="`card-color-${(index % 4) + 1}`"
        >
          <div class="card-icon">{{ category.icon }}</div>
          <div class="card-content">
            <h3 class="card-name">{{ category.name }}</h3>
            <p class="card-desc">{{ category.description }}</p>
          </div>
          <div class="card-arrow">→</div>
        </div>
      </div>

      <!-- Empty State -->
      <div v-if="!loading && categories.length === 0" class="empty-state">
        <div class="empty-icon">📚</div>
        <h3>Henüz kategori yok</h3>
        <p>Kategoriler yakında eklenecek!</p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import api from '../services/api'
import MarioCard from '../components/MarioCard.vue'
import MarioButton from '../components/MarioButton.vue'

const router = useRouter()
const categories = ref([])
const loading = ref(true)

const fetchCategories = async () => {
  try {
    loading.value = true
    const response = await api.get('/parameters/CATEGORY/values')
    categories.value = response.data.map(param => ({
      id: param.value,
      name: param.name,
      icon: getCategoryIcon(param.name),
      description: getCategoryDescription(param.name)
    }))
  } catch (error) {
    console.error('Error fetching categories:', error)
  } finally {
    loading.value = false
  }
}

const getCategoryIcon = (name) => {
  const icons = {
    'Matematik': '🔢',
    'Fizik': '⚛️',
    'Kimya': '🧪',
    'Biyoloji': '🧬',
    'Türkçe': '📚',
    'Tarih': '📜',
    'Coğrafya': '🌍',
    'Felsefe': '🤔'
  }
  return icons[name] || '📖'
}

const getCategoryDescription = (name) => {
  const descriptions = {
    'Matematik': 'Sayılar, fonksiyonlar ve problem çözme',
    'Fizik': 'Hareket, enerji ve doğa yasaları',
    'Kimya': 'Elementler, bileşikler ve reaksiyonlar',
    'Biyoloji': 'Canlılar, hücreler ve yaşam bilimi',
    'Türkçe': 'Dil bilgisi, edebiyat ve anlama',
    'Tarih': 'Geçmişten günümüze olaylar',
    'Coğrafya': 'Dünya, iklim ve coğrafi yapılar',
    'Felsefe': 'Düşünce, mantık ve etik'
  }
  return descriptions[name] || `${name} ile ilgili sorular`
}

const goToExams = (categoryId) => {
  router.push(`/exams?categoryId=${categoryId}`)
}

const goToMultiplayer = () => {
  router.push('/lobby')
}

onMounted(() => {
  fetchCategories()
})
</script>

<style scoped>
.home-page {
  max-width: 1200px;
  margin: 0 auto;
}

/* ==========================================
   HERO SECTION - Compact & Wide
   ========================================== */

.hero-section {
  margin-bottom: 24px;
}

.hero-badge {
  display: inline-flex;
  align-items: center;
  gap: 6px;
  padding: 6px 12px;
  background: rgba(255, 255, 255, 0.15);
  border-radius: var(--radius-full);
  font-size: 0.75rem;
  font-weight: 600;
  color: rgba(255, 255, 255, 0.9);
  margin-bottom: 12px;
}

.hero-title {
  font-size: 2.2rem;
  font-weight: 800;
  color: white;
  margin: 0 0 6px 0;
  letter-spacing: -1px;
}

.hero-subtitle {
  font-size: 0.95rem;
  color: rgba(255, 255, 255, 0.85);
  margin: 0 0 20px 0;
  font-weight: 500;
}

/* Play Button */
.btn-play {
  margin-bottom: 8px;
}

.btn-play-sub {
  font-size: 0.75rem;
  color: rgba(255, 255, 255, 0.8);
  font-weight: 500;
  margin: 0 0 16px 0;
}

/* Hero Stats - Inline & Compact */
.hero-stats {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 24px;
}

.stat-box {
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 8px 16px;
  background: rgba(255, 255, 255, 0.1);
  border-radius: var(--radius-md);
}

.stat-box .stat-value {
  font-size: 1.2rem;
  font-weight: 700;
  color: white;
}

.stat-box .stat-label {
  font-size: 0.7rem;
  color: rgba(255, 255, 255, 0.7);
  text-transform: uppercase;
  font-weight: 600;
}

/* ==========================================
   CATEGORIES SECTION
   ========================================== */

.categories-section {
  padding: 0;
}

.section-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 16px;
}

.section-title {
  font-size: 1.1rem;
  font-weight: 700;
  color: var(--text);
  margin: 0;
}

.category-count {
  font-size: 0.8rem;
  font-weight: 600;
  color: var(--text-muted);
  padding: 4px 10px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: var(--radius-full);
}

/* Categories Grid - 3 columns for wider layout */
.categories-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 12px;
}

/* Category Card - Slim */
.category-card {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px 16px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: var(--radius-md);
  cursor: pointer;
  transition: all 0.2s ease;
  position: relative;
}

.category-card::before {
  content: '';
  position: absolute;
  left: 0;
  top: 0;
  bottom: 0;
  width: 3px;
  border-radius: 3px 0 0 3px;
}

.category-card.card-color-1::before { background: #ef4444; }
.category-card.card-color-2::before { background: #3b82f6; }
.category-card.card-color-3::before { background: #10b981; }
.category-card.card-color-4::before { background: #f59e0b; }

.category-card:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  border-color: var(--border-light);
}

.category-card:hover .card-arrow {
  transform: translateX(3px);
  opacity: 1;
}

.card-icon {
  font-size: 1.5rem;
  flex-shrink: 0;
}

.card-content {
  flex: 1;
  min-width: 0;
}

.card-name {
  font-size: 0.95rem;
  font-weight: 600;
  color: var(--text);
  margin: 0 0 2px 0;
}

.card-desc {
  font-size: 0.75rem;
  color: var(--text-muted);
  margin: 0;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.card-arrow {
  font-size: 1rem;
  color: var(--text-muted);
  opacity: 0;
  transition: all 0.2s ease;
}

/* Skeleton Loading */
.category-skeleton {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px 16px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: var(--radius-md);
}

.skeleton-icon {
  width: 36px;
  height: 36px;
  background: var(--bg-input);
  border-radius: var(--radius-sm);
  animation: pulse 1.5s ease-in-out infinite;
}

.skeleton-content {
  flex: 1;
}

.skeleton-title {
  width: 80px;
  height: 14px;
  background: var(--bg-input);
  border-radius: 3px;
  animation: pulse 1.5s ease-in-out infinite;
}

.skeleton-desc {
  width: 120px;
  height: 10px;
  background: var(--bg-input);
  border-radius: 3px;
  margin-top: 6px;
  animation: pulse 1.5s ease-in-out infinite;
}

@keyframes pulse {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.5; }
}

/* Empty State */
.empty-state {
  text-align: center;
  padding: 40px 20px;
  background: var(--bg-card);
  border: 1px dashed var(--border);
  border-radius: var(--radius-lg);
  grid-column: 1 / -1;
}

.empty-state .empty-icon {
  font-size: 2.5rem;
  margin-bottom: 12px;
}

.empty-state h3 {
  font-size: 1rem;
  font-weight: 600;
  color: var(--text);
  margin: 0 0 6px 0;
}

.empty-state p {
  font-size: 0.85rem;
  color: var(--text-muted);
  margin: 0;
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */

@media (max-width: 900px) {
  .categories-grid {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (max-width: 600px) {
  .hero-section {
    padding: 24px 20px;
  }

  .hero-title {
    font-size: 1.8rem;
  }

  .btn-play {
    width: 100%;
    justify-content: center;
  }

  .hero-stats {
    flex-wrap: wrap;
    gap: 8px;
  }

  .stat-box {
    padding: 6px 12px;
  }

  .hero-deco {
    display: none;
  }

  .categories-grid {
    grid-template-columns: 1fr;
  }
}
</style>

<template>
  <div class="home-page">
    <div class="hero-section">
      <h1 class="page-title">🧬 Tiroksin</h1>
      <p class="page-subtitle">
        Öğrenmenin Katalizörü - Sınavlarına hazırlan, gelişimini takip et
      </p>

      <button @click="goToMultiplayer" class="multiplayer-btn">
        🎮 Çok Oyunculu Yarışma Başlat
      </button>
    </div>

    <h2 class="section-title">Kategoriler</h2>

    <div v-if="loading" class="categories-grid">
      <div v-for="i in 6" :key="i" class="category-skeleton"></div>
    </div>

    <div v-else class="categories-grid">
      <div
        v-for="category in categories"
        :key="category.id"
        @click="goToExams(category.id)"
        class="category-card"
      >
        <div class="category-icon">{{ category.icon }}</div>
        <h3 class="category-name">{{ category.name }}</h3>
        <p class="category-description">{{ category.description }}</p>
      </div>
    </div>

    <div v-if="!loading && categories.length === 0" class="empty-state">
      <div class="empty-icon">📚</div>
      <p>Henüz kategori bulunmuyor</p>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import api from '../services/api'

const router = useRouter()
const categories = ref([])
const loading = ref(true)

const fetchCategories = async () => {
  try {
    loading.value = true
    const response = await api.get('/parameters/CATEGORY/values')
    // Transform parameter values to category format
    categories.value = response.data.map(param => ({
      id: param.value,
      name: param.name,
      icon: getCategoryIcon(param.name),
      description: `${param.name} kategorisi`
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
    'Türkçe': '📚'
  }
  return icons[name] || '📖'
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
  max-width: 900px;
  margin: 0 auto;
}

.hero-section {
  text-align: center;
  margin-bottom: 32px;
  padding: 40px 24px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 20px;
}

.page-title {
  font-size: 2.5rem;
  font-weight: 800;
  margin-bottom: 12px;
  background: linear-gradient(135deg, var(--primary-light) 0%, var(--accent) 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.page-subtitle {
  font-size: 1rem;
  color: var(--text-muted);
  margin-bottom: 28px;
}

.multiplayer-btn {
  padding: 16px 36px;
  font-size: 1.1rem;
  font-weight: 700;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  border: none;
  border-radius: 14px;
  cursor: pointer;
  transition: all 0.2s;
  box-shadow: 0 4px 20px var(--glow-blue);
}

.multiplayer-btn:hover {
  transform: translateY(-3px);
  box-shadow: 0 8px 30px var(--glow-blue);
}

.multiplayer-btn:active {
  transform: scale(0.98);
}

.section-title {
  font-size: 1.4rem;
  font-weight: 700;
  margin-bottom: 20px;
  color: var(--text);
}

.categories-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(260px, 1fr));
  gap: 16px;
}

.category-skeleton {
  background: var(--bg-card-light);
  padding: 2rem;
  border-radius: 14px;
  height: 160px;
  animation: pulse 1.5s ease-in-out infinite;
}

@keyframes pulse {
  0%, 100% { opacity: 0.6; }
  50% { opacity: 0.3; }
}

.category-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  padding: 24px;
  border-radius: 14px;
  cursor: pointer;
  transition: all 0.2s;
}

.category-card:hover {
  transform: translateY(-4px);
  border-color: var(--primary);
  box-shadow: 0 8px 32px rgba(0, 0, 0, 0.3);
}

.category-icon {
  font-size: 2.8rem;
  margin-bottom: 14px;
}

.category-name {
  font-size: 1.2rem;
  font-weight: 700;
  margin-bottom: 8px;
  color: var(--text);
}

.category-description {
  color: var(--text-muted);
  font-size: 0.85rem;
  line-height: 1.5;
}

.empty-state {
  text-align: center;
  padding: 60px 20px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
}

.empty-icon {
  font-size: 4rem;
  margin-bottom: 16px;
}

.empty-state p {
  color: var(--text-muted);
  font-size: 1rem;
}

@media (max-width: 600px) {
  .hero-section {
    padding: 32px 20px;
  }

  .page-title {
    font-size: 2rem;
  }

  .multiplayer-btn {
    width: 100%;
    padding: 14px 24px;
  }

  .categories-grid {
    grid-template-columns: 1fr;
  }
}
</style>

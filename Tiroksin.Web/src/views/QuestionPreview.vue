<template>
  <div class="game-arena">
    <!-- Loading -->
    <div v-if="loading" class="state-card waiting">
      <div class="state-icon">⏳</div>
      <h2>Soru yükleniyor...</h2>
    </div>

    <!-- Error -->
    <div v-else-if="error" class="state-card">
      <div class="state-icon">❌</div>
      <h2>{{ error }}</h2>
      <button @click="fetchQuestion" class="btn-retry">Tekrar Dene</button>
    </div>

    <!-- Question Display -->
    <template v-else-if="question">
      <!-- Top Bar -->
      <div class="top-bar">
        <div class="question-section">
          <span class="question-number">Soru Önizleme</span>
          <span class="category-badge">{{ question.categoryPr }} / {{ question.subjectPr }}</span>
        </div>
        <div class="stats">
          <span class="difficulty" :class="getDifficultyClass(question.difficulty)">
            {{ getDifficultyText(question.difficulty) }}
          </span>
          <span class="score">💯 {{ question.points }} puan</span>
        </div>
      </div>

      <!-- Question Card -->
      <div class="game-container">
        <div class="question-area">
          <div class="question-card">
            <!-- Question Text -->
            <div class="question-header">
              <div class="question-text" v-html="getSafeQuestionText()"></div>
            </div>

            <!-- Question Image (if exists) -->
            <div v-if="question.imageUrl" class="question-image-container">
              <img :src="question.imageUrl" alt="Question Image" class="question-image" />
            </div>

            <!-- Options -->
            <div :class="getOptionsLayoutClass(question.optionsLayout)">
              <button
                v-for="option in question.options"
                :key="option.id"
                @click="selectOption(option.id)"
                class="option-btn"
                :class="{
                  selected: selectedOption === option.id && !showAnswer,
                  correct: showAnswer && option.isCorrect,
                  wrong: showAnswer && selectedOption === option.id && !option.isCorrect
                }"
              >
                <span class="option-key">{{ option.optionKey }}</span>
                <span class="option-text" v-html="getSafeOptionText(option.text)"></span>
              </button>
            </div>
          </div>

          <!-- Action Bar -->
          <div class="action-bar">
            <button v-if="!showAnswer && selectedOption" @click="showAnswer = true" class="btn-check">
              Cevabı Göster
            </button>
            <button v-if="showAnswer" @click="resetQuestion" class="btn-reset">
              Tekrar Dene
            </button>
          </div>
        </div>
      </div>

      <!-- Question Info -->
      <div class="question-info">
        <div class="info-item">
          <span class="info-label">ID:</span>
          <span class="info-value">{{ question.id }}</span>
        </div>
        <div class="info-item">
          <span class="info-label">Konu:</span>
          <span class="info-value">{{ question.topicPr }}</span>
        </div>
      </div>
    </template>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import api from '../services/api'
import { sanitizeHtml } from '../utils/sanitize'

const route = useRoute()
const question = ref(null)
const loading = ref(true)
const error = ref(null)
const selectedOption = ref(null)
const showAnswer = ref(false)

onMounted(() => {
  fetchQuestion()
})

async function fetchQuestion() {
  loading.value = true
  error.value = null

  try {
    const response = await api.get(`/questions/${route.params.id}`)
    question.value = response.data
  } catch (err) {
    error.value = err.response?.data?.message || 'Soru bulunamadı'
  } finally {
    loading.value = false
  }
}

function selectOption(optionId) {
  if (!showAnswer.value) {
    selectedOption.value = optionId
  }
}

function resetQuestion() {
  selectedOption.value = null
  showAnswer.value = false
}

function getDifficultyClass(difficulty) {
  const map = { 0: 'easy', 1: 'medium', 2: 'hard' }
  return map[difficulty] || 'easy'
}

function getDifficultyText(difficulty) {
  const map = { 0: 'Kolay', 1: 'Orta', 2: 'Zor' }
  return map[difficulty] || 'Kolay'
}

function getOptionsLayoutClass(layout) {
  switch (layout) {
    case 1: return 'options-grid'
    case 2: return 'options-horizontal'
    default: return 'options-vertical'
  }
}

// XSS koruması için HTML temizleme fonksiyonları
function getSafeQuestionText() {
  return sanitizeHtml(question.value?.text || '')
}

function getSafeOptionText(text) {
  return sanitizeHtml(text || '')
}
</script>

<style scoped>
.game-arena {
  display: flex;
  flex-direction: column;
  gap: 16px;
  max-width: 700px;
  margin: 0 auto;
  padding: 20px;
  min-height: calc(100vh - 100px);
}

/* Top Bar */
.top-bar {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 12px;
  padding: 14px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 12px;
}

.question-section {
  display: flex;
  align-items: center;
  gap: 12px;
}

.question-number {
  font-size: 1rem;
  font-weight: 700;
  color: var(--text);
}

.category-badge {
  font-size: 0.8rem;
  font-weight: 600;
  color: var(--primary-light);
  padding: 4px 10px;
  background: rgba(59, 130, 246, 0.15);
  border-radius: 20px;
}

.stats {
  display: flex;
  gap: 12px;
  align-items: center;
}

.difficulty {
  font-size: 0.85rem;
  font-weight: 600;
  padding: 4px 12px;
  border-radius: 20px;
}

.difficulty.easy {
  background: rgba(34, 197, 94, 0.15);
  color: var(--success);
}

.difficulty.medium {
  background: rgba(245, 158, 11, 0.15);
  color: var(--warning);
}

.difficulty.hard {
  background: rgba(239, 68, 68, 0.15);
  color: var(--error);
}

.score {
  font-size: 0.9rem;
  font-weight: 700;
  color: var(--primary-light);
  padding: 6px 12px;
  background: var(--bg-card-light);
  border-radius: 8px;
}

/* State Cards */
.state-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 40px 24px;
  text-align: center;
}

.state-card.waiting {
  background: linear-gradient(135deg, rgba(59, 130, 246, 0.1) 0%, rgba(6, 182, 212, 0.1) 100%);
  border: 2px solid var(--primary);
}

.state-icon {
  font-size: 3.5rem;
  margin-bottom: 16px;
}

.state-card h2 {
  font-size: 1.4rem;
  font-weight: 700;
  margin: 0 0 10px 0;
  color: var(--text);
}

.btn-retry {
  margin-top: 20px;
  padding: 12px 32px;
  background: var(--primary);
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 600;
}

.btn-retry:hover {
  opacity: 0.9;
}

/* Game Container */
.game-container {
  flex: 1;
}

.question-area {
  width: 100%;
}

.question-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 24px;
}

.question-header {
  margin-bottom: 20px;
}

.question-text {
  font-size: 1.15rem;
  font-weight: 600;
  line-height: 1.6;
  color: var(--text);
}

.question-image-container {
  margin: 16px 0;
  text-align: center;
}

.question-image {
  max-width: 100%;
  max-height: 220px;
  border-radius: 12px;
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.2);
}

/* Options Layouts */
.options-vertical {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.options-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 10px;
}

.options-horizontal {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
  gap: 10px;
}

.option-btn {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px 16px;
  background: var(--bg-card-light);
  border: none;
  border-radius: 8px;
  cursor: pointer;
  text-align: left;
  font-size: 0.95rem;
  transition: all 0.2s;
}

.option-btn:hover {
  background: rgba(59, 130, 246, 0.1);
}

.option-btn.selected {
  background: rgba(59, 130, 246, 0.2);
}

.option-btn.correct {
  background: rgba(34, 197, 94, 0.2);
  border: 2px solid var(--success);
}

.option-btn.wrong {
  background: rgba(239, 68, 68, 0.2);
  border: 2px solid var(--error);
}

.option-key {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 32px;
  height: 32px;
  background: var(--primary);
  border: none;
  border-radius: 50%;
  font-weight: 700;
  font-size: 0.9rem;
  color: white;
  flex-shrink: 0;
}

.option-btn.selected .option-key {
  background: var(--success);
}

.option-btn.correct .option-key {
  background: var(--success);
}

.option-btn.wrong .option-key {
  background: var(--error);
}

.option-text {
  flex: 1;
  font-weight: 500;
  font-size: 0.95rem;
  color: var(--text);
}

/* Action Bar */
.action-bar {
  margin-top: 20px;
  display: flex;
  justify-content: center;
  gap: 12px;
}

.btn-check, .btn-reset {
  padding: 14px 40px;
  border: none;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s;
}

.btn-check {
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  box-shadow: 0 2px 8px var(--glow-blue);
}

.btn-check:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 12px var(--glow-blue);
}

.btn-reset {
  background: var(--bg-card-light);
  color: var(--text);
}

.btn-reset:hover {
  background: var(--bg-card);
}

/* Question Info */
.question-info {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 12px;
  padding: 16px 20px;
  display: flex;
  gap: 24px;
  flex-wrap: wrap;
}

.info-item {
  display: flex;
  gap: 8px;
}

.info-label {
  color: var(--text-muted);
  font-size: 0.85rem;
}

.info-value {
  color: var(--text);
  font-size: 0.85rem;
  font-weight: 600;
  font-family: monospace;
}

/* Support for HTML content (from Quill editor) */
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

:deep(ul), :deep(ol) {
  margin: 0.5rem 0;
  padding-left: 1.5rem;
}

/* Responsive */
@media (max-width: 768px) {
  .top-bar {
    flex-direction: column;
    align-items: flex-start;
    gap: 12px;
  }

  .options-grid {
    grid-template-columns: 1fr;
  }
}
</style>

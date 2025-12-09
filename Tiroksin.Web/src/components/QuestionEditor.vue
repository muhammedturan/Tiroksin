<template>
  <div class="question-editor">
    <!-- Question Text -->
    <div class="question-header" @click="$emit('edit-question')">
      <div class="question-block">?</div>
      <div class="question-text" :class="{ 'placeholder': !hasQuestionText }">
        <span v-if="hasQuestionText" v-html="safeQuestionText"></span>
        <span v-else>Soruyu yazmak için tıklayın...</span>
      </div>
      <span class="edit-icon">✏️</span>
    </div>

    <!-- Options - Always 2x2 Grid -->
    <div class="options-grid">
      <div
        v-for="(option, index) in options"
        :key="index"
        class="option-item"
        :class="{
          'option-item--correct': option.isCorrect,
          'option-item--filled': hasTextContent(option.text)
        }"
      >
        <button
          type="button"
          :class="[
            'option-letter-btn',
            `option-letter-btn--${getOptionColor(index)}`,
            { 'option-letter-btn--selected': option.isCorrect }
          ]"
          @click.stop="$emit('set-correct', index)"
          :title="option.isCorrect ? 'Doğru cevap' : 'Doğru cevap olarak işaretle'"
        >
          {{ getOptionLetter(index) }}
        </button>
        <div class="option-content" @click="$emit('edit-option', index)">
          <span v-if="hasTextContent(option.text)" v-html="getSafeOptionText(option.text)" class="option-text"></span>
          <span v-else class="placeholder">Şık {{ getOptionLetter(index) }}...</span>
        </div>
        <button class="edit-icon-btn" @click="$emit('edit-option', index)" title="Düzenle">
          ✏️
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue'
import { sanitizeHtml } from '../utils/sanitize'

const props = defineProps({
  // Soru metni
  questionText: {
    type: String,
    default: ''
  },
  // Seçenekler dizisi
  options: {
    type: Array,
    default: () => [
      { text: '', isCorrect: false },
      { text: '', isCorrect: false },
      { text: '', isCorrect: false },
      { text: '', isCorrect: false },
      { text: '', isCorrect: false }
    ]
  }
})

defineEmits(['edit-question', 'edit-option', 'set-correct'])

// Soru metni var mı kontrol
const hasQuestionText = computed(() => {
  return hasTextContent(props.questionText)
})

// Güvenli soru metni
const safeQuestionText = computed(() => {
  return sanitizeHtml(props.questionText || '')
})

// Metin içeriği var mı kontrol (HTML taglerini kaldırarak)
function hasTextContent(html) {
  if (!html) return false
  const text = html.replace(/<[^>]*>/g, '').trim()
  return text.length > 0
}

// Seçenek harfi
function getOptionLetter(index) {
  return String.fromCharCode(65 + index) // A, B, C, D, E
}

// Seçenek rengi
function getOptionColor(index) {
  const colors = ['red', 'blue', 'yellow', 'green', 'purple']
  return colors[index % colors.length]
}

// Güvenli seçenek metni
function getSafeOptionText(text) {
  return sanitizeHtml(text || '')
}
</script>

<style scoped>
.question-editor {
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-lg);
  padding: 20px;
  box-shadow: 0 4px 0 var(--border);
}

/* Question Header */
.question-header {
  display: flex;
  align-items: flex-start;
  gap: 14px;
  margin-bottom: 16px;
  padding: 16px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  cursor: pointer;
  transition: all 0.15s ease;
}

.question-header:hover {
  border-color: var(--mario-blue);
  background: var(--bg-card-hover);
}

/* Mario Question Block */
.question-block {
  display: flex;
  align-items: center;
  justify-content: center;
  min-width: 44px;
  height: 44px;
  background: linear-gradient(180deg, #fbd000 0%, #e5a000 100%);
  border: 3px solid #8b5a2b;
  border-radius: 6px;
  font-size: 1.5rem;
  font-weight: 900;
  color: #8b5a2b;
  text-shadow: 1px 1px 0 #fbd000;
  box-shadow:
    inset 0 2px 0 rgba(255, 255, 255, 0.3),
    inset 0 -2px 0 rgba(0, 0, 0, 0.2),
    0 3px 0 #8b5a2b;
  flex-shrink: 0;
}

.question-text {
  flex: 1;
  font-size: 1.1rem;
  font-weight: 600;
  line-height: 1.5;
  color: var(--text);
}

.question-text.placeholder {
  color: var(--text-muted);
  font-weight: 400;
}

.edit-icon {
  font-size: 1.2rem;
  opacity: 0.5;
  transition: opacity 0.15s;
  flex-shrink: 0;
}

.question-header:hover .edit-icon {
  opacity: 1;
}

/* Options Grid - Always 2x2 */
.options-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 12px;
}

/* Option Item */
.option-item {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px 16px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  transition: all 0.15s ease;
  min-height: 52px;
}

.option-item:hover {
  border-color: var(--mario-blue);
  background: var(--bg-card-hover);
}

.option-item--filled {
  border-color: var(--text-muted);
}

.option-item--correct {
  border-color: var(--mario-green);
  background: rgba(67, 176, 71, 0.08);
}

/* Option Letter Button - Circle */
.option-letter-btn {
  display: flex;
  align-items: center;
  justify-content: center;
  min-width: 36px;
  height: 36px;
  border-radius: 50%;
  border: 3px solid transparent;
  cursor: pointer;
  transition: all 0.15s ease;
  font-weight: 800;
  font-size: 0.95rem;
  color: white;
  flex-shrink: 0;
  box-shadow: 0 2px 0 rgba(0, 0, 0, 0.2);
}

.option-letter-btn--red {
  background: var(--mario-red, #e52521);
}

.option-letter-btn--blue {
  background: var(--mario-blue, #049cd8);
}

.option-letter-btn--yellow {
  background: var(--mario-yellow, #fbd000);
  color: #333;
}

.option-letter-btn--green {
  background: var(--mario-green, #43b047);
}

.option-letter-btn--purple {
  background: #9b59b6;
}

.option-letter-btn:hover {
  transform: scale(1.1);
  box-shadow: 0 4px 0 rgba(0, 0, 0, 0.2);
}

/* Selected state - checkmark ring */
.option-letter-btn--selected {
  border-color: var(--mario-green);
  box-shadow: 0 0 0 3px rgba(67, 176, 71, 0.3), 0 2px 0 rgba(0, 0, 0, 0.2);
}

.option-letter-btn--selected::after {
  content: '✓';
  position: absolute;
  top: -6px;
  right: -6px;
  width: 18px;
  height: 18px;
  background: var(--mario-green);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.65rem;
  color: white;
  font-weight: 800;
}

.option-letter-btn {
  position: relative;
}

/* Option Content */
.option-content {
  flex: 1;
  min-height: 36px;
  display: flex;
  align-items: center;
  cursor: pointer;
}

.option-text {
  color: var(--text);
  line-height: 1.4;
  font-size: 0.9rem;
  font-weight: 600;
}

.placeholder {
  color: var(--text-muted);
}

/* Edit Icon Button */
.edit-icon-btn {
  background: none;
  border: none;
  font-size: 1rem;
  cursor: pointer;
  opacity: 0.4;
  transition: opacity 0.15s;
  padding: 4px;
  flex-shrink: 0;
}

.option-item:hover .edit-icon-btn {
  opacity: 1;
}

/* Grid Layout - Odd item centering (5th option) */
.options-grid .option-item:last-child:nth-child(odd) {
  grid-column: 1 / -1;
  width: calc(50% - 6px);
  justify-self: center;
}

/* Responsive */
@media (max-width: 600px) {
  .question-editor {
    padding: 16px;
  }

  .question-header {
    padding: 12px;
  }

  .question-text {
    font-size: 1rem;
  }

  .options-grid {
    grid-template-columns: 1fr;
  }

  .options-grid .option-item:last-child:nth-child(odd) {
    width: 100%;
  }

  .option-item {
    padding: 12px 14px;
    min-height: 46px;
  }

  .option-text {
    font-size: 0.85rem;
  }
}

/* HTML Content Support */
:deep(img) {
  max-width: 100%;
  height: auto;
  border-radius: 4px;
  margin: 0.3rem 0;
}

:deep(p) {
  margin: 0;
  line-height: 1.4;
}

:deep(ul), :deep(ol) {
  margin: 0.3rem 0;
  padding-left: 1rem;
}
</style>

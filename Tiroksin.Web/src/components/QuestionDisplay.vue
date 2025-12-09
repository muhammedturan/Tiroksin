<template>
  <div class="question-display">
    <!-- Question Text -->
    <div class="question-header">
      <div class="question-block">?</div>
      <div class="question-text" v-html="safeQuestionText"></div>
    </div>

    <!-- Question Image (if exists) -->
    <div v-if="question?.imageUrl" class="question-image-container">
      <img :src="question.imageUrl" alt="Question Image" class="question-image" />
    </div>

    <!-- Options - Always 2x2 Grid -->
    <div v-if="showOptions" class="options-grid">
      <component
        :is="interactive ? 'button' : 'div'"
        v-for="(option, index) in question?.options"
        :key="option.id"
        :class="[
          'option-item',
          interactive ? 'option-interactive' : 'option-readonly',
          { selected: selectedOptionId === option.id }
        ]"
        :disabled="interactive && disabled"
        @click="interactive && !disabled && handleOptionClick(option.id)"
      >
        <span :class="['option-letter', `option-letter--${getOptionColor(index)}`]">{{ getOptionLetter(index) }}</span>
        <span class="option-content" v-html="getSafeOptionText(option.text)"></span>
      </component>
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue'
import { sanitizeHtml } from '../utils/sanitize'

const props = defineProps({
  // Soru objesi
  question: {
    type: Object,
    required: true
  },
  // Seçenekleri göster
  showOptions: {
    type: Boolean,
    default: true
  },
  // Interaktif mi (tıklanabilir)
  interactive: {
    type: Boolean,
    default: false
  },
  // Seçili seçenek ID'si
  selectedOptionId: {
    type: String,
    default: null
  },
  // Disabled durumu (interactive modda)
  disabled: {
    type: Boolean,
    default: false
  }
})

const emit = defineEmits(['select'])

// Güvenli soru metni
const safeQuestionText = computed(() => {
  return sanitizeHtml(props.question?.text || '')
})

// Seçenek harfi (A, B, C, D, E)
function getOptionLetter(index) {
  return String.fromCharCode(65 + index)
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

// Seçenek tıklama
function handleOptionClick(optionId) {
  emit('select', optionId)
}
</script>

<style scoped>
.question-display {
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

/* Question Image */
.question-image-container {
  text-align: center;
  margin-bottom: 16px;
}

.question-image {
  max-width: 100%;
  max-height: 200px;
  border-radius: var(--radius-md);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}

/* Options Grid - Always 2x2 */
.options-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 8px;
}

/* Option Item Base */
.option-item {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 14px 16px;
  border-radius: var(--radius-md);
  font-size: 0.9rem;
  font-weight: 600;
  text-align: left;
  min-height: 52px;
}

/* Readonly Options (Spectator) */
.option-readonly {
  background: var(--bg-input);
  border: 1px solid var(--border);
  color: var(--text-muted);
  opacity: 0.8;
}

/* Interactive Options (GameArena) */
.option-interactive {
  background: var(--bg-card);
  border: 2px solid var(--border);
  color: var(--text);
  cursor: pointer;
  transition: all 0.15s ease;
  box-shadow: 0 3px 0 var(--border);
}

.option-interactive:hover:not(:disabled) {
  transform: translateY(-2px);
  border-color: var(--primary);
  box-shadow: 0 5px 0 var(--border);
}

.option-interactive:active:not(:disabled) {
  transform: translateY(1px);
  box-shadow: 0 1px 0 var(--border);
}

.option-interactive.selected {
  transform: translateY(1px) scale(0.99);
  border-color: var(--primary);
  background: var(--primary-soft);
  box-shadow: 0 1px 0 var(--border) !important;
}

.option-interactive.selected::after {
  content: '✓';
  position: absolute;
  top: 6px;
  right: 6px;
  width: 20px;
  height: 20px;
  background: var(--primary);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.75rem;
  color: white;
  font-weight: 800;
  animation: checkPop 0.25s ease;
}

@keyframes checkPop {
  0% { transform: scale(0); }
  50% { transform: scale(1.2); }
  100% { transform: scale(1); }
}

.option-interactive:disabled {
  cursor: not-allowed;
  opacity: 0.7;
}

.option-interactive {
  position: relative;
  overflow: hidden;
}

/* Option Letter Circle */
.option-letter {
  display: flex;
  align-items: center;
  justify-content: center;
  min-width: 32px;
  height: 32px;
  border-radius: 50%;
  font-weight: 800;
  font-size: 0.9rem;
  flex-shrink: 0;
  color: white;
  box-shadow: 0 2px 0 rgba(0, 0, 0, 0.2);
}

.option-letter--red {
  background: var(--mario-red, #e52521);
}

.option-letter--blue {
  background: var(--mario-blue, #049cd8);
}

.option-letter--yellow {
  background: var(--mario-yellow, #fbd000);
  color: #333;
}

.option-letter--green {
  background: var(--mario-green, #43b047);
}

.option-letter--purple {
  background: #9b59b6;
}

/* Option Content */
.option-content {
  flex: 1;
  line-height: 1.3;
}

/* Grid Layout - Odd item centering */
.options-grid .option-item:last-child:nth-child(odd) {
  grid-column: 1 / -1;
  width: calc(50% - 4px);
  justify-self: center;
}

/* Responsive */
@media (max-width: 600px) {
  .question-display {
    padding: 16px;
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

  .option-letter {
    min-width: 28px;
    height: 28px;
    font-size: 0.8rem;
  }

  .option-content {
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

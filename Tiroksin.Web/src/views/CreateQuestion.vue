<template>
  <div class="create-question">
    <div class="form-container">
      <!-- Form Card with MarioDiv -->
      <MarioDiv color="white" icon="📝" title="Yeni Soru Ekle">
        <!-- Kategori Secimi -->
        <div class="form-section">
          <div class="category-grid">
            <!-- 1. Sınav Tipi (Root - parent yok) -->
            <MarioSelect
              v-model="form.examType"
              parameter-key="EXAM_TYPE"
            />

            <!-- 2. Kategori (parent: examType) -->
            <MarioSelect
              v-model="form.category"
              parameter-key="CATEGORY"
              :parent-value="form.examType"
            />

            <!-- 3. Konu (parent: category) -->
            <MarioSelect
              v-model="form.subject"
              parameter-key="SUBJECT"
              :parent-value="form.category"
            />

            <!-- 4. Alt Konu (parent: subject) -->
            <MarioSelect
              v-model="form.topic"
              parameter-key="TOPIC"
              :parent-value="form.subject"
            />
          </div>
        </div>

        <!-- Soru Alani -->
        <div class="form-section">
          <label class="section-label">Soru</label>
          <div
            class="question-box"
            :class="{ 'question-box--filled': hasTextContent(form.text) }"
            @click="openQuestionEditor"
          >
            <span class="question-number">1</span>
            <div class="question-content">
              <div v-if="hasTextContent(form.text)" v-html="form.text" class="question-text"></div>
              <span v-else class="placeholder">Soruyu yazmak için tıklayın...</span>
            </div>
            <span class="edit-icon">✏️</span>
          </div>
        </div>

        <!-- Layout Secici -->
        <div class="form-section">
          <label class="section-label">Şık Düzeni</label>
          <div class="layout-buttons">
            <MarioButton
              :color="form.optionsLayout === 'Vertical' ? 'blue' : 'gray'"
              size="sm"
              @click="form.optionsLayout = 'Vertical'"
            >
              <template #icon>☰</template>
              Dikey
            </MarioButton>
            <MarioButton
              :color="form.optionsLayout === 'Grid' ? 'blue' : 'gray'"
              size="sm"
              @click="form.optionsLayout = 'Grid'"
            >
              <template #icon>⊞</template>
              Grid
            </MarioButton>
            <MarioButton
              :color="form.optionsLayout === 'Horizontal' ? 'blue' : 'gray'"
              size="sm"
              @click="form.optionsLayout = 'Horizontal'"
            >
              <template #icon>═</template>
              Yatay
            </MarioButton>
          </div>
        </div>

        <!-- Secenekler -->
        <div class="form-section">
          <label class="section-label">Şıklar <span class="hint">(Doğru cevabı seçmek için harfe tıklayın)</span></label>
          <div :class="getLayoutClass(form.optionsLayout)">
            <div
              v-for="(option, index) in form.options"
              :key="index"
              class="option-item"
              :class="{
                'option-item--correct': option.isCorrect,
                'option-item--filled': hasTextContent(option.text),
                'option-item--horizontal': form.optionsLayout === 'Horizontal'
              }"
              @click="form.optionsLayout === 'Horizontal' ? openOptionEditor(index) : null"
            >
              <button
                type="button"
                class="option-letter-btn"
                :class="{ 'option-letter-btn--selected': option.isCorrect }"
                @click.stop="setCorrectAnswer(index)"
                :title="option.isCorrect ? 'Doğru cevap' : 'Doğru cevap olarak işaretle'"
              >
                {{ String.fromCharCode(65 + index) }}
              </button>
              <div v-if="form.optionsLayout !== 'Horizontal'" class="option-content" @click="openOptionEditor(index)">
                <span v-if="hasTextContent(option.text)" v-html="option.text" class="option-text"></span>
                <span v-else class="placeholder">Şık {{ String.fromCharCode(65 + index) }}...</span>
              </div>
              <button v-if="form.optionsLayout !== 'Horizontal'" class="edit-icon-btn" @click="openOptionEditor(index)" title="Düzenle">
                ✏️
              </button>
              <!-- Horizontal mode: show fill status indicator -->
              <span v-if="form.optionsLayout === 'Horizontal' && hasTextContent(option.text)" class="horizontal-fill-dot">●</span>
            </div>
          </div>
        </div>

        <!-- Uyari -->
        <div v-if="showWarning" class="warning-box">
          <span class="warning-icon">⚠️</span>
          <span>{{ warningMessage }}</span>
        </div>

        <!-- Butonlar -->
        <div class="form-actions">
          <MarioButton color="gray" @click="router.back()">
            İptal
          </MarioButton>
          <MarioButton
            color="green"
            :disabled="!canSubmit || loading"
            :loading="loading"
            @click="handleSubmit"
          >
            <template #icon>✓</template>
            Onaya Gönder
          </MarioButton>
        </div>
      </MarioDiv>
    </div>

    <!-- Editor Modal -->
    <Teleport to="body">
      <Transition name="modal">
        <div v-if="showEditorModal" class="modal-overlay" @click="closeEditorModal">
          <div class="modal-card" @click.stop>
            <div class="modal-header">
              <div class="modal-icon">{{ editorType === 'question' ? '❓' : '✍️' }}</div>
              <h2 class="modal-title">{{ editorTitle }}</h2>
              <button class="modal-close" @click="closeEditorModal">✕</button>
            </div>

            <div class="modal-body">
              <QuillEditor
                v-model:content="editorContent"
                contentType="html"
                theme="snow"
                :toolbar="editorToolbar"
                placeholder="Metninizi buraya yazın..."
                class="quill-editor"
              />
            </div>

            <div class="modal-footer">
              <MarioButton color="gray" @click="closeEditorModal">
                İptal
              </MarioButton>
              <MarioButton color="green" @click="saveEditorContent">
                <template #icon>✓</template>
                Kaydet
              </MarioButton>
            </div>
          </div>
        </div>
      </Transition>
    </Teleport>
  </div>
</template>

<script setup>
import { ref, computed } from 'vue'
import { useRouter } from 'vue-router'
import api from '../services/api'
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css'
import MarioButton from '../components/MarioButton.vue'
import MarioSelect from '../components/MarioSelect.vue'
import MarioDiv from '../components/MarioDiv.vue'

const router = useRouter()
const loading = ref(false)

const currentUserId = 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6'

const editorToolbar = [
  ['bold', 'italic', 'underline'],
  ['image']
]

const form = ref({
  category: '',
  subject: '',
  topic: '',
  examType: '',
  text: '',
  optionsLayout: 'Vertical',
  options: [
    { text: '', isCorrect: false },
    { text: '', isCorrect: false },
    { text: '', isCorrect: false },
    { text: '', isCorrect: false },
    { text: '', isCorrect: false }
  ]
})

// Modal state
const showEditorModal = ref(false)
const editorContent = ref('')
const editorTitle = ref('')
const editorType = ref('')
const editingOptionIndex = ref(-1)


const hasTextContent = (html) => {
  if (!html) return false
  const text = html.replace(/<[^>]*>/g, '').trim()
  return text.length > 0
}

const hasCorrectAnswer = computed(() => {
  return form.value.options.some(opt => opt.isCorrect)
})

const filledOptionsCount = computed(() => {
  return form.value.options.filter(opt => hasTextContent(opt.text)).length
})

const showWarning = computed(() => {
  return filledOptionsCount.value > 0 && !hasCorrectAnswer.value
})

const warningMessage = computed(() => {
  if (!hasCorrectAnswer.value && filledOptionsCount.value > 0) {
    return 'Doğru cevabı işaretlemeyi unutmayın!'
  }
  return ''
})

const canSubmit = computed(() => {
  const correctOption = form.value.options.find(opt => opt.isCorrect)
  const isCorrectAnswerFilled = correctOption && hasTextContent(correctOption.text)

  return (
    form.value.category &&
    form.value.examType &&
    hasTextContent(form.value.text) &&
    filledOptionsCount.value >= 2 &&
    hasCorrectAnswer.value &&
    isCorrectAnswerFilled
  )
})

const getLayoutClass = (layout) => {
  switch (layout) {
    case 'Grid':
      return 'options-grid options-grid--2col'
    case 'Horizontal':
      return 'options-grid options-grid--5col'
    default:
      return 'options-grid options-grid--1col'
  }
}

const openQuestionEditor = () => {
  editorTitle.value = 'Soru Metni'
  editorType.value = 'question'
  editorContent.value = form.value.text
  showEditorModal.value = true
}

const openOptionEditor = (index) => {
  editorTitle.value = `Şık ${String.fromCharCode(65 + index)}`
  editorType.value = 'option'
  editingOptionIndex.value = index
  editorContent.value = form.value.options[index].text
  showEditorModal.value = true
}

const closeEditorModal = () => {
  showEditorModal.value = false
  editorContent.value = ''
  editorTitle.value = ''
  editorType.value = ''
  editingOptionIndex.value = -1
}

const saveEditorContent = () => {
  if (editorType.value === 'question') {
    form.value.text = editorContent.value
  } else if (editorType.value === 'option' && editingOptionIndex.value >= 0) {
    form.value.options[editingOptionIndex.value].text = editorContent.value
  }
  closeEditorModal()
}

const setCorrectAnswer = (index) => {
  form.value.options.forEach(opt => opt.isCorrect = false)
  form.value.options[index].isCorrect = true
}

const handleSubmit = async () => {
  if (!canSubmit.value) return

  try {
    loading.value = true
    const filledOptions = form.value.options.filter(opt => hasTextContent(opt.text))

    await api.post('/questions', {
      category: form.value.category,
      subject: form.value.subject,
      topic: form.value.topic,
      examType: form.value.examType,
      createdBy: currentUserId,
      text: form.value.text,
      optionsLayout: form.value.optionsLayout,
      options: filledOptions
    })

    alert('Soru başarıyla gönderildi!')
    router.push('/')
  } catch (error) {
    const errorMessage = error.response?.data?.error || 'Soru eklenirken bir hata oluştu'
    alert(errorMessage)
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.create-question {
  min-height: calc(100vh - 80px);
  padding: 24px;
}

.form-container {
  max-width: 800px;
  margin: 0 auto;
}

/* Form Section */
.form-section {
  margin-bottom: 28px;
}

.form-section:last-of-type {
  margin-bottom: 0;
}

/* Category Grid */
.category-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 16px;
}

/* Section Labels */
.section-label {
  display: block;
  font-size: 0.8rem;
  font-weight: 700;
  color: var(--text);
  text-transform: uppercase;
  letter-spacing: 0.5px;
  margin-bottom: 12px;
}

.section-label .hint {
  font-weight: 500;
  color: var(--text-muted);
  text-transform: none;
  font-size: 0.75rem;
}

/* Question Box */
.question-box {
  display: flex;
  align-items: flex-start;
  gap: 14px;
  padding: 16px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  cursor: pointer;
  transition: all 0.15s ease;
}

.question-box:hover {
  border-color: var(--mario-blue);
  background: var(--bg-card-hover);
}

.question-box--filled {
  border-color: var(--mario-green);
}

.question-box--filled:hover {
  border-color: var(--mario-blue);
}

.question-number {
  display: flex;
  align-items: center;
  justify-content: center;
  min-width: 40px;
  height: 40px;
  background: var(--mario-red);
  color: white;
  font-weight: 800;
  font-size: 1.1rem;
  border-radius: var(--radius-sm);
  box-shadow: 0 3px 0 #a31b18;
}

.question-content {
  flex: 1;
  min-height: 40px;
  display: flex;
  align-items: center;
}

.question-text {
  color: var(--text);
  line-height: 1.5;
}

.placeholder {
  color: var(--text-muted);
}

.edit-icon {
  font-size: 1.2rem;
  opacity: 0.5;
  transition: opacity 0.15s;
}

.question-box:hover .edit-icon {
  opacity: 1;
}

/* Layout Buttons */
.layout-buttons {
  display: flex;
  gap: 10px;
  flex-wrap: wrap;
}

/* Options Grid */
.options-grid {
  display: grid;
  gap: 12px;
}

.options-grid--1col {
  grid-template-columns: 1fr;
}

.options-grid--2col {
  grid-template-columns: repeat(2, 1fr);
}

.options-grid--5col {
  grid-template-columns: repeat(5, 1fr);
  gap: 10px;
}

/* Option Item */
.option-item {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 12px 14px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  transition: all 0.15s ease;
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

/* Option Letter Button */
.option-letter-btn {
  display: flex;
  align-items: center;
  justify-content: center;
  min-width: 36px;
  height: 36px;
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-sm);
  cursor: pointer;
  transition: all 0.15s ease;
  font-weight: 800;
  font-size: 0.95rem;
  color: var(--text);
}

.option-letter-btn:hover {
  border-color: var(--mario-green);
  background: rgba(67, 176, 71, 0.1);
  transform: scale(1.05);
}

.option-letter-btn--selected {
  background: var(--mario-green);
  border-color: var(--mario-green);
  color: white;
  box-shadow: 0 3px 0 #2d8a31;
}

.option-letter-btn--selected:hover {
  background: var(--mario-green);
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
}

.option-item:hover .edit-icon-btn {
  opacity: 1;
}

/* Horizontal Mode - Compact cards */
.option-item--horizontal {
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 16px 12px;
  cursor: pointer;
  min-height: 80px;
  position: relative;
}

.option-item--horizontal .option-letter-btn {
  min-width: 44px;
  height: 44px;
  font-size: 1.1rem;
}

.option-item--horizontal:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}

/* Fill indicator dot for horizontal mode */
.horizontal-fill-dot {
  position: absolute;
  top: 8px;
  right: 8px;
  color: var(--mario-green);
  font-size: 0.6rem;
}

/* Warning Box */
.warning-box {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 14px 18px;
  background: rgba(251, 208, 0, 0.12);
  border: 2px solid var(--mario-yellow);
  border-radius: var(--radius-md);
  margin-top: 20px;
  color: #92400e;
  font-weight: 600;
  font-size: 0.9rem;
}

.warning-icon {
  font-size: 1.2rem;
}

/* Form Actions */
.form-actions {
  display: flex;
  gap: 12px;
  justify-content: flex-end;
  margin-top: 28px;
  padding-top: 24px;
  border-top: 2px solid var(--border);
}

/* Modal */
.modal-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.7);
  backdrop-filter: blur(8px);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
  padding: 24px;
}

.modal-card {
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-xl);
  max-width: 700px;
  width: 100%;
  max-height: 90vh;
  overflow-y: auto;
  box-shadow: var(--shadow-lg);
}

.modal-header {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 20px 24px;
  border-bottom: 2px solid var(--border);
}

.modal-icon {
  font-size: 1.3rem;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 44px;
  height: 44px;
  background: var(--mario-blue);
  border-radius: var(--radius-md);
  box-shadow: 0 3px 0 #037bb5;
}

.modal-title {
  flex: 1;
  font-size: 1.2rem;
  font-weight: 800;
  color: var(--text);
  margin: 0;
}

.modal-close {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 36px;
  height: 36px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-sm);
  cursor: pointer;
  font-size: 1rem;
  font-weight: 700;
  color: var(--text-muted);
  transition: all 0.15s ease;
}

.modal-close:hover {
  background: var(--mario-red);
  border-color: var(--mario-red);
  color: white;
}

.modal-body {
  padding: 24px;
}

.modal-footer {
  display: flex;
  gap: 12px;
  justify-content: flex-end;
  padding: 20px 24px;
  border-top: 2px solid var(--border);
}

/* Modal Animation */
.modal-enter-active,
.modal-leave-active {
  transition: all 0.25s ease;
}

.modal-enter-from,
.modal-leave-to {
  opacity: 0;
}

.modal-enter-from .modal-card,
.modal-leave-to .modal-card {
  transform: translateY(20px) scale(0.95);
}

/* Quill Editor */
.quill-editor {
  border-radius: var(--radius-md);
  overflow: hidden;
}

:deep(.ql-toolbar) {
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-bottom: none;
  border-radius: var(--radius-md) var(--radius-md) 0 0;
}

:deep(.ql-container) {
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-top: 1px solid var(--border);
  border-radius: 0 0 var(--radius-md) var(--radius-md);
  color: var(--text);
  font-size: 1rem;
  font-family: var(--font-primary);
}

:deep(.ql-editor) {
  min-height: 200px;
}

:deep(.ql-editor.ql-blank::before) {
  color: var(--text-muted);
  font-style: normal;
}

:deep(.ql-stroke) {
  stroke: var(--text-muted);
}

:deep(.ql-fill) {
  fill: var(--text-muted);
}

:deep(.ql-picker-label) {
  color: var(--text-muted);
}

:deep(img) {
  max-width: 100%;
  height: auto;
  border-radius: var(--radius-sm);
  margin: 8px 0;
}

/* Responsive */
@media (max-width: 768px) {
  .create-question {
    padding: 16px;
  }

  .form-card {
    padding: 20px;
  }

  .category-grid {
    grid-template-columns: 1fr;
  }

  .options-grid--5col {
    grid-template-columns: repeat(2, 1fr);
  }

  .options-grid--2col {
    grid-template-columns: 1fr;
  }

  .layout-buttons {
    width: 100%;
  }

  .layout-buttons > * {
    flex: 1;
  }

  .form-actions {
    flex-direction: column;
  }

  .form-actions > * {
    width: 100%;
  }

  .modal-card {
    margin: 16px;
  }
}
</style>

<template>
  <div class="create-question">
    <div class="question-form-container">
      <!-- Önizleme Formatında Soru -->
      <div class="form-card">
        <h1 class="form-title">Yeni Soru Ekle</h1>

        <!-- Header - Soru Kategorileri -->
        <div class="category-grid">
            <div>
              <label class="form-label">Ders</label>
              <select
                v-model="form.subjectId"
                @change="onSubjectChange"
                class="form-select">
                <option value="">-- Ders Seçin --</option>
                <option v-for="subject in subjects" :key="subject.id" :value="subject.id">{{ subject.name }}</option>
              </select>
            </div>
            <div>
              <label class="form-label">Konu</label>
              <select
                v-model="form.topicId"
                :disabled="!form.subjectId"
                class="form-select"
                :class="{ disabled: !form.subjectId }">
                <option value="">-- Konu Seçin --</option>
                <option v-for="topic in filteredTopics" :key="topic.id" :value="topic.id">{{ topic.name }}</option>
              </select>
            </div>
            <div>
              <label class="form-label">Sınav Tipi</label>
              <select
                v-model="form.examType"
                class="form-select">
                <option value="">-- Sınav Tipi Seçin --</option>
                <option value="YksTyt">YKS - TYT</option>
                <option value="YksAyt">YKS - AYT</option>
                <option value="Lgs">LGS</option>
                <option value="Kpss">KPSS</option>
                <option value="Ales">ALES</option>
                <option value="Dgs">DGS</option>
                <option value="Custom">Özel/Diğer</option>
              </select>
            </div>
            <div>
              <label class="form-label">Zorluk</label>
              <select
                v-model="form.difficulty"
                class="form-select">
                <option value="Easy">Kolay</option>
                <option value="Medium">Orta</option>
                <option value="Hard">Zor</option>
              </select>
            </div>
          </div>

          <!-- Soru -->
          <div class="question-section">
            <div
              @click="openQuestionEditor"
              class="question-preview"
              :class="{ 'question-preview--empty': !hasTextContent(form.text) }"
            >
              <span class="question-number">1</span>
              <div v-if="hasTextContent(form.text)" v-html="form.text" class="question-text"></div>
              <div v-else class="question-placeholder">Sorunuzu girin...</div>
              <div class="edit-icon">✏️</div>
            </div>
          </div>

          <!-- Layout Seçici İkonlar -->
          <div class="layout-selector">
            <button
              @click="form.optionsLayout = 'Vertical'"
              class="layout-btn"
              :class="{ 'layout-btn--active': form.optionsLayout === 'Vertical' }"
              title="Dikey"
            >
              ☰
            </button>
            <button
              @click="form.optionsLayout = 'Grid'"
              class="layout-btn"
              :class="{ 'layout-btn--active': form.optionsLayout === 'Grid' }"
              title="Grid"
            >
              ⊞
            </button>
            <button
              @click="form.optionsLayout = 'Horizontal'"
              class="layout-btn"
              :class="{ 'layout-btn--active': form.optionsLayout === 'Horizontal' }"
              title="Yatay"
            >
              ▭▭▭▭▭
            </button>
          </div>

          <!-- Cevaplar -->
          <div :class="getLayoutClass(form.optionsLayout)">
            <div
              v-for="(option, index) in form.options"
              :key="index"
              class="option-item"
              :class="{ 'option-item--empty': !hasTextContent(option.text) }"
            >
              <input
                type="radio"
                :name="`question-preview`"
                :checked="option.isCorrect"
                @click="setCorrectAnswer(index)"
                class="option-radio"
              />
              <div
                @click="openOptionEditor(index)"
                class="option-content"
              >
                <div class="option-text-wrapper">
                  <span class="option-letter">{{ String.fromCharCode(65 + index) }})</span>
                  <span v-if="hasTextContent(option.text)" v-html="option.text"></span>
                  <span v-else class="option-placeholder">Cevabı girin...</span>
                </div>
              </div>
              <div
                @click="openOptionEditor(index)"
                class="edit-icon edit-icon--small"
              >
                ✏️
              </div>
            </div>
          </div>

        <!-- Uyarı -->
        <div v-if="!hasCorrectAnswer && form.options.some(opt => hasTextContent(opt.text))" class="warning-box">
          <p class="warning-text">
            ⚠️ En az bir doğru cevap işaretlemelisiniz
          </p>
        </div>

        <!-- Kaydet Butonu -->
        <div class="action-buttons">
          <button @click="router.back()" class="btn-cancel">
            İptal
          </button>
          <button
            @click="handleSubmit"
            :disabled="!canSubmit || loading"
            class="btn-submit"
            :class="{ 'btn-submit--disabled': !canSubmit || loading }"
          >
            {{ loading ? 'Gönderiliyor...' : 'Onaya Gönder' }}
          </button>
        </div>
      </div>
    </div>

    <!-- MODAL: Soru/Cevap Editörü -->
    <div
      v-if="showEditorModal"
      @click="closeEditorModal"
      class="modal-overlay"
    >
      <div @click.stop class="modal-content">
        <h2 class="form-title">{{ editorTitle }}</h2>

        <QuillEditor
          v-model:content="editorContent"
          contentType="html"
          theme="snow"
          :toolbar="editorToolbar"
          placeholder="Metninizi buraya yazın... Resim eklemek için toolbar'daki resim ikonuna tıklayın."
          class="quill-editor"
        />

        <div class="modal-actions">
          <button @click="closeEditorModal" class="btn-cancel">
            İptal
          </button>
          <button @click="saveEditorContent" class="btn-submit">
            Kaydet
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import api from '../services/api'
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css'

const router = useRouter()
const loading = ref(false)
const subjects = ref([])
const topics = ref([])

// Mock user ID (gerçek uygulamada auth'dan gelecek)
const currentUserId = 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6'

// Quill editor toolbar
const editorToolbar = [
  ['bold', 'italic', 'underline'],
  ['image']
]

const form = ref({
  subjectId: '',
  topicId: '',
  examType: '',
  difficulty: 'Medium',
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

// Seçilen derse göre konuları filtrele
const filteredTopics = computed(() => {
  if (!form.value.subjectId) return []
  return topics.value.filter(t => t.subjectId === form.value.subjectId)
})

// Ders değiştiğinde konuyu sıfırla
const onSubjectChange = () => {
  form.value.topicId = ''
}

// Modal state
const showEditorModal = ref(false)
const editorContent = ref('')
const editorTitle = ref('')
const editorType = ref('') // 'question' veya 'option'
const editingOptionIndex = ref(-1)

// Subject ve Topic'leri yükle
onMounted(async () => {
  try {
    // Şimdilik mock data kullan (backend endpoint'leri eklenecek)
    subjects.value = [
      { id: '11111111-1111-1111-1111-111111111111', name: 'Matematik' },
      { id: '22222222-2222-2222-2222-222222222222', name: 'Fizik' },
      { id: '33333333-3333-3333-3333-333333333333', name: 'Kimya' },
      { id: '44444444-4444-4444-4444-444444444444', name: 'Biyoloji' }
    ]

    topics.value = [
      // Matematik konuları
      { id: '11111111-1111-1111-1111-111111111112', subjectId: '11111111-1111-1111-1111-111111111111', name: 'Temel Matematik' },
      { id: '11111111-1111-1111-1111-111111111113', subjectId: '11111111-1111-1111-1111-111111111111', name: 'Geometri' },
      { id: '11111111-1111-1111-1111-111111111114', subjectId: '11111111-1111-1111-1111-111111111111', name: 'İntegral' },
      // Fizik konuları
      { id: '22222222-2222-2222-2222-222222222223', subjectId: '22222222-2222-2222-2222-222222222222', name: 'Kuvvet ve Hareket' },
      { id: '22222222-2222-2222-2222-222222222224', subjectId: '22222222-2222-2222-2222-222222222222', name: 'Elektrik' },
      { id: '22222222-2222-2222-2222-222222222225', subjectId: '22222222-2222-2222-2222-222222222222', name: 'Optik' },
      // Kimya konuları
      { id: '33333333-3333-3333-3333-333333333334', subjectId: '33333333-3333-3333-3333-333333333333', name: 'Atomun Yapısı' },
      { id: '33333333-3333-3333-3333-333333333335', subjectId: '33333333-3333-3333-3333-333333333333', name: 'Organik Kimya' },
      // Biyoloji konuları
      { id: '44444444-4444-4444-4444-444444444445', subjectId: '44444444-4444-4444-4444-444444444444', name: 'Hücre' },
      { id: '44444444-4444-4444-4444-444444444446', subjectId: '44444444-4444-4444-4444-444444444444', name: 'Genetik' }
    ]
  } catch (error) {
    console.error('Veriler yüklenemedi:', error)
    alert('Veriler yüklenirken bir hata oluştu')
  }
})

// HTML içeriğini kontrol et
const hasTextContent = (html) => {
  if (!html) return false
  const text = html.replace(/<[^>]*>/g, '').trim()
  return text.length > 0
}

// Doğru cevap var mı?
const hasCorrectAnswer = computed(() => {
  return form.value.options.some(opt => opt.isCorrect)
})

// Kaydet butonu aktif mi?
const canSubmit = computed(() => {
  // Dolu cevapları say
  const filledOptions = form.value.options.filter(opt => hasTextContent(opt.text))

  // Doğru işaretli cevap dolu mu?
  const correctOption = form.value.options.find(opt => opt.isCorrect)
  const isCorrectAnswerFilled = correctOption && hasTextContent(correctOption.text)

  return (
    form.value.subjectId &&
    form.value.topicId &&
    form.value.examType &&
    form.value.difficulty &&
    hasTextContent(form.value.text) &&
    filledOptions.length >= 2 &&
    hasCorrectAnswer.value &&
    isCorrectAnswerFilled
  )
})

const getLayoutClass = (layout) => {
  switch (layout) {
    case 'Grid':
      return 'options-layout options-layout--grid'
    case 'Horizontal':
      return 'options-layout options-layout--horizontal'
    case 'Vertical':
    default:
      return 'options-layout options-layout--vertical'
  }
}

// Modal açma fonksiyonları
const openQuestionEditor = () => {
  editorTitle.value = 'Soru Metni'
  editorType.value = 'question'
  editorContent.value = form.value.text
  showEditorModal.value = true
}

const openOptionEditor = (index) => {
  editorTitle.value = `Cevap ${String.fromCharCode(65 + index)}`
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
  // Tüm cevapları false yap
  form.value.options.forEach(opt => opt.isCorrect = false)
  // Seçilen cevabı true yap
  form.value.options[index].isCorrect = true
}

const addOption = () => {
  if (form.value.options.length >= 5) {
    alert('En fazla 5 cevap ekleyebilirsiniz!')
    return
  }
  form.value.options.push({ text: '', isCorrect: false })
}

const removeOption = (index) => {
  if (form.value.options.length <= 2) {
    alert('En az 2 cevap olmalıdır!')
    return
  }
  form.value.options.splice(index, 1)
}

const handleSubmit = async () => {
  if (!canSubmit.value) {
    alert('Lütfen tüm alanları doldurun, en az 2 cevap girin ve doğru cevabı işaretleyin!')
    return
  }

  try {
    loading.value = true

    // Sadece dolu cevapları gönder
    const filledOptions = form.value.options.filter(opt => hasTextContent(opt.text))

    await api.post('/questions', {
      subjectId: form.value.subjectId,
      topicId: form.value.topicId,
      examType: form.value.examType,
      difficulty: form.value.difficulty,
      createdBy: currentUserId,
      text: form.value.text,
      optionsLayout: form.value.optionsLayout,
      options: filledOptions
    })

    alert('Soru başarıyla gönderildi! Onay sürecinden sonra kullanılabilir olacaktır.')
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
}

.question-form-container {
  max-width: 900px;
  margin: 0 auto;
}

.form-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 2rem;
}

.form-title {
  font-size: 1.5rem;
  font-weight: 700;
  margin-bottom: 1.5rem;
  color: var(--text);
}

.category-grid {
  background: var(--bg-card-light);
  padding: 1rem;
  border-radius: 12px;
  margin-bottom: 1.5rem;
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 1rem;
}

.form-label {
  display: block;
  font-size: 0.75rem;
  color: var(--text-muted);
  margin-bottom: 0.5rem;
  font-weight: 600;
}

.form-select {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid var(--border);
  border-radius: 8px;
  font-size: 0.9rem;
  background: var(--input-bg);
  color: var(--text);
  cursor: pointer;
}

.form-select:focus {
  outline: none;
  border-color: var(--primary);
  box-shadow: 0 0 0 3px var(--glow-blue);
}

.form-select.disabled {
  background: var(--bg-card);
  cursor: not-allowed;
  opacity: 0.6;
}

.form-select option {
  background: var(--bg-card);
  color: var(--text);
}

/* Question Section */
.question-section {
  margin-bottom: 1.5rem;
}

.question-preview {
  display: flex;
  align-items: start;
  gap: 1rem;
  margin-bottom: 1rem;
  cursor: pointer;
  padding: 1rem;
  border-radius: 8px;
  transition: background 0.2s;
  background: var(--bg-card-light);
}

.question-preview:hover {
  background: var(--input-bg);
}

.question-preview--empty {
  background: var(--warning);
  background: rgba(245, 158, 11, 0.15);
}

.question-number {
  background: var(--primary);
  color: white;
  padding: 0.5rem 1rem;
  border-radius: 6px;
  font-weight: bold;
  flex-shrink: 0;
}

.question-text {
  font-size: 1.1rem;
  line-height: 1.6;
  flex: 1;
  color: var(--text);
}

.question-placeholder {
  flex: 1;
  color: var(--warning);
  font-style: italic;
}

.edit-icon {
  font-size: 1.3rem;
  color: var(--primary);
  flex-shrink: 0;
  cursor: pointer;
}

.edit-icon--small {
  font-size: 1.1rem;
  margin-left: 1rem;
}

/* Layout Selector */
.layout-selector {
  display: flex;
  gap: 0.25rem;
  margin-bottom: 1rem;
  justify-content: flex-end;
}

.layout-btn {
  padding: 0.35rem 0.5rem;
  border: none;
  background: var(--bg-card-light);
  color: var(--text-muted);
  border-radius: 4px;
  cursor: pointer;
  font-size: 0.85rem;
  transition: all 0.2s;
}

.layout-btn:hover {
  background: var(--input-bg);
}

.layout-btn--active {
  background: var(--primary);
  color: white;
}

/* Options Layout */
.options-layout--vertical {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.options-layout--grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 1rem;
}

.options-layout--horizontal {
  display: grid;
  grid-template-columns: repeat(5, 1fr);
  gap: 1rem;
}

/* Option Item */
.option-item {
  display: flex;
  align-items: start;
  padding: 0.75rem;
  border-radius: 6px;
  transition: background 0.2s;
  background: var(--bg-card-light);
}

.option-item:hover {
  background: var(--input-bg);
}

.option-item--empty {
  background: rgba(245, 158, 11, 0.15);
}

.option-radio {
  margin-right: 0.75rem;
  margin-top: 0.25rem;
  flex-shrink: 0;
  cursor: pointer;
  accent-color: var(--primary);
}

.option-content {
  flex: 1;
  min-width: 0;
  cursor: pointer;
}

.option-text-wrapper {
  display: inline;
  color: var(--text);
}

.option-letter {
  font-weight: bold;
  margin-right: 0.5rem;
  color: var(--text);
}

.option-placeholder {
  color: var(--warning);
  font-style: italic;
}

/* Warning Box */
.warning-box {
  margin-top: 1.5rem;
  padding: 0.75rem;
  background: rgba(245, 158, 11, 0.15);
  border-radius: 6px;
  border: 1px solid var(--warning);
}

.warning-text {
  margin: 0;
  font-size: 0.85rem;
  color: var(--warning);
}

/* Action Buttons */
.action-buttons {
  display: flex;
  gap: 1rem;
  justify-content: flex-end;
  margin-top: 2rem;
  padding-top: 2rem;
  border-top: 1px solid var(--border);
}

.btn-cancel {
  padding: 1rem 2rem;
  background: var(--bg-card-light);
  color: var(--text);
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 500;
  transition: background 0.2s;
}

.btn-cancel:hover {
  background: var(--input-bg);
}

.btn-submit {
  padding: 1rem 2rem;
  border: none;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  box-shadow: 0 2px 8px var(--glow-blue);
  transition: all 0.2s;
}

.btn-submit:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 4px 12px var(--glow-blue);
}

.btn-submit--disabled,
.btn-submit:disabled {
  background: var(--bg-card-light);
  color: var(--text-muted);
  cursor: not-allowed;
  box-shadow: none;
}

/* Modal */
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.7);
  backdrop-filter: blur(4px);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
  padding: 2rem;
}

.modal-content {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 12px;
  padding: 2rem;
  max-width: 800px;
  width: 100%;
  max-height: 90vh;
  overflow-y: auto;
  box-shadow: 0 8px 32px var(--shadow);
}

.modal-actions {
  display: flex;
  gap: 1rem;
  justify-content: flex-end;
}

/* Quill Editor */
.quill-editor {
  min-height: 300px;
  margin-bottom: 1.5rem;
  border-radius: 8px;
}

:deep(.ql-toolbar) {
  background: var(--bg-card-light);
  border-color: var(--border);
  border-radius: 8px 8px 0 0;
}

:deep(.ql-container) {
  background: var(--input-bg);
  border-color: var(--border);
  border-radius: 0 0 8px 8px;
  color: var(--text);
  font-size: 1rem;
}

:deep(.ql-editor) {
  min-height: 250px;
}

:deep(.ql-editor.ql-blank::before) {
  color: var(--text-muted);
  font-style: italic;
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
  border-radius: 8px;
  margin: 0.5rem 0;
}

:deep(p) {
  margin: 0;
  display: inline;
}

@media (max-width: 768px) {
  .category-grid {
    grid-template-columns: 1fr;
  }

  .options-layout--horizontal {
    grid-template-columns: repeat(2, 1fr);
  }

  .action-buttons {
    flex-direction: column;
  }

  .btn-cancel,
  .btn-submit {
    width: 100%;
    text-align: center;
  }
}
</style>

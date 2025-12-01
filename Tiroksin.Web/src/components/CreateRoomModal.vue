<template>
  <div class="modal-overlay" @click.self="$emit('close')">
    <div class="modal">
      <div class="modal-header">
        <span class="header-icon">🎮</span>
        <h2>Yeni Oda Olustur</h2>
        <button @click="$emit('close')" class="close">✕</button>
      </div>

      <div class="modal-body">
        <div class="form-group">
          <label>Oda Adi</label>
          <input
            v-model="form.name"
            type="text"
            placeholder="Ornek: Efsane Yaris"
            maxlength="50"
            @keyup.enter="handleCreate"
          />
        </div>

        <div class="form-group">
          <label>Soru Sayisi</label>
          <input v-model.number="form.questionCount" type="number" min="5" max="50" />
          <small class="hint">Her soru icin 60 saniye sure</small>
        </div>

        <div class="form-group">
          <label>Oda Tipi</label>
          <div class="toggle-group">
            <button
              type="button"
              :class="['toggle-btn', { active: form.isPublic }]"
              @click="form.isPublic = true"
            >
              🌐 Acik
            </button>
            <button
              type="button"
              :class="['toggle-btn', { active: !form.isPublic }]"
              @click="form.isPublic = false"
            >
              🔒 Gizli
            </button>
          </div>
        </div>

        <div v-if="!form.isPublic" class="form-group">
          <label>Parola</label>
          <input
            v-model="form.password"
            type="password"
            placeholder="Odaya giris parolasi"
            maxlength="20"
          />
        </div>

        <div v-if="errorMessage" class="error-message">{{ errorMessage }}</div>
      </div>

      <div class="modal-footer">
        <button @click="$emit('close')" class="btn-cancel">Iptal</button>
        <button @click="handleCreate" :disabled="!isValid || loading" class="btn-create">
          {{ loading ? 'Olusturuluyor...' : 'Oda Olustur' }}
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from 'vue'
import { useRouter } from 'vue-router'
import { useRoomStore } from '../stores/room'

const emit = defineEmits(['close', 'created'])
const router = useRouter()
const roomStore = useRoomStore()
const loading = ref(false)
const errorMessage = ref('')

const form = ref({
  name: '',
  gameMode: 2, // Always Survival (Elimination) mode
  maxPlayers: 10,
  minPlayers: 2, // Sabit 2
  isPublic: true,
  password: '',
  questionCount: 10
})

const isValid = computed(() => {
  const nameValid = form.value.name.trim().length >= 3
  const questionValid = form.value.questionCount >= 5 && form.value.questionCount <= 50
  const passwordValid = form.value.isPublic || form.value.password.trim().length >= 3
  return nameValid && questionValid && passwordValid
})

async function handleCreate() {
  if (!isValid.value || loading.value) return

  loading.value = true
  errorMessage.value = ''

  try {
    console.log('🎮 Creating room with data:', form.value)
    const room = await roomStore.createRoom(form.value)
    console.log('✅ Room created successfully:', room)

    emit('created', room)
    emit('close')

    // Navigate to room waiting page
    router.push(`/room/${room.roomId}`)
  } catch (error) {
    console.error('❌ Error creating room:', error)
    errorMessage.value = error.message || 'Oda oluşturulurken bir hata oluştu'
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.modal-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.7);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
  backdrop-filter: blur(8px);
}

.modal {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  max-width: 400px;
  width: 90%;
  max-height: 90vh;
  overflow-y: auto;
  box-shadow: 0 20px 60px rgba(0, 0, 0, 0.5);
}

.modal-header {
  padding: 20px;
  border-bottom: 1px solid var(--border);
  display: flex;
  align-items: center;
  gap: 12px;
}

.header-icon {
  font-size: 1.5rem;
}

.modal-header h2 {
  margin: 0;
  flex: 1;
  font-size: 1.2rem;
  font-weight: 700;
  color: var(--text);
}

.close {
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  font-size: 1rem;
  cursor: pointer;
  padding: 0;
  color: var(--text-muted);
  width: 32px;
  height: 32px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 8px;
  transition: all 0.2s;
}

.close:hover {
  background: var(--error);
  border-color: var(--error);
  color: white;
}

.modal-body {
  padding: 20px;
}

.form-group {
  margin-bottom: 16px;
}

.form-group label {
  display: block;
  margin-bottom: 8px;
  font-size: 0.85rem;
  font-weight: 600;
  color: var(--text-muted);
}

.form-group input,
.form-group select,
.form-group textarea {
  width: 100%;
  padding: 12px 14px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 10px;
  font-size: 0.95rem;
  font-family: inherit;
  color: var(--text);
  transition: all 0.2s;
}

.form-group input::placeholder,
.form-group textarea::placeholder {
  color: var(--text-muted);
  opacity: 0.6;
}

.form-group input:focus,
.form-group select:focus,
.form-group textarea:focus {
  outline: none;
  border-color: var(--primary);
  box-shadow: 0 0 0 3px var(--glow-blue);
}

.form-group textarea {
  resize: vertical;
  min-height: 60px;
}

.hint {
  display: block;
  margin-top: 6px;
  font-size: 0.75rem;
  color: var(--text-muted);
}

.toggle-group {
  display: flex;
  gap: 8px;
}

.toggle-btn {
  flex: 1;
  padding: 12px 16px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 10px;
  font-size: 0.9rem;
  font-weight: 600;
  color: var(--text-muted);
  cursor: pointer;
  transition: all 0.2s;
}

.toggle-btn:hover {
  background: var(--bg-card);
  color: var(--text);
}

.toggle-btn.active {
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  border-color: var(--primary);
  color: white;
}

.error-message {
  padding: 12px;
  background: rgba(239, 68, 68, 0.15);
  border: 1px solid var(--error);
  border-radius: 8px;
  color: var(--error);
  font-size: 0.85rem;
  margin-top: 12px;
}

.modal-footer {
  padding: 16px 20px;
  border-top: 1px solid var(--border);
  display: flex;
  justify-content: flex-end;
  gap: 12px;
  background: var(--bg-card-light);
  border-bottom-left-radius: 16px;
  border-bottom-right-radius: 16px;
}

.btn-cancel,
.btn-create {
  padding: 12px 20px;
  border: none;
  border-radius: 10px;
  font-size: 0.9rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s;
}

.btn-cancel {
  background: var(--bg-card);
  color: var(--text-muted);
  border: 1px solid var(--border);
}

.btn-cancel:hover {
  background: var(--bg-card-light);
  color: var(--text);
  border-color: var(--text-muted);
}

.btn-create {
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  min-width: 120px;
  box-shadow: 0 4px 16px var(--glow-blue);
}

.btn-create:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 24px var(--glow-blue);
}

.btn-create:disabled {
  opacity: 0.5;
  cursor: not-allowed;
  transform: none;
}
</style>

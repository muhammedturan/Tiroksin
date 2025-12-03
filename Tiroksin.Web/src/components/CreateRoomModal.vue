<template>
  <div class="modal-overlay" @click.self="$emit('close')">
    <div class="modal">
      <div class="modal-header">
        <span class="header-icon">🎮</span>
        <h2>Yeni Oda Oluştur</h2>
        <button @click="$emit('close')" class="close">✕</button>
      </div>

      <div class="modal-body">
        <MarioInput
          v-model="form.name"
          label="Oda Adı"
          placeholder="EFSANE YARIŞ"
          :maxlength="50"
          prefix="🏠"
          :is-uppercase="true"
          :centered="true"
          @enter="handleCreate"
        />

        <MarioInput
          v-model="form.questionCount"
          type="number"
          label="Soru Sayısı"
          :min="5"
          :max="50"
          hint="Her soru için 60 saniye süre"
          prefix="❓"
        />

        <div class="form-group">
          <label class="toggle-label">Oda Tipi</label>
          <div class="toggle-group">
            <button
              type="button"
              :class="['toggle-btn', { active: form.isPublic }]"
              @click="form.isPublic = true"
            >
              🌐 Açık
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

        <MarioInput
          v-if="!form.isPublic"
          v-model="form.password"          
          label="Parola"
          :centered="true"
          placeholder="Odaya giriş parolası"
          :maxlength="20"
          prefix="🔑"
        />

        <div v-if="errorMessage" class="error-message">{{ errorMessage }}</div>
      </div>

      <div class="modal-footer">
        <MarioButton color="gray" @click="$emit('close')">İptal</MarioButton>
        <MarioButton
          color="green"
          :disabled="!isValid"
          :loading="loading"
          @click="handleCreate"
        >
          Oda Oluştur
        </MarioButton>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from 'vue'
import { useRouter } from 'vue-router'
import { useRoomStore } from '../stores/room'
import MarioInput from './MarioInput.vue'
import MarioButton from './MarioButton.vue'

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
/* Gaming Style Modal */
.modal-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.7);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
  backdrop-filter: blur(8px);
  padding: 20px;
}

.modal {
  background: var(--bg-card);
  border: 2px solid var(--border);
  border-radius: var(--radius-xl);
  max-width: 420px;
  width: 100%;
  max-height: 90vh;
  overflow-y: auto;
  box-shadow: var(--shadow-lg);
  animation: modalSlideUp 0.3s cubic-bezier(0.34, 1.56, 0.64, 1);
}

@keyframes modalSlideUp {
  from {
    opacity: 0;
    transform: translateY(30px) scale(0.95);
  }
  to {
    opacity: 1;
    transform: translateY(0) scale(1);
  }
}

.modal-header {
  padding: 20px 24px;
  border-bottom: 2px solid var(--border);
  display: flex;
  align-items: center;
  gap: 14px;
  background: var(--bg-input);
}

.header-icon {
  font-size: 1.8rem;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 48px;
  height: 48px;
  background: var(--mario-red);
  border-radius: var(--radius-lg);
  box-shadow: 0 3px 0 #a31b18;
}

.modal-header h2 {
  margin: 0;
  flex: 1;
  font-size: 1.2rem;
  font-weight: 800;
  color: var(--text);
}

.close {
  background: var(--bg-card);
  border: 2px solid var(--border);
  font-size: 1rem;
  cursor: pointer;
  padding: 0;
  color: var(--text-muted);
  width: 36px;
  height: 36px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: var(--radius-md);
  transition: all 0.15s ease;
  font-weight: 700;
}

.close:hover {
  background: var(--option-red);
  border-color: var(--option-red);
  color: white;
  transform: scale(1.1);
}

.modal-body {
  padding: 24px;
  display: flex;
  flex-direction: column;
  gap: 16px;
}

.form-group {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.toggle-label {
  font-size: 0.75rem;
  font-weight: 700;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.toggle-group {
  display: flex;
  gap: 12px;
}

.toggle-btn {
  flex: 1;
  padding: 12px 18px;
  background: var(--bg-card-light);
  border: none;
  border-radius: var(--radius-md);
  font-size: 0.9rem;
  font-weight: 700;
  color: var(--text);
  cursor: pointer;
  transition: all 0.15s ease;
  box-shadow: 0 4px 0 var(--border);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.toggle-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 var(--border);
  background: var(--bg-card-hover);
}

.toggle-btn:active {
  transform: translateY(2px);
  box-shadow: 0 1px 0 var(--border);
}

.toggle-btn.active {
  background: var(--mario-blue);
  color: white;
  box-shadow: 0 4px 0 #037bb5;
}

.toggle-btn.active:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #037bb5;
}

.toggle-btn.active:last-child {
  background: var(--mario-yellow);
  color: #92400e;
  box-shadow: 0 4px 0 #d97706;
}

.toggle-btn.active:last-child:hover {
  box-shadow: 0 6px 0 #d97706;
}

.error-message {
  padding: 14px 16px;
  background: var(--option-red);
  border-radius: var(--radius-md);
  color: white;
  font-size: 0.9rem;
  font-weight: 600;
  margin-top: 16px;
  box-shadow: 0 3px 0 #b01530;
}

.modal-footer {
  padding: 18px 24px;
  border-top: 2px solid var(--border);
  display: flex;
  justify-content: flex-end;
  gap: 12px;
  background: var(--bg-input);
}
</style>

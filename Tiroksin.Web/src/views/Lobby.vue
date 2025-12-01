<template>
  <div class="lobby">
    <div class="lobby-header">
      <div>
        <h1>Oyun Lobisi</h1>
        <p>Bir odaya katil veya yeni oda olustur</p>
      </div>
      <button @click="showCreateModal = true" class="btn-create">
        + Yeni Oda
      </button>
    </div>

    <div class="join-card card">
      <div class="join-icon">🔑</div>
      <div class="join-content">
        <span class="join-label">Oda Kodu ile Katil</span>
        <div class="join-input">
          <input
            v-model="joinCode"
            placeholder="ABCDEF"
            maxlength="6"
            @input="joinCode = joinCode.toUpperCase()"
          />
          <button @click="handleJoinByCode" :disabled="joinCode.length !== 6" class="btn-join">
            Katil
          </button>
        </div>
      </div>
    </div>

    <div class="rooms-section">
      <div class="section-header">
        <h2>Aktif Odalar</h2>
        <span class="room-count">{{ roomStore.rooms.length }}</span>
      </div>

      <div v-if="roomStore.loading" class="loading">
        <div class="spinner"></div>
        <span>Odalar yukleniyor...</span>
      </div>

      <div v-else-if="roomStore.rooms.length === 0" class="empty card">
        <span class="empty-icon">🎲</span>
        <h3>Aktif oda yok</h3>
        <p>Ilk odayi sen olustur!</p>
      </div>

      <div v-else class="rooms-grid">
        <div
          v-for="room in roomStore.rooms"
          :key="room.id"
          class="room-card card"
          @click="handleJoinRoom(room)"
        >
          <div class="room-top">
            <span class="room-name">{{ room.name }}</span>
            <span class="room-code">{{ room.roomCode }}</span>
          </div>
          <div class="room-stats">
            <div class="stat">
              <span class="stat-icon">👥</span>
              <span>{{ room.currentPlayers }}/{{ room.maxPlayers }}</span>
            </div>
            <div class="stat">
              <span class="stat-icon">❓</span>
              <span>{{ room.questionCount }} Soru</span>
            </div>
          </div>
          <button class="btn-room-join" :disabled="room.currentPlayers >= room.maxPlayers">
            {{ room.currentPlayers >= room.maxPlayers ? 'Dolu' : 'Katil' }}
          </button>
        </div>
      </div>
    </div>

    <CreateRoomModal v-if="showCreateModal" @close="showCreateModal = false" @created="handleRoomCreated" />

    <!-- Password Modal -->
    <div v-if="showPasswordModal" class="modal-overlay" @click.self="showPasswordModal = false">
      <div class="password-modal">
        <div class="modal-header">
          <span class="header-icon">🔒</span>
          <h2>Gizli Oda</h2>
          <button @click="showPasswordModal = false" class="close">✕</button>
        </div>
        <div class="modal-body">
          <p class="modal-text">Bu oda gizli. Katilmak icin parolayi girin.</p>
          <div class="form-group">
            <label>Parola</label>
            <input
              v-model="passwordInput"
              type="password"
              placeholder="Oda parolasi"
              @keyup.enter="submitPassword"
            />
          </div>
          <div v-if="passwordError" class="error-message">{{ passwordError }}</div>
        </div>
        <div class="modal-footer">
          <button @click="showPasswordModal = false" class="btn-cancel">Iptal</button>
          <button @click="submitPassword" :disabled="!passwordInput.trim()" class="btn-join-modal">
            Katil
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { useRoomStore } from '../stores/room'
import CreateRoomModal from '../components/CreateRoomModal.vue'

const router = useRouter()
const roomStore = useRoomStore()
const showCreateModal = ref(false)
const showPasswordModal = ref(false)
const joinCode = ref('')
const passwordInput = ref('')
const passwordError = ref('')
const pendingRoomCode = ref('')

onMounted(() => {
  roomStore.fetchRooms({ isPublic: true })
})

async function handleJoinByCode() {
  // Kod ile katılırken önce parolasız dene, 400 alırsan parola sor
  try {
    await roomStore.joinRoom(joinCode.value)
    router.push(`/room/${roomStore.currentRoom.roomId}`)
  } catch (error) {
    // Eğer parola gerekiyorsa modal aç
    if (error.message?.includes('parola') || error.message?.includes('password') || error.response?.status === 400) {
      pendingRoomCode.value = joinCode.value
      passwordInput.value = ''
      passwordError.value = ''
      showPasswordModal.value = true
    } else {
      alert(error.message)
    }
  }
}

async function handleJoinRoom(room) {
  try {
    await roomStore.joinRoom(room.roomCode)
    router.push(`/room/${roomStore.currentRoom.roomId}`)
  } catch (error) {
    alert(error.message)
  }
}

async function submitPassword() {
  if (!passwordInput.value.trim()) return

  try {
    await roomStore.joinRoom(pendingRoomCode.value, passwordInput.value)
    showPasswordModal.value = false
    router.push(`/room/${roomStore.currentRoom.roomId}`)
  } catch (error) {
    passwordError.value = error.message || 'Yanlis parola'
  }
}

function handleRoomCreated(room) {
  showCreateModal.value = false
  router.push(`/room/${room.roomId}`)
}
</script>

<style scoped>
.lobby {
  max-width: 900px;
  margin: 0 auto;
}

.lobby-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 28px;
}

.lobby-header h1 {
  font-size: 1.8rem;
  font-weight: 800;
  color: var(--text);
  margin: 0 0 6px 0;
}

.lobby-header p {
  color: var(--text-muted);
  margin: 0;
  font-size: 0.95rem;
}

.btn-create {
  padding: 14px 28px;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  border: none;
  border-radius: 12px;
  color: white;
  font-weight: 700;
  font-size: 1rem;
  cursor: pointer;
  transition: all 0.2s;
  box-shadow: 0 4px 20px var(--glow-blue);
}

.btn-create:hover {
  transform: translateY(-2px);
  box-shadow: 0 8px 30px var(--glow-blue);
}

.join-card {
  display: flex;
  align-items: center;
  gap: 20px;
  margin-bottom: 32px;
}

.join-icon {
  font-size: 2.5rem;
}

.join-content {
  flex: 1;
}

.join-label {
  display: block;
  font-weight: 600;
  color: var(--text);
  margin-bottom: 10px;
}

.join-input {
  display: flex;
  gap: 12px;
}

.join-input input {
  flex: 1;
  max-width: 200px;
  padding: 14px 16px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 10px;
  font-size: 1.1rem;
  font-weight: 700;
  letter-spacing: 3px;
  color: var(--text);
  text-transform: uppercase;
}

.join-input input::placeholder {
  color: var(--text-muted);
  opacity: 0.5;
  letter-spacing: 3px;
}

.join-input input:focus {
  outline: none;
  border-color: var(--primary);
}

.btn-join {
  padding: 14px 28px;
  background: var(--success);
  border: none;
  border-radius: 10px;
  color: white;
  font-weight: 700;
  cursor: pointer;
  transition: all 0.2s;
}

.btn-join:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 4px 16px rgba(34, 197, 94, 0.4);
}

.btn-join:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.rooms-section {
  margin-top: 20px;
}

.section-header {
  display: flex;
  align-items: center;
  gap: 12px;
  margin-bottom: 20px;
}

.section-header h2 {
  font-size: 1.3rem;
  font-weight: 700;
  color: var(--text);
  margin: 0;
}

.room-count {
  background: var(--primary);
  color: white;
  padding: 4px 12px;
  border-radius: 20px;
  font-size: 0.85rem;
  font-weight: 700;
}

.loading {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 16px;
  padding: 60px 0;
  color: var(--text-muted);
}

.spinner {
  width: 40px;
  height: 40px;
  border: 3px solid var(--border);
  border-top-color: var(--primary);
  border-radius: 50%;
  animation: spin 1s linear infinite;
}

@keyframes spin {
  to { transform: rotate(360deg); }
}

.empty {
  text-align: center;
  padding: 60px 40px;
}

.empty-icon {
  font-size: 4rem;
  display: block;
  margin-bottom: 16px;
}

.empty h3 {
  font-size: 1.3rem;
  color: var(--text);
  margin: 0 0 8px 0;
}

.empty p {
  color: var(--text-muted);
  margin: 0;
}

.rooms-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
  gap: 16px;
}

.room-card {
  cursor: pointer;
  transition: all 0.2s;
  border: 1px solid var(--border);
}

.room-card:hover {
  border-color: var(--primary);
  transform: translateY(-4px);
  box-shadow: 0 8px 32px rgba(0, 0, 0, 0.3);
}

.room-top {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 16px;
}

.room-name {
  font-size: 1.1rem;
  font-weight: 700;
  color: var(--text);
}

.room-code {
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  padding: 6px 12px;
  border-radius: 8px;
  font-size: 0.85rem;
  font-weight: 700;
  letter-spacing: 1px;
}

.room-stats {
  display: flex;
  gap: 20px;
  margin-bottom: 16px;
}

.stat {
  display: flex;
  align-items: center;
  gap: 6px;
  color: var(--text-muted);
  font-size: 0.9rem;
}

.stat-icon {
  font-size: 1rem;
}

.btn-room-join {
  width: 100%;
  padding: 12px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 10px;
  color: var(--text);
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s;
}

.btn-room-join:hover:not(:disabled) {
  background: var(--primary);
  border-color: var(--primary);
  color: white;
}

.btn-room-join:disabled {
  opacity: 0.5;
  cursor: not-allowed;
  color: var(--text-muted);
}

@media (max-width: 600px) {
  .lobby-header {
    flex-direction: column;
    align-items: flex-start;
    gap: 16px;
  }

  .btn-create {
    width: 100%;
  }

  .join-card {
    flex-direction: column;
    text-align: center;
  }

  .join-input {
    flex-direction: column;
  }

  .join-input input {
    max-width: none;
    text-align: center;
  }
}

/* Password Modal */
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

.password-modal {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  max-width: 400px;
  width: 90%;
  box-shadow: 0 20px 60px rgba(0, 0, 0, 0.5);
}

.password-modal .modal-header {
  padding: 20px;
  border-bottom: 1px solid var(--border);
  display: flex;
  align-items: center;
  gap: 12px;
}

.password-modal .header-icon {
  font-size: 1.5rem;
}

.password-modal .modal-header h2 {
  margin: 0;
  flex: 1;
  font-size: 1.2rem;
  font-weight: 700;
  color: var(--text);
}

.password-modal .close {
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

.password-modal .close:hover {
  background: var(--error);
  border-color: var(--error);
  color: white;
}

.password-modal .modal-body {
  padding: 20px;
}

.password-modal .modal-text {
  color: var(--text-muted);
  font-size: 0.9rem;
  margin-bottom: 16px;
}

.password-modal .form-group {
  margin-bottom: 16px;
}

.password-modal .form-group label {
  display: block;
  margin-bottom: 8px;
  font-size: 0.85rem;
  font-weight: 600;
  color: var(--text-muted);
}

.password-modal .form-group input {
  width: 100%;
  padding: 12px 14px;
  background: var(--bg-card-light);
  border: 1px solid var(--border);
  border-radius: 10px;
  font-size: 0.95rem;
  color: var(--text);
  transition: all 0.2s;
}

.password-modal .form-group input:focus {
  outline: none;
  border-color: var(--primary);
  box-shadow: 0 0 0 3px var(--glow-blue);
}

.password-modal .error-message {
  padding: 12px;
  background: rgba(239, 68, 68, 0.15);
  border: 1px solid var(--error);
  border-radius: 8px;
  color: var(--error);
  font-size: 0.85rem;
}

.password-modal .modal-footer {
  padding: 16px 20px;
  border-top: 1px solid var(--border);
  display: flex;
  justify-content: flex-end;
  gap: 12px;
  background: var(--bg-card-light);
  border-bottom-left-radius: 16px;
  border-bottom-right-radius: 16px;
}

.password-modal .btn-cancel {
  padding: 12px 20px;
  background: var(--bg-card);
  color: var(--text-muted);
  border: 1px solid var(--border);
  border-radius: 10px;
  font-size: 0.9rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s;
}

.password-modal .btn-cancel:hover {
  background: var(--bg-card-light);
  color: var(--text);
}

.password-modal .btn-join-modal {
  padding: 12px 20px;
  background: linear-gradient(135deg, var(--primary) 0%, var(--accent) 100%);
  color: white;
  border: none;
  border-radius: 10px;
  font-size: 0.9rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s;
  min-width: 100px;
  box-shadow: 0 4px 16px var(--glow-blue);
}

.password-modal .btn-join-modal:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 24px var(--glow-blue);
}

.password-modal .btn-join-modal:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}
</style>

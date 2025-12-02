<template>
  <div class="lobby">
    <!-- HERO SECTION - Full Width -->
    <MarioCard color="blue" hero showDeco class="hero-section">
      <div class="hero-text">
        <h1 class="hero-title">🎮 Oyun Lobisi</h1>
        <p class="hero-subtitle">Bir odaya katıl veya yeni oda oluştur</p>
      </div>

      <!-- Quick Join - Horizontal -->
      <div class="quick-join-bar">
        <MarioInput
          v-model="joinCode"
          placeholder="ODA KODU"
          :maxlength="6"
          prefix="🔑"
          centered
          isUppercase
          class="code-input-wrapper"
        />
        <MarioButton color="green" size="md" :disabled="joinCode.length !== 6" @click="handleJoinByCode">
          Katıl →
        </MarioButton>
        <div class="or-divider">veya</div>
        <MarioButton color="orange" size="md" @click="showCreateModal = true">
          + Yeni Oda Oluştur
        </MarioButton>
      </div>
    </MarioCard>

    <!-- ROOMS LIST SECTION -->
    <div class="rooms-section">
      <div class="section-header">
        <div class="header-left">
          <h2 class="section-title">🏠 Aktif Odalar</h2>
          <span class="room-count">{{ roomStore.rooms.length }} oda</span>
        </div>
        <MarioButton color="gray" size="sm" @click="roomStore.fetchRooms({ isPublic: true })">
          🔄 Yenile
        </MarioButton>
      </div>

      <!-- Loading -->
      <div v-if="roomStore.loading" class="loading-state">
        <div class="spinner"></div>
        <span>Odalar yükleniyor...</span>
      </div>

      <!-- Empty State -->
      <div v-else-if="roomStore.rooms.length === 0" class="empty-state">
        <div class="empty-icon">🎲</div>
        <h3>Henüz aktif oda yok</h3>
        <p>İlk odayı sen oluştur ve arkadaşlarını davet et!</p>
        <MarioButton color="green" @click="showCreateModal = true">
          + Oda Oluştur
        </MarioButton>
      </div>

      <!-- Rooms List (Vertical Cards) -->
      <div v-else class="rooms-list">
        <MarioHeader
          v-for="(room, index) in roomStore.rooms"
          :key="room.id"
          :title="room.name"
          :subtitle="room.roomCode"
          icon="🎮"
          :color="getRoomCardColor(index)"
          :stats="[
            { icon: '👥', value: `${room.currentPlayers}/${room.maxPlayers}` },
            { icon: '❓', value: room.questionCount }
          ]"
        >
          <template #action>
            <MarioButton
              :color="room.currentPlayers >= room.maxPlayers ? 'gray' : 'green'"
              size="sm"
              :disabled="room.currentPlayers >= room.maxPlayers"
              @click="handleJoinRoom(room)"
            >
              {{ room.currentPlayers >= room.maxPlayers ? '🔒 Dolu' : '🚀 Katıl' }}
            </MarioButton>
          </template>
        </MarioHeader>
      </div>
    </div>

    <!-- Create Room Modal -->
    <CreateRoomModal v-if="showCreateModal" @close="showCreateModal = false" @created="handleRoomCreated" />

    <!-- Password Modal -->
    <Teleport to="body">
      <div v-if="showPasswordModal" class="modal-overlay" @click.self="showPasswordModal = false">
        <div class="modal password-modal">
          <div class="modal-header">
            <span class="header-icon">🔒</span>
            <h2>Gizli Oda</h2>
            <button @click="showPasswordModal = false" class="btn-close">✕</button>
          </div>
          <div class="modal-body">
            <p class="modal-desc">Bu oda gizli. Katılmak için parolayı girin.</p>
            <MarioInput
              v-model="passwordInput"
              type="password"
              label="Parola"
              placeholder="Oda parolası"
              prefix="🔑"
              :error="passwordError"
              @enter="submitPassword"
            />
          </div>
          <div class="modal-footer">
            <MarioButton color="gray" @click="showPasswordModal = false">İptal</MarioButton>
            <MarioButton color="green" :disabled="!passwordInput.trim()" @click="submitPassword">
              Katıl
            </MarioButton>
          </div>
        </div>
      </div>
    </Teleport>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { useRoomStore } from '../stores/room'
import { useToastStore } from '../stores/toast'
import CreateRoomModal from '../components/CreateRoomModal.vue'
import MarioCard from '../components/MarioCard.vue'
import MarioButton from '../components/MarioButton.vue'
import MarioInput from '../components/MarioInput.vue'
import MarioHeader from '../components/MarioHeader.vue'

const router = useRouter()
const roomStore = useRoomStore()
const toastStore = useToastStore()
const showCreateModal = ref(false)
const showPasswordModal = ref(false)
const joinCode = ref('')
const passwordInput = ref('')
const passwordError = ref('')
const pendingRoomCode = ref('')

onMounted(() => {
  roomStore.fetchRooms({ isPublic: true })
})

const roomColors = ['red', 'blue', 'green', 'orange']

function getRoomCardColor(index) {
  return roomColors[index % roomColors.length]
}

async function handleJoinByCode() {
  try {
    await roomStore.joinRoom(joinCode.value)
    router.push(`/room/${roomStore.currentRoom.roomId}`)
  } catch (error) {
    if (error.message?.includes('parola') || error.message?.includes('password') || error.response?.status === 400) {
      pendingRoomCode.value = joinCode.value
      passwordInput.value = ''
      passwordError.value = ''
      showPasswordModal.value = true
    } else {
      toastStore.error(error.message)
    }
  }
}

async function handleJoinRoom(room) {
  try {
    await roomStore.joinRoom(room.roomCode)
    router.push(`/room/${roomStore.currentRoom.roomId}`)
  } catch (error) {
    toastStore.error(error.message)
  }
}

async function submitPassword() {
  if (!passwordInput.value.trim()) return

  try {
    await roomStore.joinRoom(pendingRoomCode.value, passwordInput.value)
    showPasswordModal.value = false
    router.push(`/room/${roomStore.currentRoom.roomId}`)
  } catch (error) {
    passwordError.value = error.message || 'Yanlış parola'
  }
}

function handleRoomCreated(room) {
  showCreateModal.value = false
  router.push(`/room/${room.roomId}`)
}
</script>

<style scoped>
/* ==========================================
   LOBBY - COMPACT & WIDE LAYOUT
   ========================================== */

.lobby {
  max-width: 1200px;
  margin: 0 auto;
}

/* ==========================================
   HERO SECTION - COMPACT
   ========================================== */

.hero-section {
  margin-bottom: 24px;
}

.hero-text {
  text-align: center;
  margin-bottom: 20px;
}

.hero-title {
  font-size: 1.6rem;
  font-weight: 800;
  color: white;
  margin: 0 0 6px 0;
}

.hero-subtitle {
  font-size: 0.9rem;
  color: rgba(255, 255, 255, 0.85);
  margin: 0;
  font-weight: 500;
}

/* Quick Join Bar - Compact Horizontal */
.quick-join-bar {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 12px;
  flex-wrap: wrap;
}

.code-input-wrapper {
  width: 180px;
}

.or-divider {
  color: rgba(255, 255, 255, 0.6);
  font-weight: 500;
  font-size: 0.8rem;
}

/* ==========================================
   ROOMS LIST SECTION
   ========================================== */

.rooms-section {
  padding: 0;
}

.section-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 16px;
}

.header-left {
  display: flex;
  align-items: center;
  gap: 12px;
}

.section-title {
  font-size: 1.1rem;
  font-weight: 700;
  color: var(--text);
  margin: 0;
}

.room-count {
  padding: 4px 10px;
  background: var(--primary-soft);
  color: var(--primary);
  border-radius: var(--radius-full);
  font-size: 0.75rem;
  font-weight: 600;
}


/* Loading */
.loading-state {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 12px;
  padding: 60px 0;
  color: var(--text-muted);
  font-size: 0.9rem;
}

/* Empty State */
.empty-state {
  text-align: center;
  padding: 50px 20px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: var(--radius-lg);
}

.empty-state .empty-icon {
  font-size: 3rem;
  margin-bottom: 14px;
}

.empty-state h3 {
  font-size: 1.1rem;
  font-weight: 700;
  color: var(--text);
  margin: 0 0 8px 0;
}

.empty-state p {
  color: var(--text-muted);
  font-size: 0.9rem;
  margin: 0 0 20px 0;
}


/* Rooms List - Grid for wider layout */
.rooms-list {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 12px;
}

/* ==========================================
   PASSWORD MODAL
   ========================================== */

.password-modal .modal-desc {
  color: var(--text-secondary);
  font-size: 0.85rem;
  margin-bottom: 16px;
}

.btn-close {
  background: transparent;
  border: 1px solid var(--border);
  width: 28px;
  height: 28px;
  border-radius: 4px;
  cursor: pointer;
  color: var(--text-muted);
  font-size: 0.9rem;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: all 0.15s ease;
}

.btn-close:hover {
  background: #fef2f2;
  border-color: #ef4444;
  color: #ef4444;
}

/* ==========================================
   RESPONSIVE DESIGN
   ========================================== */

@media (max-width: 800px) {
  .rooms-list {
    grid-template-columns: 1fr;
  }

  .quick-join-bar {
    flex-direction: column;
    gap: 10px;
  }

  .code-input-wrapper {
    width: 100%;
    max-width: 280px;
  }
}

@media (max-width: 500px) {
  .hero-section {
    padding: 20px 16px;
  }

  .hero-title {
    font-size: 1.4rem;
  }

  .section-header {
    flex-direction: column;
    align-items: flex-start;
    gap: 10px;
  }
}
</style>

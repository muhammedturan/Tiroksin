<template>
  <Teleport to="body">
    <div class="toast-container">
      <TransitionGroup name="toast">
        <div
          v-for="toast in toasts"
          :key="toast.id"
          :class="['toast', `toast-${toast.type}`]"
          @click="removeToast(toast.id)"
        >
          <span class="toast-icon">{{ getIcon(toast.type) }}</span>
          <span class="toast-message">{{ toast.message }}</span>
          <button class="toast-close" @click.stop="removeToast(toast.id)">×</button>
        </div>
      </TransitionGroup>
    </div>
  </Teleport>
</template>

<script setup>
import { storeToRefs } from 'pinia'
import { useToastStore } from '../stores/toast'

const toastStore = useToastStore()
const { toasts } = storeToRefs(toastStore)
const { removeToast } = toastStore

function getIcon(type) {
  switch (type) {
    case 'success': return '✓'
    case 'error': return '!'
    case 'warning': return '⚠'
    case 'info': return 'ℹ'
    default: return 'ℹ'
  }
}
</script>

<style scoped>
.toast-container {
  position: fixed;
  top: 20px;
  right: 20px;
  z-index: 9999;
  display: flex;
  flex-direction: column;
  gap: 12px;
  max-width: 380px;
  pointer-events: none;
}

.toast {
  display: flex;
  align-items: center;
  gap: 14px;
  padding: 16px 18px;
  border-radius: var(--radius-lg);
  cursor: pointer;
  pointer-events: auto;
  transition: all 0.15s ease;
  font-weight: 600;
}

.toast:hover {
  transform: translateX(-4px) scale(1.02);
}

.toast-success {
  background: var(--option-green);
  color: white;
  box-shadow: 0 4px 0 #1c6609, var(--shadow-lg);
}

.toast-error {
  background: var(--option-red);
  color: white;
  box-shadow: 0 4px 0 #b01530, var(--shadow-lg);
}

.toast-warning {
  background: var(--option-yellow);
  color: white;
  box-shadow: 0 4px 0 #a67d00, var(--shadow-lg);
}

.toast-info {
  background: var(--option-blue);
  color: white;
  box-shadow: 0 4px 0 #0e4fa3, var(--shadow-lg);
}

.toast-icon {
  font-size: 1rem;
  font-weight: 800;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 28px;
  height: 28px;
  background: rgba(255, 255, 255, 0.25);
  border-radius: var(--radius-md);
  flex-shrink: 0;
}

.toast-message {
  flex: 1;
  font-size: 0.95rem;
  font-weight: 600;
  line-height: 1.4;
}

.toast-close {
  background: rgba(255, 255, 255, 0.2);
  border: none;
  color: inherit;
  font-size: 1rem;
  cursor: pointer;
  padding: 4px 8px;
  border-radius: var(--radius-sm);
  line-height: 1;
  transition: all 0.15s ease;
  font-weight: 700;
}

.toast-close:hover {
  background: rgba(255, 255, 255, 0.35);
  transform: scale(1.1);
}

/* Animations */
.toast-enter-active {
  animation: toastSlideIn 0.3s cubic-bezier(0.34, 1.56, 0.64, 1);
}

.toast-leave-active {
  animation: toastSlideOut 0.25s ease-in forwards;
}

@keyframes toastSlideIn {
  from {
    opacity: 0;
    transform: translateX(100%) scale(0.8);
  }
  to {
    opacity: 1;
    transform: translateX(0) scale(1);
  }
}

@keyframes toastSlideOut {
  from {
    opacity: 1;
    transform: translateX(0) scale(1);
  }
  to {
    opacity: 0;
    transform: translateX(100%) scale(0.8);
  }
}

@media (max-width: 480px) {
  .toast-container {
    left: 16px;
    right: 16px;
    max-width: none;
    top: 16px;
  }

  .toast {
    padding: 14px 16px;
  }
}
</style>

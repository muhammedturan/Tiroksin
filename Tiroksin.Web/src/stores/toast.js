import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useToastStore = defineStore('toast', () => {
  const toasts = ref([])
  let toastId = 0

  function addToast({ message, type = 'info', duration = 4000 }) {
    const id = ++toastId

    toasts.value.push({
      id,
      message,
      type, // 'success' | 'error' | 'warning' | 'info'
      timestamp: Date.now()
    })

    // Auto remove after duration
    if (duration > 0) {
      setTimeout(() => {
        removeToast(id)
      }, duration)
    }

    return id
  }

  function removeToast(id) {
    const index = toasts.value.findIndex(t => t.id === id)
    if (index > -1) {
      toasts.value.splice(index, 1)
    }
  }

  function clearAll() {
    toasts.value = []
  }

  // Convenience methods
  function success(message, duration = 4000) {
    return addToast({ message, type: 'success', duration })
  }

  function error(message, duration = 5000) {
    return addToast({ message, type: 'error', duration })
  }

  function warning(message, duration = 4000) {
    return addToast({ message, type: 'warning', duration })
  }

  function info(message, duration = 4000) {
    return addToast({ message, type: 'info', duration })
  }

  return {
    toasts,
    addToast,
    removeToast,
    clearAll,
    success,
    error,
    warning,
    info
  }
})

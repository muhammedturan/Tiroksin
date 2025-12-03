<template>
  <div
    ref="selectRef"
    :class="[
      'mario-select-wrapper',
      {
        'mario-select-wrapper--open': isOpen,
        'mario-select-wrapper--error': error,
        'mario-select-wrapper--disabled': isDisabled
      }
    ]"
  >
    <label v-if="displayLabel" class="mario-select__label">{{ displayLabel }}</label>

    <div class="mario-select__container">
      <!-- Custom Select Button -->
      <button
        type="button"
        class="mario-select"
        :disabled="isDisabled"
        @click="toggleDropdown"
        @keydown="handleKeydown"
      >
        <span class="mario-select__value">
          {{ selectedLabel || displayPlaceholder }}
        </span>
        <span class="mario-select__arrow">
          <span v-if="isLoading" class="mario-select__spinner"></span>
          <span v-else class="mario-select__chevron" :class="{ 'mario-select__chevron--open': isOpen }">▼</span>
        </span>
      </button>

      <!-- Dropdown Menu -->
      <Transition name="dropdown">
        <div v-if="isOpen" class="mario-select__dropdown">
          <div class="mario-select__options">
            <!-- Empty state -->
            <div v-if="options.length === 0" class="mario-select__empty">
              Veri bulunamadı
            </div>
            <button
              v-else
              v-for="(opt, index) in options"
              :key="opt.value"
              type="button"
              :class="[
                'mario-select__option',
                {
                  'mario-select__option--selected': opt.value === modelValue,
                  'mario-select__option--highlighted': highlightedIndex === index
                }
              ]"
              @click="selectOption(opt)"
              @mouseenter="highlightedIndex = index"
            >
              <span class="mario-select__option-icon">
                {{ opt.value === modelValue ? '★' : '○' }}
              </span>
              <span class="mario-select__option-text">{{ opt.name }}</span>
              <span v-if="opt.value === modelValue" class="mario-select__option-check">✓</span>
            </button>
          </div>
        </div>
      </Transition>
    </div>

    <p v-if="hint && !error" class="mario-select__hint">{{ hint }}</p>
    <p v-if="error" class="mario-select__error">{{ error }}</p>
  </div>
</template>

<script setup>
import { ref, computed, watch, onMounted, onUnmounted } from 'vue'
import api from '../services/api'

const props = defineProps({
  modelValue: {
    type: [String, Number],
    default: ''
  },
  label: {
    type: String,
    default: ''
  },
  placeholder: {
    type: String,
    default: ''
  },
  hint: {
    type: String,
    default: ''
  },
  error: {
    type: String,
    default: ''
  },
  disabled: {
    type: Boolean,
    default: false
  },
  parameterKey: {
    type: String,
    default: ''
  },
  parentValue: {
    type: [String, Number],
    default: null
  },
  valueField: {
    type: String,
    default: 'value'
  },
  labelField: {
    type: String,
    default: 'name'
  }
})

const emit = defineEmits(['update:modelValue', 'change', 'optionsLoaded'])

const selectRef = ref(null)
const isOpen = ref(false)
const isLoading = ref(false)
const options = ref([])
const parameterName = ref('')
const parentParameterKey = ref(null)
const highlightedIndex = ref(-1)

// Computed
const hasParentDependency = computed(() => parentParameterKey.value !== null)
const isWaitingForParent = computed(() => hasParentDependency.value && !props.parentValue)
const displayLabel = computed(() => props.label || parameterName.value)
const displayPlaceholder = computed(() => {
  if (isWaitingForParent.value) return 'Önce üst seçimi yapın...'
  if (props.placeholder) return props.placeholder
  return 'Seçiniz...'
})

const selectedLabel = computed(() => {
  const selected = options.value.find(opt => opt.value === props.modelValue)
  return selected ? selected.name : ''
})

// Methods
const isDisabled = computed(() => props.disabled || isLoading.value || isWaitingForParent.value)

const toggleDropdown = () => {
  if (isDisabled.value) return
  isOpen.value = !isOpen.value
  if (isOpen.value) {
    highlightedIndex.value = options.value.findIndex(opt => opt.value === props.modelValue)
  }
}

const selectOption = (opt) => {
  emit('update:modelValue', opt.value)
  emit('change', opt.value)
  isOpen.value = false
}

const handleKeydown = (e) => {
  if (!isOpen.value) {
    if (e.key === 'Enter' || e.key === ' ' || e.key === 'ArrowDown') {
      e.preventDefault()
      isOpen.value = true
      highlightedIndex.value = options.value.findIndex(opt => opt.value === props.modelValue)
    }
    return
  }

  switch (e.key) {
    case 'ArrowDown':
      e.preventDefault()
      highlightedIndex.value = Math.min(highlightedIndex.value + 1, options.value.length - 1)
      break
    case 'ArrowUp':
      e.preventDefault()
      highlightedIndex.value = Math.max(highlightedIndex.value - 1, 0)
      break
    case 'Enter':
    case ' ':
      e.preventDefault()
      if (highlightedIndex.value >= 0) {
        selectOption(options.value[highlightedIndex.value])
      }
      break
    case 'Escape':
      e.preventDefault()
      isOpen.value = false
      break
  }
}

const handleClickOutside = (e) => {
  if (selectRef.value && !selectRef.value.contains(e.target)) {
    isOpen.value = false
  }
}

const fetchOptions = async () => {
  if (!props.parameterKey) return

  isLoading.value = true
  try {
    // Build URL with optional parentValue query parameter
    let url = `/parameters/${props.parameterKey}/values`
    if (props.parentValue) {
      url += `?parentValue=${encodeURIComponent(props.parentValue)}`
    }

    const response = await api.get(url)
    parameterName.value = response.data.parameterName || ''
    parentParameterKey.value = response.data.parentParameterKey || null
    options.value = (response.data.values || []).map(item => ({
      value: item[props.valueField],
      name: item[props.labelField],
      orderNo: item.orderNo
    }))
    emit('optionsLoaded', options.value)
  } catch (error) {
    console.error(`Failed to fetch options for ${props.parameterKey}:`, error)
    options.value = []
    parameterName.value = ''
    parentParameterKey.value = null
  } finally {
    isLoading.value = false
  }
}

// Watchers
watch(() => props.parameterKey, (newKey) => {
  if (newKey) {
    fetchOptions()
  } else {
    options.value = []
    parameterName.value = ''
    parentParameterKey.value = null
  }
}, { immediate: false })

// Parent değiştiğinde seçimi sıfırla ve yeniden yükle
watch(() => props.parentValue, (newParentValue, oldParentValue) => {
  // Parent değeri değiştiyse ve önceki değer varsa (ilk yükleme değilse)
  if (oldParentValue !== undefined && newParentValue !== oldParentValue) {
    emit('update:modelValue', '')
    emit('change', '')
  }
  // Parent değeri varsa options'ları yeniden yükle
  if (newParentValue && props.parameterKey) {
    fetchOptions()
  } else if (!newParentValue && hasParentDependency.value) {
    // Parent value temizlendiğinde options'ları da temizle
    options.value = []
  }
})

// Lifecycle
onMounted(() => {
  if (props.parameterKey) {
    fetchOptions()
  }
  document.addEventListener('click', handleClickOutside)
})

onUnmounted(() => {
  document.removeEventListener('click', handleClickOutside)
})
</script>

<style scoped>
.mario-select-wrapper {
  display: flex;
  flex-direction: column;
  gap: 6px;
  position: relative;
}

.mario-select__label {
  font-size: 0.75rem;
  font-weight: 700;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.mario-select__container {
  position: relative;
}

.mario-select {
  width: 100%;
  padding: 12px 40px 12px 14px;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  font-size: 0.95rem;
  font-weight: 500;
  color: var(--text);
  font-family: inherit;
  cursor: pointer;
  text-align: left;
  transition: all 0.15s ease;
  box-shadow: 0 3px 0 var(--border);
}

.mario-select:hover:not(:disabled) {
  border-color: var(--mario-blue);
}

.mario-select:focus {
  outline: none;
  border-color: var(--mario-blue);
  box-shadow: 0 3px 0 #037bb5, 0 0 0 4px rgba(4, 156, 216, 0.2);
}

.mario-select-wrapper--open .mario-select {
  border-color: var(--mario-blue);
  box-shadow: 0 3px 0 #037bb5;
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.mario-select-wrapper--error .mario-select {
  border-color: var(--mario-red);
  box-shadow: 0 3px 0 #b91c1c;
}

.mario-select-wrapper--disabled .mario-select {
  opacity: 0.5;
  cursor: not-allowed;
}

.mario-select__value {
  display: block;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.mario-select__arrow {
  position: absolute;
  right: 14px;
  top: 50%;
  transform: translateY(-50%);
  font-size: 0.7rem;
  color: var(--text-muted);
  pointer-events: none;
}

.mario-select__chevron {
  display: inline-block;
  transition: transform 0.2s ease;
}

.mario-select__chevron--open {
  transform: rotate(180deg);
}

.mario-select-wrapper--open .mario-select__arrow {
  color: var(--mario-blue);
}

/* Dropdown */
.mario-select__dropdown {
  position: absolute;
  top: 100%;
  left: 0;
  right: 0;
  background: var(--bg-card);
  border: 2px solid var(--mario-blue);
  border-top: none;
  border-radius: 0 0 var(--radius-md) var(--radius-md);
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.25);
  z-index: 100;
  overflow: hidden;
}

.mario-select__options {
  max-height: 240px;
  overflow-y: auto;
}

.mario-select__empty {
  padding: 16px;
  text-align: center;
  color: var(--text-muted);
  font-size: 0.9rem;
  font-style: italic;
}

.mario-select__option {
  display: flex;
  align-items: center;
  gap: 10px;
  width: 100%;
  padding: 12px 14px;
  background: transparent;
  border: none;
  border-bottom: 1px solid var(--border);
  font-size: 0.95rem;
  font-weight: 500;
  color: var(--text);
  font-family: inherit;
  cursor: pointer;
  text-align: left;
  transition: all 0.1s ease;
}

.mario-select__option:last-child {
  border-bottom: none;
}

.mario-select__option:hover,
.mario-select__option--highlighted {
  background: rgba(4, 156, 216, 0.1);
}

.mario-select__option--selected {
  background: rgba(67, 176, 71, 0.15);
  color: var(--mario-green);
  font-weight: 700;
}

.mario-select__option--selected:hover,
.mario-select__option--selected.mario-select__option--highlighted {
  background: rgba(67, 176, 71, 0.25);
}

.mario-select__option-icon {
  font-size: 0.8rem;
  color: var(--text-muted);
  width: 16px;
  text-align: center;
}

.mario-select__option--selected .mario-select__option-icon {
  color: var(--mario-yellow);
}

.mario-select__option-text {
  flex: 1;
}

.mario-select__option-check {
  font-size: 0.9rem;
  color: var(--mario-green);
  font-weight: 700;
}

/* Hint & Error */
.mario-select__hint {
  font-size: 0.8rem;
  color: var(--text-muted);
  margin: 0;
  font-weight: 500;
}

.mario-select__error {
  font-size: 0.8rem;
  color: var(--mario-red);
  margin: 0;
  font-weight: 600;
}

/* Loading spinner */
.mario-select__spinner {
  display: inline-block;
  width: 12px;
  height: 12px;
  border: 2px solid var(--text-muted);
  border-top-color: var(--mario-blue);
  border-radius: 50%;
  animation: selectSpin 0.8s linear infinite;
}

@keyframes selectSpin {
  to { transform: rotate(360deg); }
}

/* Dropdown Animation */
.dropdown-enter-active,
.dropdown-leave-active {
  transition: all 0.15s ease;
}

.dropdown-enter-from,
.dropdown-leave-to {
  opacity: 0;
  transform: translateY(-8px);
}

/* Scrollbar styling */
.mario-select__options::-webkit-scrollbar {
  width: 6px;
}

.mario-select__options::-webkit-scrollbar-track {
  background: var(--bg-input);
}

.mario-select__options::-webkit-scrollbar-thumb {
  background: var(--border);
  border-radius: 3px;
}

.mario-select__options::-webkit-scrollbar-thumb:hover {
  background: var(--text-muted);
}
</style>

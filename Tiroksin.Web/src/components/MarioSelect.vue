<template>
  <div
    :class="[
      'mario-select-wrapper',
      {
        'mario-select-wrapper--focused': isFocused,
        'mario-select-wrapper--error': error,
        'mario-select-wrapper--disabled': disabled
      }
    ]"
  >
    <label v-if="label" class="mario-select__label">{{ label }}</label>

    <div class="mario-select__container">
      <select
        :value="modelValue"
        :disabled="disabled"
        class="mario-select"
        @change="$emit('update:modelValue', $event.target.value)"
        @focus="isFocused = true"
        @blur="isFocused = false"
      >
        <option v-if="placeholder" value="" disabled>{{ placeholder }}</option>
        <slot></slot>
      </select>
      <span class="mario-select__arrow">▼</span>
    </div>

    <p v-if="hint && !error" class="mario-select__hint">{{ hint }}</p>
    <p v-if="error" class="mario-select__error">{{ error }}</p>
  </div>
</template>

<script setup>
import { ref } from 'vue'

defineProps({
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
  }
})

defineEmits(['update:modelValue'])

const isFocused = ref(false)
</script>

<style scoped>
.mario-select-wrapper {
  display: flex;
  flex-direction: column;
  gap: 6px;
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
  display: flex;
  align-items: center;
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
  appearance: none;
  -webkit-appearance: none;
  transition: all 0.15s ease;
  box-shadow: 0 3px 0 var(--border);
}

.mario-select:focus {
  outline: none;
  border-color: var(--mario-blue);
  box-shadow: 0 3px 0 #037bb5, 0 0 0 4px rgba(4, 156, 216, 0.2);
}

.mario-select-wrapper--error .mario-select {
  border-color: var(--mario-red);
  box-shadow: 0 3px 0 #b91c1c, 0 0 0 4px rgba(224, 36, 36, 0.2);
}

.mario-select-wrapper--disabled .mario-select {
  opacity: 0.5;
  cursor: not-allowed;
}

.mario-select option {
  background: var(--bg-card);
  color: var(--text);
  padding: 10px;
}

.mario-select__arrow {
  position: absolute;
  right: 14px;
  font-size: 0.7rem;
  color: var(--text-muted);
  pointer-events: none;
  transition: transform 0.2s ease;
}

.mario-select-wrapper--focused .mario-select__arrow {
  color: var(--mario-blue);
}

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
</style>

<template>
  <div
    :class="[
      'mario-input-wrapper',
      `mario-input-wrapper--${size}`,
      {
        'mario-input-wrapper--focused': isFocused,
        'mario-input-wrapper--error': error,
        'mario-input-wrapper--disabled': disabled,
        'mario-input-wrapper--centered': centered
      }
    ]"
  >
    <label v-if="label" class="mario-input__label">{{ label }}</label>

    <div class="mario-input__container">
      <span v-if="$slots.prefix || prefix" class="mario-input__prefix">
        <slot name="prefix">{{ prefix }}</slot>
      </span>

      <input
        v-if="type !== 'textarea'"
        :type="type"
        :value="modelValue"
        :placeholder="placeholder"
        :disabled="disabled"
        :readonly="readonly"
        :maxlength="maxlength"
        :min="min"
        :max="max"
        :class="['mario-input', { 'mario-input--uppercase': isUppercase }]"
        @input="handleInput($event)"
        @focus="handleFocus"
        @blur="handleBlur"
        @keyup.enter="$emit('enter', $event)"
      />

      <textarea
        v-else
        :value="modelValue"
        :placeholder="placeholder"
        :disabled="disabled"
        :readonly="readonly"
        :maxlength="maxlength"
        :rows="rows"
        class="mario-input mario-input--textarea"
        @input="$emit('update:modelValue', $event.target.value)"
        @focus="handleFocus"
        @blur="handleBlur"
      ></textarea>

      <span v-if="$slots.suffix || suffix" class="mario-input__suffix">
        <slot name="suffix">{{ suffix }}</slot>
      </span>
    </div>

    <p v-if="hint && !error" class="mario-input__hint">{{ hint }}</p>
    <p v-if="error" class="mario-input__error">{{ error }}</p>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const props = defineProps({
  modelValue: {
    type: [String, Number],
    default: ''
  },
  type: {
    type: String,
    default: 'text'
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
  readonly: {
    type: Boolean,
    default: false
  },
  maxlength: {
    type: [String, Number],
    default: null
  },
  min: {
    type: [String, Number],
    default: null
  },
  max: {
    type: [String, Number],
    default: null
  },
  rows: {
    type: [String, Number],
    default: 3
  },
  prefix: {
    type: String,
    default: ''
  },
  suffix: {
    type: String,
    default: ''
  },
  centered: {
    type: Boolean,
    default: false
  },
  isUppercase: {
    type: Boolean,
    default: false
  },
  size: {
    type: String,
    default: 'md',
    validator: (v) => ['sm', 'md', 'lg'].includes(v)
  }
})

const emit = defineEmits(['update:modelValue', 'focus', 'blur', 'enter'])

const isFocused = ref(false)

function handleInput(e) {
  let value = e.target.value
  if (props.isUppercase) {
    value = value.toUpperCase()
  }
  emit('update:modelValue', value)
}

function handleFocus() {
  isFocused.value = true
}

function handleBlur() {
  isFocused.value = false
}
</script>

<style scoped>
.mario-input-wrapper {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.mario-input__label {
  font-size: 0.75rem;
  font-weight: 700;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.mario-input__container {
  display: flex;
  align-items: center;
  background: var(--bg-input);
  border: 2px solid var(--border);
  border-radius: var(--radius-md);
  transition: all 0.15s ease;
  overflow: hidden;
  box-shadow: 0 4px 0 rgba(0, 0, 0, 0.2);
}

.mario-input-wrapper--focused .mario-input__container {
  border-color: var(--mario-blue);
  box-shadow: 0 3px 0 #037bb5, 0 0 0 4px rgba(4, 156, 216, 0.2);
}

.mario-input-wrapper--error .mario-input__container {
  border-color: var(--mario-red);
  box-shadow: 0 3px 0 #b91c1c, 0 0 0 4px rgba(224, 36, 36, 0.2);
}

.mario-input-wrapper--disabled .mario-input__container {
  opacity: 0.5;
  cursor: not-allowed;
}

.mario-input {
  flex: 1;
  background: transparent;
  border: none;
  font-weight: 600;
  color: var(--text);
}

/* Size variants - match MarioButton heights */
.mario-input-wrapper--sm .mario-input {
  padding: 6px 12px;
  font-size: 0.8rem;
}

.mario-input-wrapper--md .mario-input {
  padding: 10px 14px;
  font-size: 0.9rem;
}

.mario-input-wrapper--lg .mario-input {
  padding: 14px 18px;
  font-size: 1rem;
}

.mario-input-wrapper--sm .mario-input__prefix,
.mario-input-wrapper--sm .mario-input__suffix {
  padding: 0 10px;
  font-size: 0.9rem;
}

.mario-input-wrapper--lg .mario-input__prefix,
.mario-input-wrapper--lg .mario-input__suffix {
  padding: 0 14px;
  font-size: 1.1rem;
}

.mario-input::placeholder {
  color: var(--text-muted);
  font-weight: 400;
}

.mario-input:focus {
  outline: none;
}

.mario-input:disabled {
  cursor: not-allowed;
}

.mario-input--textarea {
  resize: vertical;
  min-height: 80px;
}

.mario-input__prefix,
.mario-input__suffix {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 0 12px;
  font-size: 1rem;
  color: var(--text-muted);
  background: transparent;
  min-height: 100%;
  align-self: stretch;
}

.mario-input__hint {
  font-size: 0.8rem;
  color: var(--text-muted);
  margin: 0;
  font-weight: 500;
}

.mario-input__error {
  font-size: 0.8rem;
  color: var(--mario-red);
  margin: 0;
  font-weight: 600;
}

/* Centered variant */
.mario-input-wrapper--centered .mario-input {
  text-align: center;
  letter-spacing: 3px;
  font-weight: 700;
}

.mario-input-wrapper--centered .mario-input::placeholder {
  letter-spacing: 1px;
}

/* Uppercase variant */
.mario-input--uppercase {
  text-transform: uppercase;
}
</style>

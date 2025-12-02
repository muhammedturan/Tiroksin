<template>
  <component
    :is="componentTag"
    :type="isButton ? type : undefined"
    :to="to"
    :href="href"
    :disabled="disabled || loading"
    :class="[
      'mario-button',
      `mario-button--${color}`,
      `mario-button--${size}`,
      {
        'mario-button--block': block,
        'mario-button--loading': loading,
        'mario-button--icon-only': iconOnly
      }
    ]"
    @click="$emit('click', $event)"
  >
    <span v-if="loading" class="mario-button__loader"></span>
    <span v-else class="mario-button__content">
      <span v-if="$slots.icon || icon" class="mario-button__icon">
        <slot name="icon">{{ icon }}</slot>
      </span>
      <span v-if="!iconOnly" class="mario-button__text">
        <slot></slot>
      </span>
    </span>
  </component>
</template>

<script setup>
import { computed } from 'vue'

const props = defineProps({
  color: {
    type: String,
    default: 'green',
    validator: (v) => ['red', 'blue', 'green', 'yellow', 'orange', 'pink', 'gray'].includes(v)
  },
  size: {
    type: String,
    default: 'md',
    validator: (v) => ['sm', 'md', 'lg'].includes(v)
  },
  type: {
    type: String,
    default: 'button'
  },
  // router-link destination
  to: {
    type: [String, Object],
    default: null
  },
  // anchor href
  href: {
    type: String,
    default: null
  },
  disabled: {
    type: Boolean,
    default: false
  },
  loading: {
    type: Boolean,
    default: false
  },
  block: {
    type: Boolean,
    default: false
  },
  icon: {
    type: String,
    default: ''
  },
  iconOnly: {
    type: Boolean,
    default: false
  }
})

defineEmits(['click'])

const componentTag = computed(() => {
  if (props.to) return 'router-link'
  if (props.href) return 'a'
  return 'button'
})

const isButton = computed(() => !props.to && !props.href)
</script>

<style scoped>
.mario-button {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
  border: none;
  border-radius: var(--radius-md);
  font-weight: 700;
  cursor: pointer;
  transition: all 0.15s ease;
  position: relative;
  text-transform: uppercase;
  letter-spacing: 0.5px;
  text-decoration: none;
}

/* Sizes */
.mario-button--sm {
  padding: 8px 14px;
  font-size: 0.8rem;
}

.mario-button--md {
  padding: 12px 20px;
  font-size: 0.9rem;
}

.mario-button--lg {
  padding: 16px 28px;
  font-size: 1rem;
}

/* Icon only adjustments - match text button heights */
.mario-button--icon-only.mario-button--sm {
  padding: 8px;
  width: 32px;
  height: 32px;
}

.mario-button--icon-only.mario-button--md {
  padding: 10px;
  width: 40px;
  height: 40px;
}

.mario-button--icon-only.mario-button--lg {
  padding: 14px;
  width: 48px;
  height: 48px;
}

/* Block */
.mario-button--block {
  width: 100%;
}

/* Colors */
.mario-button--green {
  background: var(--mario-green);
  color: white;
  box-shadow: 0 4px 0 #2d8a31;
}

.mario-button--green:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #2d8a31;
}

.mario-button--green:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 1px 0 #2d8a31;
}

.mario-button--red {
  background: var(--mario-red);
  color: white;
  box-shadow: 0 4px 0 #a31b18;
}

.mario-button--red:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #a31b18;
}

.mario-button--red:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 1px 0 #a31b18;
}

.mario-button--blue {
  background: var(--mario-blue);
  color: white;
  box-shadow: 0 4px 0 #037bb5;
}

.mario-button--blue:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #037bb5;
}

.mario-button--blue:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 1px 0 #037bb5;
}

.mario-button--yellow {
  background: var(--mario-yellow);
  color: #92400e;
  box-shadow: 0 4px 0 #d97706;
}

.mario-button--yellow:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #d97706;
}

.mario-button--yellow:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 1px 0 #d97706;
}

.mario-button--orange {
  background: var(--mario-orange);
  color: white;
  box-shadow: 0 4px 0 #c46a19;
}

.mario-button--orange:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #c46a19;
}

.mario-button--orange:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 1px 0 #c46a19;
}

.mario-button--pink {
  background: var(--mario-pink);
  color: white;
  box-shadow: 0 4px 0 #db2777;
}

.mario-button--pink:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 #db2777;
}

.mario-button--pink:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 1px 0 #db2777;
}

.mario-button--gray {
  background: var(--bg-card-light);
  color: var(--text);
  box-shadow: 0 4px 0 var(--border);
}

.mario-button--gray:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 0 var(--border);
  background: var(--bg-card-hover);
}

.mario-button--gray:active:not(:disabled) {
  transform: translateY(2px);
  box-shadow: 0 1px 0 var(--border);
}

/* Disabled */
.mario-button:disabled {
  opacity: 0.5;
  cursor: not-allowed;
  transform: none !important;
  box-shadow: 0 2px 0 rgba(0, 0, 0, 0.2) !important;
}

/* Loading */
.mario-button--loading {
  pointer-events: none;
}

.mario-button__loader {
  width: 18px;
  height: 18px;
  border: 3px solid rgba(255, 255, 255, 0.3);
  border-top-color: white;
  border-radius: 50%;
  animation: spin 0.8s linear infinite;
}

.mario-button--yellow .mario-button__loader {
  border: 3px solid rgba(146, 64, 14, 0.3);
  border-top-color: #92400e;
}

@keyframes spin {
  to { transform: rotate(360deg); }
}

/* Content */
.mario-button__content {
  display: flex;
  align-items: center;
  gap: 8px;
}

.mario-button__icon {
  font-size: 1.1em;
  line-height: 1;
}

.mario-button__text {
  line-height: 1;
}
</style>

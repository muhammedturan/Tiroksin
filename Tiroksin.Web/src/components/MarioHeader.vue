<template>
  <MarioCard :color="color" class="mario-header">
    <div class="mario-header__content">
      <div class="mario-header__left">
        <div class="mario-header__icon">{{ icon }}</div>
        <div class="mario-header__info">
          <span class="mario-header__title">{{ title }}</span>
          <span v-if="subtitle" class="mario-header__subtitle">{{ subtitle }}</span>
        </div>
      </div>
      <div class="mario-header__right">
        <div v-if="stats && stats.length" class="mario-header__stats">
          <span v-for="stat in stats" :key="stat.label" class="mario-header__stat">
            {{ stat.icon }} {{ stat.value }}
          </span>
        </div>
        <slot name="action">
          <!-- Default action slot -->
        </slot>
      </div>
    </div>
  </MarioCard>
</template>

<script setup>
import MarioCard from './MarioCard.vue'

defineProps({
  title: {
    type: String,
    required: true
  },
  subtitle: {
    type: String,
    default: ''
  },
  icon: {
    type: String,
    default: '🎮'
  },
  color: {
    type: String,
    default: 'blue'
  },
  stats: {
    type: Array,
    default: () => []
    // Format: [{ icon: '👥', value: '0/10' }, { icon: '❓', value: '10' }]
  }
})
</script>

<style scoped>
.mario-header {
  padding: 14px 18px !important;
}

.mario-header__content {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 16px;
}

.mario-header__left {
  display: flex;
  align-items: center;
  gap: 12px;
  flex: 1;
  min-width: 0;
}

.mario-header__icon {
  width: 44px;
  height: 44px;
  background: rgba(255, 255, 255, 0.2);
  border-radius: var(--radius-md);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.4rem;
  flex-shrink: 0;
}

.mario-header__info {
  display: flex;
  flex-direction: column;
  min-width: 0;
  gap: 2px;
}

.mario-header__title {
  font-size: 1.1rem;
  font-weight: 700;
  color: white;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.mario-header__subtitle {
  font-size: 0.75rem;
  color: rgba(255, 255, 255, 0.8);
  font-weight: 500;
}

.mario-header__right {
  display: flex;
  align-items: center;
  gap: 12px;
  flex-shrink: 0;
}

.mario-header__stats {
  display: flex;
  gap: 8px;
}

.mario-header__stat {
  display: flex;
  align-items: center;
  gap: 4px;
  padding: 6px 10px;
  background: rgba(255, 255, 255, 0.2);
  border-radius: var(--radius-md);
  font-size: 0.8rem;
  font-weight: 700;
  color: white;
}

/* Responsive */
@media (max-width: 600px) {
  .mario-header {
    padding: 12px 14px !important;
  }

  .mario-header__content {
    flex-wrap: wrap;
    gap: 12px;
  }

  .mario-header__icon {
    width: 38px;
    height: 38px;
    font-size: 1.2rem;
  }

  .mario-header__title {
    font-size: 1rem;
  }

  .mario-header__stats {
    display: none;
  }
}
</style>

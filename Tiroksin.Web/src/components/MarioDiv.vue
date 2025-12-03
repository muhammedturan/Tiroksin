<template>
  <div class="mario-div" :class="[`mario-div--${color}`, { 'mario-div--no-header': !title }]">
    <!-- Header -->
    <div v-if="title" class="mario-div__header">
      <div class="header-left">
        <span v-if="icon" class="header-icon">{{ icon }}</span>
        <h3 class="header-title">{{ title }}</h3>
      </div>
      <div v-if="$slots.badge || badge" class="header-badge">
        <slot name="badge">{{ badge }}</slot>
      </div>
    </div>

    <!-- Content -->
    <div class="mario-div__content">
      <slot />
    </div>

    <!-- Footer (optional) -->
    <div v-if="$slots.footer" class="mario-div__footer">
      <slot name="footer" />
    </div>
  </div>
</template>

<script setup>
defineProps({
  // Border rengi: red, blue, green, yellow, orange, pink, white
  color: {
    type: String,
    default: 'white',
    validator: (value) => ['red', 'blue', 'green', 'yellow', 'orange', 'pink', 'white'].includes(value)
  },
  // Header başlığı
  title: {
    type: String,
    default: ''
  },
  // Header ikonu
  icon: {
    type: String,
    default: ''
  },
  // Header badge (sayı vs.)
  badge: {
    type: [String, Number],
    default: ''
  }
})
</script>

<style scoped>
.mario-div {
  background: var(--bg-card);
  border-radius: var(--radius-xl);
  overflow: hidden;
  border: 3px solid;
}

/* ==========================================
   RENK VARYASYONLARI
   ========================================== */

.mario-div--red {
  border-color: var(--mario-red);
  box-shadow: 0 6px 0 rgba(163, 27, 24, 0.4);
}

.mario-div--red .mario-div__header {
  background: linear-gradient(135deg, var(--mario-red), #dc2626);
}

.mario-div--red .header-badge {
  background: var(--mario-red);
  box-shadow: 0 2px 0 #a31b18;
}

.mario-div--blue {
  border-color: var(--mario-blue);
  box-shadow: 0 6px 0 rgba(3, 123, 181, 0.4);
}

.mario-div--blue .mario-div__header {
  background: linear-gradient(135deg, var(--mario-blue), #0369a1);
}

.mario-div--blue .header-badge {
  background: var(--mario-blue);
  box-shadow: 0 2px 0 #037bb5;
}

.mario-div--green {
  border-color: var(--mario-green);
  box-shadow: 0 6px 0 rgba(45, 138, 49, 0.4);
}

.mario-div--green .mario-div__header {
  background: linear-gradient(135deg, var(--mario-green), #15803d);
}

.mario-div--green .header-badge {
  background: var(--mario-green);
  box-shadow: 0 2px 0 #2d8a31;
}

.mario-div--yellow {
  border-color: var(--mario-yellow);
  box-shadow: 0 6px 0 rgba(201, 160, 0, 0.4);
}

.mario-div--yellow .mario-div__header {
  background: linear-gradient(135deg, var(--mario-yellow), #eab308);
  color: #92400e;
}

.mario-div--yellow .header-badge {
  background: var(--mario-yellow);
  box-shadow: 0 2px 0 #c9a000;
  color: #92400e;
}

.mario-div--orange {
  border-color: var(--mario-orange);
  box-shadow: 0 6px 0 rgba(196, 106, 25, 0.4);
}

.mario-div--orange .mario-div__header {
  background: linear-gradient(135deg, var(--mario-orange), #ea580c);
}

.mario-div--orange .header-badge {
  background: var(--mario-orange);
  box-shadow: 0 2px 0 #c46a19;
}

.mario-div--pink {
  border-color: var(--mario-pink);
  box-shadow: 0 6px 0 rgba(219, 39, 119, 0.4);
}

.mario-div--pink .mario-div__header {
  background: linear-gradient(135deg, var(--mario-pink), #db2777);
}

.mario-div--pink .header-badge {
  background: var(--mario-pink);
  box-shadow: 0 2px 0 #db2777;
}

.mario-div--white {
  border-color: var(--border);
  box-shadow: 0 6px 0 rgba(0, 0, 0, 0.1);
}

.mario-div--white .mario-div__header {
  background: linear-gradient(135deg, #f8f9fa, #e9ecef);
  color: var(--text);
}

.mario-div--white .header-badge {
  background: var(--bg-card);
  box-shadow: 0 2px 0 rgba(0, 0, 0, 0.1);
  color: var(--text);
  border: 1px solid var(--border);
}

/* ==========================================
   HEADER
   ========================================== */

.mario-div__header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 12px 16px;
  color: white;
}

.header-left {
  display: flex;
  align-items: center;
  gap: 10px;
}

.header-icon {
  font-size: 1.2rem;
}

.header-title {
  font-size: 0.95rem;
  font-weight: 800;
  margin: 0;
  text-transform: uppercase;
  letter-spacing: 1px;
}

.header-badge {
  min-width: 28px;
  height: 28px;
  padding: 0 10px;
  border-radius: var(--radius-full);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.85rem;
  font-weight: 800;
  color: white;
}

/* ==========================================
   CONTENT
   ========================================== */

.mario-div__content {
  padding: 16px;
}

.mario-div--no-header .mario-div__content {
  padding: 20px;
}

/* ==========================================
   FOOTER
   ========================================== */

.mario-div__footer {
  padding: 12px 16px;
  border-top: 2px dashed var(--border);
  text-align: center;
  color: var(--text-muted);
  font-size: 0.85rem;
}

/* ==========================================
   RESPONSIVE
   ========================================== */

@media (max-width: 600px) {
  .mario-div__header {
    padding: 10px 14px;
  }

  .header-title {
    font-size: 0.85rem;
  }

  .mario-div__content {
    padding: 14px;
  }

  .mario-div--no-header .mario-div__content {
    padding: 16px;
  }
}
</style>

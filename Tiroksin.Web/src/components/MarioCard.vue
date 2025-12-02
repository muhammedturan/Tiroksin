<template>
  <div
    class="mario-card"
    :class="[`mario-card--${color}`, { 'mario-card--hero': hero }]"
  >
    <div class="mario-card__content">
      <slot />
    </div>

    <!-- Optional Mario-style decorative blocks -->
    <div v-if="showDeco" class="mario-card__deco">
      <div class="deco-block block-1">?</div>
      <div class="deco-block block-2">!</div>
      <div class="deco-star">⭐</div>
    </div>
  </div>
</template>

<script setup>
defineProps({
  // Mario renkleri: red, blue, green, yellow, orange, pink
  color: {
    type: String,
    default: 'red',
    validator: (value) => ['red', 'blue', 'green', 'yellow', 'orange', 'pink'].includes(value)
  },
  // Hero section olarak mı kullanılacak (daha büyük padding)
  hero: {
    type: Boolean,
    default: false
  },
  // Dekoratif blokları göster
  showDeco: {
    type: Boolean,
    default: false
  }
})
</script>

<style scoped>
.mario-card {
  border-radius: var(--radius-lg);
  position: relative;
  overflow: hidden;
  color: white;
}

.mario-card__content {
  position: relative;
  z-index: 1;
}

/* ==========================================
   RENK VARYASYONLARI
   ========================================== */

/* 🔴 Kırmızı - Mario Red */
.mario-card--red {
  background: var(--mario-red);
  box-shadow: 0 4px 0 #a31b18;
}

/* 🔵 Mavi - Mario Blue */
.mario-card--blue {
  background: var(--mario-blue);
  box-shadow: 0 4px 0 #037bb5;
}

/* 🟢 Yeşil - Mario Green */
.mario-card--green {
  background: var(--mario-green);
  box-shadow: 0 4px 0 #2d8a31;
}

/* 🟡 Sarı - Mario Yellow */
.mario-card--yellow {
  background: var(--mario-yellow);
  box-shadow: 0 4px 0 #c9a000;
  color: #92400e;
}

/* 🟠 Turuncu - Mario Orange */
.mario-card--orange {
  background: var(--mario-orange);
  box-shadow: 0 4px 0 #c46a19;
}

/* 🩷 Pembe - Mario Pink */
.mario-card--pink {
  background: var(--mario-pink);
  box-shadow: 0 4px 0 #db2777;
}

/* ==========================================
   HERO VARYASYONU (Büyük Padding)
   ========================================== */

.mario-card--hero {
  padding: 28px 24px;
  text-align: center;
}

.mario-card:not(.mario-card--hero) {
  padding: 16px 20px;
}

/* ==========================================
   DEKORATİF BLOKLAR
   ========================================== */

.mario-card__deco {
  position: absolute;
  bottom: 12px;
  right: 20px;
  display: flex;
  align-items: flex-end;
  gap: 8px;
  z-index: 0;
  opacity: 0.6;
  pointer-events: none;
}

.deco-block {
  width: 28px;
  height: 28px;
  background: #fbbf24;
  border-radius: 4px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.8rem;
  font-weight: 800;
  color: #92400e;
  box-shadow: 0 2px 0 #d97706;
  animation: blockBounce 2s ease-in-out infinite;
}

.deco-block.block-2 {
  animation-delay: 0.3s;
  background: #f472b6;
  box-shadow: 0 2px 0 #db2777;
  color: white;
}

.deco-star {
  font-size: 1.2rem;
  animation: starSpin 3s linear infinite;
}

@keyframes blockBounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-4px); }
}

@keyframes starSpin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

/* ==========================================
   RESPONSIVE
   ========================================== */

@media (max-width: 600px) {
  .mario-card--hero {
    padding: 24px 20px;
  }

  .mario-card__deco {
    display: none;
  }
}
</style>

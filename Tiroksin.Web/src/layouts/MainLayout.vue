<template>
  <div class="main-layout">
    <div class="content-area">
      <slot></slot>
    </div>
  </div>
</template>

<script setup>
// Main layout wrapper
</script>

<style scoped>
.main-layout {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  background: white;
}

.content-area {
  flex: 1;
  width: 100%;
  height: 100%;
  overflow: hidden;
  display: flex;
  flex-direction: column;
}
</style>

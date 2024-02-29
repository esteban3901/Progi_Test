<script setup>
import Home from './views/Home.vue'
import Vehicle from "@/components/Vehicle.vue";
</script>

<template>
  <header>
    <div class="wrapper">
      <Home msg="Welcome"/>
    </div>
  </header>

  <main>
    <div>
      <Vehicle></Vehicle>
    </div>
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
    margin-bottom: 10rem;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>

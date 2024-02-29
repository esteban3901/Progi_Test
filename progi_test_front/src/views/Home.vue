<script setup>
defineProps({
  msg: {
    type: String,
    required: true
  }
})
</script>

<template>
  <div>
    <h1> {{ msg }}</h1>
    <h3>
      This little webapp provides you a view where you can see the taxes applied to common or luxury vehicles.
    </h3>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  position: relative;
  top: -10px;
}

h3 {
  font-size: 1.2rem;
}

h1,
h3 {
  text-align: center;
}
</style>

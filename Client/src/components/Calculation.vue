<template>
  <div class="text-5xl text-white text-right mx-4">{{current}}</div>
</template>

<script>
export default {
  data() {
    return {
      current: 0,
      number1: null,
      number2: null
    }
  }
}
</script>

<style scoped>
div {
  font-family: 'Noto Sans SC', sans-serif;
}
</style>
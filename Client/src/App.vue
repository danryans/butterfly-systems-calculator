<template>
  <div class="w-screen flex justify-center">
    <main class="w-1/4 p-3 mt-12">
      <Calculation/>
      <Buttons/>
    </main>
  </div>
</template>

<script>
import Calculation from './components/Calculation.vue'
import Buttons from './components/Buttons.vue'

export default {
  name: 'App',
  components: {
    Calculation,
    Buttons
  }
}
</script>

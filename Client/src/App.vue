<template>
  <div class="w-screen flex justify-center">
    <main class="w-1/4 border rounded bg-blue-200 p-1 mt-12">
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

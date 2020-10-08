<template>
  <div class="w-screen flex justify-center">
    <main class="w-1/4 p-3 mt-12">
      <Buttons/>
    </main>
  </div>
</template>

<script>
import Buttons from './components/Buttons.vue'

export default {
  name: 'App',
  components: {
    Buttons
  }
}
</script>

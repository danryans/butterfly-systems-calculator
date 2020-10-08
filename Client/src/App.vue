<template>
  <main class="container">
    <Header/>
    <Calculation/>
    <Buttons/>
  </main>
</template>

<script>
import Header from './components/Header.vue'
import Calculation from './components/Calculation.vue'
import Buttons from './components/Buttons.vue'

export default {
  name: 'App',
  components: {
    Header,
    Calculation,
    Buttons
  }
}
</script>

<template>
  <div class="border-blue-800 border-t border-r border-l rounded-t shadow-sm bg-blue-200 text-5xl text-white text-right px-5">{{current}}</div>
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
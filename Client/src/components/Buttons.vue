<template>
  <div class="shadow-lg">
    <div class="border-t border-r border-l rounded-t text-blue-800 font-bold text-6xl py-3 px-5">
      <span v-if="!number1 && !number2">{{current}}</span>
      <span v-if="operator">{{operator}}</span>
    </div>
    <!-- buttons -->
    <div class="border-l border-r border-b p-6">
      <div class="grid grid-cols-4 gap-4">
        <Button v-for="operation in operations" :key="operation"
          @click="operator = operation; $forceUpdate()" primary="true">{{operation}}</Button>
        <Button v-for="index in 9" :key="index">{{ index }}</Button>
        <Button>0</Button>
        <Button @click="$emit('add-decimal', '+')" primary="true">.</Button>
        <Button @click="$emit('evaluate', '+')" primary="true">C</Button>
      </div>

      <!-- evaluate button -->
      <div class="pt-4 grid grid-cols-1">
        <Button primary="true">=</Button>
      </div>
    </div>
  </div>
</template>

<script>
import Button from "./Button";

export default {
  components: {
    Button,
  },
  data() {
    return {
      operations: ['+', '-', 'x ', '%'],
      current: 0,
      operator: null,
      number1: null,
      number2: null,
    };
  },
  methods: {
    calculate: function() {
      fetch("localhost:20661/calculator/calculate/")
        .then(reply => reply.json())
        .then(response => console.log(response));
    }
  }
};
</script>

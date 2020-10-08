<template>
  <div class="shadow-lg">
    <div class="border-t border-r border-l rounded-t text-blue-800 font-bold text-6xl py-3 px-5">
      {{numbers[1]}}
      <span class="ml-1 mr-1" v-if="operator">{{operator}}</span>
      {{numbers[2]}}
    </div>
    <!-- buttons -->
    <div class="border-l border-r border-b p-6">
      <div class="grid grid-cols-4 gap-4">
        <!-- operations -->
        <Button v-for="operation in operations" :key="operation"
          @click="setOperator(operation)"
          primary="true">{{operation}}</Button>

        <!-- 1 to 9 -->
        <Button v-for="index in 9" @click="addToNumber(index)" :key="index">{{ index }}</Button>

        <!-- 0 . C -->
        <Button @click="addToNumber(0)">0</Button>
        <Button @click="addDecimalToNumber" primary="true">.</Button>
        <Button @click="clear" primary="true">C</Button>
      </div>

      <!-- evaluate -->
      <div class="pt-4 grid grid-cols-1">
        <Button @click="evaluate" primary="true">=</Button>
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
      operator: null,
      active: 1,
      numbers: {
        "1": "0",
        "2": ""
      }
    };
  },
  methods: {
    evaluate: function() {
      fetch("http://localhost:5000/calculator/calculate/")
        .then(reply => reply.json())
        .then(response => console.log(response));
    },
    clear: function() {
      this.active = 1;
      this.operator = null;
      this.numbers = {
        1: "0",
        2: ""
      };
    },
    setOperator: function (operator) {
      this.operator = operator;
      this.active = 2;
      
      // check if second number is set, if not set to 0
      if (this.numbers["2"] === null) {
        this.number2 = "0";
      }
    },
    addToNumber: function(value) {
      // convert number to string
      value = value.toString();
      const active = this.active.toString();

      // check active number for 0. set to value - if not concat it on end
      this.numbers[active] = (this.numbers[active] === "0" ? value : this.numbers[active].concat(value));
    },
    addDecimalToNumber: function() {
      // check active number does not already have a decimal point
      const active = this.active.toString();
      if (this.numbers[active].indexOf(".") === -1) {
        // add decimal
        this.numbers[active] += ".";
      }
    }
  }
};
</script>

<template>
  <div class="shadow-lg">
    <!-- calculation -->
    <div :class="{
          'break-words border-t border-r border-l rounded-t font-bold py-3 px-5': true,
          'text-3xl text-white bg-blue-400 text-shadow': result,
          'text-5xl text-blue-800': !result
        }">
      {{numbers[1]}}
      <span class="ml-1 mr-1" v-if="operator">{{operator}}</span>
      {{numbers[2]}}
    </div>

    <!-- result -->
    <div v-if="result" class="break-all border-r border-l bg-green-400 text-blue-800 font-extrabold text-3xl py-2 px-5">
      = {{result}}
    </div>

    <!-- error (if any - hopefully not!) -->
    <div v-if="error" class="text-red-400 text-center text-lg border-l border-r p-3">
      <div class="text-red-400 font-bold">Oh no! 😞</div>
      <div class="text-sm">{{error}}</div>
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
      operations: ['+', '-', 'x', '%'],
      operator: null,
      active: 1,
      numbers: {
        "1": "0",
        "2": ""
      },
      error: null,
      result: null
    };
  },
  methods: {
    evaluate: function() {
      // reset any errors
      this.error = null;
      this.result = null;

      // remove leading decimal (if necessary)
      this.removeLeadingDecimal();

      // send POST request to our REST api endpoint
      fetch("https://localhost:5001/calculator/calculate", {
        method: 'post',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "number1": Number(this.numbers["1"]),
          "number2": Number(this.numbers["2"]),
          "operation": this.operator
        })
      })
      // check response was great, if not lets print an error
      .then(reply => {
        if (!reply.ok) {
          reply.json().then(error => this.error = error.message);
        } else {
          return reply.json();
        }
      })

      // handle success
      .then(response => this.result = response.result)

      // handle network errors
      .catch(error => this.error = error);
    },
    clear: function() {
      this.active = 1;
      this.operator = null;
      this.result = null;
      this.numbers = {
        "1": "0",
        "2": ""
      };
      this.error = null;
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
    },
    removeLeadingDecimal: function() {
      // remove lone decimal point at the end of each number if no trailing numbers
      for (var i = 1; i <= 2; i++) {
        const number = i.toString();
        if (this.numbers[number].endsWith('.')) {
          this.numbers[number] = this.numbers[number].replace('.', '');
        }
      }
    }
  }
};
</script>

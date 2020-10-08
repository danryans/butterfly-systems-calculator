<template>
    <div class="border border-blue-500 shadow-lg p-3 grid grid-cols-4 gap-4">
        <Button primary="true">+</Button>
        <Button primary="true">-</Button>
        <Button primary="true">x</Button>
        <Button primary="true">/</Button>
        <Button v-for="index in 9" :key="index">{{index}}</Button>
        <Button>0</Button>
    </div>
</template>

<script>
import Button from './Button'

export default {
    components: {
        Button
    }
}
</script>

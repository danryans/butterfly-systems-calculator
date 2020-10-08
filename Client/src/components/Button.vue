<template>
    <button :class="{'focus:border-blue-300 focus:border-solid hover:bg-blue-200 font-medium rounded-md bg-blue-100 text-blue-500 shadow-sm text-lg text-center my-1 p-4': true, 
                'hover:bg-blue-400 hover:text-white border-blue-200 bg-blue-300 text-blue-700': primary
            }"
        @click="$emit('click')">
        <slot></slot>
    </button>
</template>

<script>
export default {
    props: ['primary']
}
</script>
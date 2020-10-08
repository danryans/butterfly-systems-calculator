<template>
    <button :class="{'rounded-md bg-blue-100 border-solid text-grey-800 shadow-sm border border-blue-200 text-center my-1 p-4': true, 
                'border-blue-200 bg-blue-300 text-blue-700': primary
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
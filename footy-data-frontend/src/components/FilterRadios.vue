<template>
    <label class="flex mr-4 items-center flex-nowrap">
        <input type="radio" name="show" value="all" checked @change="filter">
        <span class="whitespace-nowrap ml-1">Show all</span>
    </label>
    <label class="flex mr-4 items-center flex-nowrap">
        <input type="radio" name="show" value="past" @change="filter">
        <span class="whitespace-nowrap ml-1">Past</span>
    </label>
    <label class="flex mr-4 items-center flex-nowrap">
        <input type="radio" name="show" value="live" @change="filter">
        <span class="whitespace-nowrap ml-1">LIVE !</span>
    </label>
    <label class="flex mr-4 items-center flex-nowrap">
        <input type="radio" name="show" value="future" @change="filter">
        <span class="whitespace-nowrap ml-1">Next</span>
    </label>
</template>

<script setup lang="ts">

const emit: any = defineEmits(["filter"])
const filter: Function = (e: Event) => {
    emit("filter", (e.target as HTMLInputElement).value);
}
</script>

<style>

</style>
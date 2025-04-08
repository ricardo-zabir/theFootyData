<template>
    <form class="py-3 px-4 flex items-center">
        <label class="sr-only">Search</label>
        <div class="relative w-full">
            
            <input type="text" placeholder="Search a team" class="border border-gray-300 rounded-full px-4 py-2 " @input="searchFor"/>
        </div>
    </form>
</template>

<script setup lang="ts">
import { ref, Ref } from "vue";

const show: Ref = ref(false);
const emit: any = defineEmits(["search"])
const searchFor: Function = (e: Event) => {
    emit("search", (e.target as HTMLInputElement).value);
}
</script>

<style>

</style>
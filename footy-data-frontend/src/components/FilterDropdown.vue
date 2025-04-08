<template>
  <div class="relative flex items-center w-full px-4">
    <button @click="show = !show" class="w-full flex items-center justify-center py-2 px-4">
        Filter
    </button>
    <div v-if="show" class="absolute top-12 right-0 z-10 w-48 p-3 rounded-lg shadow bg-white ">
        <h6 class="mb-3 text-gray-900 font-medium text-sm ">
            Matchday
        </h6>
        <ul class="space-y-2 text-sm">
            <li v-for="matchday, idx in matchdays" :key="idx">
                <input :id="idx" @change="filter" type="checkbox" :value="matchday" class="w-4 h-4">
                <label :for="idx" class="ml-2 text-sm font-medium text-black">{{"Matchday " + matchday}}</label>
            </li>
        </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref, Ref } from "vue";
import Match from "../models/Match";

const props = defineProps<{
  matches: Match[]
}>()

const emit = defineEmits(["filter"])

const filter: Function = (e: Event) => {
    emit("filter", (e.target as HTMLInputElement).value)
}

const matchdays = computed(() => {
    return [... new Set(props.matches.sort((a,b) => a.matchday - b.matchday).map((m: Match) => m.matchday))]
})

const show: Ref = ref(false);
</script>

<style>

</style>
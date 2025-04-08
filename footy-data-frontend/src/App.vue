<script setup lang="ts">
import HelloWorld from './components/HelloWorld.vue'
import DataGrid from './components/DataGrid.vue'
import type Match from './models/Match'
import { onMounted, ref, Ref } from 'vue';

const matches: Ref = ref([]);

onMounted(async () => {
    const response: Response = await fetch("https://localhost:7112/Match");
    matches.value = await response.json() as Array<Match>;
    matches.value = (matches.value as Match[]).sort((a: Match, b: Match) => a.matchday - b.matchday)
    
})


</script>

<template>
  <div>
    <h1 class="mt-4 mb-10">The Footy Data</h1>
    <data-grid :matches="matches" />
  </div>
</template>

<style scoped>
h1 {
  margin-top: 5%;
}
#app {
  height: 100vh;
}
</style>
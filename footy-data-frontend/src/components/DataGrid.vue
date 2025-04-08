<template>
  <div class="relative  rounded-lg">
    <div class="flex items-center justify-between">
        <search-filter v-on:search="handleSearch">

        </search-filter>
    <div class="flex items-center justify-end">
        <filter-radios v-on:filter="handleRadioFilter" />
       <filter-dropdown v-on:filter="handleCheckboxFilter" :matches="matches">

        </filter-dropdown>
    </div>
    </div>
    
  </div>
  <table class="w-full text-sm text-left">
    <thead class="text-xs uppercase">
        <tr>
            <th class="px-4 py-3">ID</th>
            <th class="px-4 py-3">Matchday</th>
            <th class="px-4 py-3">Home Team</th>
            <th class="px-4 py-3">Score</th>
            <th class="px-4 py-3">Away Team</th>
            <th class="px-4 py-3">Status</th>
            <th class="px-4 py-3">Date</th>
        </tr>
    </thead>
    <tbody>
        <tr v-for="(match, idx) in filteredMatches" :key="idx">
            <td class="px-4 py-3">{{ match.matchId }}</td>
            <td class="px-4 py-3">Matchday {{match.matchday}}</td>
            <td class="px-4 py-3">{{match.homeTeam}}</td>
            <td class="px-4 py-3">{{match.fullTimeResult}}</td>
            <td class="px-4 py-3">{{match.awayTeam}}</td>
            <td class="px-4 py-3">{{match.status}}</td>
            <td class="px-4 py-3">{{formatDate(match.utcDate)}}</td>
         </tr>
    </tbody>
  </table>
</template>

<script lang="ts" setup>
import { ref, computed, onMounted, Ref } from 'vue'
import type Match  from '../models/Match'
 import FilterDropdown from './FilterDropdown.vue';
import SearchFilter from './Search.vue';
import FilterRadios from './FilterRadios.vue';

const searchStr: Ref = ref("");
const radioref: Ref = ref("");
const matchDayRef: Ref = ref([]);

const handleSearch: Function = (text: string) => {
    searchStr.value = text;
}


const handleCheckboxFilter: Function = (text: string) => {
    if(matchDayRef.value.includes(text)) {
        return (matchDayRef.value as string[]).splice((matchDayRef.value as string[]).indexOf(text), 1)
    }
    return (matchDayRef.value as string[]).push(text);
}

const handleRadioFilter: Function = (text: string) => {
    radioref.value = text;
}


const props = defineProps<{
  matches: Match[]
}>()


const filteredMatches = computed(() => {
    let filtMatches: Match[] = props.matches;
    switch(radioref.value) {
        case "past":
            filtMatches = props.matches.filter((m: Match) => m.status === "FINISHED")
            break;
        case "live":
            filtMatches = props.matches.filter((m: Match) => m.status === "IN_PLAY")
            break;
        case "future":
            filtMatches = props.matches.filter((m: Match) => m.status === "TIMED")
            break;
        default:
            break
    }
    if((matchDayRef.value as string[]).length != 0) {
        filtMatches = filtMatches.filter((match) => (matchDayRef.value as string[]).includes(match.matchday.toString()))
    }
    filtMatches = filtMatches.filter((match) => {
        const search: string = searchStr.value.toLowerCase();
        return match.homeTeam.toLowerCase().includes(search) || match.awayTeam.toLowerCase().includes(search);
    })

    return filtMatches

})


function formatDate(dateStr: string): string {
  return new Date(dateStr).toLocaleDateString()
}
</script>

<style scoped>
table {
  border-collapse: collapse;
  width: 100%;
}
</style>
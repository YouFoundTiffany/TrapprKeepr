<template>
    <div class="card bg-dark text-white">
        <img src="..." class="card-img" alt="...">
        <div class="card-img-overlay">
            <h5 class="card-title">Card title</h5>
            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content.
                This content is a little bit longer.</p>
            <p class="card-text">Last updated 3 mins ago</p>
        </div>
    </div>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
    props: {
        keep: { type: Object, required: true }
    },
    setup() {
        return {
            AppState: computed(() => AppState),
            profile: computed(() => AppState.profile),
            keeps: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults),
            account: computed(() => AppState.account),

        };
    },
};
</script>


<style></style>
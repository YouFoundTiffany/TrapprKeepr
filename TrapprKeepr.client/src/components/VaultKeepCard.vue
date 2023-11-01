<!-- VAULT KEEP CARD COMPONENT -->
<template>
    <div class="card acc-kcard text-bg-dark ard text-bg-dark ">
        <img :src="keep.img" class="acc-kcard-img" :alt="keep.name">
        <div class="card-img-overlay" :title="keep.name">
            <h5 class="card-title">{{ keep.name }}</h5>
        </div>





    </div>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js';


export default {
    props: {
        vaultKeeps: { type: Object, required: true }
    },

    setup() {




        return {
            AppState: computed(() => AppState),
            activeKeep: computed(() => AppState.activeKeep),
            profile: computed(() => AppState.profile),
            keeps: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults),
            account: computed(() => AppState.account),



        };
    },
};
</script>



<style scoped>
.acc-kcard {
    width: calc(100% / 6);
    height: auto;
    aspect-ratio: 1;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
    margin: 0.5%;
}

.acc-kcard-img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
</style>
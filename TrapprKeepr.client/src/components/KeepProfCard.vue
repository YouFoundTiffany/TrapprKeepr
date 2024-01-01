<!-- KEEP PROFILE CARD COMPONENT -->
<template>
    <div class="card acc-kcard text-bg-dark text-bg-dark">
        <img :src="keep.img" class="acc-kcard-img" :alt="keep.name">

        <div class="card-img-overlay" :title="keep.name">
            <div class="blurred-background">
                <h5 class="keep-title">{{ keep.name }}</h5>
            </div>
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
        keep: { type: Object, required: true }
    },

    setup() {

        // // STUB Get Keep Details
        // async function getKeepDetails() {
        //   try {
        //     await keepsService.getKeepDetails(route.params.keepId)
        //   } catch (error) {
        //     // route.push({ name: 'Home' })
        //     logger.error(error)
        //     Pop.toast('Not Accessible')
        //   }
        // }


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
.blurred-background {
    background: white !important;
    box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2) !important;
    border-radius: 5px !important;
    /* For shadow effect */
    /* filter: blur(2px) !important; */
    /* For blurred edges */
}

.keep-title {
    color: var(--bright-raspberry-royale);
    font-weight: bold;
    font-size: auto;
    text-align: center;
}

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
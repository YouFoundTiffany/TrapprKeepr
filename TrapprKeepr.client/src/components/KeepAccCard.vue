<!-- KEEP ACCOUNT CARD COMPONENT -->
<template>
    <div class="card acc-kcard text-bg-dark ard text-bg-dark ">
        <img :src="keep.img" class="acc-kcard-img" :alt="keep.name">
        <div class="card-img-overlay">
            <h5 class="card-title">{{ keep.name }}</h5>
        </div>
        <!-- TODO PUT THIS IN MODAL WITH DETAILS -->

        <button @click="deleteKeep(keep.id)">Delete?</button>
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

            async deleteKeep(activeKeep) {
                try {
                    if (await Pop.confirm(`Are you sure you want to delete this keep?`)) {
                        await keepsService.deleteKeep(activeKeep)
                    }
                    Pop.toast(`You deleted the keep!`)
                } catch (error) {
                    Pop.error(error)
                }
            },
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
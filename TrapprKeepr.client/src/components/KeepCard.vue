<!-- KEEP CARD COMPONENT -->
<template>
    <section @click="setActiveKeep()" data-bs-toggle="modal" data-bs-target="#projectModal">
        <!-- DON'T TOUCH, ITS WORKING -->
        <div v-if="keep" class="container-flex card mb-3 elevation-3 card-flow m-0 d-flex gb-1">
            <img :src="keep.img" :title="keep.name" alt="keep.img" class="card-image rounded-top">
            <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ keep.name }}</h5>



            <img :src="keep.creator.picture" :title="keep.creator.name" :alt="keep.creator.picture"
                class="profile-pic m-3 elevation-3" data-bs-toggle="modal" data-bs-target="#KeepDetailsModal">
        </div>

        <div class="p-2">
        </div>

        <!-- <KeepDetailsCard v-if="activeKeep" :activeKeep="activeKeep" :userVaults="userVaults" /> -->
    </section>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import KeepDetailsCard from '../components/KeepDetailsCard.vue';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js';
import { router } from '../router';

import { useRouter } from 'vue-router';
import { Account, Profile } from '../models/Account';


export default {
    props: {
        keep: { type: Object, required: true },

    },
    setup(props) {



        return {
            keeps: computed(() => AppState.keeps),
            account: computed(() => AppState.account),
            profileVaults: computed(() => AppState.profileVaults),
            userVaults: computed(() => AppState.userVaults),

            setActiveKeep() {
                keepsService.setActiveKeep(props.keep)
            }
        };
    },
    components: {}
};
</script>
<style>
.profile-pic {
    height: 50px;
    width: 50px;
    object-fit: contain;
    /* object-position: none; */
    border-radius: 50em;
    position: absolute;
    /* bottom: 10vh;
    right: 4vw; */
    align-items: baseline;
    align-items: end;

}

.h5-over {
    position: absolute;
    align-items: baseline;
    align-items: start;
    /* top: 70%;
    left: 0; */
    width: 100%;
    text-shadow: 0 4px 8px rgba(0, 0, 0, 0.927) !Important;
}

.card-image {
    object-fit: cover;
    /* object-fit: cover; */
    /* overflow: hidden; */
    /* height: auto; */
    width: 100%;
    z-index: 1.5;
    position: relative;
}

.keep-name {
    z-index: 10;
    position: relative;
}

.card-flow {
    /* background-size: cover; */
    overflow: hidden;
}
</style>
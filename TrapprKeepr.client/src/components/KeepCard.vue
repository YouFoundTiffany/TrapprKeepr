<!-- KEEP CARD COMPONENT -->
<template>
    <div v-if="keep" class="container-flex card mb-3 elevation-3 card-flow m-0 d-flex gb-1">
        <img :src="keep.img" class="card-image rounded-top" keep.img>
        <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ keep.name }}</h5>
        <!-- FIXME add browser button attribute -->
        <!-- FIXME make profile pic bigger -->

        <img @click="setActiveKeep(keep.id)" :src="keep.creator.picture" :title="keep.creator.name"
            :alt="keep.creator.picture" class="profile-pic" data-bs-toggle="modal" data-bs-target="#keep-details">
    </div>


    <ModalWrapper class="container-flex" :id="'keep-details'">
        <template #body>
            <KeepDetailsCard />
        </template>
    </ModalWrapper>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import KeepDetailsCard from '../components/KeepDetailsCard.vue';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js';
export default {
    props: {
        keep: { type: Object, required: true }, profile: { type: Object, required: true }
    },
    setup(props) {


        return {
            keeps: computed(() => AppState.keeps),
            acccount: computed(() => AppState.account),
            profileVaults: computed(() => AppState.profileVaults),
            activeKeep: computed(() => AppState.activeKeep),


            async setActiveKeep(keepId) {
                try {
                    logger.log('did it click?', keepId)
                    // const keepId = props.keep.id
                    await keepsService.getKeepById(keepId)
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
    components: { KeepDetailsCard }
};
</script>
<style>
.profile-pic {
    height: 30px;
    width: 30px;
    object-fit: contain;
    object-position: none;
    border-radius: 50em;
    position: absolute;
    bottom: 10vh;
    right: 4vw;

}

.h5-over {
    position: absolute;
    top: 70%;
    left: 0;
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
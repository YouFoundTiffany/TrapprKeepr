<!-- KEEP CARD COMPONENT -->
<template>
    <div v-if="keep" @click="openKeepModal" :keep="keep" :id="'details-' + keep.id"
        class="container-flex card mb-3 elevation-3 card-flow m-0 d-flex gb-1">
        <img :src="keep.img" class="card-image rounded-top" keep.img>
        <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ keep.name }}</h5>
        <!-- FIXME -->
        <!-- TODO move this into the modal -->
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
            <img :src="keep.creator.picture" :title="keep.creator.name" :alt="keep.creator.picture" class="profile-pic">
        </router-link>

    </div>
</template>
<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { Account, Profile } from '../models/Account.js';
import { logger } from '../utils/Logger';

export default {
    props: {
        keep: { type: Object, required: true },
    },
    openKeepModal() {
        this.$emit('open-modal', this.keep)
    },
    setup() {
        onMounted(() => {
            getProfileById();
        })

        async function getProfileById(profileId) {
            try {
                logger.log('profileId', route.params.profileId)
                // await profilesService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }

        return {
            activeProfile: computed(() => AppState.activeProfile),
            keeps: computed(() => AppState.keeps),
            account: computed(() => AppState.account),
            resetModal() {
                this.showModal = false
            },
            showModal() {
                this.$emit('open-modal', this.keep)
                this.showModal = true
            }
        }
    },
};
</script>
<style>
.profile-pic {
    height: 30px;
    width: 30px;
    object-fit: cover;
    object-position: center;
    border-radius: 50em;
    position: absolute;
    bottom: 8px;
    right: 10px;

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
    align-items: baseline;
    align-items: end;
    position: relative;
}

.keep-name {
    align-items: baseline;
    align-items: end;
    position: relative;
}

.card-flow {
    /* background-size: cover; */
    overflow: hidden;
}
</style>
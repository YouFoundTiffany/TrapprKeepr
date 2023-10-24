<!-- KEEP CARD COMPONENT -->
<template>
    <div v-if="keep" @click="openKeepModal" :keep="keep" :id="'details-' + keep.id"
        class="container-flex card mb-3 elevation-3 card-flow m-0 d-flex gb-1">
        <img :src="keep.img" class="card-image rounded-top" alt="keep image">
        <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ keep.name }}</h5>
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
            <img :src="keep.creator.picture" alt="" class="profile-pic">
        </router-link>

    </div>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { Account, Profile } from '../models/Account.js';

export default {
    props: {
        keep: { type: Object, required: true }, profile: { type: Profile, required: true }
    },
    openKeepModal() {
        this.$emit('open-modal', this.keep)
    },
    setup() {

        return {
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
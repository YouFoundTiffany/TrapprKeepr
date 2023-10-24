<template>
    <div v-if="keep" @click="openKeepModal" :keep="keep" :id="'details-' + keep.id"
        class="container-flex card mb-3 elevation-3 card-flow m-0 d-flex gb-1">
        <img :src="keep.img" class="card-image rounded-top" alt="...">
        <h5 class="keep-name ps-2">{{ keep.name }}</h5>
        <img :src="keep.creator.picture" alt="" class="profile-pic">

    </div>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
export default {
    props: {
        keep: { type: Object, required: true }
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

.card-image {
    object-fit: cover;
    /* object-fit: cover; */
    /* overflow: hidden; */
    /* height: auto; */
    z-index: 1;
    /* position: relative; */
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
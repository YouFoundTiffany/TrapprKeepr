<template>
    <div v-if="keep" class="keep-card" :keep="keep" :id="'details-' + keep.id">
        <div @click="openKeepModal" class="card mb-3">
            <img :src="keep.img" class="card-img-top mxht" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">{{ keep.description }}</p>
                <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
            </div>
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
    openKeepModal() {
        this.$emit('open-modal', this.keep)
    },
    setup() {

        return {
            keeps: computed(() => AppState.keeps),
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
.keep-card {
    max-width: 200px;
}
</style>
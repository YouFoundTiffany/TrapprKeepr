<!-- KEEP CARD COMPONENT -->
<template>
    <!-- type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#KeepCardModal" -->
    <div v-if="keep" :keep="keep" :id="'details-' + keep.id"
        class="container-flex card mb-3 elevation-3 card-flow m-0 d-flex gb-1">
        <img @click="openKeepModal(keep)" :src="keep.img" class="card-image rounded-top" type="button"
            :data-bs-target="'#KeepCardModal' + keep.id">
        <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ activeKeep.name }}</h5>
        <!-- FIXME -->
        <!-- TODO move this into the modal -->
        <router-link @click="closeModal(keep)" :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
            <img :src="keep.creator.picture" :title="keep.creator.name" :alt="keep.creator.picture" class="profile-pic">
        </router-link>

        <KeepDetailsCard v-for="keep in keeps" :key="keep.id" :keep="keep" />
        <!-- Modal -->
        <div class="modal fade" :id="'KeepCardModal-' + keep.id" tabindex="-1"
            :aria-labelledby="'KeepCardModalLabel-' + keep.id" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <!-- Modal -->
                        <!-- Keep Details -->
                        <!-- LEFT SIDE OF CARD -->
                        <div v-if="keep" class='container-fluid text-dark'>
                            <div class="row no-gutters">
                                <div class="col-md-6">
                                    <img :src="activeKeep.img" :title="activeKeep.creator.name" :alt="activeKeep.img"
                                        class="keep-image w-100">
                                </div>
                                <!-- RIGHT SIDE OF CARD-->
                                <div class="col-6 d-flex flex-column justify-content-between">
                                    <h6 class="text-dark bg-transparent m-0 p-0">Kept by: {{ activeKeep.creator.name }}</h6>
                                    <router-link @click="closeModal"
                                        :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
                                        <img :src="activeKeep.creator.picture" :title="activeKeep.creator.name"
                                            :alt="activeKeep.creator.picture" class="modprofile-pic">
                                    </router-link>
                                    <!-- KEEP NAME AND KEEP DESCRIPTION - CENTERED HORIZONTALLY AND VERTICALLY -->
                                    <div class="d-flex flex-column justify-content-center align-items-center h-50">
                                        <h4>Title: {{ activeKeep.name }}</h4>
                                        <p>{{ activeKeep.description }}</p>
                                    </div>
                                    <!-- CREATING VAULT-KEEPS!!!! -->
                                    <div>
                                        <!-- SAVE TO VAULT FORM -->
                                        <form @submit.prevent="saveKeepToVault" class="row">
                                            <!-- LOGGED IN USER'S VAULTS -->
                                            <div class="dropdown col-7">
                                                <select v-model="selectedVault" class="form-select fs-6">
                                                    <label for="option">Save to a Vault</label>
                                                    <option v-for="vault in myVaults" :key="vault.id" :value="vault.id">
                                                        {{ vault.name }}
                                                    </option>
                                                </select>
                                            </div>
                                            <div class="col-5 pl-2">
                                                <button type="submit"
                                                    class="btn btn-primary btn-sm btn-block fs-6">Save</button>
                                            </div>
                                        </form>
                                    </div>
                                    <!-- SAVE TO VAULT FORM END -->
                                </div>
                            </div>
                        </div>
                        Keep Details END
                    </div>
                    <!-- MODAL FOOTER IF I WANT ONE -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js';
import { Modal } from 'bootstrap';



export default {

    props: {
        keep: { type: Object, required: true },
    },




    setup(props) {
        const activeKeep = ref(props.keep);
        const modalId = '#KeepCardModal-' + props.keep.id
        const modalEl = document.querySelector(modalId)


        function openKeepModal() {
            Modal.getOrCreateInstance(modalEl).show()
        }
        function closeModal() {
            Modal.getOrCreateInstance(modalEl).hide()
        }
        return {
            activeProfile: computed(() => AppState.activeProfile),
            keeps: computed(() => AppState.keeps),
            account: computed(() => AppState.account),
            myVaults: computed(() => AppState.myVaults),
            activeKeep,
            openKeepModal,
            closeModal,



        }
    }
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

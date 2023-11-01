<!-- KEEP DETAILS CARD COMPONENT -->
<template>
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
                                    <form @submit.prevent="createVaultKeep()" class="row">
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
                                <!-- SAVE TO VAULT FORM END-->




                            </div>
                        </div>
                    </div>
                    <!-- Keep Details END -->
                </div>
                <!-- MODAL FOOTER IF I WANT ONE -->
                <!-- <div class="modal-footer"> -->
                <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button> -->
                <!-- <button type="button" class="btn btn-primary">Save changes</button> -->
                <!-- </div> -->
            </div>
        </div>
    </div>
</template>
<script>
import { computed, popScopeId, ref } from 'vue';
import { AppState } from '../AppState.js';
import { Modal } from 'bootstrap';
// import { logger } from '../utils/Logger';
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger';



export default {
    props: { keep: { type: Object, required: true } },

    setup(props) {
        const route = useRoute();
        const activeKeep = ref(props.keep)



        return {
            // saveKeepToVault,

            // selectedVault,

            profileVaults: computed(() => AppState.profileVaults),
            account: computed(() => AppState.account),
            activeProfile: computed(() => AppState.activeProfile),
            keeps: computed(() => AppState.keeps),
            myVaults: computed(() => AppState.myVaults),
            activeKeep,







            // STUB SAVING TO VAULT
            async createVaultKeep() {
                try {
                    logger.log("does it click?")
                } catch (error) {
                    Pop.error(error)
                }
            },
        }
    }
}

</script>

<style>
.h5-over {
    position: absolute;
    top: 70%;
    left: 0;
    width: 100%;
    text-shadow: 0 4px 8px rgba(0, 0, 0, 0.927) !Important;
}

.modprofile-pic {
    max-height: 35px;
    width: 35px;
    object-fit: cover;
    /* object-position: center; */
    border-radius: 50em;
    /* position: absolute; */
    /* align-items: baseline; */
    justify-content: end;
    /* bottom: 30vh;
    right: 4vw; */
}

.keep-image {
    max-height: 350px;
    object-fit: cover;
    object-position: center center;

}

.container-fluid {
    padding-left: 0;
    padding-right: 0;
}
</style>
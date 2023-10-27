<!-- KEEP DETAILS CARD COMPONENT -->
<template>
    <div v-if="keep" class='container-fluid text-dark'>
        <div class="row no-gutters">
            <div class="col-md-6">

                <img :src="keep.img" :title="keep.creator.name" :alt="keep.img" class="keep-image w-100">

            </div>
            <!-- RIGHT SIDE -->
            <div class="col-6 d-flex flex-column justify-content-between">
                <h5 class="text-dark bg-transparent m-0 p-0">{{ keep.creator.name }}</h5>
                <RouterLink :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">

                    <img :src="keep.creator.picture" class="modprofile-pic" alt="keep.creator.picture"
                        :title="keep.creator.name">
                </RouterLink>
                <!-- KEEP NAME AND KEEP DESCRIPTION - CENTERED HORIZONTALLY AND VERTICALLY -->
                <div class="d-flex flex-column justify-content-center align-items-center h-50">
                    <h4>{{ keep.name }}</h4>
                    <p>{{ keep.description }}</p>
                </div>
                <!-- PROFILE PIC AND CREATOR NAME -->
                <!-- <div class="d-flex flex-column align-items-center">

                </div> -->
                <!-- CHECK IF USER IS AUTHENTICATED & SAVE KEEP TO YOUR VAULT FORM -->
                <!-- CREATING VAULT-KEEPS!!!! -->
                <div>
                    <form @submit.prevent="saveKeepToVault" class="row">
                        <!-- LOGGED IN USER'S VAULTS -->
                        <div class="dropdown col-7">
                            <select v-model="selectedVault" class="form-select fs-6">
                                <option v-for="vault in profileVaults" :key="vault.id" :value="vault.id">
                                    {{ vault.name }}
                                </option>
                            </select>
                        </div>
                        <div class="col-5 pl-2">
                            <button type="submit" class="btn btn-primary btn-sm btn-block fs-6">Save</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>
    <!-- tifftag -->
              <!-- TODO disable or HIDE button if not album creator OR collaborator -->
<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js';
// import { Modal } from 'bootstrap';
// import { logger } from '../utils/Logger';

import { useRoute } from 'vue-router';
// import Pop from '../utils/Pop.js';



export default {
    props: { keep: { type: Object, required: true } },

    setup(props) {
        const route = useRoute();
        const selectedVault = ref(null);
        // onMounted(async () => {
        //     getProfilesVaults();
        // });


        // STUB GET USER VAULTS
        // STUB Get all Vaults with this Profile Id
        // async function getProfilesVaults() {
        //     try {
        //         logger.log('profileId', route.params.profileId)
        //         // await accountService.getProfilesVaults(route.params.profileId)
        //     } catch (error) {
        //         Pop.error(error)
        //     }
        // }
        return {
            // saveKeepToVault,

            selectedVault,
            // keep: computed(() => AppState.keep),
            profileVaults: computed(() => AppState.profileVaults),
            account: computed(() => AppState.account),


            // closeModal() {
            //     Modal.getOrCreateInstance('#KeepDetailsModal').hide();
            // },





            // STUB SAVING TO VAULT
            // async createVaultKeep() {
            //     try {
            // isAllowed.value = true THIS IS FOR HIDING THE BUTTON IF NOT ALBUM CREATOR OR COLLABORATOR OR AUTHENTICATED
            // logger.log('did it click?', selectedVault)
            //   let collabData = { albumId: route.params.albumId } // just creating a body with albumId on it equal to the route params
            //   await collaboratorsService.createCollab(collabData)
            //   inProgress.value = false
            //     } catch (error) {
            //         Pop.error(error)
            //     }
            // },
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
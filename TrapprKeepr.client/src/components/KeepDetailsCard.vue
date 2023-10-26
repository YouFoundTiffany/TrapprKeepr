<!-- KEEP DETAILS CARD COMPONENT -->
<template>
    <div v-if="activeKeep" class='container-fluid text-dark'>
        <div class="row no-gutters">
            <div class="col-6">
                <img :src="activeKeep.img" :title="activeKeep.creator.name" :alt="activeKeep.img" class="keep-image w-100">
            </div>
            <!-- RIGHT SIDE -->
            <div class="col-6 d-flex flex-column justify-content-between">
                <!-- KEEP NAME AND KEEP DESCRIPTION - CENTERED HORIZONTALLY AND VERTICALLY -->
                <div class="d-flex flex-column justify-content-center align-items-center h-50">
                    <h4>{{ activeKeep.name }}</h4>
                    <p>{{ activeKeep.description }}</p>
                </div>
                <!-- PROFILE PIC AND CREATOR NAME -->
                <div class="d-flex flex-column align-items-center">
                    <img :src="activeKeep.creator.picture" class="modprofile-pic" alt="activeKeep.creator.picture">
                    <h5 class="h5-over text-light bg-transparent m-0 p-0">{{ activeKeep.creator.name }}</h5>
                </div>
                <!-- CHECK IF USER IS AUTHENTICATED & SAVE KEEP TO YOUR VAULT FORM -->
                <div v-if="user.isAuthenticated">
                    <form @submit.prevent="saveKeepToVault">
                        <!-- LOGGED IN USER'S VAULTS  -->
                        <div class="dropdown">
                            <select v-model="selectedVault" class="form-select">
                                <option v-for="vault in userVaults" :key="vault.id" :value="vault.id">
                                    {{ vault.name }}
                                </option>
                            </select>
                        </div>
                        <button type="submit" class="btn btn-primary mt-2">Save to Vault</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js';
import { ref } from 'vue';
import { AppState } from '../AppState.js';

export default {
    setup() {
        // const userVaults = computed(() => {
        //     return AppState.vaults.filter(vault => vault.userId === user.id);
        // });

        const selectedVault = ref(null);

        function saveKeepToVault() {
            // Logic to save the keep to the selected vault goes here.
            // You'll likely make an API call or Vuex action here to save the relationship
            console.log(`Saving keep to vault with ID ${selectedVault.value}`);
        }

        return {
            user,
            userVaults,
            selectedVault,
            saveKeepToVault,
            activeKeep: computed(() => AppState.activeKeep)
        };
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
    object-position: center;
    border-radius: 50em;
    position: absolute;
    bottom: 30vh;
    right: 4vw;
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
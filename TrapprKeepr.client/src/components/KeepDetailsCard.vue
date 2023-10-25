<template>
    <div class='container text-dark'>
        <div>
            Its a Modal!!! Yay!
            <!-- <img :src="keep.img" class="card-image rounded-top" keep.img> -->
            <!-- <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ keep.name }}</h5> -->
            <!-- FIXME POINTER ON PROF PIC -->
            <!-- <img :src="keep.creator.picture" :title="keep.creator.name" :alt="keep.creator.picture" class="profile-pic"> -->

            <!-- v-if="user.isAuthenticated && !isMember"-->
            <!-- v-if="user.isAuthenticated" -->
            <!-- Shows MY Vaults -->

            <!-- Final dropdown here.  -->
            <!-- <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton"
                    data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Dropdown button
                </button>
                <div v-for="vault in vaults" :key="vault.id" class="dropdown-menu" aria-labelledby="dropdownMenuButton"> -->
            <!-- {{ vault.name }} -->
            <!-- Final dropdown here.  -->





            <!-- <div v-for="vault in vaults" :key="vault.id"> -->
            <!-- <VaultDropDown :vault="vault" > -->
            <!-- STUB DropDown Users Vaults  -->
            <!-- </div> -->


            <!-- DropDownTEmplage moved to VaultDropDown -->
            <!-- <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Dropdown button
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="#">Action</a>
                            <a class="dropdown-item" href="#">Another action</a>
                            <a class="dropdown-item" href="#">Something else here</a>
                        </div>
                    </div> -->
            <!-- </div> -->
            <!-- </div> -->
        </div>
    </div>
</template>
<script>
import { computed } from 'vue';
import VaultDropDown from './VaultDropDown.vue';
import { AppState } from '../AppState';

export default {
    setup() {
        // NOTE may not need this.
        // onMounted(() => {
        //     getProfileById();
        // })
        // async function getProfileById(profileId) {
        //     try {
        //         logger.log('profileId', route.params.profileId)
        //         // await profilesService.getProfileById(route.params.profileId)
        //     } catch (error) {
        //         Pop.error(error)
        //     }
        // }
        return {
            acccount: computed(() => AppState.account.id),
            profileVaults: computed(() => AppState.profileVaults),
        };
    },
    components: { VaultDropDown }
};
</script>


<style></style>
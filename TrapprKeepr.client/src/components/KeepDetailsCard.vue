
<!-- KEEP DETAILS CARD COMPONENT -->
<template>
    <div v-if="activeKeep" class='container text-dark'>
        <div>
            <!-- {{ activeProfile }}
            {{ activeKeep }} -->
            <img :src="activeKeep.creator.picture" class="card-image rounded-top modprofile-pic"
                alt="activeKeep.creator.picture">
            <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ activeKeep.creator.name }}</h5>
            <!-- FIXME POINTER ON PROF PIC -->
            <!-- <img :src="activeKeep.img" :title="activeKeep.creator.name" :alt="keep.creator.picture" class="profile-pic"> -->

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
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop';


export default {

    setup() {


        // onMounted(() => {
        //         getProfileById();
        //     })
        const route = useRoute()

        const activeProfile = computed(() => route.params.profileId)






        // NOTE may not need this.
        async function getProfileById(profileId) {
            try {
                profileId = (route.params)
                // await profilesService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
        return {
            // AppState: computed(() => AppState),
            activeProfile: computed(() => AppState.activeProfile),
            acccount: computed(() => AppState.account),
            keeps: computed(() => AppState.keeps),
            activeKeep: computed(() => AppState.activeKeep)

        };
    },
}

</script>


<style>
.modprofile-pic {
    max-height: 15em;
    width: 15em;
    object-fit: cover;
    object-position: center;
    border-radius: 50em;
}
</style>
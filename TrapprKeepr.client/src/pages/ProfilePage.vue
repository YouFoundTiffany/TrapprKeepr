<!-- eslint-disable space-before-function-paren -->
<!-- PROFILE PAGE -->
<!-- TODO MEDIA QUERY TO CENTER AND AJUST ON SMALL SCREENS -->
<template>
    <section v-if="profile" class="container">
        <div class="row">
            PROFILE PAGE {{ profile.name



            }}

            <div class="about text-center">
                <div class="justify-content-center row d-flex">
                    <img class="m-0 banner-image rounded" :src="profile.coverImg" :alt="profile.coverImg"
                        title="profile.coverImg" />
                </div>
                <div class="justify-content-center d-flex">
                    <!-- <img class="rounded elevation-2 avatar" :src="activeProfile.picture" :alt="activeProfile.picture"  title="activeProfile.picture"  /> -->
                </div>
                <!-- <h1>{{ activeProfile.name }}</h1> -->


            </div>

            <!-- PROFILE VAULTS CARDS -->
            <h2 class="">Vaults</h2>
            <section class="container-fluid m-0 p-0">
                <div class="row m-0 p-0">
                    <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1"
                        v-for="vault in profileVaults" :key="vault.id">
                        <VaultAccCard :vault="vault" class="my-2" style="width: 20vw;" />
                    </div>
                </div>
            </section>


            <!-- PROFILE KEEPS CARDS -->
            <h2 class="">Keeps</h2>
            <section class="container-fluid m-0 p-0">
                <div class="row m-0 p-0">
                    <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1"
                        v-for="keep in profileKeeps" :key="keep.id">
                        <KeepAccCard :keep="keep" class="my-2" style="width: 20vw;" />
                    </div>
                </div>
            </section>


        </div>
    </section>
</template>

  <!-- // TODO ADD isOwner to items in template for private vaults template above buttons
  // v -if= "!restaurant.isShutdown && isOwner" - Make Private
  // v-if="restaurant.isShutdown && isOwner" - Make Public
  // v-if="isOwner" - Delete
  // const isOwner = computed(() => AppState.account.id == AppState.activeVault?.creatorId)
  // let userIdToShow = profileId ? profileId : accountId; -->
<script>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import KeepAccCard from '../components/KeepAccCard.vue';
import VaultAccCard from '../components/VaultAccCard.vue';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop.js';
import { accountService } from '../services/AccountService';
accountService

export default {
    setup() {

        // NOTE The Order of the variables below Matters!
        onMounted(async () => {
            getProfilesKeeps();
            getProfilesVaults();
            getProfileById();
        })
        const route = useRoute();
        // STUB Get all Keeps with this Profile Id
        async function getProfilesKeeps() {
            try {
                // logger.log('profileId', route.params.profileId)
                await accountService.getProfilesKeeps(route.params.profileId)
                // logger.log(AppState.keeps, 'helloooo')
            } catch (error) {
                Pop.error(error)
            }
        }
        // STUB Get all Vaults with this Profile Id
        async function getProfilesVaults() {
            try {
                // logger.log('profileId', route.params.profileId)
                await accountService.getProfilesVaults(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }

        async function getProfileById() {
            try {
                await accountService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }


        // const isOwner = computed(() => {
        // return !route.params.profileId || route.params.profileId === AppState.account.id;
        // });

        return {
            profileKeeps: computed(() => AppState.profileKeeps),
            profileVaults: computed(() => AppState.profileVaults),
            profile: computed(() => AppState.activeProfile),
            account: computed(() => AppState.account),
            keeps: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults),

        };
    },
    components: { KeepAccCard, VaultAccCard }
}
</script>

<style scoped>
.acard {
    max-width: 100%;
    height: auto;
    object-fit: cover;
}

.avatar {
    margin-top: -2%;
    object-fit: cover;
    aspect-ratio: 1/1;
    height: 50px;
    width: 50px;
    object-fit: scale-down;
    object-position: center;
    border-radius: 50em;
}

.banner-image {
    overflow: hidden;
    justify-content: center;
    max-width: 100vh;
    max-height: 30vh;
    aspect-ratio: 4/3;
    object-fit: cover;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2) !Important;

}
</style>
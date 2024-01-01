<!-- PROFILE PAGE -->
<template>
    <section v-if="activeProfile" class="container">
        <div class="row">
            <h1 class="text-center text-minty-meadow fst-italic">{{ profile.name }} Profile Page
            </h1>
            <div class="about text-center">
                <div class="justify-content-center row d-flex">
                    <img class="m-0 p-0 banner-image rounded" :src="profile.coverImg" :alt="profile.coverImg"
                        title="profile.coverImg" />
                </div>

                <div class="justify-content-center d-flex">
                    <img class="rounded elevation-2 avatar" :src="activeProfile.picture" :alt="activeProfile.picture"
                        title="activeProfile.picture" />
                </div>
            </div>

            <!-- PROFILE VAULTS CARDS -->
            <div class="bg-faded-periwinkle-dream rounded py-4 my-4">
                <h1 class="text-bright-periwinkle-dream fw-bold fs-exl text-center">Vaults</h1>
                <section class="moblView container-fluid m-0 p-0 indicate">
                    <div class="row m-0 p-0">
                        <div class="col-12 col-md-3 m-0 p-0 justify-content-center shadow" style="aspect-ratio: 1/1"
                            v-for="vault in profileVaults" :key="vault.id">
                            <VaultProfCard :vault="vault" class="my-2" style="width: 15vw;" />
                        </div>
                    </div>
                </section>
            </div>

            <!-- 🚀 spacer div -->
            <div style="height:15vh;"></div>

            <!-- PROFILE KEEPS CARDS -->
            <div class="bg-faded-raspberry-royale rounded py-4 my-4">
                <h1 class="text-bright-raspberry-royale fw-bold fs-exl text-center">Keeps</h1>
                <section class="moblView container-fluid m-0 p-0 indicate">
                    <div class="row m-0 p-0">
                        <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1"
                            v-for="keep in profileKeeps" :key="keep.id">
                            <KeepProfCard :keep="keep" class="my-2 shadow" style="width: 15vw;" />
                        </div>
                    </div>
                </section>
            </div>
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
import KeepProfCard from '../components/KeepProfCard.vue';
import VaultProfCard from '../components/VaultProfCard.vue';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop.js';
import { accountService } from '../services/AccountService';
accountService

export default {
    props: { activeVault: { type: Object, required: true } },


    setup(props) {

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
            activeProfile: computed(() => AppState.activeProfile)

        };
    },
    components: { KeepProfCard, VaultProfCard }
}
</script>

<style scoped>
.shadow {
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2) !Important;
}

.vault-title {
    position: relative !important;
    /* Or 'absolute', 'fixed', or 'sticky', depending on your layout */
    z-index: 1000 !important;
    /* A high value to ensure it's on top */
    clear: both !important;
    /* If there are floating elements around */
    /* Other styling properties */
    margin-top: 10rem;
}

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
    align-items: baseline;
    align-items: start;
    border-radius: 50em;
}

.banner-image {
    /* overflow: hidden; */
    justify-content: center;
    max-width: 100vh;
    max-height: 30vh;
    aspect-ratio: 4/3;
    object-fit: cover;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2) !Important;
}

/* Media query for mobile view */
@media (max-width: 767px) {
    .moblView {
        columns: 2;
    }
}
</style>
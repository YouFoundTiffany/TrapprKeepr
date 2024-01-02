<!-- VAULT DETAILS PAGE -->
<template>
    <section v-if="activeVault" class="container">

        <div class="row">
            <h1 class="text-center">{{ activeVault.name }} Vault Details Page
            </h1>

            <div class="about text-center bg-faded-periwinkle-dream rounded py-4 my-4">
                <div class=" justify-content-center row d-flex ">
                    <img :src="activeVault.img" alt="activeVault.picture" title-="activeVault.picture">
                </div>
                <!-- 🚀 spacer div -->
                <div style="height:15vh;"></div>
                <!-- 🚀 spacer div -->
                <div class="justify-content-center row d-flex">
                    <img class="m-0 p-0 banner-image rounded" :src="profile.coverImg" :alt="profile.coverImg"
                        title="profile.coverImg" />
                </div>
                <h2 class="text-minty-meadow">This Vault was created by {{ account.name }}</h2>
                <!-- TODO LIST KEEPS IN THIS VAULT -->
            </div>
            <!-- 🚀 spacer div -->
            <div style="height:15vh;"></div>
            <!-- 🚀 spacer div -->
            <div class="bg-faded-raspberry-royale rounded py-4 my-4">

                <h3 class="text-center text-minty-meadow fst-italic">All Keeps in this Vault</h3>
                <div class="hmasonry-container container">
                    <KeepCard v-for="keep in keeps" :key="keep.id" :keep="keep" style="min-height: 5em;" />

                </div>
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
import KeepAccCard from '../components/KeepAccCard.vue';
import VaultAccCard from '../components/VaultAccCard.vue';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService';
import { Vault } from '../models/Vault';
import { keepsService } from '../services/KeepsService';

export default {

    setup() {
        const route = useRoute()
        const accountId = computed(() => AppState.account.id)
        const vaultId = route.params.id
        onMounted(() => {
            setActiveVault(); getVaultKeeps();
        });

        async function setActiveVault() {
            try {
                // logger.log('Getting Vault data', route.params.profileId)

                await vaultsService.getVaultDetails(route.params.vaultId);
            } catch (error) {
                Pop.error(error)
            }
        }

        // STUB GETTING THOSE MANY TO MANYs!!!!
        // vaults/{{vaultId}}/keeps
        async function getVaultKeeps() {
            try {
                // debugger
                logger.log('[GETTING VKs!]')
                await keepsService.getKeepsbyVaultId(route.params.vaultId)
                // await vaultsService.getVaultKeeps(route.params.id)
            } catch (error) {

                Pop.error(error)
            }
        }






        return {
            AppState,
            profileKeeps: computed(() => AppState.profileKeeps),
            profileVaults: computed(() => AppState.profileVaults),
            profile: computed(() => AppState.activeProfile),
            account: computed(() => AppState.account),
            keeps: computed(() => AppState.keeps),
            // don't think I need this data but not going to delete it now.
            // 🤷‍♀️vaults: computed(() => AppState.vaults),
            activeVault: computed(() => AppState.activeVault),
            vaultKeeps: computed(() => AppState.vaultKeeps)
        };
    },
    // components: { KeepAccCard, VaultAccCard }
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

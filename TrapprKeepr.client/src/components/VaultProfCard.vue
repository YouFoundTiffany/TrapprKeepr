<!-- VAULT PROFILE CARD -->
<template>
    <router-link :to="{ name: 'Vault Details', params: { vaultId: vault.id } }">

        <div class="card text-bg-dark text-bg-dark justify-content-center">
            <img :src="vault.img" class="acc-vcard-img" :alt="vault.img" title="vault.img">

            <div class="card-img-overlay">
                <div class="blurred-background">
                    <h5 class="vault-title">{{ vault.name }}</h5>
                </div>
            </div>
        </div>
    </router-link>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';
import { router } from '../router';
import { RouterLink } from 'vue-router';

export default {
    props: {
        vault: { type: Object, required: true }
    },
    setup() {




        // STUB Get Vault Details
        // async function getVaultDetails() {
        //   try {
        //     await vaultsService.getVaultDetails(route.params.vaultId)
        //   } catch (error) {
        //     // route.push({ name: 'Home' })
        //     logger.error(error)
        //     Pop.toast('Not Accessible')
        //   }
        // }
        return {
            AppState: computed(() => AppState),
            profile: computed(() => AppState.profile),
            keeps: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults),
            account: computed(() => AppState.account),

            async deleteVault(deleteVault) {
                try {
                    if (await Pop.confirm(`Are you sure you want to delete this vault?`)) {
                        await vaultsService.deleteVault(deleteVault)
                    }
                    Pop.toast(`You deleted the keep!`)
                } catch (error) {
                    Pop.error(error)
                }
            },
        };
    },
};
</script>


<style scoped>
.iconshaddisplay {
    /* box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.824) !important; */
    height: 30px;
    width: 30px;
    object-fit: cover;
    object-position: center;
    border-radius: 50em;
    position: absolute;
    bottom: 8px;
    right: 10px;
}

.blurred-background {
    background: white !important;
    box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2) !important;
    border-radius: 5px !important;
    /* For shadow effect */
    /* filter: blur(2px) !important; */
    /* For blurred edges */
}

.vault-title {
    color: var(--bright-periwinkle-dream);
    font-weight: bold;
    font-size: auto;
    text-align: center;
}
</style>
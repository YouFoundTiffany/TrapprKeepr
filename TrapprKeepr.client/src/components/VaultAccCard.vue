<template>
    <div class="card acc-vcard text-bg-dark">
        <img :src="vault.img" class="acc-vcard-img" alt="vault image">
        <div class="card-img-overlay">
            <h5 class="card-title">{{ vault.name }}</h5>
        </div>
        <!-- TODO PUT THIS IN MODAL WITH DETAILS -->
        <button @click="deleteVault(vault.id)">Delete?</button>
    </div>
</template>
<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';

export default {
    props: {
        vault: { type: Object, required: true }
    },
    setup() {
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


<style>
.acc-vcard {
    width: calc(100% / 6);
    height: auto;
    aspect-ratio: 1;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
    margin: 0.5%;
}

.acc-vcard-img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
</style>
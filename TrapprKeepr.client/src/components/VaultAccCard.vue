<template>
    <!-- <section class="container-fluid"> -->




    <!-- MODAL -->
    <div class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <!-- MODAL BODY HERE -->
                    <p>Modal body text goes here.</p>
                    <!-- MODAL -->
                    <!-- {{ myVaults }} -->


                    <div class="card acc-vcard text-bg-dark m-0 p-0 justify-content-center">
                        <img :src="vault.img" class="acc-vcard-img" :alt="vault.img" title="vault.img">
                        <div class="card-img-overlay">
                            <h5 class="card-title">{{ vault.name }}</h5>
                            <i class="mdi mdi-lock text-light iconshaddisplay"></i>
                        </div>
                        <!-- TODO PUT THIS IN MODAL WITH DETAILS -->
                        <button @click="deleteVault(vault.id)">Delete?</button>
                    </div>


                    <!-- MODAL -->
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary">Save changes</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- MODAL -->



    <!-- </section> -->
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
    setup(props) {




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


<style>
.iconshaddisplay {
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
    height: 30px;
    width: 30px;
    object-fit: cover;
    object-position: center;
    border-radius: 50em;
    position: absolute;
    bottom: 8px;
    right: 10px;
}

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
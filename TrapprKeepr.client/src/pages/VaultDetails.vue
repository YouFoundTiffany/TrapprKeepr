<!-- eslint-disable space-before-function-paren -->
<!-- VAULT DETAILS PAGE -->
<template>
    <section v-if="vault" class="container">
        <div class="row">
            VAULT DETAILS PAGE


            <!-- v-if="keeps || vaults" -->
            <div class="about text-center">
                <div class="justify-content-center row d-flex">
                    <!-- STUB VAULT COVER IMAGE -->
                    <!-- <img class="m-0 banner-image rounded" :src="activeProfile.coverImg" :alt="activeProfile.coverImg" title="activeProfile.coverImg"/> -->
                </div>

                <div class="justify-content-center d-flex">
                    <!-- TODO -->
                    <p>total number of keeps in this vault</p>
                </div>
                <!-- <h1>{{ activeProfile.name }}</h1> -->
                <p>TODO <span> 0</span> Vaults | 0 Keeps<span></span></p>






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
                                <h2 class="">Vaults</h2>
                                <section class="container-fluid m-0 p-0">
                                    <div class="row m-0 p-0">
                                        <div class="col-12 col-md-3 m-0 p-0 justify-content-center"
                                            style="aspect-ratio: 1/1" v-for="vault in profileVaults" :key="vault.id">
                                            <VaultAccCard :vault="vault" class="my-2" style="width: 20vw;" />
                                        </div>
                                    </div>
                                </section>
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
                                <!-- MODAL -->
                                <!-- {{ myKeeps }} -->
                                <h2 class="">Keeps</h2>
                                <section class="container-fluid m-0 p-0">
                                    <div class="row m-0 p-0">
                                        <div class="col-12 col-md-3 m-0 p-0 justify-content-center"
                                            style="aspect-ratio: 1/1" v-for="keep in profileKeeps" :key="keep.id">
                                            <KeepAccCard :keep="keep" class="my-2" style="width: 20vw;" />
                                        </div>
                                    </div>
                                </section>
                                <!-- MODAL -->
                                <p>Modal body text goes here.</p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary">Save changes</button>
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- MODAL -->







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
import { profilesService } from '../services/ProfilesService.js';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop.js';


export default {

    setup() {
        // NOTE The Order of the variables below Matters!








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
<script>
import KeepCard from '../components/KeepCard.vue';

export default {
    setup() {
        return {};
    },
    components: { KeepCard }
};
</script>


<style></style>
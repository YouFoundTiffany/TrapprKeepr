<!-- ACCOUNT PAGE -->
<template>
  <section v-if="account" class="container">
    <div class="row">
      <h1 class="text-center">{{ account.name }} Account Page
      </h1>
    </div>

    <div class="justify-content-center row d-flex">
      <img class="m-0 banner-image rounded" :src="account.coverImg" :alt="account.coverImg" title="account.coverImg" />


      <div class="justify-content-center d-flex">
        <img class="rounded elevation-2 avatar" :src="account.picture" :alt="account.picture" title="account.picture" />
      </div>
    </div>


    <button class="m-2">Edit Profile</button>
    <button class="m-2">View Profile</button>

    <!-- PROFILE VAULTS CARDS -->
    <h2 class="">Vaults</h2>
    <section class="moblView container-fluid m-0 p-0">
      <div class="row m-0 p-0">
        <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1"
          v-for="vault in profileVaults" :key="vault.id">
          <VaultAccCard :vault="vault" class="my-2" style="width: 15vw;" />
        </div>
      </div>
    </section>
    <!-- PROFILE KEEPS CARDS -->
    <!-- <h2 class="">Keeps</h2>
    <section class="moblView container-fluid m-0 p-0">
      <div class="row m-0 p-0">
        <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1" v-for="keep in profileKeeps"
          :key="keep.id">
          <KeepAccCard :keep="keep" class="my-2" style="width: 15vw;" />
        </div>
      </div>
    </section>
  </section> -->


  </section>
</template>







<script>
// onMounted
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepAccCard from '../components/KeepAccCard.vue';
import VaultAccCard from '../components/VaultAccCard.vue';
import { keepsService } from '../services/KeepsService.js';
import { accountService } from '../services/AccountService.js';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { useRoute } from 'vue-router';



export default {
  setup() {
    const route = useRoute()
    const accountId = computed(() => AppState.account.id)
    const vaultId = route.params.id
    onMounted(() => { getMyVaults(); getVaultsByProfile(); })

    async function getMyVaults() {

      try {
        await vaultsService.getVaultsByProfile()
      } catch (error) {
        Pop.error(error)
      }
    }

    // Get all of this person's vaults
    async function getVaultsByProfile() {
      try {
        await vaultsService.getVaultsByProfile(vaultId)
      } catch (error) {
        Pop.error(error)
      }
    }


    return {
      // profileKeeps,
      // profileVaults,
      // AppState: computed(() => AppState),
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      myKeeps: computed(() => AppState.keeps.filter(keep => keep.creatorId === AppState.account.id)),

      myVaults: computed(() => AppState.myVaults),
    }
  }
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
  align-items: baseline;
  align-items: start;
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

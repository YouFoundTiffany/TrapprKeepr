<!-- ACCOUNT PAGE -->
<!-- TODO MEDIA QUERY TO CENTER AND AJUST ON SMALL SCREENS -->
<template>
  <section v-if="account" class="container">
    <div class="row">


      <div class="about text-center">
        <div class="justify-content-center row d-flex">
          <img class="m-0 banner-image rounded" :src="account.coverImg" :alt="account.coverImg" :title="account.name" />
        </div>
        <div class="justify-content-center d-flex">
          <img class="rounded elevation-2 avatar" :src="account.picture" :alt="account.picture" :title="account.name" />
        </div>
        <h1>{{ account.name }}</h1>

      </div>

      <button col-3>Your Profile Page</button>


      <!-- ... -->
      <router-link :to="{ name: 'Edit Profile', params: { profileId: account.id } }">
        <button v-if="!profileId || profileId == accountId">Edit Profile</button>
      </router-link>


      <h2 class="">Vaults</h2>
      <section class="container-fluid m-0 p-0">
        <div class="row m-0 p-0">
          <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1"
            v-for="vault in profileVaults" :key="vault.id">
            {{ myVaults }}
            <VaultAccCard :vault="vault" class="my-2" style="width: 20vw;" />
          </div>
        </div>
      </section>







      <h2 class="">Keeps</h2>
      <section class="container-fluid m-0 p-0">
        <div class="row m-0 p-0">
          <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1"
            v-for="keep in profileKeeps" :key="keep.id">
            <!-- {{ myKeeps }} -->
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
import { computed, onMounted, ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import KeepAccCard from '../components/KeepAccCard.vue';
import VaultAccCard from '../components/VaultAccCard.vue';
import { keepsService } from '../services/KeepsService.js';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';
import { accountService } from '../services/AccountService';
import { vaultsKeepsService } from '../services/VaultKeepsService';



export default {

  setup() {


    // STUB Get My Vaults
    async function getMyVaults() {
      try {

        await accountService.myVaults();
      } catch (error) {
        Pop.error(error);
      }
    }

    // STUB Get My Keeps
    async function getMyKeeps() {
      try {
        await keepsService.getKeepsByProfile();
      } catch (error) {
        Pop.error(error);
      }
    }
    async function getMyVaultKeeps() {
      try {
        await vaultKeepsService.getVaultKeeps();
      } catch (error) {
        Pop.error(error);
      }
    }

    watchEffect(() => {
      getMyVaults();
      getMyKeeps();
      getMyVaultKeeps()
    });

    return {
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      myKeeps: computed(() => AppState.myKeeps),





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

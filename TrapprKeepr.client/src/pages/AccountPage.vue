<!-- ACCOUNT PAGE -->
<!-- TODO MEDIA QUERY TO CENTER AND AJUST ON SMALL SCREENS -->
<template>
  <div v-if="keeps || vaults" class="about text-center">
    <div class="justify-content-center row d-flex">
      <img class="m-0 banner-image rounded" :src="account.coverImg" alt="Cover Image" />
    </div>
    <div class="justify-content-center d-flex">
      <img class="rounded elevation-2 avatar" :src="account.picture" alt="Avatar" />
    </div>
    <h1>{{ account.name }}</h1>
    <p>TODO <span> 0</span> Vaults | 0 Keeps<span></span></p>
  </div>
  <!-- TODO router link to profile page -->
  <!-- <router-link :to="{ name: 'Profile', params: profile.id }"> -->
  <button class="m-2">Edit Profile</button>
  <!-- </router-link> -->
  <!-- <router-link :to="{ name: 'Profile', params: { profileId } }">
    <div class="list-group-item dropdown-item list-group-item-action">
      View Profile
    </div>
  </router-link> -->
  <!--
  <h2 v-if="vault" class="card-title masonry-container">Vaults</h2>
  <section class="" v-for="vault in vaults" :key="vault.id">
    <VaultAccCard :vault="vault" />
  </section> -->
  <div>
    <div v-if="myKeeps && myKeeps.length" class="card-title masonry-container">Keeps</div>
    <div v-for="keep in myKeeps" :key="keep.id">
      <KeepAccCard :myKeeps="keep" />
    </div>
  </div>
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



export default {
  setup() {
    const accountId = computed(() => AppState.account.id)

    // onMounted(() => { getMyVaults() })

    // async function getMyVaults() {

    //   try {
    //     await vaultsService.getVaultsByProfile()
    //   } catch (error) {
    //     Pop.error(error)
    //   }
    // // }

    // async function getVaultsByProfile() {
    //   try {
    //     await vaultsService.getVaultsByProfile(route.params.profileId)
    //   } catch (error) {
    //     Pop.error(error)
    //   }
    // }


    return {
      // profileKeeps,
      // profileVaults,
      // AppState: computed(() => AppState),
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      myKeeps: computed(() => AppState.keeps.filter(keep => keep.creatorId === AppState.account.id)),

      // mVaults: computed(() => AppState.vaults),

    };
  },
  components: { KeepAccCard, VaultAccCard }
}
</script>

<style scoped>
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

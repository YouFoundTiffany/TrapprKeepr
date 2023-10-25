<!-- ACCOUNT PAGE -->
<!-- TODO MEDIA QUERY TO CENTER AND AJUST ON SMALL SCREENS -->
<template>
  <!-- v-if="keeps || vaults" -->
  <div class="about text-center">
    <div class="justify-content-center row d-flex">
      <img class="m-0 banner-image rounded" :src="account.coverImg" :alt="account.coverImg" />
    </div>
    <div class="justify-content-center d-flex">
      <img class="rounded elevation-2 avatar" :src="account.picture" :alt="account.picture" />
    </div>
    <h1>{{ account.name }}</h1>
    <p>TODO <span> 0</span> Vaults | 0 Keeps<span></span></p>
  </div>

  <!-- TODO router link to profile page -->
  <!-- ... -->
  <!-- <router-link :to="{ name: 'Edit Profile', params: { profileId: account.id } }">
    <button v-if="!profileId || profileId == accountId">Edit Profile</button>
  </router-link> -->


  <section class="" v-for="vault in myVaults" :key="vault.id">
    <h2 class="card-title masonry-container">Vaults</h2>
    <VaultAccCard :vault="vault" />
  </section>

  <section class="" v-for="keep in myKeeps" :key="keep.id">
    <KeepAccCard :keep="keep" />
    <h2 class="card-title masonry-container">Keeps</h2>
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
import { keepsService } from '../services/KeepsService.js';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger.js';
import { accountService } from '../services/AccountService.js';
import { profilesService } from '../services/ProfilesService.js';
import { Account, Profile } from '../models/Account.js';




export default {
  setup() {
    // NOTE The Order of the variables below Matters!
    // const route = useRoute();
    const profileId = computed(() => AppState.account.id)
    // const profileId = route.params.profileId;

    async function getProfile(profileId) {
      try {
        // logger.log('route', route)
        await profilesService.getProfile(profileId)
      } catch (error) {
        Pop.error(error.message)
      }
    }



    // const isOwner = computed(() => {
    // return !route.params.profileId || route.params.profileId === AppState.account.id;
    // });

    // getKeepsByProfile(); getVaultsByProfile();
    onMounted(() => { getProfile() })

    // async function getKeepsByProfile() {
    //   try {
    //     await keepsService.getKeepsByProfile(route.params.profileId)
    //   } catch (error) {
    //     Pop.error(error)
    //   }
    // }
    // async function getVaultsByProfile() {
    //   try {
    //     await vaultsService.getVaultsByProfile(route.params.profileId)
    //   } catch (error) {
    //     Pop.error(error)
    //   }
    // }


    return {
      profileId,
      // getKeepsByProfile,
      // getVaultsByProfile,
      profile: computed(() => AppState.activeProfile),
      account: computed(() => AppState.account),
      // keeps: computed(() => AppState.keeps),
      // vaults: computed(() => AppState.vaults),
      myKeeps: computed(() => AppState.myKeeps),
      myVaults: computed(() => AppState.myVaults),

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

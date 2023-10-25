<!-- ACCOUNT PAGE -->
<!-- TODO MEDIA QUERY TO CENTER AND AJUST ON SMALL SCREENS -->
<template>
  <section class="container">
    <div class="row">



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
      <router-link :to="{ name: 'Edit Profile', params: { profileId: account.id } }">
        <button v-if="!profileId || profileId == accountId">Edit Profile</button>
      </router-link>

      <!-- {{ myVaults }} -->
      <h2 class="">Vaults</h2>
      <section class="container-fluid m-0 p-0">
        <div class="row m-0 p-0">
          <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1" v-for="vault in myVaults"
            :key="vault.id">
            <VaultAccCard :vault="vault" class="my-2" style="width: 20vw;" />
          </div>
        </div>
      </section>
      <h2 class="">Keeps</h2>
      <section class="container-fluid m-0 p-0">
        <div class="row m-0 p-0">
          <div class="col-12 col-md-3 m-0 p-0 justify-content-center" style="aspect-ratio: 1/1" v-for="keep in myKeeps"
            :key="keep.id">
            <KeepAccCard :keep="keep" class="my-2" style="width: 20vw;" />
          </div>
        </div>
      </section>
      <!-- {{ myKeeps }} -->

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
import { keepsService } from '../services/KeepsService.js';
// import { vaultsService } from '../services/VaultsService.js';
// import Pop from '../utils/Pop.js';
// import { useRoute } from 'vue-router';
// import { logger } from '../utils/Logger.js';
// import { accountService } from '../services/AccountService.js';
// import { profilesService } from '../services/ProfilesService.js';
// import { Account, Profile } from '../models/Account.js';




export default {

  setup() {
    // NOTE The Order of the variables below Matters!
    const accountId = computed(() => AppState.account.id)

    onMounted(async () => {
      await keepsService.getKeeps()
    })

    const myKeeps = computed(() => {
      return AppState.keeps.filter(k => k.creatorId === accountId.value)
    })
    const myVaults = computed(() => {
      return AppState.vaults.filter(v => v.creatorId === accountId.value)
    })

    // const isOwner = computed(() => {
    // return !route.params.profileId || route.params.profileId === AppState.account.id;
    // });

    return {
      myKeeps,
      myVaults,
      profile: computed(() => AppState.activeProfile),
      account: computed(() => AppState.account),
      activeProfile: computed(() => AppState.account),
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

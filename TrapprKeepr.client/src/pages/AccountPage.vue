<!-- ACCOUNT PAGE -->
<template>
  <section v-if="account" class="container">
    <div class="row">
      <h1 class="text-center text-midnight-plum">{{ account.name }} Account Page
      </h1>
    </div>

    <div class="justify-content-center row d-flex">
      <img class="m-0 p-0 banner-image rounded" :src="account.coverImg" :alt="account.coverImg"
        title="account.coverImg" />


      <div class="justify-content-center d-flex">
        <img class="rounded elevation-2 avatar" :src="account.picture" :alt="account.picture" title="account.picture" />
      </div>
    </div>
    <div class="p-1 d-flex justify-content-center">
      <router-link :to="{ name: 'Edit Profile', params: { profileId: account.id } }"><button
          class="m-2 btn dropdown-toggle create-btn" type="button" id="">Edit Profile</button>
      </router-link>
      <router-link :to="{ name: 'Profile', params: { profileId: account.id } }">
        <button class="m-2 btn dropdown-toggle create-btn" type="button" id="">View Profile</button>
      </router-link>
    </div>
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





    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),


      // profileKeeps,
      // profileVaults,
      AppState
      // profile: computed(() => AppState.profile),
      // account: computed(() => AppState.account),
      // keeps: computed(() => AppState.keeps),
      // myKeeps: computed(() => AppState.keeps.filter(keep => keep.creatorId === AppState.account.id)),

      // myVaults: computed(() => AppState.myVaults),
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

.create-btn {
  background-color: var(--sunset-coral) !important;
  color: #14213d !important;
  border: none !important;
  border-radius: 5px !important;
  box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2) !important;
}

.create-btn:hover {
  background-color: #e7816f7d !important;
  color: #14213d !important;
  border: none !important;
  border-radius: 5px !important;
  box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2) !important;
}
</style>

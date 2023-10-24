<!-- ACCOUNT PAGE -->
<template>
  <div class="about text-center">
    <div class="justify-content-center row d-flex">
      <img class="banner-image rounded" :src="account.coverImg" alt="Cover Image" />
    </div>
    <div class="justify-content-center">
      <img class="rounded p-3" :src="account.picture" alt="Avatar" />
    </div>
    <h1>{{ account.name }}</h1>
    <p>TODO <span> 0</span> Vaults | 0 Keeps<span></span></p>
  </div>

  <h2 class="card-title masonry-container">Vaults</h2>
  <section class="">
    <VaultAccCard v-for="keep in keeps" :key="keep.id" :keep="keep" />
  </section>

  <h2 class="card-title masonry-container">Keeps</h2>
  <section class="">
    <KeepAccCard v-for="keep in keeps" :key="keep.id" :keep="keep" />
  </section>
</template>

<script>
// onMounted
import { computed } from 'vue';
import { AppState } from '../AppState';
import KeepAccCard from '../components/KeepAccCard.vue';
import VaultAccCard from '../components/VaultAccCard.vue';
import { keepsService } from '../services/KeepsService';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';

export default {
  setup() {

    async function getKeepsByProfile() {
      try {
        await keepsService.getKeepsByProfile()
      } catch (error) {
        Pop.error(error)
      }
    }
    async function getVaultsByProfile() {
      try {
        await vaultsService.getVaultsByProfile()
      } catch (error) {
        Pop.error(error)
      }
    }


    return {
      getKeepsByProfile,
      getVaultsByProfile,
      AppState: computed(() => AppState),
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      account: computed(() => AppState.account),

    };
  },
  components: { KeepAccCard, VaultAccCard }
}
</script>

<style scoped>
/* .profile-pic { */
/* height: 30px; */
/* width: 30px; */
/* object-fit: cover; */
/* object-position: center; */
/* border-radius: 50em; */
/* } */

.banner-image {
  overflow: hidden;
  justify-content: center;
  max-width: 100vh;
  max-height: 30vh;
  /* aspect-ratio: 4/3; */
  object-fit: cover;
}
</style>

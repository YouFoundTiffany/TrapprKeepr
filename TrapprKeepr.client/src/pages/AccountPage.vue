<!-- ACCOUNT PAGE -->
<!-- TODO MEDIA QUERY TO CENTER AND AJUST ON SMALL SCREENS -->
<template>
  <div class="about text-center">
    <div class="justify-content-center row d-flex">
      <img class="m-0 banner-image rounded" :src="account.coverImg" alt="Cover Image" />
    </div>
    <div class="justify-content-center d-flex">
      <img class="rounded elevation-2 avatar" :src="account.picture" alt="Avatar" />
    </div>
    <h1>{{ account.name }}</h1>
    <p>TODO <span> 0</span> Vaults | 0 Keeps<span></span></p>
  </div>
  <!-- <router-link :to="{ name: 'Profile', params: profile.id }"> -->
  <button>Edit Profile</button>
  <!-- </router-link> -->

  <h2 class="card-title masonry-container">Vaults</h2>
  <section class="" v-for="vault in vaults" :key="vault.id">
    <VaultAccCard :vault="vault" />
  </section>

  <h2 class="card-title masonry-container">Keeps</h2>
  <section class="" v-for="keep in keeps" :key="keep.id">
    <KeepAccCard :keep="keep" />
  </section>
</template>

<script>
// onMounted
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import KeepAccCard from '../components/KeepAccCard.vue';
import VaultAccCard from '../components/VaultAccCard.vue';
import { keepsService } from '../services/KeepsService';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';
import { useRoute } from 'vue-router';
export default {
  setup() {
    const route = useRoute();
    //
    onMounted(() => { getKeepsByProfile(); getVaultsByProfile(); })

    async function getKeepsByProfile() {
      try {
        await keepsService.getKeepsByProfile(route.params.profileId)
      } catch (error) {
        Pop.error(error)
      }
    }
    async function getVaultsByProfile() {
      try {
        await vaultsService.getVaultsByProfile(route.params.profileId)
      } catch (error) {
        Pop.error(error)
      }
    }


    return {
      getKeepsByProfile,
      getVaultsByProfile,
      // AppState: computed(() => AppState),
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      myKeeps: computed(() => AppState.keeps),
      mVaults: computed(() => AppState.vaults),

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

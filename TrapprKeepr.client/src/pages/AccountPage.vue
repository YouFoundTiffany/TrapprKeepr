<template>
  <div class="about text-center">
    <div class="justify-content-center ">
      <img class="rounded" :src="account.coverImg" alt="Cover Image">
    </div>
    <div class="justify-content-center ">
      <img class="rounded" :src="account.picture" alt="Avatar" />
    </div>
    <h1>{{ account.name }}</h1>
    <!-- <p><span>{{ vaults }} 0</span> Vaults | 0 Keeps<span></span>{{ account.keeps }}</p> -->
  </div>
  <section v-if="vault" class="">
    <h5 class="card-title">Vaults</h5>
    <VaultAccCard />
  </section>

  <section v-for="keep in keeps" :key="keep.id" :keep="keep" class="">
    <h5 class="card-title">Keeps</h5>
    {{ keep }}
    <KeepAccCard v-for="keep in keeps" :key="keep.id" :keep="keep" />
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
// import VaultAccCard from '../components/VaultAccCard.vue';
import KeepAccCard from '../components/KeepAccCard.vue';
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
    // watchEffect(() => {
    //   getKeepsByProfile(),
    //     getVaultsByProfile(),
    // });

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
  // VaultAccCard
  components: { KeepAccCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>

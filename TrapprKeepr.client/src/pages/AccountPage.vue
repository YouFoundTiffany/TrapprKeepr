<template>
  <div class="about text-center">
    <div>
      <!-- <img class="rounded" :src="account.coverImg"alt="Cover Image"> -->
      <img class="rounded" :src="account.picture" alt="Avatar" />
    </div>
    <h1>{{ account.name }}</h1>
    <!-- <p><span>{{ account.vaulst }}0</span>Vaults | 0 Keeps<span></span>{{ account.keeps }}</p> -->
  </div>
  <section class="">
    <h5 class="card-title">Vaults</h5>
    <!-- <VaultAccCard /> -->
  </section>

  <section class="">
    <h5 class="card-title">Keeps</h5>
    <!-- <KeepAccCard /> -->
  </section>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import VaultAccCard from '../components/VaultAccCard.vue';
import KeepAccCard from '../components/KeepAccCard.vue';
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    };
  },
  // components: { VaultAccCard, KeepAccCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>

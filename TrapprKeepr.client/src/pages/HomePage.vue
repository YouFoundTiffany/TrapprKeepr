<!-- HOME PAGE  -->
<template>
  <div class="hmasonry-container container">
    <KeepCard v-for="keep in keeps" :key="keep.id" :keep="keep" style="min-height: 5em;" />

  </div>
</template>

<script>
import { accountService } from '../services/AccountService.js'
import { keepsService } from '../services/KeepsService.js'
import KeepCard from '../components/KeepCard.vue';
import { computed, onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
// import { Modal } from 'bootstrap';
import { vaultsService } from '../services/VaultsService.js';
// import { logger } from '../utils/Logger.js';
import { useRoute } from 'vue-router';
// import { router } from '../router';


export default {
  setup() {
    onMounted(() => { getKeeps(); });


    // STUB Get all Keeps
    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      } catch (error) {
        Pop.error(error);
      }
    }





    return {
      // account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep),
      // profile: computed(() => AppState.profiles),
      // profileKeeps: computed(() => AppState.profileKeeps),
      // profileVaults: computed(() => AppState.profileVaults),
      // activeProfile: computed(() => AppState.activeProfile),
      // userVaults: computed(() => AppState.userVaults),
    };
  },
  components: { KeepCard },
};

</script>
<style>
/* Best version so far */
.hmasonry-container {
  top: 45px;
  columns: 200px;
  /* column-gap: 1.25em; */
  overflow: hidden;
  min-height: 100vh;
}

/* Media query for mobile view */
@media (max-width: 767px) {
  .hmasonry-container {
    columns: 2;
  }
}
</style>
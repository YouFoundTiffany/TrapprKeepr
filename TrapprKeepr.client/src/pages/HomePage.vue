<!-- HOME PAGE  -->
<template>
  <div class="hmasonry-container">
    <KeepCard v-for="keep in keeps" :key="keep.id" :keep="keep" :profile="profile" style="min-height: 5em;" />

  </div>
</template>

<script>
import { accountService } from '../services/AccountService.js'
import { keepsService } from '../services/KeepsService.js'
import { profilesService } from '../services/ProfilesService.js'
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
  // const: router = useRouter(),
  setup() {
    onMounted(async () => { getAccount(); getKeeps(); getVaults(); getProfilesVaults() });
    const route = useRoute();

    const selectedKeep = ref(null);


    // STUB - Getting logged in Account Holder if they exist
    // REVIEW, MAY NOT REALLY NEED THIS ON HOME PAGE LOAD
    async function getAccount() {
      try {
        await accountService.getAccount();
      } catch (error) {
        Pop.error(error);
      }
    }

    // STUB Get all Keeps
    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      } catch (error) {
        Pop.error(error);
      }
    }

    // we need to get logged in Account holder vaults ONLY, this is MyVaults, not Profile Vaults

    // STUB Get all Vaults with this Profile Id
    async function getProfilesVaults() {
      try {
        await profilesService.getProfilesVaults(route.params.profileId);
      } catch (error) {
        Pop.error(error);
      }
    }

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      profile: computed(() => AppState.profiles),
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults),
      activeProfile: computed(() => AppState.activeProfile),

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
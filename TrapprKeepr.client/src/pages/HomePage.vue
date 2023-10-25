<!-- HOME PAGE  -->
<template>
  <section class="container">
    <div class="row">
      <div class="hmasonry-container">
        <KeepCard v-for="keep in keeps" :key="keep.id" :keep="keep" :profile="profile" />
        <!-- @click="openModal(keep)" -->
      </div>
    </div>
  </section>
</template>

<script>
import { keepsService } from '../services/KeepsService.js'
import KeepCard from '../components/KeepCard.vue';
import { computed, onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
// import { Modal } from 'bootstrap';
import { vaultsService } from '../services/VaultsService';
// import { router } from '../router';

export default {
  // const: router = useRouter(),
  setup() {
    onMounted(() => { getKeeps(); getVaults(); });

    const selectedKeep = ref(null);
    // const modalRef = ref(null);

    // function openModal(keep) {
    //   selectedKeep.value = keep;
    //   const modal = new Modal(modalRef.value);
    //   modal.show();
    // }

    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    async function getVaults() {
      try {
        await vaultsService.getVaults();
      }
      catch (error) {
        Pop.error(error);
      }
    }

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      profile: computed(() => AppState.profiles),
      selectedKeep,
      // openModal
    }
  },
  components: { KeepCard }
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
</style>
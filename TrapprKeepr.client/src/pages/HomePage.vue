<template>
  <section class="container">
    <div class="row">
      <div class="masonry-container">

        <KeepCard v-for="keep in keeps" :key="keep.id" :keep="keep" @click="openModal(keep)" />


        <!-- <KeepDetailsModalView v-if="selectedKeep" :keep="selectedKeep" @close="selectedKeep = null" ref="modalRef" /> -->
      </div>
    </div>
  </section>
</template>

<script>
import { keepsService } from '../services/KeepsService.js'
import KeepCard from '../components/KeepCard.vue';
import { computed, onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState';
import { Modal } from 'bootstrap';
import { vaultsService } from '../services/VaultsService';

export default {
  setup() {
    onMounted(() => { getKeeps(); });

    const selectedKeep = ref(null);
    const modalRef = ref(null);

    function openModal(keep) {
      selectedKeep.value = keep;
      const modal = new Modal(modalRef.value);
      modal.show();
    }

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
      selectedKeep,
      openModal
    }
  },
  components: { KeepCard }
};

</script>
<style>
/* .keeps-container {
  display: flex;
  flex-wrap: wrap;
} */

.keep-card {
  max-width: 200px;
}


.masonry-container {
  $gap: 1.25em;
  columns: 200px;
  column-gap: $gap;

}



/* .masonry-container {
  display: grid;
  grid-gap: 3px;
  display: flex;
  flex-wrap: wrap;
} */
</style>
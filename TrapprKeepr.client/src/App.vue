<!-- APP.VUE -->
<template>
  <header>
    <Navbar />

  </header>
  <main>
    <div class="border border-bottom border-secondary mb-4 light-shadow" style="height: 1px;"></div>
    <router-view />
  </main>



  <!-- TIFFTAG MODAL PIECE -->

  <!--1️⃣ KEEP CARD MODAL-->
  <div class="modal fade" id="KeepDetailsModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content" v-if="activeKeep">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">{{ activeKeep.name }}</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-bodyKeepDetailsModal">
          <div class="container-fluid">
            <div class="row">
              <!-- NOTE img is an array on the project object: we just need to v-for over that array in order to get the imgs on the screen THIS IS IMPORTANT*** -->
              <!-- <div class="col-12 mb-3" v-for=" in activeProject.projectImgs" :key="img"> -->
              {{ activeKeep.name }}

              <KeepDetailsCard v-if="activeKeep" :activeKeep="activeKeep" :userVaults="userVaults" />
              <img class="img-fluid" :src="img" alt="">
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <!-- <button type="button" class="btn btn-primary">Save changes</button> -->
      </div>
    </div>
  </div>

  <!--2️⃣ OTHER CARD MODAL-->





  <footer class="bg-secondary lighten-10 text-dark">

  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import { Modal } from 'bootstrap'


export default {
  setup() {
    return {
      appState: computed(() => AppState),
      activeKeep: computed(() => AppState.activeKeep)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

// .shadow {
//   box-shadow: 10px 10px 10px rgba(0, 0, 0, 0.546) !Important;
// }

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>

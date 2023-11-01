<!-- APP.VUE -->
<template>
  <header>
    <Navbar />

  </header>
  <main>
    <div class="border border-bottom border-secondary mb-4 light-shadow" style="height: 1px;"></div>
    <router-view />
  </main>



  <footer class="bg-secondary lighten-10 text-dark">
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'


export default {
  setup() {
    return {
      appState: computed(() => AppState),
      activeKeep: computed(() => AppState.activeKeep),
      keeps: computed(() => AppState.keeps),
      activeProfile: computed(() => AppState.activeProfile),
      account: computed(() => AppState.account),
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



.h5-over {
  position: absolute;
  top: 70%;
  left: 0;
  width: 100%;
  text-shadow: 0 4px 8px rgba(0, 0, 0, 0.927) !Important;
}

.modprofile-pic {
  max-height: 35px;
  width: 35px;
  object-fit: cover;
  /* object-position: center; */
  border-radius: 50em;
  /* position: absolute; */
  /* align-items: baseline; */
  justify-content: end;
  /* bottom: 30vh;
    right: 4vw; */
}

.keep-image {
  max-height: 350px;
  object-fit: cover;
  object-position: center center;

}

.container-fluid {
  padding-left: 0;
  padding-right: 0;
}
</style>

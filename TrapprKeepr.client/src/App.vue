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
import ModalWrapper from './components/ModalWrapper.vue'


export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, ModalWrapper }
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

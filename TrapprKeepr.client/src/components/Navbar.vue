<template>
  <nav class="container-flex navbar navbar-expand-lg mt-5 px-3  navbar-text justify-content-around">
    <!-- LEFT -->
    <div class="col-12 col-md-4">
      <!-- DROPDOWN -->
      <div class="dropdown">
        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown"
          aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
          <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#modal1">New Keep</a></li>
          <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#modal2">New Vault</a></li>
        </ul>
      </div>
    </div>

    <!-- Modal 1 for Keep-->
    <div class="modal fade" id="modal1" tabindex="-1" aria-labelledby="modal1Label" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="modal1Label">Create Keep</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createKeep">
              <div class="mb-3">
                <label for="keepName" class="form-label">Name</label>
                <input type="text" class="form-control" id="keepName" v-model="keep.name">
              </div>
              <div class="mb-3">
                <label for="keepDescription" class="form-label">Description</label>
                <input type="text" class="form-control" id="keepDescription" v-model="keep.description">
              </div>
              <div class="mb-3">
                <label for="keepImg" class="form-label">Image URL</label>
                <input type="url" class="form-control" id="keepImg" v-model="keep.img">
              </div>
              <button type="submit" class="btn btn-primary">Create Keep</button>
            </form>
          </div>
        </div>
      </div>
    </div>


    <!-- Modal 2 for Vault-->
    <div class="modal fade" id="modal2" tabindex="-1" aria-labelledby="modal2Label" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="modal2Label">Create Vault</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createVault">
              <div class="mb-3">
                <label for="vaultName" class="form-label">Name</label>
                <input type="text" class="form-control" id="vaultName" v-model="vault.name">
              </div>
              <div class="mb-3">
                <label for="vaultDescription" class="form-label">Description</label>
                <input type="text" class="form-control" id="vaultDescription" v-model="vault.description">
              </div>
              <div class="mb-3">
                <label for="vaultImg" class="form-label">Image URL</label>
                <input type="url" class="form-control" id="vaultImg" v-model="vault.img">
              </div>
              <div class="mb-3 form-check">
                <input type="checkbox" class="form-check-input" id="vaultPrivate" v-model="vault.isPrivate">
                <label class="form-check-label" for="vaultPrivate">Is Private?</label>
              </div>
              <button type="submit" class="btn btn-primary">Create Vault</button>
            </form>
          </div>
        </div>
      </div>
    </div>

    <!-- CENTER -->
    <div class="col-12 col-md-4 text-center">
      <router-link class="navbar-brand " :to="{ name: 'Home' }">
        <div class="flex-column align-items-center">TrapprKeepr
          <img alt="logo" src="src/assets/img/trapprkeeprcolor.png" height="85" />
        </div>
      </router-link>
    </div>
    <!-- RIGHT -->
    <div class="col-12 col-md-4 ">
      <button class="navbar-toggler text-start" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon text-start"></span>
      </button>
      <Login class="collapse navbar-collapse avatar" id="navbarText" />
    </div>
  </nav>
  <hr class="shadow justify--center ">
</template>

<script>
import { logger } from '../utils/Logger';
import Login from './Login.vue';
logger
export default {
  data() {
    return {
      vault: {
        name: '',
        description: '',
        img: '',
        isPrivate: false,
      },
      keep: {
        name: '',
        description: '',
        img: ''
      }
    };
  },
  methods: {
    createVault() {
      // Call the API or service to create the vault
      logger.log("Vault to be created:", this.vault);
    },
    createKeep() {
      // Call the API or service to create the keep
      logger.log("Keep to be created:", this.keep);
    }
  },
  components: { Login }
};
</script>


<style scoped>
.shadow {
  width: 70vw;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2) !Important;
}

.avatar {
  display: flex !important;
  justify-content: flex-end !important;
}


@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>

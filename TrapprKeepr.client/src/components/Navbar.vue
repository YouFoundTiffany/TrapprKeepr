<!-- NAVBAR COMPONENT -->
<template>
  <nav v-if="keepData || vaultData"
    class="container-flex navbar navbar-expand-lg my-5 px-3  navbar-text justify-content-around" style="max-height: 155;">
    <!-- LEFT -->

    <div class="col-12 col-md-4">
      <!-- DROPDOWN -->
      <div v-if="user.isAuthenticated" class="dropdown">
        <button class="btn dropdown-toggle create-btn fw-bold" type="button" id="dropdownMenuButton"
          data-bs-toggle="dropdown" aria-expanded="false">
          Create
        </button>
        <!-- v-if="account.id == profile.id && detailspage" -->
        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
          <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#create-keep">New Keep</a></li>
          <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#create-vault">New Vault</a></li>
        </ul>
      </div>
    </div>

    <!-- Modal 1 for CREATE Keep-->
    <div class="modal fade" id="create-keep" tabindex="-1" aria-labelledby="create-keepLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="create-keepLabel">Create Keep</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <!-- Create Keep Form -->
          <div class="modal-body">
            <form @submit.prevent="createKeep">
              <div class="mb-3">
                <label for="name" class="form-label">Name</label>
                <input v-model="keepData.name" type="text" class="form-control" id="name" minlength="1" maxlength="20">
              </div>
              <div class="mb-3">
                <label for="keepDescription" class="form-label">Description</label>
                <input v-model="keepData.description" type="text" class="form-control" id="keepDescription" minlength="1"
                  maxlength="100">
              </div>
              <div class="mb-3">
                <label for="keepImg" class="form-label">Image URL</label>
                <input v-model="keepData.img" type="url" class="form-control" id="keepImg" minlength="150"
                  maxlength="700">
              </div>
              <button type="submit" class="btn btn-primary">Create Keep</button>
            </form>
          </div>
        </div>
      </div>
    </div>


    <!-- Modal 2 for CREATE Vault-->
    <div class="modal fade" id="create-vault" tabindex="-1" aria-labelledby="create-vaultLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="create-vaultLabel">Create Vault</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <!-- Create Vault Form -->
          <div class="modal-body">

            <form @submit.prevent="createVault">

              <div class="mb-3">
                <label for="vault-name" class="form-label">Name</label>
                <input v-model="vaultData.name" id="vault-name" class="form-control" type="text" minlength="5"
                  maxlength="20">
              </div>
              <div class="mb-3">
                <label for="vault-description" class="form-label">Description</label>
                <input v-model="vaultData.description" id="vault-description" class="form-control" type="text"
                  minlength="1" maxlength="100">
              </div>
              <div class="mb-3">
                <label for="vault-img" class="form-label">Image URL</label>
                <input v-model="vaultData.img" id="vault-img" class="form-control" type="text" minlength="150"
                  maxlength="700">
              </div>
              <div class="mb-3 form-check">
                <label class="vault-isPrivate" for="vault-isPrivate">Is Private?</label>
                <input v-model="vaultData.isPrivate" id="vault-isPrivate" class="form-checkbox" type="checkbox">
              </div>
              <button type="submit" class="btn btn-primary">Create Vault</button>
            </form>
          </div>
        </div>
      </div>
    </div>

    <!-- CENTER -->
    <div class="col-12 col-md-4 text-center mt-4">
      <router-link class="navbar-brand " :to="{ name: 'Home' }">
        <div class="flex-column align-items-center text-midnight-plum fw-bold fs-1">
          <img src="src/assets/img/Trapper.png" alt="" height="135">
          <img alt=" logo" title="logo" src="src/assets/img/trapprkeeprcolor.png" height="85" />
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
</template>

<script>
import { computed, ref } from 'vue';
import { logger } from '../utils/Logger.js';
import Login from './Login.vue';
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop.js';
import { router } from '../router';
import { useRoute } from 'vue-router';
import { Modal } from 'bootstrap';



export default {
  setup() {
    const keepData = ref({})
    const vaultData = ref({})
    const keep = ref({ name: '', description: '', img: '' })
    const vault = ref({ name: '', description: '', img: '', isPrivate: false })
    const route = useRoute()

    return {
      keepData,
      vaultData,
      keep,
      vault,
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.user),


      // STUB CREATE KEEP
      async createKeep() {
        try {
          logger.log('[Creat Keep]', keepData.value)
          const newKeep = await keepsService.createKeep(keepData.value)
          keepData.value = {}
          Pop.toast('Keep Created', 'success')
          // router.push({ name: 'Keep Details', params: { keepId: newKeep.id } })
          Modal.getOrCreateInstance('#create-keep').hide()
        } catch (error) {
          Pop.error(error)
        }
      },
      // STUB CREATE VAULT
      async createVault() {
        try {
          logger.log('[Create Vault]', vaultData.value)
          const newVault = await vaultsService.createVault(vaultData.value)
          vaultData.value = {}
          Pop.toast('Vault Created', 'success')
          // router.push({ name: 'Vault Details', params: { vaultId: newVault.id } })
          Modal.getOrCreateInstance('#create-vault').hide()
        } catch (error) {
          Pop.error(error)
        }
      }
      // async createVault() {
      //   try {
      //     logger.log(vaultData.value, AppState.activeVault.id, route.params.vaultId)
      //     vaultData.value.vaultId = route.params.vaultId
      //     await vaultsService.createVault(vaultData.value)
      //     Pop.toast('Added Vault', 'success', 'center-end')
      //     vaultData.value = {}
      //     // Modal.getOrCreateInstance('#KeepDetailsModal').hide()
      //   } catch (error) {
      //     Pop.error(error)
      //   }
      // }


    }
  },
  components: { Login }
};
</script>


<style scoped>
/* CREATE BUTTON */
.create-btn {
  background-color: #e7816f7d !important;
  color: var(--midnight-plum) !important;
  border: none !important;
  border-radius: 5px !important;
  box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2) !important;
}

.create-btn:hover {
  background-color: var(--sunset-coral) !important;
  color: var(--midnight-plum) !important;
  border: none !important;
  border-radius: 5px !important;
  box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2) !important;
}

.shadow {
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

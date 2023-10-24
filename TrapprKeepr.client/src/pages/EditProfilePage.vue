<!-- PROFILE PAGE -->
          <!-- tifftags display active item in form -->
<template>
    <div v-if="profile" class='container'>

        <section class='row'>
            <div class="container-fluid">
                <div class="row justify-content-center">
                    <div class="col-md-10 col-12 bg-white elevation-3 rounded p-2">
                        <form action="" @submit.prevent="editProfile()">
                            <div class="mb-2">
                                <label for="name">Name</label>
                                <input class="form-control" type="text" id="name" minlength="3" maxlength="75"
                                    v-model="editable.name">
                            </div>
                            <div class="mb-2">
                                <label for="picture">Picture</label>
                                <input class="form-control" type="url" id="picture" minlength="3" maxlength="200"
                                    v-model="editable.picture">
                            </div>
                            <div class="mb-2">
                                <label for="coverImg">Cover Image</label>
                                <input class="form-control" type="url" id="coverImg" minlength="3" maxlength="200"
                                    v-model="editable.coverImg">
                            </div>
                            <div class="mb-2 text-end">
                                <button class="btn btn-success" type="submit">Submit</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>
<script>
import { computed, onMounted, ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import { accountService } from '../services/AccountService';
import Pop from '../utils/Pop';
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService';
import { vaultsKeepsService } from '../services/VaultKeepsService';
import { vaultsService } from '../services/VaultsService';
import { logger } from '../utils/Logger';

// <!-- tifftag get profile  -->


export default {
    setup() {
        const editable = ref({})
        onMounted(() => {
            getKeepsByProfileId();
            getVaultsByProfileId();
            getProfileById()
        });
        watchEffect(() => {
            editable.value = { ...AppState.account }
        })

        const route = useRoute();
        async function getKeepsByProfileId() {
            try {
                await keepsService.getKeepsByProfileId(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getVaultsByProfileId() {
            try {
                await vaultsService.getVaultsByProfileId(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getProfileById() {
            try {
                await accountService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
        return {
            editable,
            projects: computed(() => AppState.projects),
            profile: computed(() => AppState.activeProfile),
            account: computed(() => AppState.account),
            // NOTE need elvis operator here, cause we still can't reach into a null object, even in our computeds

            async editProfile() {
                try {
                    logger.log('[EDITING PROFILE]', editable.value)
                    // NOTE finish the method to create a project
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }

    // components: { ProjectCard, ProjectForm }
};
</script >
.cover-img {
    background-image: v-bind(coverImg);
    min-height: 50vh;
    background-position: center;
    background-size: cover;
  }

  .profile-pic {
    height: 100px;
    width: 100px;
    object-fit: cover;
    object-position: center;
    border-radius: 50em;
  }


<style></style>
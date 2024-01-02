<!-- EDIT PROFILE PAGE -->
<template>
    <div v-if="profile" class='container text-periwinkle-dream fw-bold'>

        <section class='row m-3 p-2'>
            <div class="container-fluid">
                <div class="row justify-content-center p-2">
                    <div class="col-md-10 col-12 bg-white elevation-3 rounded p-2">
                        <form action="" @submit.prevent="editProfile()">
                            <div class="mb-2 p-2">
                                <label for="name">Name</label>
                                <input class="form-control" type="text" id="name" minlength="3" maxlength="75"
                                    v-model="editable.name">
                            </div>
                            <div class="mb-2 p-2">
                                <label for="picture">Picture</label>
                                <input class="form-control" type="url" id="picture" minlength="3" maxlength="200"
                                    v-model="editable.picture">
                            </div>
                            <div class="d-flex justify-content-center p-2">
                                <img :src="editable.picture" alt="" class="rounded shadow">
                            </div>
                            <div class="mb-2 p-2">
                                <label for="coverImg">Cover Image</label>
                                <input class="form-control" type="url" id="coverImg" minlength="3" maxlength="200"
                                    v-model="editable.coverImg">
                            </div>
                            <div class="d-flex justify-content-center p-2">
                                <img :src="editable.coverImg" alt="" class="rounded shadow p-0">
                            </div>
                            <div class="mb-1 text-end py-1 pe-2">
                                <button class="btn btn-success shadow p-2 fw-bold" type="submit">Submit</button>
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
// import { keepsService } from '../services/KeepsService';
// import { vaultsKeepsService } from '../services/VaultKeepsService';
// import { vaultsService } from '../services/VaultsService';
import { logger } from '../utils/Logger';
// import { Profile } from '../models/Account';


export default {
    setup() {
        const editable = ref({})
        onMounted(() => {
            getProfileById()
        });
        watchEffect(() => {
            editable.value = { ...AppState.account }
        })

        const route = useRoute();
        async function getProfileById() {
            try {
                await accountService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
        return {
            AppState,
            editable,
            profile: computed(() => AppState.profile),
            account: computed(() => AppState.account),
            // NOTE need elvis operator here, cause we still can't reach into a null object, even in our computeds
            // coverImg: computed(() => `url(${AppState.activeProfile?.coverImg})`)
            async editProfile() {
                try {
                    const profileId = AppState.activeProfile.id
                    logger.log('[EDITING PROFILE]', editable.value)
                    await accountService.editProfile(editable.value)
                    Pop.toast('Profile Updated')
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
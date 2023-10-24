<!-- PROFILE PAGE -->
<template>
    <div class='container'>
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
import { computed, ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import { accountService } from '../services/AccountService';
import Pop from '../utils/Pop';


export default {
    setup() {
        const editable = ref({})

        // watchEffect(() => {
        //     editable.value = { ...AppState.account }
        // })
        function setForm() {
            if (AppState.activeProfile) {
                formData.value = {
                    name.AppState.activeProfile.name,
                    picture.AppState.activeProfile.picture,
                    coverImg.AppState.activeProfile.coverImg

                }
            }
        }
        return {
            editable,
            profile: computed(() => AppState.account),
            formData,
            activeProfile: computed(() => AppState.activeProfile),
            // tifftags editable form.
            async editProfile() {
                try {
                    const formData = editable.value
                    await accountService.editProfile(formData)
                    Pop.success('You updated your profile.')
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};
</script>


<style></style>
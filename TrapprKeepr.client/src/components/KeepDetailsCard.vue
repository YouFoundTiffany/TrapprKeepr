<template>
    <div class='container'>
        < class=''>
            Its a Modal!!! Yay!
            <!-- <img :src="keep.img" class="card-image rounded-top" keep.img> -->
            <!-- <h5 class="h5-over text-light d-flex ps-2 bg-transparent m-0 p-0">{{ keep.name }}</h5> -->
            <!-- FIXME POINTER ON PROF PIC -->
            <!-- <img :src="keep.creator.picture" :title="keep.creator.name" :alt="keep.creator.picture" class="profile-pic"> -->

            <!-- <VaultDropDown :vault in > -->
            <!-- STUB DropDown Users Vaults  -->



            <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton"
                    data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Dropdown button
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <a class="dropdown-item" href="#">Action</a>
                    <a class="dropdown-item" href="#">Another action</a>
                    <a class="dropdown-item" href="#">Something else here</a>
                </div>
            </div>
            </section>
    </div>
</template>
<script>
import VaultDropDown from './VaultDropDown.vue';

export default {
    setup() {
        // NOTE may not need this.
        // onMounted(() => {
        //     getProfileById();
        // })
        // async function getProfileById(profileId) {
        //     try {
        //         logger.log('profileId', route.params.profileId)
        //         // await profilesService.getProfileById(route.params.profileId)
        //     } catch (error) {
        //         Pop.error(error)
        //     }
        // }
        return {};
    },
    components: { VaultDropDown }
};
</script>


<style></style>
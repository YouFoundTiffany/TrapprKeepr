<!-- PROFILE PAGE -->
<!-- TODO MEDIA QUERY TO CENTER AND AJUST ON SMALL SCREENS -->
<template>
    <div v-if="keeps || vaults" class="about text-center">
        <div class="justify-content-center row d-flex">
            <img class="m-0 banner-image rounded" :src="account.coverImg" :alt="account.coverImg" />
        </div>
        <div class="justify-content-center d-flex">
            <img class="rounded elevation-2 avatar" :src="account.picture" :alt="account.picture" />
        </div>
        <h1>{{ account.name }}</h1>
        <p>TODO <span> 0</span> Vaults | 0 Keeps<span></span></p>
    </div>


    <h2 v-if="vault" class="card-title masonry-container">Vaults</h2>
    <section class="" v-for="vault in vaults" :key="vault.id">
        <VaultAccCard :vault="vault" />
    </section>

    <h2 v-if="keep" class="card-title masonry-container">Keeps</h2>
    <section class="" v-for="keep in keeps" :key="keep.id">
        <KeepAccCard :keep="keep" />
    </section>
</template>
<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';

export default {
    setup() {
        //     const route = useRoute()
        //     const profileId = route.params.profileId

        //     onMounted(() => {
        //         getProfileById();
        //     });
        return {
            // getProfileById(),
            // account: computed(() => AppState.account),
            // keeps: computed(() => AppState.keeps),
            // vaults: computed(() => AppState.vaults),
            // profile: computed(() => AppState.profiles),
        };
    },
};
</script>


<style></style>
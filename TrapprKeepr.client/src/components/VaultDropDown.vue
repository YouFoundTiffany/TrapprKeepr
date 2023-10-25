<template>
    <!-- <a class="dropdown-item" href="#">Action{{ vault.name }}</a> -->
    <!-- {{ vault.name }} -->
    Hello From the dropdown
</template>
<script>
import { Account } from '../models/Account';
import { Vault } from '../models/Vault.js';
export default {

    props: { vault: { type: Vault, required: true }, account: { type: Account, required: true }, profileVaults: { type: Vault, required: true } },
    setup() {





        return {};
    },
};
</script>
<style></style>
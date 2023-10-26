<!-- MODAL WRAPPER COMPONENT -->
<template>
    <!-- Modal Body -->
    <!-- if you want to close by clicking outside the modal, delete the last endpoint:data-bs-backdrop and data-bs-keyboard -->
    <!-- NOTE the id for this modal is passed using props, so the id can be specified by any component using it -->
    <div class="modal fade modal-xl" :id="id" tabindex="-1" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
        <!-- NOTE the size of this modal is also passed through props so you could create different sized modals, all with one modal wrapper -->
        <div :class="`modal-dialog modal-dialog-scrollable mod-hea modal-dialog-centered modal-xl`" role="document">
            <div class="modal-content mod-hea">

                <div class="modal-header">
                    <!-- NOTE slots here create spaces that can later be filled in depending on the use case -->
                    <!-- NOTE any content in between a the slot will be used as a default if one is not provided in when the wrapper is used -->
                    <slot name="header">
                        <!-- <div class="d-flex justify-content-end w-100"><i class="mdi mdi-close fs-3 selectable text-dark"
                                data-bs-dismiss="modal"></i></div> -->
                    </slot>
                </div>
                <div class="modal-body">
                    <!-- NOTE the name on the slots allow the creation of multiple slots to be created for one component -->
                    <slot name="body">
                    </slot>
                </div>
                <div class="modal-footer">
                    <slot name="footer">
                    </slot>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
// REVIEW this modal component is created using slots in the template and props in the script to allow re-use across the app. This keeps this component flexible for a variety of situations
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    // NOTE modal takes in a bool so the button can be used, and an id, so we can make each instance of the modal unique
    props: { id: { type: String, required: true }, size: { type: String, default: 'xl' } },
    setup() {
        return {
            keeps: computed(() => AppState.keeps),
            acccount: computed(() => AppState.account.id),
        }
    }
};
</script>


<style lang="scss" scoped></style>

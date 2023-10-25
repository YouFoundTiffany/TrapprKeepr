<!-- KEEP DETAILS MODAL VIEW COMPONENT -->
<template>
    <div v-if="keep" class="modal fade" :id="'details-modal-' + keep.id" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true" ref="myModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">{{ keep.name }}</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class='container'>
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row g-0">
                                <div class="col-md-4 keep-image-div">
                                    <img :src="keep.img" class="img-fluid rounded-start" :alt="keep.img">
                                </div>
                                <div class="col-md-8 keep-name-desc-div">
                                    <div class="card-body">
                                        <h5 class="card-title">{{ keep.name }}</h5>
                                        <p class="card-text">{{ keep.description }}.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button @click="closeModal" type=" button" class="btn btn-secondary"
                            data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { computed, onMounted, ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import { Modal } from 'bootstrap';

export default {
    props: {
        keep: {
            type: Object,
            required: true
        },
        showModal: Boolean
    },
    setup(props, { emit }) {
        const myModalRef = ref(null);
        let modalInstance = null;

        onMounted(() => {
            modalInstance = new Modal(myModalRef.value);
        });

        watchEffect(() => {
            if (props.keep && modalInstance) {
                modalInstance.show();
            } else if (!props.keep && modalInstance) {
                modalInstance.hide();
            }
        });

        const closeModal = () => {
            emit('close');
        };

        return {
            myModalRef,
            keeps: computed(() => AppState.keeps),
            closeModal
        };
    }
};
</script>

<style scoped>
/* Base Styles for Larger Screens */
/* .keep-image-div {
    flex-basis: 33.33333%;
    max-width: 33.33333%;
}

.keep-name-desc-div {
    flex-basis: 66.66667%;
    max-width: 66.66667%;
} */

/* mobile  */
@media (max-width: 576px) {

    .keep-image-div,
    .keep-name-desc-div {
        flex-basis: 100%;
        max-width: 100%;
    }

    /* test bottom margin as needed :D */
    .keep-image-div {
        margin-bottom: 15px;
    }
}
</style>
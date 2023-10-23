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
                                <div class="col-md-4">
                                    <img :src="keep.img" class="img-fluid rounded-start" alt="...">
                                </div>
                                <div class="col-md-8">
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
<style></style>
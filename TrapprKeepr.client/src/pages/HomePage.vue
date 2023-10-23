<template>
  <section class="container">
    <div class="row" data-masonry='{"percentPosition": true }'>
      <!-- STUB MASONRY ROW TAG -->
      <!-- STUB KEEPS VERTICAL CARD TEMPLATE -->
      <!-- STUB COLUMN 1 -->
      <div class="col-12 col-md-3">
        <KeepCard v-for="keep in keeps" :key="keep.id" :keep="keep" @click.native="handleKeepClick(keep)" />
        <!-- Modal
        <KeepDetailsModalView v-if="showModal" :keep="selectedKeep" @close="showModal = false" /> -->

        <!-- <KeepDetailsModalView /> -->
        <!-- test card vertical cards -->
        <div class="card mb-3 ">
          <img src="https://i.etsystatic.com/40931115/r/il/aa29a7/5040212059/il_1140xN.5040212059_lo5y.jpg"
            class="card-img-top mxht" alt="...">
          <div class="card-body">
            <h5 class="card-title">Card title</h5>
            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional
              content.
              This content is a little bit longer.</p>
            <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
          </div>
        </div>

        <!-- test card -->
      </div>
      <!-- STUB COLUMN 2 -->
      <div class="col-12 col-md-3"> <!-- test card -->
        <div class="card mb-3 ">
          <img src="https://i.etsystatic.com/40931115/r/il/aa29a7/5040212059/il_1140xN.5040212059_lo5y.jpg"
            class="card-img-top mxht" alt="...">
          <div class="card-body">
            <h5 class="card-title">Card title</h5>
            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional
              content.
              This content is a little bit longer.</p>
            <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
          </div>
        </div>
        <!-- test card -->
      </div>
      <!-- STUB COLUMN 3 -->
      <div class="col-12 col-md-3"> <!-- test card -->
        <div class="card mb-3 ">
          <img src="https://i.etsystatic.com/40931115/r/il/aa29a7/5040212059/il_1140xN.5040212059_lo5y.jpg"
            class="card-img-top mxht" alt="...">
          <div class="card-body">
            <h5 class="card-title">Card title</h5>
            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional
              content.
              This content is a little bit longer.</p>
            <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
          </div>
        </div>
        <!-- test card -->
      </div>
      <!-- STUB COLUMN 4 -->
      <div class="col-12 col-md-3">
        <!-- test card -->
        <div class="card mb-3 ">
          <img src="https://i.etsystatic.com/40931115/r/il/aa29a7/5040212059/il_1140xN.5040212059_lo5y.jpg"
            class="card-img-top mxht" alt="...">
          <div class="card-body">
            <h5 class="card-title">Card title</h5>
            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional
              content.
              This content is a little bit longer.</p>
            <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
          </div>
        </div>
        <!-- test card end -->
      </div>
    </div>
  </section>



  <!-- STUB Details Modal  -->
  <!-- STUB Button trigger modal -->
  <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
    Details
  </button> -->
  <!-- STUB Button trigger modal -->
  <!-- <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
    aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body"> -->

  <!-- STUB KEEPS DETAILS HORIZONTAL CARD TEMPLATE -->
  <!-- <div class="card mb-3" style="max-width: 540px;">
            <div class="row g-0">
              <div class="col-md-4">
                <img src="https://i.etsystatic.com/40931115/r/il/aa29a7/5040212059/il_1140xN.5040212059_lo5y.jpg"
                  class="img-fluid rounded-start" alt="...">
              </div>
              <div class="col-md-8">
                <div class="card-body">
                  <h5 class="card-title">Card title</h5>
                  <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional
                    content. This content is a little bit longer.</p>
                  <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
                </div>
              </div>
            </div>
          </div> -->
  <!-- STUB KEEPS DETAILS HORIZONTAL CARD TEMPLATE -->
  <!-- </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Understood</button>
        </div>
      </div>
    </div>
  </div> -->




  <!-- End of Card Template -->

  <!-- STUB Details Modal  -->
</template>
<script>
import { keepsService } from '../services/KeepsService.js'
import KeepDetailsModalView from '../components/KeepDetailsModalView.vue';
import KeepCard from '../components/KeepCard.vue';
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState';



export default {
  setup() {
    onMounted(() => { getKeeps(); });

    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      }
      catch (error) {
        Pop.error(error);
      }
    }

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      selectedKeep: null,
      showDetailsModal: false,

      selectKeep(keep) {
        this.selectedKeep = keep;
        this.showDetailsModal = true;
      },

    }
  },
  components: { KeepCard, KeepDetailsModalView }
}
</script>


<style>
.mxht {
  max-height: 15vh;
  width: auto;
  object-fit: contain;
  object-position: auto;
}
</style>


<!-- https://codepen.io/SteveJRobertson/pen/POdvgz  CARD LINK -->
<!-- https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_grid_layout/Masonry_layout Masonry Link -->
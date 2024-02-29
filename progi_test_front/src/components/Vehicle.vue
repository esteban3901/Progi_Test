<script setup>
import {endpointSettings} from '@/settings';
import {ref} from 'vue';
import axios from 'axios';

const selectedType = ref('');
const price = ref('');
const vehicles = ref([]);

const calculate = async () => {
  try {
    const requestData = {
      vehicle: {
        type: selectedType.value,
        basePrice: price.value
      }
    };
    console.log(requestData);
    const {data} = await axios.post(endpointSettings.BASE_URL + endpointSettings.VEHICLE_ENDPOINT, requestData);
    vehicles.value.push(data);
  } catch (error) {
    alert('Error calculating: ' + error);
  }
  selectedType.value = '';
  price.value = '';
};
</script>

<template>
  <div class="container">
    <div class="row">
      <form class="mb-3 row">
        <label for="price" class="col-sm-2 col-form-label">Vehicle Type</label>
        <div class="col-sm-3">
          <select v-model.number="selectedType" class="form-select form-select-lg col-md-4">
            <option disabled>Select an option</option>
            <option value="0">Common</option>
            <option value="1">Luxury</option>
          </select>
        </div>
        <label for="price" class="col-sm-2 col-form-label">Vehicle Price</label>
        <div class="col-sm-3">
          <input v-model.number="price" type="text" class="form-control" id="price" placeholder="0">
        </div>
        <div class="col-sm-2">
          <button @click.prevent="calculate" :disabled="!selectedType<0 || price < 1" class="btn btn-primary">
            Calculate
          </button>
        </div>
      </form>
    </div>

    <div class="row">
      <div class="col">
        <table v-if="vehicles.length>0" class="table table-striped" style="text-align: center">
          <thead>
          <tr>
            <th style="vertical-align: middle;" rowspan="2">Vehicle Price ($)</th>
            <th style="vertical-align: middle;" rowspan="2">Vehicle Type</th>
            <th style="vertical-align: middle;" colspan="4">Fees ($)</th>
            <th style="vertical-align: middle;" rowspan="2">Total ($)</th>
          </tr>
          <tr>
            <th>Basic</th>
            <th>Special</th>
            <th>Association</th>
            <th>Storage</th>
          </tr>
          </thead>
          <tbody v-if="vehicles.length>0" align="right">
          <tr v-for="vehicle in vehicles">
            <td>{{ vehicle.basePrice.toFixed(2) }}</td>
            <td align="center">{{ vehicle.type }}</td>
            <td v-for="fee in vehicle.fees" :key="fee.feeName">{{ fee.value.toFixed(2) }}</td>
            <td>{{ vehicle.total.toFixed(2) }}</td>
          </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>
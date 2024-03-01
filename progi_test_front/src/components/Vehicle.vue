<script setup>
import {endpointSettings} from '@/settings';
import {ref} from 'vue';
import axios from 'axios';

const selectedType = ref('');
const price = ref('');
const vehicle = ref(null);

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
    vehicle.value = data;
    //vehicles.value.push(data);
  } catch (error) {
    alert('Error calculating: ' + error);
  }
};

const onChange = () => {
  if (selectedType.value !== '' && price.value > 0) {
    calculate();
  }
};
</script>

<template>
  <div class="container">
    <div class="row">
      <form class="mb-3 row">
        <label for="price" class="col-sm-3 col-form-label">Vehicle Type</label>
        <div class="col-sm-3">
          <select v-model.number="selectedType" @change="onChange" class="form-select form-select-lg col-md-4">
            <option value="" disabled>Select an option</option>
            <option value="0">Common</option>
            <option value="1">Luxury</option>
          </select>
        </div>
        <label for="price" class="col-sm-3 col-form-label">Vehicle Price</label>
        <div class="col-sm-3">
          <input v-model.number="price" @keyup="onChange" type="number" class="form-control" id="price" placeholder="0">
        </div>
      </form>
    </div>

    <div class="row">
      <div class="col">
        <table v-if="vehicle != null" class="table table-striped" style="text-align: center">
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
          <tbody align="right">
          <tr>
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
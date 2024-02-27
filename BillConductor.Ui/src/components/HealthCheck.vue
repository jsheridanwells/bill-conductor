<script setup lang="ts">
import { HealthCheckStatus, useHealthCheckStore } from '@/stores/health-check'
import { ref } from 'vue'

const healthCheck = useHealthCheckStore()
const status = ref(HealthCheckStatus.Unknown)
let statusClass = 'unknown'
const statusLookup: { [key in HealthCheckStatus]: string } = {
  [HealthCheckStatus.Healthy]: 'healthy-status',
  [HealthCheckStatus.NotHealthy]: 'not-healthy-status',
  [HealthCheckStatus.Unknown]: 'unknown-status'
}

async function getHealthCheck() {
  const val = await healthCheck.getStatus()
  status.value = val;
  statusClass = statusLookup[val]
}
</script>

<template>
  <div class="health-check-container">
    <h1>Health Check</h1>

    <div class="button-container">
      <button class="material-button" @click="getHealthCheck">Get Health Status</button>
    </div>
    <div class="status-container">
      <h3 class="status-message">
        <div>Status:</div>
        <div :class="statusClass">
          {{ status }}
        </div>
      </h3>
    </div>
  </div>
</template>

<style scoped>
.health-check-container {
  display: flex;
  flex-direction: column;
}

.health-check-container div {
    margin: 1rem;
    padding: 1rem;
}

h3.status-message {
  display: flex;
  flex-direction: row;
}

.unknown-status {
  background-color: inherit;
}

.healthy-status {
  background-color: #41b883;
  color: black;
}

.not-healthy-status {
  background-color: rgb(206, 17, 17);
  color: #fff;
}

.button-container,
.status-container {
  margin: 1rem;
}

.material-button {
  display: inline-block;
  padding: 12px 24px;
  font-size: 16px;
  font-weight: 500;
  text-align: center;
  text-decoration: none;
  cursor: pointer;
  border: none;
  border-radius: 4px;
  overflow: hidden;
  position: relative;
  background-color: #41b883;
  color: #fff;
  transition: background-color 0.3s;
}

.material-button:hover {
  background-color: #34495e; /* Darker shade on hover */
}

/* Ripple Effect Animation */
.material-button::after {
  content: '';
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 0;
  height: 0;
  background-color: rgba(255, 255, 255, 0.6); /* Ripple color */
  border-radius: 50%;
  opacity: 0;
  pointer-events: none;
  transition:
    width 0.3s,
    height 0.3s,
    opacity 0.3s;
}

.material-button:hover::after {
  width: 200%;
  height: 200%;
  opacity: 1;
}
</style>

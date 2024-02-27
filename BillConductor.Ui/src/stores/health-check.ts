import { getHealthCheck, sendHealthCheckRequest } from '@/api/health-check-api'
import { defineStore } from 'pinia'

export enum HealthCheckStatus {
  Healthy = 'Healthy',
  NotHealthy = 'Not Healthy',
  Unknown = 'Unknown'
}

export const useHealthCheckStore = defineStore('healthCheck', () => {
  async function getStatus(): Promise<HealthCheckStatus> {
    try {
      const requestResult = await sendHealthCheckRequest(new Date())
      if (!requestResult.ok) {
        return HealthCheckStatus.NotHealthy
      }
      const requestResultBody = await requestResult.json()
      if (!requestResultBody?.uid) {
        return HealthCheckStatus.NotHealthy
      }

      const verifyResult = await getHealthCheck(requestResultBody.uid)
      if (!verifyResult.ok) {
        return HealthCheckStatus.NotHealthy
      }

      return HealthCheckStatus.Healthy
    } catch (ex) {
      return HealthCheckStatus.NotHealthy
    }
  }

  return { getStatus }
})

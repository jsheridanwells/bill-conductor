import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest'
import { setActivePinia, createPinia } from 'pinia'

import * as api from '@/api/health-check-api'
import { HealthCheckStatus, useHealthCheckStore } from '../health-check'

describe('useHealthCheck', () => {
  beforeEach(() => {
    setActivePinia(createPinia())
  })

  it('returns a Healthy status', async () => {
    // const spy = vi.spyOn(api, 'sendHealthCheckRequest');
    // spy.mockImplementation(async () => {
    //   return new Request()
    // });

    // TODO : plan is to have the api methods process the API response to something meaningful
    // for the store to use
    
    

    const sut = useHealthCheckStore();

    const result = await sut.getStatus();
    expect(result).toEqual(HealthCheckStatus.Healthy);
  })

  it('returns an Unhealthy status when request not ok', () => {})

  it('returns an Unhealthy status on errir', () => {})

  afterEach(() => {})
})

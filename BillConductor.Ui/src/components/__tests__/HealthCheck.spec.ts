import { mount, VueWrapper } from '@vue/test-utils'
import { describe, expect, it, vi, afterEach, beforeEach } from 'vitest'
import { createTestingPinia } from '@pinia/testing'

import { HealthCheckStatus, useHealthCheckStore } from '@/stores/health-check'
import HealthCheckVue from '../HealthCheck.vue'

// TODO : utility function for wrapper and store

describe('Health Check', () => {
  let wrapper: VueWrapper,
    store: any = null // TODO : add type

  beforeEach(() => {
    wrapper = mount(HealthCheckVue, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ]
      }
    })
    store = useHealthCheckStore()
  })

  it('renders', () => {
    expect(wrapper).toBeTruthy()
    expect(wrapper.text()).toContain('Health Check')
  })

  it('requests health check from store', () => {
    const btn = wrapper.find('button')
    btn.trigger('click')
    expect(store.getStatus).toHaveBeenCalled()
  })

  it('displays healthy status', async () => {
    const pinia = createTestingPinia({
      stubActions: false,
      createSpy: vi.fn
    })
    wrapper = mount(HealthCheckVue, {
      global: {
        plugins: [pinia]
      }
    })
    store = useHealthCheckStore(pinia)
    store.getStatus = vi.fn(() => HealthCheckStatus.Healthy)

    await wrapper.find('button').trigger('click')
    const statusEl = wrapper.find('.status-message div:nth-child(2)')
    
    expect(statusEl.text()).toContain('Healthy')
  })

  it('displays unhealthy status', async() => {
    const pinia = createTestingPinia({
      stubActions: false,
      createSpy: vi.fn
    })
    wrapper = mount(HealthCheckVue, {
      global: {
        plugins: [pinia]
      }
    })
    store = useHealthCheckStore(pinia)
    store.getStatus = vi.fn(() => HealthCheckStatus.NotHealthy)
    await wrapper.find('button').trigger('click')
    const statusEl = await wrapper.find('.status-message div:nth-child(2)')
    expect(statusEl.text()).toContain('Not Healthy')
  })

  afterEach(() => {
    if (wrapper) {
      wrapper.unmount()
    }
  })
})

export async function sendHealthCheckRequest(date: Date): Promise<Response> {
  const url = buildUrl();

  const uid = self.crypto.randomUUID()
  const response = await fetch(url, {
    method: 'POST',
    body: JSON.stringify({ date, uid })
  })

  return response
}

export async function getHealthCheck(uid: string): Promise<Response> {
  const url = buildUrl();
  return await fetch(`${url}?uid=${uid}`)
}

function buildUrl(): string {
  let host = import.meta.env.VITE_API_HOST
  if (import.meta.env.MODE === 'mock-api') {
    host = 'http://localhost:3000'
  }
  return host + import.meta.env.VITE_HEALTH_CHECK_PATH
}

import api from './api'

export const authService = {
  async register(data) {
    const response = await api.post('/auth/register', {
      username: data.username,
      displayName: data.displayName,
      email: data.email,
      password: data.password,
      theme: data.theme || 'dark'
    })
    return response.data
  },

  async login(data) {
    const response = await api.post('/auth/login', {
      username: data.username,
      password: data.password
    })
    return response.data
  },

  async getUsers() {
    const response = await api.get('/auth/users')
    return response.data
  },

  async updateTheme(theme) {
    const response = await api.put('/auth/theme', { theme })
    return response.data
  }
}

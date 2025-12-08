import axios from 'axios'

const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5000'

const api = axios.create({
  baseURL: `${API_URL}/api`,
  headers: {
    'Content-Type': 'application/json'
  }
})

// Request interceptor - her istekte token ekle
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token')
    if (token) {
      config.headers.Authorization = `Bearer ${token}`
    }
    console.log('🌐 Axios request:', {
      method: config.method,
      url: config.url,
      baseURL: config.baseURL,
      fullURL: `${config.baseURL}${config.url}`,
      data: config.data,
      headers: config.headers
    })
    return config
  },
  (error) => {
    return Promise.reject(error)
  }
)

// Response interceptor - hataları yakala
api.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error('API Error:', error.response?.data || error.message)

    // Extract error message from response
    const responseData = error.response?.data
    let errorMessage = 'Bir hata oluştu'

    if (responseData) {
      // Handle our standard ApiResponse format
      if (responseData.error?.message) {
        errorMessage = responseData.error.message
      }
      // Handle direct message in response
      else if (responseData.message) {
        errorMessage = responseData.message
      }
      // Handle string response
      else if (typeof responseData === 'string') {
        errorMessage = responseData
      }
    }

    // Create a new error with the extracted message
    const enhancedError = new Error(errorMessage)
    enhancedError.response = error.response
    enhancedError.originalError = error

    return Promise.reject(enhancedError)
  }
)

export default api

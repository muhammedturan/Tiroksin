<template>
  <div style="min-height: calc(100vh - 80px); display: flex; align-items: center; justify-content: center; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 2rem;">
    <div style="background: white; border-radius: 12px; padding: 3rem; width: 100%; max-width: 500px; box-shadow: 0 20px 60px rgba(0,0,0,0.3);">
      <div style="text-align: center; margin-bottom: 2rem;">
        <h1 style="font-size: 2rem; margin-bottom: 0.5rem; color: #333;">🧬 Tiroksin'a Katıl</h1>
        <p style="color: #666; font-size: 0.95rem;">Hesap oluştur ve sınavlara başla</p>
      </div>

      <form @submit.prevent="handleRegister">
        <div style="margin-bottom: 1.25rem;">
          <label style="display: block; margin-bottom: 0.5rem; font-weight: 500; color: #333;">Kullanıcı Adı</label>
          <input
            v-model="form.username"
            type="text"
            required
            style="width: 100%; padding: 0.875rem; border: 2px solid #e0e0e0; border-radius: 8px; font-size: 1rem; box-sizing: border-box; transition: border-color 0.2s;"
            @focus="$event.target.style.borderColor = '#667eea'"
            @blur="$event.target.style.borderColor = '#e0e0e0'"
            placeholder="kullaniciadi"
          />
        </div>

        <div style="margin-bottom: 1.25rem;">
          <label style="display: block; margin-bottom: 0.5rem; font-weight: 500; color: #333;">Email</label>
          <input
            v-model="form.email"
            type="email"
            required
            style="width: 100%; padding: 0.875rem; border: 2px solid #e0e0e0; border-radius: 8px; font-size: 1rem; box-sizing: border-box; transition: border-color 0.2s;"
            @focus="$event.target.style.borderColor = '#667eea'"
            @blur="$event.target.style.borderColor = '#e0e0e0'"
            placeholder="ornek@email.com"
          />
        </div>

        <div style="margin-bottom: 1.25rem;">
          <label style="display: block; margin-bottom: 0.5rem; font-weight: 500; color: #333;">Ad Soyad</label>
          <input
            v-model="form.displayName"
            type="text"
            required
            style="width: 100%; padding: 0.875rem; border: 2px solid #e0e0e0; border-radius: 8px; font-size: 1rem; box-sizing: border-box; transition: border-color 0.2s;"
            @focus="$event.target.style.borderColor = '#667eea'"
            @blur="$event.target.style.borderColor = '#e0e0e0'"
            placeholder="Adınız Soyadınız"
          />
        </div>

        <div style="margin-bottom: 1.25rem;">
          <label style="display: block; margin-bottom: 0.5rem; font-weight: 500; color: #333;">Şifre</label>
          <input
            v-model="form.password"
            type="password"
            required
            minlength="6"
            style="width: 100%; padding: 0.875rem; border: 2px solid #e0e0e0; border-radius: 8px; font-size: 1rem; box-sizing: border-box; transition: border-color 0.2s;"
            @focus="$event.target.style.borderColor = '#667eea'"
            @blur="$event.target.style.borderColor = '#e0e0e0'"
            placeholder="En az 6 karakter"
          />
        </div>

        <div style="margin-bottom: 1.25rem;">
          <label style="display: block; margin-bottom: 0.5rem; font-weight: 500; color: #333;">Şifre (Tekrar)</label>
          <input
            v-model="form.confirmPassword"
            type="password"
            required
            minlength="6"
            style="width: 100%; padding: 0.875rem; border: 2px solid #e0e0e0; border-radius: 8px; font-size: 1rem; box-sizing: border-box; transition: border-color 0.2s;"
            @focus="$event.target.style.borderColor = '#667eea'"
            @blur="$event.target.style.borderColor = '#e0e0e0'"
            placeholder="Şifrenizi tekrar girin"
          />
        </div>

        <button
          type="submit"
          :disabled="loading"
          style="width: 100%; padding: 1rem; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; border: none; border-radius: 8px; font-size: 1.1rem; font-weight: 600; cursor: pointer; transition: transform 0.2s, box-shadow 0.2s;"
          @mouseover="$event.target.style.transform = 'translateY(-2px)'; $event.target.style.boxShadow = '0 8px 20px rgba(102, 126, 234, 0.4)'"
          @mouseleave="$event.target.style.transform = 'translateY(0)'; $event.target.style.boxShadow = 'none'"
        >
          {{ loading ? 'Kaydediliyor...' : 'Hesap Oluştur' }}
        </button>
      </form>

      <div style="text-align: center; margin-top: 1.5rem; color: #666; font-size: 0.95rem;">
        Zaten hesabın var mı?
        <router-link to="/" style="color: #667eea; font-weight: 600; text-decoration: none;">Giriş Yap</router-link>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import api from '../services/api'

const router = useRouter()
const loading = ref(false)
const form = ref({
  username: '',
  email: '',
  displayName: '',
  password: '',
  confirmPassword: ''
})

const handleRegister = async () => {
  // Şifre kontrolü
  if (form.value.password !== form.value.confirmPassword) {
    alert('Şifreler eşleşmiyor!')
    return
  }

  if (form.value.password.length < 6) {
    alert('Şifre en az 6 karakter olmalıdır!')
    return
  }

  try {
    loading.value = true

    const response = await api.post('/auth/register', {
      username: form.value.username,
      email: form.value.email,
      displayName: form.value.displayName,
      password: form.value.password
    })

    // Token'ı localStorage'a kaydet
    localStorage.setItem('token', response.data.token)
    localStorage.setItem('user', JSON.stringify(response.data))

    // Başarılı mesajı
    alert(`Hoş geldin, ${response.data.displayName}! Hesabın oluşturuldu.`)

    // Ana sayfaya yönlendir
    router.push('/')
  } catch (error) {
    const errorMessage = error.response?.data?.error || 'Kayıt başarısız oldu'
    alert(errorMessage)
  } finally {
    loading.value = false
  }
}
</script>

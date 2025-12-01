import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Lobby from '../views/Lobby.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    meta: { requiresAuth: true }
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('../components/Login.vue')
  },
  {
    path: '/lobby',
    name: 'Lobby',
    component: Lobby,
    meta: { requiresAuth: true }
  },
  {
    path: '/room/:id',
    name: 'Room',
    component: () => import('../views/RoomWaiting.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/game/:sessionId',
    name: 'Game',
    component: () => import('../views/GameArena.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/game-result/:sessionId',
    name: 'GameResult',
    component: () => import('../views/GameResult.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/game-spectator/:sessionId',
    name: 'GameSpectator',
    component: () => import('../views/GameSpectator.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/create-question',
    name: 'CreateQuestion',
    component: () => import('../views/CreateQuestion.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/question/:id',
    name: 'QuestionPreview',
    component: () => import('../views/QuestionPreview.vue'),
    meta: { requiresAuth: true }
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

// Navigation guard for authentication
router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('token')
  const requiresAuth = to.matched.some(record => record.meta.requiresAuth)

  if (requiresAuth && !token) {
    next('/login')
  } else if (to.path === '/login' && token) {
    next('/')
  } else {
    next()
  }
})

export default router

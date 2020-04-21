import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

import Login from '../views/Login.vue'
import profile_index from '../views/profile/profile_index.vue'


Vue.use(VueRouter)

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/login', name: 'Login', component: Login },
  { path: '/profile/profile_index', name: 'profile_index', component: profile_index },

]

const router = new VueRouter({
  routes 
})

export default router

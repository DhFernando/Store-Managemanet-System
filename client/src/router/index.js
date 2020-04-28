import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

import registration from '../views/Registration.vue'
import profile_index from '../views/profile/profile_index.vue'
import administration_index from '../views/Administration/Administration_index.vue'


Vue.use(VueRouter)

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/registration', name: 'Login', component: registration },
  { path: '/profile/profile_index', name: 'profile_index', component: profile_index },
  { path: '/Administration/Administration_index', name: 'Administration_index', component: administration_index },

]

const router = new VueRouter({
  routes 
})

export default router

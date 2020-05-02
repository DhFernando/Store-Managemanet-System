import Vue from 'vue'
import VueRouter from 'vue-router'

import Home from '../views/Home.vue'
import Registration from '../views/Registration.vue'
import profile_index from '../views/profile/profile_index.vue'
import Template from '../views/Administration/Users/Template.vue'

Vue.use(VueRouter)

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/Registration', name: 'Registration', component: Registration },
  { path: '/profile/profile_index', name: 'profile_index', component: profile_index },
 
  { path: '/Administration/User/', name: 'Template', component: Template },

]

const router = new VueRouter({
  routes 
})

export default router

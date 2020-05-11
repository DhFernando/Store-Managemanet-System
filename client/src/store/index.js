import Vue from 'vue'
import Vuex from 'vuex'
import UserManagement from './modules/UserManagement';
import AdvertistmentManagement from './modules/AdvertistmentManagement';

Vue.use(Vuex)

export default new Vuex.Store({
  modules:{
    UserManagement,
    AdvertistmentManagement
  }
})

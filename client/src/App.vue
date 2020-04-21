<template>
  <v-app>
    <Header></Header>
    <v-content>
      <router-view></router-view>
      {{test}}
    </v-content>
    
  </v-app>
</template>

<script>
import Header from './components/layout/Header'

export default {
  name: 'App',
  created(){
    if(this.$store.getters.LogedIn != null){
      this.$store.dispatch("GetProfile")
    }
  },

  components: {
    Header
  },

  data: () => ({
    test:""
  }),
};
</script>

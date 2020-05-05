<template>
  <v-app>
    <Header></Header>
    <v-content>
      <router-view></router-view>
     
    </v-content>

  </v-app>
</template>

<script>
import Header from './components/layout/Header'

export default {
  name: 'App',
  created(){
    if(this.$store.getters.LogedInCheck != null){
      this.$store.dispatch("GetProfile")
    }
  },
  
  components: {
    Header
  },

  data: () => ({

  }),
};
</script>

<template>
    <v-app-bar app color="primary" dark >
      <div class="d-flex align-center">
       
        <h2>Vue ASP.Net Core EMS</h2>
      </div>
      <v-btn class="ml-5 " text  href="/">Home</v-btn>
      <v-spacer></v-spacer>
      
      <v-btn to="/login" text>
        <span class="mr-2">Login</span>
        <v-icon>mdi-lock</v-icon>
      </v-btn>
      {{userLogedIn }} {{ test }}
    </v-app-bar>

    
</template>

<script>
// import axios from "axios";
export default {
    name:'Header',
    computed : {
      userLogedIn() { return this.$store.getters.userLogedIn },
      test(){
        if(this.userLogedIn == true){return 1;}
        else{ return 0 }
      },
     
    }
}
</script>

<style>

</style>
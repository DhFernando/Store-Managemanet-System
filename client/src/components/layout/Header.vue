<template>
    <v-app-bar app color="primary" dark >
      <div class="d-flex align-center">
       
        <h2>DH Store</h2>
      </div>
      <v-btn class="ml-5 " text  to="/">Home</v-btn>
      <v-btn class="ml-5 " text  to="/Advertistment">Advertistment</v-btn>
      <v-btn class="ml-5 " text  to="/profile/profile_index">Profile</v-btn>
  

      <v-menu left bottom >
        <template v-slot:activator="{ on }">
          <v-btn  text v-on="on">
            Administration <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item  to="/Administration/User/" >
            <v-list-item-title>Users</v-list-item-title>
          </v-list-item>
          <v-list-item to="/Administration/Advertistment/" >
            <v-list-item-title>Advertistment</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <v-spacer></v-spacer>
      
      <v-btn v-show="!LogedIn" to="/Login" text>
        <span class="mr-2">Login</span>
        <v-icon>mdi-lock</v-icon>
      </v-btn>
      <v-btn v-show="!LogedIn" to="/Registration" text>
        <span class="mr-2">Register</span>
        <v-icon>mdi-lock</v-icon>
      </v-btn>
      <v-btn color="yellow" v-show="LogedIn" text>
        <v-icon>mdi-cart</v-icon>
        <span class="ml-2">Rs {{Total}}</span>
      </v-btn>
      <v-btn v-show="LogedIn" @click="DestroyToken" text>
        <span class="mr-2">LogOut</span>
        <v-icon>mdi-lock</v-icon>
      </v-btn>

    </v-app-bar>

    
</template>

<script>
// import axios from "axios";
export default {
    name:'Header',
    
    computed:{
      LogedIn(){
        return this.$store.getters.LogedInCheck
      },
      Total(){
        return this.$store.getters.Total
      }
    },
    methods:{
      DestroyToken:function(){
        this.$store.dispatch("DestroyToken")
        .then(res =>{
          if(res != null){
            this.$router.push({ name : "Home" })
          }
        })
      }
    }
}
</script>

<style>

</style>
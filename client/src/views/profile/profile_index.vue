<template>
  <div>
      <v-container>
        

       
      <v-card class="mx-auto" max-width="400" >
        <v-img class="white--text align-end" height="200px" src="" ></v-img>
        <hr color="grey ">
        <v-card-title>{{userProfile.userName}}</v-card-title>
        <v-card-subtitle class="pb-0">( {{ userProfile.id }} )</v-card-subtitle>

        <v-card-text class="text--primary mt-6">
          <div>Email : {{ userProfile.email }}</div>
          <div>Adress : {{ userProfile.address }}</div>
          <div>Designation : {{ userProfile.designation }}</div>
        </v-card-text>
        

        <v-card-actions>
         
          <v-btn color="primary" tile outlined > Edit </v-btn>
        </v-card-actions>
      </v-card>


      </v-container>
  </div>
</template>

<script>
export default {
    name:'profile_index',
    data(){
      return{
          
      }
    },
    created(){
      
    },
    computed: {
      userProfile(){ return this.$store.getters.userProfile}
    },
}
</script>

<style>

</style>
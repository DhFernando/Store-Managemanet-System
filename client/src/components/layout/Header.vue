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
      
    </v-app-bar>

    
</template>

<script>
export default {
    name:'Header'
}
</script>

<style>

</style>
<template>
    <v-app-bar app color="primary" dark >
      <div class="d-flex align-center">
       
        <h2>test</h2>
      </div>

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
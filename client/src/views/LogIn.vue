<template>
    <div class="mt-5">
        <v-container class="fill-height " fluid >
        <v-row align="center" justify="center" >
          <v-col cols="12" sm="8" md="4" >
            <v-card class="elevation-12">
              <v-toolbar color="primary" dark flat>
                <v-toolbar-title>Login Form</v-toolbar-title>
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field v-model="LoginData.Email"  label="Email"   type="text" /> 
                 
                  
                  <v-text-field v-model="LoginData.Password"  label="Password"   type="password" /> 
                  
                 </v-form>
            
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary" @click="Login()">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
   </div>
</template>


<script>

export default {
    name:'Login',
    data(){
      return{
        LoginData : {
          Email:"",
        
          Password:"",
         
          TokenAvailable:localStorage.getItem("access_token") || "null"
         }
         
      }
    },
    methods:{
   
      Login: function(){
        const _LoginData = this.LoginData
  
       
          this.$store.dispatch('Login' , _LoginData )
          .then( res => {
            if(res != null){
              this.$router.push({ name : "Home" })
            }
          })
        
      }

    },
    created(){
      if(localStorage.getItem("access_token") != null){
        alert('you online')
        this.$router.push({path:'/'})
      }
    }
}
</script>

<style>

</style>
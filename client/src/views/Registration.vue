<template>
    <div class="mt-5">
        <v-container class="fill-height " fluid >
        <v-row align="center" justify="center" >
          <v-col cols="12" sm="8" md="4" >
            <v-card class="elevation-12">
              <v-toolbar color="primary" dark flat>
                <v-toolbar-title>Register Form</v-toolbar-title>
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field v-model="RegistrationData.Email"  label="Email"   type="text" /> 
                  <v-text-field v-model="RegistrationData.Address"  label="Address"   type="text" /> 
                  <v-select class="mt-4"  :items="Designations" v-model="RegistrationData.Designation"  label="Designation" dense ></v-select> 
                  <v-text-field v-model="RegistrationData.Password"  label="Password"   type="password" /> 
                  <v-text-field v-model="RegistrationData.ConfirmPassword"  label="Confirm Password"   type="password" /> 
                 </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary" @click="Registration()">Register</v-btn>
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
        RegistrationData : {
          Email:"",
          Address:"",
          Designations:"",
          Password:"",
          ConfirmPassword:"",
          TokenAvailable:localStorage.getItem("access_token") || "null"
         },
         Designations: ['Customer', 'Manager', 'Supervisor', 'CEO' , 'Salesman']
      }
    },
    methods:{
   
      Registration: function(){
        var _RegistrationData = this.RegistrationData
      
        if(this.AccountRegistrationData.Password == this.RegistrationData.ConfirmPassword ){
          this.$store.dispatch('Registration' , _RegistrationData )
          .then( res => {
            if(res != null){
              this.$router.push({ name : "Home" })
            }
          })
          
        }else{ 
          alert("Password Not Match") 
        }
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
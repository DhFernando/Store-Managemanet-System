<template>
  <div>
      
      <v-toolbar color="primary" dark flat>
        <v-toolbar-title>Register new user </v-toolbar-title>
      </v-toolbar>
      <v-card-text>
        <v-form>
          <v-text-field v-model="AccountRegistrationData.Email"  label="Email"   type="text" /> 
          <v-text-field v-model="AccountRegistrationData.Address"  label="Address"   type="text" />
          <v-select class="mt-4"  :items="Designations" v-model="AccountRegistrationData.Designation"  label="Designation" dense ></v-select> 
          <v-text-field v-model="AccountRegistrationData.Password"  label="Password"   type="password" /> 
          <v-text-field v-model="AccountRegistrationData.ConfirmPassword"  label="Confirm Password"   type="password" /> 
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="primary" @click="AccountRegistrationDataSend()">Register</v-btn>
      </v-card-actions>
          
  </div>
</template>

<script>

export default {
    name:'Login',
    data(){
      return{
        AccountRegistrationData : {
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
    computed:{
      
    },
    methods:{
   
      AccountRegistrationDataSend: function(){
        var _AccountRegistrationData = this.AccountRegistrationData
      
        if(this.AccountRegistrationData.Password == this.AccountRegistrationData.ConfirmPassword ){
          this.$store.dispatch('AccountRegistrationDataSend' , _AccountRegistrationData )
          .then( response => {
            if(response != null){
              this.$store.dispatch("getApplicationUsers")
            }
          })
          
        }else{ 
          alert("Password Not Match") 
        }
      }

    }
}
</script>

<style>

</style>
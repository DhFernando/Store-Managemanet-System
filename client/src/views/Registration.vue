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
    methods:{
   
      AccountRegistrationDataSend: function(){
        var _AccountRegistrationData = this.AccountRegistrationData
      
        if(this.AccountRegistrationData.Password == this.AccountRegistrationData.ConfirmPassword ){
          this.$store.dispatch('AccountRegistrationDataSend' , _AccountRegistrationData )
          .then( res => {
            if(res != null){
              this.$router.push({ name : "Home" })
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
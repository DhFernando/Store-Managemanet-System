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
                  <v-text-field v-model="AccountRegistrationData.Password"  label="Password"   type="password" /> 
                  <v-text-field v-model="AccountRegistrationData.ConfirmPassword"  label="Confirm Password"   type="password" /> 
                 </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary" @click="AccountRegistrationDataSend()">Login</v-btn>
               
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
      
      {{(AccountRegistrationData)}}
    </div>
</template>


<script>
import axios from "axios";
export default {
    name:'Login',
    data(){
      return{
        AccountRegistrationData : {
          Email:"",
          Password:"",
          ConfirmPassword:"",
          
        },
      
      }
    },
    methods:{
   
      AccountRegistrationDataSend: function(){
        var _AccountRegistrationData = this.AccountRegistrationData
        if(this.AccountRegistrationData.Password == this.AccountRegistrationData.ConfirmPassword ){
        
          
          
            axios.post("https://localhost:44361/account/Register", {
              Email:_AccountRegistrationData.Email,
              Password:_AccountRegistrationData.Password,
              ConfirmPassword:_AccountRegistrationData.ConfirmPassword
            }).then(res => {
              if(res.data != null ){ 
                // state.userLogedIn = true
                alert(res.data)
              }
            })
         

        }else{ alert("Password Not Match") }
      }
    }
}
</script>

<style>

</style>
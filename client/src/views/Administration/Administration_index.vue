<template>
  <div>
    <v-container>
      <v-row>
        <v-col  cols="12">
            <div>
              <v-btn class="ml-5 " text @click="GoTo('Administration_ApplicationUser')" >User Management</v-btn> |
              <v-btn class="ml-5 " text @click="GoTo('Administration_role')">Role Management</v-btn> |
              <v-btn class="ml-5 " text @click.stop="dialog = true" >Add User</v-btn>
            </div>
            <hr />
        </v-col>
      </v-row>
      <v-row v-show="where == 'Administration_ApplicationUser' ">
        <v-col cols="12">
          <AdministrationApplicationUser ></AdministrationApplicationUser>
        </v-col>
      </v-row>
      <v-row v-show="where == 'Administration_role' ">
        <v-col  cols="12">
          <AdministrationRole ></AdministrationRole>
        </v-col>
      </v-row>
      <v-row >
        <!-- ----------------------------------------------------------------------------------------- -->
          <v-dialog v-model="dialog"  max-width="590" >
            <v-card>
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
            </v-card>
          </v-dialog>
          
        <!-- ----------------------------------------------------------------------------------------- -->
      </v-row>
      
    </v-container>
   
  </div>
</template>

<script>
import AdministrationApplicationUser from './AdministrationComponents/Administration_ApplicationUser.vue'
import AdministrationRole from './AdministrationComponents/Administration_role.vue'


export default {
    name:'Administration_index',
    data(){
      return{
           where:'Administration_ApplicationUser',
           dialog:false,
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
    components: {
      AdministrationApplicationUser,
      AdministrationRole,
      
    },
    created(){
      
    },
    computed: {
      
    },
    methods:{
     GoTo:function(_where){  this.where = _where  },
     AccountRegistrationDataSend: function(){
      
        var _AccountRegistrationData = this.AccountRegistrationData
      
        if(this.AccountRegistrationData.Password == this.AccountRegistrationData.ConfirmPassword ){
          this.$store.dispatch('AccountRegistrationDataSend' , _AccountRegistrationData )
          .then( response => {
            if(response != null){
              this.$store.dispatch("getApplicationUsers").then(()=>{
                  this.dialog=false
              })
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
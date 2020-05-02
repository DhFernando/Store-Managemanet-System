<template>
  <div>
    <v-container>
      <v-row>
        <v-col  cols="12">
            <div>
              <v-btn class="ml-5 " text @click="GoTo('ApplicationUser')" >Users</v-btn> |
              <v-btn class="ml-5 " text @click="GoTo('Role')">Role</v-btn> |
              <v-btn class="ml-5 " text @click.stop="dialog = true" >Add User</v-btn>
            </div>
            <hr />
        </v-col>
      </v-row>
      <v-row v-show="where == 'ApplicationUser' ">
        <v-col cols="12">
          <ApplicationUser ></ApplicationUser>
        </v-col>
      </v-row>
      <v-row v-show="where == 'Role' ">
        <v-col  cols="12">
          <Role ></Role>
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
          </v-dialog>
          
        <!-- ----------------------------------------------------------------------------------------- -->
      </v-row>
      
    </v-container>
   
  </div>
</template>

<script>
import ApplicationUser from './ApplicationUser.vue'
import Role from './Role.vue'


export default {
    name:'Template',
    data(){
      return{
           where:'ApplicationUser',
           dialog:false,
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
    components: {
      ApplicationUser,
      Role,
      
    },
    created(){
      
    },
    computed: {
      
    },
    methods:{
     GoTo:function(_where){  this.where = _where  },
     Registration: function(){
      
        var _RegistrationData = this.RegistrationData
      
        if(this.RegistrationData.Password == this.RegistrationData.ConfirmPassword ){
          this.$store.dispatch('Registration' , _RegistrationData )
          .then( response => {
            if(response != null){
              this.$store.dispatch("GetUsers").then(()=>{
                  this.dialog=false
              })
            }
          })
          
        }else{ 
          alert("Password and Confirmed Password Not Match") 
        }
      }
    }
}
</script>

<style>

</style>
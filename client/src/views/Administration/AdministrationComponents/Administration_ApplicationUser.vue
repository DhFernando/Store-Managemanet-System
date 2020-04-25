<template>
  <div>
    <v-container>
        <v-row >
          <v-col :cols="12">
                <v-row><h4>Employee List</h4></v-row>
                <v-row>
                  <v-col :cols="12">
                      <v-simple-table fixed-header height="300px">
                        <template v-slot:default>
                          <thead>
                            <tr>
                              <th class="text-left">#</th>
                              <th class="text-left">userName</th>
                              
                              <th class="text-left">email</th>
                             
                              <th class="text-left">Action</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr v-for="ApplicationUser in ApplicationUsers" :key="ApplicationUser.id" >
                              <td>{{ApplicationUser.id}}</td>
                              <td>{{ApplicationUser.userName}}</td>
                              <td>{{ApplicationUser.email}}</td>
                              
                              <td>
                                <v-icon @click="deleteApplicationUser(ApplicationUser.id)" color="error">mdi-delete-forever</v-icon> |
                                <v-icon color="blue" @click.stop="dialog = true" @click="getApplicationUser(ApplicationUser.id)">mdi-file-find</v-icon> |
                                <v-icon color="green" @click="editEmployee(Employee.id)">mdi-account-edit</v-icon>
                               </td>
                            </tr>
                          </tbody>
                        </template>
                      </v-simple-table>
                  </v-col>
                </v-row>
            </v-col>  
        </v-row>
        <v-row>
          <v-col cols="12">
            
          </v-col>
        </v-row>

        <!-- ---------------------------------------------------- -->
        <v-dialog v-model="dialog"  max-width="590" >
          <v-card>
              <v-card-title class="headline"> 
                {{ApplicationUser.userName}}  # <v-btn color="primary" @click.stop="dialog2 = true" @click="GetUserRoles(ApplicationUser.id)" class="ml-12" tile >Edit Role</v-btn> 
              </v-card-title>
              <hr>
              <v-card-text class="py-4">
                  <v-form ref="form">
                      <v-text-field label="User Id" required disabled v-model="ApplicationUser.id" ></v-text-field>
                      <v-text-field  required label="User Name"  v-model="ApplicationUser.userName"></v-text-field>
                      <v-text-field  label="Email" required v-model="ApplicationUser.email"></v-text-field>
                      
                      <v-btn color="primary" class="mr-4"  > Edit ApplicationUser </v-btn>
                      <v-btn color="error" class="mr-2" @click.stop="dialog = !true">Cancle</v-btn>
                    </v-form>
              </v-card-text>
          </v-card>
        </v-dialog>
        <!-- ---------------------------------------------------- -->

        <!-- ---------------------------------------------------- -->
        <v-dialog v-model="dialog2"  max-width="590" >
          <v-card>
              <v-card-title class="headline"> 
                {{ApplicationUser.userName}}  #  
              </v-card-title>
              <hr>
              <v-card-text class="py-4">
                  <v-row><h4>Employee List</h4></v-row>
                  <v-row>
                    <v-col :cols="12">
                        <v-simple-table fixed-header >
                          <template v-slot:default>
                            <thead>
                              <tr>
                                <th v-for="UserRole in UserRoles" :key="UserRole.id" class="text-left">
                                  {{UserRole.role.name}}
                                </th>
                              </tr>
                            </thead>
                            <tbody>
                              <tr>
                                <td v-for="UserRole in UserRoles" :key="UserRole.id" >
                                   <v-checkbox v-model="UserRole.roleIsAssign"></v-checkbox>
                                </td>
                              </tr>
                            </tbody>
                          </template>
                        </v-simple-table>
                    </v-col>
                  </v-row>
                  
                  <v-btn color="primary" class="mr-4" @click="UpdateUserRoles()" > Update Role </v-btn>
                  <v-btn color="error" class="mr-2" @click.stop="dialog = true" @click="dialog2 = !true">Cancle</v-btn>
                    
              </v-card-text>
          </v-card>
        </v-dialog>
        <!-- ---------------------------------------------------- -->

{{UserRoles}}
        
    </v-container>
  </div>
</template>

<script>
// import axios from "axios";
export default {
    name:'Administration_index',
    data(){
      return{
        dialog: false,
        dialog2: false,
        ApplicationUsers : [],
        ApplicationUser:{
          id:null,
          userName:null,
          email:null
        },
        UserRoles:[]
         
      }
    },
    components: {
     
    },
    created(){
      this.$store.dispatch("getApplicationUsers")
      .then(res =>{
        if(res != null){
          this.ApplicationUsers = this.$store.getters.ApplicationUsers
        }
      })
    },
    computed: {
      
    },
    methods:{
      getApplicationUser:function(ApplicationUser_id){
        this.$store.dispatch("getApplicationUser",ApplicationUser_id).then((res)=>{
          if(res != null){
            this.ApplicationUser.id = this.$store.getters.ApplicationUser.id
            this.ApplicationUser.userName = this.$store.getters.ApplicationUser.userName
            this.ApplicationUser.email = this.$store.getters.ApplicationUser.email
          }
        })
      },

      deleteApplicationUser:function(ApplicationUser_id){
        this.$store.dispatch("deleteApplicationUser",ApplicationUser_id)
        .then(res=>{
          if(res != null){
            this.$store.dispatch("getApplicationUsers")
            .then(res =>{
              if(res != null){
                this.ApplicationUsers = this.$store.getters.ApplicationUsers
              }
            })
          }
        })
      },
      GetUserRoles(ApplicationUser_id){
        this.dialog = false
        this.$store.dispatch("GetUserRoles",ApplicationUser_id)
        .then(res =>{
          if(res != null){
            this.UserRoles = this.$store.getters.UserRoles
          }
        })
      },
      UpdateUserRoles(){
        var _userRoles = this.UserRoles
        this.$store.dispatch("UpdateUserRoles",_userRoles)
      }
    }
}
</script>

<style>

</style>
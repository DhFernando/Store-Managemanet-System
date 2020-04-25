<template>
  <div class="home">
    <v-container>
      <v-row>
        <v-col :cols="12">
          <v-row>
            <v-col :cols="8">
                <v-row><h4>Employee List</h4></v-row>
                <v-row>
                  <v-col :cols="12">
                      <v-simple-table fixed-header height="300px">
                        <template v-slot:default>
                          <thead>
                            <tr>
                              <th class="text-left">#</th>
                              <th class="text-left">Name</th>
                              <th class="text-left">Address</th>
                              <th class="text-left">BirthDay</th>
                              <th class="text-left">Department</th>
                              <th class="text-left">Action</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr v-for="Employee in getAllEmployee" :key="Employee.id">
                              <td>{{ Employee.id }} {{ typeof(Employee.id) }} </td>
                              <td>{{ Employee.name }}</td>
                              <td>{{ Employee.address }}</td>
                              <td>{{ Employee.birthDay }}</td>
                              <td>{{ Employee.department }}</td>
                              <td>
                                <v-icon @click="deleteEmployee(Employee.id)" color="error">mdi-delete-forever</v-icon>
                            
                                |
                                <v-icon color="blue" @click.stop="dialog = true" @click="getEmployee(Employee.id)">mdi-file-find</v-icon> |
                                <v-icon color="green" @click="editEmployee(Employee.id)">mdi-account-edit</v-icon>
                               </td>
                            </tr>
                          </tbody>
                        </template>
                      </v-simple-table>
                  </v-col>
                </v-row>
            </v-col>
            <v-col :cols="4">
              <v-row><h4>Add Employee</h4></v-row>
                <v-row>
                  <v-col :cols="12">
                    <v-form ref="form">
                      <v-text-field v-model="newEmployee.Name" required label="Name" ></v-text-field>
                      <v-text-field v-model="newEmployee.Address" label="Address" required ></v-text-field>
                      
                      <v-text-field v-model="newEmployee.Department" label="Department" required ></v-text-field>

                      <v-btn color="primary" class="mr-4" @click="getNewEmployee" > Add Employee </v-btn>
                      <v-btn color="error" > Cancle </v-btn>
                    </v-form>
                  </v-col>
                </v-row>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
      
      <!-- --------  dialog  ---------- -->

      <v-dialog v-model="dialog"  max-width="590" >
          <v-card>
              <v-card-title class="headline"> Edit  {{ this.$store.getters.editbleEmployee.Name }} #{{ this.$store.getters.editbleEmployee.Id }}</v-card-title>
              <hr>
              <v-card-text class="py-4">
                  <v-form ref="form">
                      <v-text-field v-model="this.$store.getters.editbleEmployee.Name" required label="Name" ></v-text-field>
                      <v-text-field v-model="this.$store.getters.editbleEmployee.Address" label="Address" required ></v-text-field>
                      
                      <v-text-field v-model="this.$store.getters.editbleEmployee.Department" label="Department" required ></v-text-field>
                      
                      <v-btn color="primary" class="mr-4" @click="updateEmployee" > Edit Employee </v-btn>
                      <v-btn color="error" class="mr-2" @click.stop="dialog = false">Cancle</v-btn>
                    </v-form>
              </v-card-text>
          </v-card>
      </v-dialog>
      <!-- --------  dialog  ---------- -->
     
    </v-container>
  </div>
</template>

<script>
//  import axios from "axios";
export default {
  
  name: 'Home',
  components: {
   
  },
  data(){
    return{
     dialog: false,
      newEmployee : {
        Name:"",
        Address:"",
        BirthDay:new Date(),
        Department:""
      },

    }
  },
  created(){
    this.$store.commit('getAllEmployee');
  },
  computed:{

    getAllEmployee(){
      if(this.$store.getters.reloadGetAllEmployee == true){
         this.$store.commit('getAllEmployee')
         this.$store.commit('makeReloadGetAllEmployeeFalse')
        }
      return this.$store.getters.getAllEmployee
    }
  },
  methods:{
    
    getEmployee:function(id){
      var url = "https://localhost:44361/home/GetEmployee?id=" + id.toString()
      this.$store.commit('getEmployee', { url }) 

    },

    updateEmployee:function(){
      // this.$store.commit('updateEmployee')
      this.test = this.$store.getters.editbleEmployee
    },
    
    getNewEmployee : function(){
      if(this.newEmployee.name == "" || this.newEmployee.Address == "" || this.newEmployee.Department == ""){
        alert("Fill all the Fields")
      }else{
        var _newEmployee = this.newEmployee
        this.$store.commit('addEmployee', { _newEmployee })
        this.$store.commit('getAllEmployee')
      }
    },
    
    deleteEmployee : function (id){
      var _id = id.toString()
      this.$store.commit('deleteEmployee', { _id })
    }
  }

}
</script>

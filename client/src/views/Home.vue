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
                              <th class="text-left">BirthDay</th>
                              <th class="text-left">Department</th>
                              <th class="text-left">Action</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr v-for="Employee in Employees" :key="Employee.id">
                              <td>{{ Employee.id }}</td>
                              <td>{{ Employee.address }}</td>
                              <td>{{ Employee.birthDay }}</td>
                              <td>{{ Employee.department }}</td>
                              <td>
                                <v-icon @click="deleteEmployee(Employee.id)" color="error">mdi-delete-forever</v-icon> |
                                <v-icon color="blue">mdi-file-find</v-icon> |
                                <v-icon color="green">mdi-account-edit</v-icon>
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
    {{test}}
    </v-container>
  </div>
</template>

<script>
// @ is an alias to /src

import axios from "axios";
export default {
  name: 'Home',
  data(){
    return{
      Employees:"",
      newEmployee : {
        Name:"",
        Address:"",
        BirthDay:new Date(),
        Department:""
      },
      headers: [
          { text: '#', value: 'id' },
          { text: 'Name', value: 'name' },
          { text: 'Address', value: 'address' },
          { text: 'BirthDay', value: 'birthDay' },
          { text: 'Department', value: 'department' },
        ],
        test:"dcwe"
    }
  },
  created(){
    this.getAllEmployee();
  },
  computed:{
    
  },
  methods:{

    getAllEmployee : function(){
      axios.get("https://localhost:44361/").then(res=>{
        this.Employees = res.data;
      });
    },

    getNewEmployee : function(){
      if(this.newEmployee.name == "" || this.newEmployee.Address == "" || this.newEmployee.Department == ""){
        alert("Fill all the Fields")
      }else{
        axios.post("https://localhost:44361/home/add",this.newEmployee).then(res=>{
          this.test = res.data;
          this.getAllEmployee();
          this.newEmployee.Name = "";
          this.newEmployee.Address = "";
          this.newEmployee.BirthDay = "";
          this.newEmployee.Department = "";
        });
        
      }

      
    },
    
    deleteEmployee : function (id){
        var url = "https://localhost:44361/home/DeleteEmployee?id=" + id.toString()
        axios.post(url).then(res=>{
            if(res.id != null){
                this.getAllEmployee();
            }
        })
        

         
        
    }
  }

}
</script>

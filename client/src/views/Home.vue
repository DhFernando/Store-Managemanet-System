<template>
  <div class="home">
    <v-container>
      <v-row>
        <v-col :cols="12">
          <v-row>
            <v-col :cols="6">
                <v-row><h4>Employee List</h4></v-row>
                <v-row>
                  <v-col :cols="12">
                      <v-data-table :headers="headers" :items="Employees" :sort-by="['id']" class="elevation-1" ></v-data-table>
                  </v-col>
                </v-row>
            </v-col>
            <v-col :cols="6">
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
      Employees:[],
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
        test:[]
    }
  },
  created(){
    axios.get("https://localhost:44361/").then(res=>{
      this.Employees = res.data;
    });
  },
  computed:{
    
  },
  methods:{
    getNewEmployee : function(){
      if(this.newEmployee.name == "" || this.newEmployee.Address == "" || this.newEmployee.Department == ""){
        alert("Fill all the Fields")
      }else{
        axios.post("https://localhost:44361/home/add",this.newEmployee).then(res=>{
          this.test = res.data;
        });
      }
      
    
    }
  }

}
</script>

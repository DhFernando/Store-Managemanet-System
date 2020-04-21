<template>
  <div>
    <v-container>
        <v-row>
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
                                <v-icon @click="deleteEmployee(Employee.id)" color="error">mdi-delete-forever</v-icon> |
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
        </v-row>

        
    </v-container>
  </div>
</template>

<script>
export default {
    name:'Administration_index',
    data(){
      return{
         

        ApplicationUsers : []
      }
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
}
</script>

<style>

</style>
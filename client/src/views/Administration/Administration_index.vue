<template>
  <div>
    <v-container>
      <v-row>
        <v-col  cols="12">
            <div>
              <v-btn class="ml-5 " text @click="GoTo('Administration_ApplicationUser')" >User Management</v-btn>
              <v-btn class="ml-5 " text @click="GoTo('Administration_role')">Role Management</v-btn>
            </div>
        </v-col>
      </v-row>
      <v-row v-show="where == 'Administration_ApplicationUser' ">
        <v-col cols="12">
          <AdministrationApplicationUser></AdministrationApplicationUser>
        </v-col>
      </v-row>
      <v-row v-show="where == 'Administration_role' ">
        <v-col  cols="12">
          <AdministrationRole></AdministrationRole>
        </v-col>
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
        where:'Administration_ApplicationUser'
         
      }
    },
    components: {
      AdministrationApplicationUser,
      AdministrationRole
    },
    created(){
      
    },
    computed: {
      
    },
    methods:{
     GoTo:function(_where){  this.where = _where  }
    }
}
</script>

<style>

</style>
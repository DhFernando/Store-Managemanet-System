<template>
  <div>
    <v-container>
      

      <v-list nav dense >
        <v-list-item-group  color="primary">
          <v-list-item v-for="RoleWithUser in RoleWithUsers" :key="RoleWithUser.id" >
            <v-list-item-content>
              <v-list-item-title >
                {{RoleWithUser.roleId}}. {{RoleWithUser.roleName}} <v-btn x-small color="secondary" >Add</v-btn>
                    <v-list-item v-for="user in RoleWithUser.users" :key="user.id" >
                    <v-list-item-icon>
                      <v-icon>mdi-account-check</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                      <v-list-item-title >
                        {{user.id}} | {{user.userName}} | <v-btn x-small color="error" >Romove</v-btn>
                            
                      </v-list-item-title>
                      
                    </v-list-item-content>
                  </v-list-item>
              </v-list-item-title>
              
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    
    </v-container>
  </div>
</template>

<script>

export default {
    name:'Administration_index',
    data(){
      return{
        
      }
    },
    created(){
      this.$store.dispatch("GetRoleWithUsers")
    },
    computed: {
      RoleWithUsers(){
        return this.$store.getters.RoleWithUsers
      }
    },
    methods:{
      
    }
}
</script>

<style>

</style>
<template>
<div>
    <v-app-bar app color="primary" dark >
      <div class="d-flex align-center">
       
        <h2>DH Store</h2>
      </div>
      <v-btn class="ml-5 " text  to="/">Home</v-btn>
      <v-btn class="ml-5 " text  to="/Advertistment">Advertistment</v-btn>
      <v-btn class="ml-5 " text  to="/profile/profile_index">Profile</v-btn>
  

      <v-menu left bottom >
        <template v-slot:activator="{ on }">
          <v-btn  text v-on="on">
            Administration <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item  to="/Administration/User/" >
            <v-list-item-title>Users</v-list-item-title>
          </v-list-item>
          <v-list-item to="/Administration/Advertistment/" >
            <v-list-item-title>Advertistment</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <v-spacer></v-spacer>
      
      <v-btn v-show="!LogedIn" to="/Login" text>
        <span class="mr-2">Login</span>
        <v-icon>mdi-lock</v-icon>
      </v-btn>
      <v-btn v-show="!LogedIn" to="/Registration" text>
        <span class="mr-2">Register</span>
        <v-icon>mdi-lock</v-icon>
      </v-btn>
      <v-btn color="yellow" v-show="LogedIn"  @click.stop="dialog=true" text>
        <v-icon>mdi-cart</v-icon>
        <span class="ml-2">Rs {{Total}}</span>
      </v-btn>
      <v-btn v-show="LogedIn" @click="DestroyToken" text>
        <span class="mr-2">LogOut</span>
        <v-icon>mdi-lock</v-icon>
      </v-btn>

    </v-app-bar>

     <v-dialog v-model="dialog" scrollable max-width="670px">
        <v-card>
          <v-card-title>Selected Items</v-card-title>
          <v-divider></v-divider>
          <v-card-text style="height: 300px;">
            <v-radio-group v-model="dialogm1" column>
              
              <v-row>
                <v-col cols="12" >
                 
                  <v-simple-table fixed-header >
                    <template v-slot:default>
                      <thead>
                        <tr>
                          <th class="text-left"> </th>
                          <th class="text-left"> Item Name </th>
                          <th class="text-left"> Price</th>
                          <th class="text-left"> Actions</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr v-for="CartItem in Cart" :key="CartItem.id">
                          <td  > imahe</td>
                          <td  > {{CartItem.item}} </td>
                          <td  > {{CartItem.price}} | {{CartItem.qty}} </td>
                          <td>
                            <v-btn small  color="primary" tile outlined> + </v-btn> 9 <v-btn small  color="primary" tile outlined> -</v-btn> |
                            <v-icon color="green" >mdi-file-find</v-icon> |
                            <v-icon color="error">mdi-delete-forever</v-icon> 
                          </td>
                        </tr>
                        <tr >
                          <td ></td>
                          <td > </td>
                          <td > </td>
                          <td class="green--text" > <u>Rs {{Total}} /= </u></td>
                        </tr>
                      </tbody>
                    </template>
                  </v-simple-table>

                </v-col>
              </v-row>

              
            </v-radio-group>
          </v-card-text>
          <v-divider></v-divider>
          <v-card-actions>
            <v-btn color="blue darken-1" text @click="dialog = false">Close</v-btn>
            <v-btn color="blue darken-1" text @click="dialog = false">Oder Now</v-btn>
            {{this.$store.getters.Total}}
          </v-card-actions>
        </v-card>
      </v-dialog>
   
    </div>
</template>

<script>
// import axios from "axios";
export default {
    name:'Header',
    data () {
      return {
        dialogm1: '',
        dialog: false,
      }
    },
    computed:{
      LogedIn(){
        return this.$store.getters.LogedInCheck
      },
      Total(){
        return this.$store.getters.Total
      },
      Cart(){
        return this.$store.getters.Cart
      }
    },
    methods:{
      DestroyToken:function(){
        this.$store.dispatch("DestroyToken")
        .then(res =>{
          if(res != null){
            this.$router.push({ name : "Home" })
          }
        })
      }
    }
}
</script>

<style>

</style>
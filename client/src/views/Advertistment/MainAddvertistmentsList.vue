<template>
  <div >
    <div class="mx-10">
        <v-card class="d-flex flex-wrap" flat tile >
        <v-card style="width:31.2%" v-for="Advertistment in  Advertistments" :key="Advertistment" class="pa-2 mx-3 mb-5" outlined tile >
            <v-img class="white--text align-end" height="200px" src="" ></v-img>
            <hr color="grey ">
            <v-card-title>{{Advertistment.item}}</v-card-title>
            <v-card-subtitle class="pb-0 green--text" >Price : Rs {{ Advertistment.price }} /=</v-card-subtitle>

            <v-card-text class="grey--text mt-6">
                <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vitae in, laudantium delect</p>
                <span class="black--text">Category</span> : {{Advertistment.mainCategory }} / {{ Advertistment.subCategory }}
            </v-card-text>
            
            <v-card-actions>
                <v-btn color="primary" tile outlined > Edit </v-btn>
            </v-card-actions>
        </v-card>
        </v-card>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
    name:'index',
     components: {

    },
    data(){
      return{
        Advertistments:null
      }
    },
    created(){
      axios.get("https://localhost:44361/Advertistment/GetAllAdvertistments", {
        headers: { 'Authorization': 'Bearer ' + localStorage.getItem("access_token") }
        }).then(res => {
            this.Advertistments = res.data
        }) 
    },
    computed: {

    },
}
</script>

<style>

</style>
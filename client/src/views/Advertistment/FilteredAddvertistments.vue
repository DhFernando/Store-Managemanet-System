<template>
  <div >
    <v-row>
        <v-col cols="12">
          
           Results for {{search}}
          
        </v-col>
    </v-row>
    <v-row v-if="Advertistments != null">
      <div class="mx-10">
        <div class="d-flex flex-wrap" flat tile >
            <v-card style="width:23%; height:420px" class="pa-0 mx-3 mb-5" v-for="Advertistment in  FilltedAdvertistments" :key="Advertistment.id"  outlined tile >
                <v-img class="white--text align-end" height="150px" src="" ></v-img>
                <hr color="grey">
                <v-card-title>{{Advertistment.item}}</v-card-title>
                <v-card-subtitle class="pb-0 green--text" >Price : Rs {{ Advertistment.price }} /=</v-card-subtitle>

                <v-card-text class="grey--text mt-6">
                    <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vitae in, laudantium delect</p>
                    <span class="black--text">Category</span> : {{Advertistment.mainCategory }} / {{ Advertistment.subCategory }}
                </v-card-text>
                
                <v-card-actions>
                    <v-btn color="primary" tile outlined > Edit </v-btn>
                    <v-btn color="primary" tile outlined @click="AddToCart(Advertistment)"> Add <v-icon class="mx-2">mdi-cart-plus</v-icon> </v-btn>
                </v-card-actions>
            </v-card>
        </div>
      </div>
     
    </v-row>
  </div>
</template>

<script>
import axios from "axios";
export default {
    name:'index',
     components: {

    },
    props: ['search'],
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
    methods:{
     
    },
    computed: {
      FilltedAdvertistments(){
        const _advertistments = []
        this.Advertistments.forEach(advertistment => {
          if(advertistment.item.toLowerCase().indexOf(this.search.toLowerCase()) != -1){
            _advertistments.push(advertistment)
          }
          
        });
        return _advertistments
      }
    },
}
</script>

<style>

</style>
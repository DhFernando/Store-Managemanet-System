<template>
  <div>
    <v-row>
      <v-col cols="4">
        <div class="text-center mt-5">
          <v-btn v-if="Display == 'Pastry'" rounded  dark outlined color="primary" class="mx-1"  @click.stop="FilterDisplay('Grocery') "   > Go to  Grocery Shop </v-btn>
          <v-btn v-if="Display == 'Grocery'" rounded  dark outlined color="primary" class="mx-1"  @click.stop="FilterDisplay('Pastry') " > Go to  Pastry shop</v-btn>
        </div>
      </v-col>
      <v-col cols="4">
        <div class="text-center">
              <v-text-field  v-model="search" label="Search Items" ></v-text-field>
        </div>
        <v-col cols="4"></v-col>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12">
        <div class="text-center" v-if="Display == null">
          <v-btn rounded x-large dark outlined color="primary" class="mx-10 px-10 pt-5 pb-9"  @click.stop="FilterDisplay('Grocery') "   >Go to Grocery Shop</v-btn>
          <v-btn rounded x-large dark outlined color="primary" class="mx-10 px-10 pt-5 pb-9"  @click.stop="FilterDisplay('Pastry') " >Go to Pastry Shop</v-btn>
        </div>
      </v-col>
    </v-row>
    <v-row>
        <v-col cols="12" class="pt-0">
            <!-- <carousel></carousel> -->
            <!-- <FilteredAddvertistments v-if="search.length != 0" :search='search'></FilteredAddvertistments> -->
            <Addvertistments  :search='search' :Display='Display'></Addvertistments>
           
        </v-col>
    </v-row>
    
  </div>
</template>

<script>
// import carousel from '@/views/Advertistment/carousel'

import Addvertistments from '@/views/Advertistment/Addvertistments'

export default {
    name:'index',
     components: {
      // carousel,
      
      Addvertistments,
     

    },
    data(){
      return{
         Display:null,
         search:''
      }
    },
   
    methods:{
      FilterDisplay(_Display){
        this.Display = _Display
      }
    }
}
</script>

<style>

</style>
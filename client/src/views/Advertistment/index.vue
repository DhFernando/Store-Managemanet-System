<template>
  <div>
    <v-row>
      <v-col cols="4"></v-col>
      <v-col cols="4">
        <div class="text-center">
              <v-text-field  v-model="search" label="Search Items" ></v-text-field>
        </div>
        <v-col cols="4"></v-col>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12">
        <div class="text-center">
          <v-btn rounded x-large dark outlined color="primary" class="mx-10 px-10 pt-5 pb-9"  @click.stop="Display = 'GroceryAddvertistments'"   >Go to Grocery Shop</v-btn>
          <v-btn rounded x-large dark outlined color="primary" class="mx-10 px-10 pt-5 pb-9"  @click.stop="Display ='PastryAddvertistments'" >Go to Pastry Shop</v-btn>
        </div>
      </v-col>
    </v-row>
    <v-row>
        <v-col cols="12" class="pt-0">
            <!-- <carousel></carousel> -->
            <FilteredAddvertistments v-if="search.length != 0" :search='search'></FilteredAddvertistments>
            <GroceryAddvertistments v-if="Display == 'GroceryAddvertistments' "></GroceryAddvertistments>
            <PastryAddvertistments v-if="Display == 'PastryAddvertistments' "></PastryAddvertistments>
        </v-col>
    </v-row>
    
  </div>
</template>

<script>
// import carousel from '@/views/Advertistment/carousel'
import FilteredAddvertistments from '@/views/Advertistment/FilteredAddvertistments'
import GroceryAddvertistments from '@/views/Advertistment/GroceryAddvertistments'
import PastryAddvertistments from '@/views/Advertistment/PastryAddvertistments'
export default {
    name:'index',
     components: {
      // carousel,
      FilteredAddvertistments,
      GroceryAddvertistments,
      PastryAddvertistments

    },
    data(){
      return{
         Display:null,
         search:''
      }
    },
    created(){
      
    },
    computed: {

    },
    methods:{
      
    }
}
</script>

<style>

</style>
<template>
  <div>
    <v-row>
        <v-col cols="12" class="pt-0">
            <carousel></carousel>
            <MainAddvertistmentsList></MainAddvertistmentsList>
        </v-col>
    </v-row>
  </div>
</template>

<script>
import carousel from '@/views/Advertistment/carousel'
import MainAddvertistmentsList from '@/views/Advertistment/MainAddvertistmentsList'
export default {
    name:'index',
     components: {
      carousel,
      MainAddvertistmentsList
    },
    data(){
      return{
         
      }
    },
    created(){
      
    },
    computed: {

    },
}
</script>

<style>

</style>
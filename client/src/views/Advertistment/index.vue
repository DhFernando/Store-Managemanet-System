<template>
  <div>
    <v-row>
        <v-col cols="12" class="pt-0">
            <carousel></carousel>
        </v-col>
    </v-row>
  </div>
</template>

<script>
import carousel from '@/views/Advertistment/carousel'
export default {
    name:'index',
     components: {
      carousel
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
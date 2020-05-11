<template>
  <div>
      <!-- <v-carousel >
          <v-carousel-item
          v-for="(item,i) in items"
          :key="i"
          :src="item.src"
          reverse-transition="fade-transition"
          transition="fade-transition"
          ></v-carousel-item>
      </v-carousel> -->

      <v-parallax   height="700" dark src="https://thumbs.dreamstime.com/b/cottage-cheese-cake-berry-jam-coffee-dark-blue-background-top-view-flat-lying-cottage-cheese-cake-berry-jam-142232982.jpg" >
        <v-row align="center" justify="center" >
          <v-col class="text-center black" cols="12">
            <h1 class="display-1 font-weight-thin mb-4">Welcome To DH Store</h1>
            <h4 class="subheading">Feel Free To Get Your Stuff today!</h4>
          </v-col>
        </v-row>
      </v-parallax>
  </div>
</template>

<script>
export default {
    name:'index',
    data(){
      return{
         items: [
          { src: 'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimg1.cookinglight.timeinc.net%2Fsites%2Fdefault%2Ffiles%2Fstyles%2Fmedium_2x%2Fpublic%2F1542062283%2Fchocolate-and-cream-layer-cake-1812-cover.jpg%3Fitok%3DrEWL7AIN'},
          { src: 'https://cdn.vuetifyjs.com/images/carousel/sky.jpg', },
          { src: 'https://cdn.vuetifyjs.com/images/carousel/bird.jpg', },
          { src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg', },
        ],
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
<template>
  <div class="home">
    {{c}}
  </div>
</template>

<script>
// @ is an alias to /src

import axios from "axios";
export default {
  name: 'Home',
  data(){
    return{
      c:[]
    }
  },
  created(){
    axios.get("https://localhost:44361/").then(res=>{
      this.c = res.data;
    });
  }

}
</script>

<template>
  <div>
    <v-container>
      <v-row>
        <v-col  cols="12">
            <div>
              <v-btn class="ml-5 " text @click.stop="dialog = true" >Create Advertistment</v-btn>
            </div>
            <hr />
            {{MainCategories}}
        </v-col>
      </v-row>
      <v-row>
        <v-dialog v-model="dialog"  max-width="1090" >
            
              <v-card class="">
                <v-toolbar color="primary" dark flat>
                  <v-toolbar-title>Create Advertistment </v-toolbar-title>
                </v-toolbar>
                <v-card-text style="padding-left:70px ; padding-top:50px ; padding-right:70px  ">
                  <v-form>
                    <v-row>
                      <v-col cols="3" class="mr-5">
                        <img v-if="imagePreview.state == false" :src="require(`@/assets/${imagePreview.picture}`)"  @click="openUpload" style="width:200px" >
                        <img v-if="imagePreview.state == true " :src="imagePreview.picture"  @click="openUpload" style="width:200px" >
                        <input type="file" name="image" id="file-field" v-on:change="updatePreview" style="display: none">
                      </v-col>
                      <v-col cols="8">
                        <v-row>
                          <v-col cols="12">
                            <v-row>
                              <v-col cols="4">
                                <v-select v-on:change="SetSubCategories"  :items="MainCategories"  :rules="[v => !!v || 'Item is required']"
                                label="Main Category" required ></v-select>
                              </v-col>
                              <v-col cols="4">
                                <v-select  :items="MainCategories"  :rules="[v => !!v || 'Item is required']"
                                label="Sub Category" required ></v-select>
                              </v-col>
                              <v-col cols="4">
                                <v-select  :items="MainCategories"  :rules="[v => !!v || 'Item is required']"
                                label="Group" required ></v-select>
                              </v-col>
                            </v-row>
                            <v-row>
                              <v-col cols="12"> 
                                <v-text-field   label="Item"   type="text" /> 
                                <v-text-field   label="Price"   type="text" /> 
                              </v-col>
                            </v-row>
                            
                          </v-col>
                        </v-row>
                      </v-col>
                    </v-row>

                  </v-form>
                </v-card-text>
                <v-card-actions>
                  <v-spacer />
                  <v-btn color="primary" @click="CreateAdd()" text>Create</v-btn>
                </v-card-actions>
              </v-card>
           
          </v-dialog>
      </v-row>
    </v-container>
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
         dialog:false,
         imagePreview:{
            picture:'addicon.png',
            state:false
           },
        MainCategories: [],
      }
    },
    
    methods: {
      CreateAdd:function(){
        alert("Created")
      },
      openUpload() {
          document.getElementById('file-field').click()
      },

      updatePreview(e){
          let reader, files = e.target.files;
          if(files.length === 0){
              console.log('empty')
          }
            reader = new FileReader()
            reader.onload = (e) =>{
                this.imagePreview.picture =  e.target.result
                this.imagePreview.state = true
            }
            reader.readAsDataURL(files[0])
      },
      SetSubCategories(e){
        alert(e.target.result)
      }
      
    },
    created(){
      axios.get("https://localhost:44361/Advertistment/Index", {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem("access_token") }
        }).then(res => {
          // this.MainCategories = res.data
          res.data.forEach(Category => {
            if(Category.categoryType == "MainCategory"){
              this.MainCategories.push(Category.categoryName)
            }
          });
        })

        
    }
}
</script>

<style>

</style>
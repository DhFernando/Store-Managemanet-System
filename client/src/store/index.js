import Vue from 'vue'
import Vuex from 'vuex'
import axios from "axios";


// import { stat } from 'fs';
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    Employees:[],
    reloadGetAllEmployee : false,
    editbleEmployee : {
      Id:"",
      Name:"",
      Address:"",
      BirthDay:new Date(),
      Department:""
    },
    
   token: localStorage.getItem("access_token") || null ,
   userProfile:null,
   ApplicationUsers:[],
   ApplicationUser : [],
   RoleWithUsers:[],
   UserRoles:[],
   newUserRegistrationDialog:false
    
  },
  getters: {
    getAllEmployee:(state)=>{  return state.Employees },
    reloadGetAllEmployee : (state) => { return state.reloadGetAllEmployee },
    getEmployee:(state)=>{ return state.getEmployee },
    editbleEmployee:(state)=>{ return state.editbleEmployee },
    LogedInCheck:(state) =>{ return state.token !== null},
    userProfile:(state)=>{ return state.userProfile },
    ApplicationUsers:(state)=>{return state.ApplicationUsers},
    ApplicationUser:(state)=>{ return state.ApplicationUser },
    RoleWithUsers:(state)=>{ return state.RoleWithUsers },
    UserRoles:(state)=>{ return state.UserRoles },
    newUserRegistrationDialog:(state)=>{return state.newUserRegistrationDialog}

    
  },
  actions: {
    Registration : (contex ,  _AccountRegistrationData ) => {  
      console.log(_AccountRegistrationData)
     return new Promise((resolve , reject)=>{
        axios.post("https://localhost:44361/account/Register", _AccountRegistrationData)
        .then(res => {
            if(res.data != null ){ 
                const token = res.data
                contex.commit('StoreAccessToken',token)
                resolve("Done")
            }
          }).catch( error => {
            console.log(error)
            reject(error)
          });

      })
  
    },

    DestroyToken:(contex)=>{
      return new Promise((resolve)=>{
        contex.commit("DestroyToken")
        resolve("done")
      })
    },
    GetProfile:(contex)=>{
      return new Promise((resolve)=>{
        axios.get("https://localhost:44361/account/GetProfile", {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem("access_token") }
        }).then(res => {
         contex.commit("StoreProfile" , res.data)
         resolve("done")
         
        }) 
       
      })
    },

    GetUsers:(contex ) =>{
      return new Promise((resolve)=>{
        axios.get("https://localhost:44361/Administration/GetAllApplicationUsers",{
          headers: { 'Content-Type': 'application/json','Authorization': 'Bearer ' + localStorage.getItem("access_token") }
        }).then(res => {
          if(res.data != null ){ 
            
            contex.commit("StoreApplicationUsers", res.data )
            resolve("done")
           }
        })
      })
    },
    GetUser:(contex,ApplicationUser_id)=>{
      var _id = {id:ApplicationUser_id}
      
      return new Promise((resolve)=>{
        axios.post("https://localhost:44361/Administration/GetApplicationUser", _id,{
            headers: { 'Content-Type': 'application/json','Authorization': 'Bearer ' + localStorage.getItem("access_token") }
          }).then(res => {
          if(res.data != null){
            contex.commit("StoreUser" , res.data )
            resolve("Success")
          }
        })
      })
    },

    DeleteUser:(contex,ApplicationUser_id)=>{
      var data = {
        id:ApplicationUser_id
      }
      return new Promise((resolve)=>{
        axios.post("https://localhost:44361/Administration/DeleteApplicationUser", data,{
            headers: { 'Content-Type': 'application/json','Authorization': 'Bearer ' + localStorage.getItem("access_token") }
          }).then(res => {
          if(res.data != null){
            resolve(res.data)
          }
        })
      })
    
    },

    GetRoleWithUsers:(contex)=>{
      return new Promise((resolve)=>{
        axios.get("https://localhost:44361/Administration/GetRoleWithUsers", {
            headers: { 'Content-Type': 'application/json','Authorization': 'Bearer ' + localStorage.getItem("access_token") }
          }).then(res => {
          if(res.data != null){
            contex.commit("StoreRoleWithUsers",res.data)
            resolve(res.data)
          }
        })
      })
    },

    GetUserRoles:(contex,ApplicationUser_id)=>{
      var url = "https://localhost:44361/Administration/GetUserRoles/" + ApplicationUser_id
      return new Promise((resolve)=>{
        axios.get(url , {
            headers: { 'Content-Type': 'application/json','Authorization': 'Bearer ' + localStorage.getItem("access_token") }
          }).then(res=>{
            if(res.data != null){
              resolve("Success")
              contex.commit("StoreUserRoles" , res.data)
            }
          })
      })
    },
    UpdateUserRoles:(contex , _userRoles)=>{
     
      return new Promise((resolve)=>{
        var url = "https://localhost:44361/Administration/UpdateUserRoles/"
        axios.post(url , _userRoles ,{
          headers: { 'Content-Type': 'application/json','Authorization': 'Bearer ' + localStorage.getItem("access_token") }
        }).then(res=>{
          if(res.data != null){
            resolve("Success")
          }
        })
      })
    }
  },

  mutations: {

    StoreAccessToken:(state , token ) =>{
      if(state.token == null){
          localStorage.setItem('access_token',token)
         state.token = token
      }
    },

    DestroyToken:(state) =>{
      localStorage.removeItem("access_token")
      state.token = null
    },
    StoreProfile:(state , data)=>{
      state.userProfile = data
    },
    StoreApplicationUsers:(state , data) =>{
      state.ApplicationUsers = data
    },
    StoreUser:(state , data)=>{
      state.ApplicationUser = []
      state.ApplicationUser = data
    },

    StoreRoleWithUsers:(state,data)=>{
      state.RoleWithUsers = data
    },

    StoreUserRoles:(state , data)=>{
      state.UserRoles = data
    },
    makeReloadGetAllEmployeeFalse : (state) => {
      state.reloadGetAllEmployee = false
    },

    
    // --------------------------------------------------------- // 
    getAllEmployee:(state)=>{
      axios.get("https://localhost:44361/").then(res=>{
        state.Employees = res.data;
      });
    },

    updateEmployee:(state) => {
      alert ( state.editbleEmployee.Name )
    },

    deleteEmployee : (state , { _id }) => {
     axios.post("https://localhost:44361/home/DeleteEmployee", _id ,{
        headers: { 'Content-Type': 'application/json','Authorization': 'Bearer ' + state.token }
      }).then(res => {
        if(res.data != null ){ state.reloadGetAllEmployee = true }
      })
    },

    addEmployee : (state, { _newEmployee }) => {
      axios.post("https://localhost:44361/home/add", _newEmployee).then(res => {
        if(res.data != null ){ state.reloadGetAllEmployee = true }
      })
    },

    getEmployee : (state , { url }) => {
      axios.get(url).then(res => {
        if(res.data != null){
          state.editbleEmployee.Id = res.data.id;
          state.editbleEmployee.Name = res.data.name;
          state.editbleEmployee.BirthDay = res.data.birthDay;
          state.editbleEmployee.Address = res.data.address;
          state.editbleEmployee.Department = res.data.department;
        }
        else{alert("Sorry")}
      })
    },
    //-----------------------------------------------------------------//

    
  },
  
})

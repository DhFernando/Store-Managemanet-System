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
    userProfile:[]
    
  },
  getters: {
    getAllEmployee:(state)=>{  return state.Employees },
    reloadGetAllEmployee : (state) => { return state.reloadGetAllEmployee },
    getEmployee:(state)=>{ return state.getEmployee },
    editbleEmployee:(state)=>{ return state.editbleEmployee },
    LogedIn:(state) =>{ return state.token !== null},
    userProfile:(state)=>{ return state.userProfile }

    
  },
  actions: {
    AccountRegistrationDataSend : (contex ,  _AccountRegistrationData ) => {  
     return new Promise((resolve , reject)=>{

        axios.post("https://localhost:44361/account/Register", _AccountRegistrationData)
        .then(res => {
            if(res.data != null ){ 
              const token = res.data
              localStorage.setItem('access_token',token)
              contex.commit('AccountRegistrationDataSend',token)
              resolve(token)
            }
          }).catch( error => {
            console.log(error)
            reject(error)
          });

      })
  
    },

    destroyToken:(contex)=>{
      return new Promise((resolve)=>{
        contex.commit("destroyToken")
        resolve("done")
      })
    },
    GetProfile:(contex)=>{
      return new Promise(()=>{
        axios.get("https://localhost:44361/account/GetProfile", {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem("access_token") }
        }).then(res => {
         contex.commit("GetProfile" , res.data)
         
        }) 
       
      })
    }
  },

  mutations: {

    AccountRegistrationDataSend:(state , token ) =>{
      state.token = token
    },

    destroyToken:(state) =>{
      localStorage.removeItem("access_token")
      state.token = null
    },
    GetProfile:(state , data)=>{
      state.userProfile = data
    },
    
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

    makeReloadGetAllEmployeeFalse : (state) => {
      state.reloadGetAllEmployee = false
    }
  },
  
})

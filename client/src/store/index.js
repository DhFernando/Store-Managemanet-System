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

    
  },
  getters: {
    getAllEmployee:(state)=>{  return state.Employees },
    reloadGetAllEmployee : (state) => { return state.reloadGetAllEmployee },
    getEmployee:(state)=>{ return state.getEmployee },
    editbleEmployee:(state)=>{ return state.editbleEmployee }
  },
  actions: {
  
  },

  mutations: {
    getAllEmployee:(state)=>{
      axios.get("https://localhost:44361/").then(res=>{
        state.Employees = res.data;
      });
    },

    updateEmployee:(state) => {
      alert ( state.editbleEmployee.Name )
    },

    deleteEmployee : (state , { url }) => {
      axios.post(url).then(res => {
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

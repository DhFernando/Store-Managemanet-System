// import axios from "axios";

 const state = {
    selectedItems : 'hey',
    Cart:[],
    Total:0,
    
    
  };

  const getters = {
    getSelectedItems:(state)=>{  return state.selectedItems },
    Cart:(state) => { return state.Cart },
    Total:(state) =>{ return state.Total}
  };

  const actions = {
   
  };

  const mutations = {
    AddItemToCart : (state , item)=>{
      // var s = state.Cart
      //  var newItem = {
      //   id:item.id,
      //   item:item.item,
      //   price:item.price,
      //   mainCategory:item.mainCategory,
      //   subCategory:item.subCategory,
      //   creatorId:item.creatorId
      //  }

      state.Total = state.Total + parseInt(item.price)
      if(state.Cart.indexOf(item) == -1){
        
        item["qty"] = 1 
        
        state.Cart.push(item)
      }else{
        state.Cart[state.Cart.indexOf(item)]["qty"] = state.Cart[state.Cart.indexOf(item)]["qty"] + 1
  
      }
     
      
    },
    
  };


  export default{
    state,
    getters,
    actions,
    mutations
}

  


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
      
      state.Total = state.Total + parseInt(item.price)
      if(state.Cart.indexOf(item) == -1){
        
        item["qty"] = 1 
        
        state.Cart.push(item)
      }else{
        state.Cart[state.Cart.indexOf(item)]["qty"] = state.Cart[state.Cart.indexOf(item)]["qty"] + 1
  
      }
     
      
    },

    ChnageItemQty:(state , data) =>{
      
      state.Cart.forEach(item => {
        if(data.qtyType == "Plus" && item.id == data.itemId){
          item.qty++
        }else if(data.qtyType == 'minus' && item.id == data.itemId){
          item.qty--
        }
      });
    }
    
  };


  export default{
    state,
    getters,
    actions,
    mutations
}

  


function validSolution(board){
    for(let i = 0; i < 9; i++){
      let row = new Set(board[i]);
      if(row.size !== 9 || row.has(0)){
        return false;
      }
    }
    
    for(let i = 0; i < 9; i++){
      let col = new Set();
      for(let j = 0; j < 9; j++){
        col.add(board[j][i]);
      }
      if(col.size !== 9 || col.has(0)){
        return false;
      }
    }
    
    for(let i = 0; i < 9; i+=3){
      for(let j = 0; j < 9; j+=3){
        let subgrid = new Set();
        for(let k = i; k < i+3; k++){
          for(let l = j; l < j+3; l++){
            subgrid.add(board[k][l]);
          }
        }
        if(subgrid.size !== 9 || subgrid.has(0)){
          return false;
        }
      }
    }
    
    return true;
  }
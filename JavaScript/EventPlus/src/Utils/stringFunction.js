
/**
 * 
 * @param {*} data 
 * @returns 
 */


export const formataDataDbToView = data => {
    //EX: 2023-09-30TT00:00 para 30/09/2023
    data = data.substr(0, 10); // retorna a data (2023-09-30)
    data = data.split("-"); //retorna um array [2023, 09, 30]
    return `${data[2]}/${data[1]}/${data[0]}` //retorna 30/09/2023
  
    
  };
  
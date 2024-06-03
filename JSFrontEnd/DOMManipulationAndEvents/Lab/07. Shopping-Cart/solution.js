function solve() {
   let productElements = document.querySelectorAll('.product');
   let textareaElement = document.querySelector('textarea');
   let checkoutButtonElement = document.querySelector('.checkout');
   let productSet = new Set();
   let totalSum = 0;

   //define event listener separately
   const addProductHandler = function(event){
      let element = event.currentTarget.parentNode.parentNode;
      let productPrice = Number(element.querySelector('.product-line-price').textContent).toFixed(2);
      let productName = element.querySelector('.product-title').textContent; 
      textareaElement.value += `Added ${productName} for ${productPrice} to the cart.\n`
         productSet.add(productName);
         totalSum += Number(productPrice);
   }

   //add button is clicked, append to input
   Array.from(productElements)
      .forEach(element => element.querySelector('.add-product').addEventListener('click', addProductHandler))


   //checkout is clicked, append total and list of products and disable all buttons
   checkoutButtonElement.addEventListener('click', function checkoutByttonHandler(){
      textareaElement.value += `You bought ${[...productSet].join(', ')} for ${totalSum.toFixed(2)}.`
      Array.from(productElements)
      .forEach(element => element.querySelector('.add-product').removeEventListener('click', addProductHandler));
      checkoutButtonElement.removeEventListener('click', checkoutByttonHandler);
   })
}
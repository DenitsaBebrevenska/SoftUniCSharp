function solve() {
  //get target elements
  let tbodyElement = document.querySelector('tbody');
  let inputElement = document.querySelector('textarea:first-of-type');
  let generateButtonElement = document.querySelector('button:first-of-type');
  let buyButtonElement = document.querySelector('button:last-of-type');

  //add event listener to generate button
  generateButtonElement.addEventListener('click', function () {
    let parsedInput = JSON.parse(inputElement.value);
    for(const jsonObj of parsedInput){
      let newTrElement = document.createElement('tr');
      //create all tds and append to tr
      let tdImgElement = document.createElement('td');
      let imgElement = document.createElement('img');
      imgElement.src = jsonObj.img;
      tdImgElement.appendChild(imgElement);
      
      let tdNameElement = document.createElement('td');
      let nameElement = document.createElement('p');
      nameElement.textContent = jsonObj.name;
      tdNameElement.appendChild(nameElement);

      let tdPriceElement = document.createElement('td');
      let priceElement = document.createElement('p');
      priceElement.textContent = Number(jsonObj.price);
      tdPriceElement.appendChild(priceElement);

      let tdFactorElement = document.createElement('td');
      let factorElement = document.createElement('p');
      factorElement.textContent = Number(jsonObj.decFactor);
      tdFactorElement.appendChild(factorElement);

      let tdInputElement = document.createElement('td');
      let inputElement = document.createElement('input');
      inputElement.type = 'checkbox';
      tdInputElement.appendChild(inputElement);

      newTrElement.appendChild(tdImgElement);
      newTrElement.appendChild(tdNameElement);
      newTrElement.appendChild(tdPriceElement);
      newTrElement.appendChild(tdFactorElement);
      newTrElement.appendChild(tdInputElement);
     //append tr to tbody
      tbodyElement.appendChild(newTrElement);
    }
  });

  //add event listener for buy button
  buyButtonElement.addEventListener('click', function(){
    //get checked items
    let checkedItemElements = Array.from(document.querySelectorAll('tbody > tr'))
      .filter(element => {
        let inputItem = element.querySelector('input[type="checkbox"]');
        if(inputItem.checked){
          return element;
        }
      });
      //select their names
      let boughtItems = checkedItemElements.map(element => {
        let nameItem = element.querySelector('td > p');
        return nameItem.textContent;
      })

      let outputElement = document.querySelector('textarea:last-of-type');
      outputElement.value += `Bought furniture: ${boughtItems.join(', ')}\n`;
      //select their price and sum 
      let totalPrice = checkedItemElements
      .map(element => {
        return Number(element.querySelector('td:nth-child(3) > p').textContent);
      })
      .reduce((result, price) => result + price, 0).toFixed(2);
      outputElement.value += `Total price: ${totalPrice}\n`;
      //select their factor and sum
      let averageFactor = checkedItemElements
      .map(element => {
        return Number(element.querySelector('td:nth-child(4) > p').textContent);
      })
      .reduce((result, price) => result + price, 0) / checkedItemElements.length;
      outputElement.value += `Average decoration factor: ${averageFactor}`
  })
}

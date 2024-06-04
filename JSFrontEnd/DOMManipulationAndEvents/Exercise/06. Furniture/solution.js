function solve() {
  let tbodyElement = document.querySelector("tbody");
  let inputElement = document.querySelector("textarea:first-of-type");
  let generateButtonElement = document.querySelector("button:first-of-type");
  let buyButtonElement = document.querySelector("button:last-of-type");

  generateButtonElement.addEventListener("click", function () {
    let parsedInput = JSON.parse(inputElement.value);
    for(const jsonObj of parsedInput){
      let newTrElement = document.createElement('tr');

      let tdImgElement = document.createElement('td');
      let imgElement = document.createElement('img');
      imgElement.src = jsonObj.img;
      tdImgElement.appendChild(imgElement);
      
      let tdNameElement = document.createElement('tr');
      let nameElement = document.createElement('p');
      nameElement.textContent = jsonObj.name;
      tdNameElement.appendChild(nameElement);

      let tdPriceElement = document.createElement('tr');
      let priceElement = document.createElement('p');
      priceElement.textContent = Number(jsonObj.price);
      tdPriceElement.appendChild(priceElement);

      let tdFactorElement = document.createElement('tr');
      let factorElement = document.createElement('p');
      factorElement.textContent = Number(jsonObj.decFactor);
      tdFactorElement.appendChild(factorElement);

      let tdInputElement = document.createElement('tr');
      let inputElement = document.createElement('input');
      inputElement.type = 'checkbox';
      tdInputElement.appendChild(inputElement);

      newTrElement.appendChild(tdImgElement);
      newTrElement.appendChild(tdNameElement);
      newTrElement.appendChild(tdPriceElement);
      newTrElement.appendChild(tdFactorElement);
      newTrElement.appendChild(tdInputElement);

      newTrElement.style.display = 'inline-block';

      tbodyElement.appendChild(newTrElement);
    }
  });
}

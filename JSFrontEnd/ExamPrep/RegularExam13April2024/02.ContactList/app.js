window.addEventListener("load", solve);

function solve() {
   //target add btn and add its functionality
   let addBtnElement = document.getElementById('add-btn');
   addBtnElement.addEventListener('click', function(event){
    event.preventDefault();
    let nameInputElement = document.getElementById('name');
    let numberInputElement = document.getElementById('phone');
    let categorySelectElement = document.getElementById('category');

    //if any of the input fields is empty, don`t do anything
    if(nameInputElement.value.length === 0 ||
      numberInputElement.value.length === 0 ||
      categorySelectElement.value === ''
    ){
      return;
    }

    let checkListElement = document.getElementById('check-list');
    //create all needed elements 
    let newLiElement = document.createElement('li');
    let newArticleElement = document.createElement('article');
    let newParagraphNameElement = document.createElement('p');
    newParagraphNameElement.textContent = 'name:' + nameInputElement.value;
    let newParagraphNumberElement = document.createElement('p');
    newParagraphNumberElement.textContent = 'phone:' + numberInputElement.value;
    let newParagraphCategoryElement = document.createElement('p');
    newParagraphCategoryElement.textContent = 'category:' + categorySelectElement.value;
    newArticleElement.appendChild(newParagraphNameElement);
    newArticleElement.appendChild(newParagraphNumberElement);
    newArticleElement.appendChild(newParagraphCategoryElement);
    newLiElement.appendChild(newArticleElement);

    let newDivBtnElement = document.createElement('div');
    newDivBtnElement.classList.add('buttons');
    let editBtnElement = document.createElement('button');
    editBtnElement.classList.add('edit-btn');
    let saveBtnElement = document.createElement('button');
    saveBtnElement.classList.add('save-btn');
    newDivBtnElement.appendChild(editBtnElement);
    newDivBtnElement.appendChild(saveBtnElement);
    newLiElement.appendChild(newDivBtnElement);

    checkListElement.appendChild(newLiElement);
   })
  }
  
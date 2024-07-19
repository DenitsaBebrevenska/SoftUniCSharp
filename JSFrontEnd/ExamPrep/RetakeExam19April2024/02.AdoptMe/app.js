window.addEventListener("load", solve);

function solve() {
  //target needed elements 
  let typeInputElement = document.getElementById('type');
  let ageInputElement = document.getElementById('age');
  let genderInputElement = document.getElementById('gender');
  let adoptBtnElement = document.getElementById('adopt-btn');
  let adoptionInfoElement = document.getElementById('adoption-info');
  //add click event
  adoptBtnElement.addEventListener('click', function(event){
    event.preventDefault();
    //all fields must have input
    if(typeInputElement.value.length > 0 &&
       ageInputElement.value.length > 0 &&
       genderInputElement.value.length > 0){
        //create all needed elements and append text and classes accordingly and append children
        let newLiElement = document.createElement('li');
        let newArticleElement = document.createElement('article');
        let petTypeElement = document.createElement('p');
        let petGenderElement = document.createElement('p');
        let petAgeElement = document.createElement('p');
        petTypeElement.textContent = `Pet: ${typeInputElement.value}`;
        petGenderElement.textContent = `Gender: ${genderInputElement.value}`;
        petAgeElement.textContent = `Age: ${ageInputElement.value}`;
        newArticleElement.appendChild(petTypeElement);
        newArticleElement.appendChild(petGenderElement);
        newArticleElement.appendChild(petAgeElement);
        let divBtnElement = document.createElement('div');
        divBtnElement.classList.add('buttons');
        let editBtnElement = document.createElement('button');
        editBtnElement.classList.add('edit-btn');
        editBtnElement.textContent = 'Edit';
        let doneBtnElement = document.createElement('button');
        doneBtnElement.classList.add('done-btn');
        doneBtnElement.textContent = 'Done';
        divBtnElement.appendChild(editBtnElement);
        divBtnElement.appendChild(doneBtnElement);
        newLiElement.appendChild(newArticleElement);
        newLiElement.appendChild(divBtnElement);
        //append new animal the adoption info
        adoptionInfoElement.appendChild(newLiElement);
        //clear input fields
        petTypeElement.value = '';
        petGenderElement.value = '';
        petAgeElement.value = '';
       }
  })
  }
  
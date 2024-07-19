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
    event.preventDefault(); //Judge could kick me bcs of this
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
        //keeping the values of the inputs as variables so I can use later easily with edit btn functionality
        let petType = typeInputElement.value;
        let petAge = ageInputElement.value;
        let petGender = genderInputElement.value;
        petTypeElement.textContent = `Pet:${petType}`;
        petGenderElement.textContent = `Gender:${petAge}`;
        petAgeElement.textContent = `Age:${petGender}`;
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
        //append new animal to the adoption info
        adoptionInfoElement.appendChild(newLiElement);
        //clear input fields
        typeInputElement.value = '';
        ageInputElement.value = '';
        genderInputElement.value = '';
        //add edit btn functionality
        editBtnElement.addEventListener('click', function(){
          adoptionInfoElement.removeChild(newLiElement);
          typeInputElement.value = petType;
          ageInputElement.value = petAge;
          genderInputElement.value = petGender;
        })
        //add done btn functionality
        doneBtnElement.addEventListener('click', function(){

        })
       }
  })

  //add click events for all buttons on adoption-info list
  let adoptionInfoListElements = document.querySelectorAll('#adoption-info > li');
  adoptionInfoListElements.forEach(listItem =>{
    //edit button functionality
    listItem.querySelector('button.edit-btn').addEventListener('click', function(){
      console.log(listItem.querySelector('p:first-child').textContent);
      typeInputElement.value = listItem.querySelector('p:first-child').textContent.split(':')[1];
    })
  })
  }
  
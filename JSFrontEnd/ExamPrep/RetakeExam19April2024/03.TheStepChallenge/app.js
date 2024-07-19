let recordsUrl = 'http://localhost:3030/jsonstore/records/';

//target all needed elements from the html
let recordsListElement = document.querySelector('#list');

//fetching all elements and listing them
async function listAllRecords(){
    //remove existing li items if any
    recordsListElement.innerHTML = '';
    //get records
    try{
        const response = await fetch(recordsUrl);
        const responseData = await response.json();
        let fragment = document.createDocumentFragment();
        Object.values(responseData)
            .forEach(entry => {
                let recordItemElement = document.createElement('li');
                recordItemElement.classList.add('record');
                let infoDivElement = document.createElement('div');
                infoDivElement.classList.add('info');
                let nameParagraph = document.createElement('p');
                nameParagraph.textContent = entry.name;
                let stepsParagraph = document.createElement('p');
                stepsParagraph.textContent = entry.steps;
                let caloriesParagraph = document.createElement('p');
                caloriesParagraph.textContent = entry.calories;
                infoDivElement.appendChild(nameParagraph);
                infoDivElement.appendChild(stepsParagraph);
                infoDivElement.appendChild(caloriesParagraph);
                let buttonDivElement = document.createElement('div');
                buttonDivElement.classList.add('btn-wrapper');
                let changeBtnElement = document.createElement('button');
                changeBtnElement.classList.add('change-btn');
                changeBtnElement.textContent = 'Change';
                let deleteBtnElement = document.createElement('button');
                deleteBtnElement.classList.add('delete-btn');
                deleteBtnElement.textContent = 'Delete';
                buttonDivElement.appendChild(changeBtnElement);
                buttonDivElement.appendChild(deleteBtnElement);
                recordItemElement.appendChild(infoDivElement);
                recordItemElement.appendChild(buttonDivElement);
                fragment.appendChild(recordItemElement);
            });

        recordsListElement.appendChild(fragment);
        
    }catch(error){
        console.log(error);
    }
}

listAllRecords();
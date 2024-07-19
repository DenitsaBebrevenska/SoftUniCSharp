let recordsUrl = 'http://localhost:3030/jsonstore/records/';

//target all needed elements from the html
let recordsListElement = document.querySelector('#list');
let loadRecordsBtnElement = document.getElementById('load-records');
let addRecordBtnElement = document.getElementById('add-record');
let inputNameElement = document.getElementById('p-name');
let inputStepsElement = document.getElementById('steps');
let inputCaloriesElement = document.getElementById('calories');

//remove existing sample li element
recordsListElement.innerHTML = '';

//attach event to load btn
loadRecordsBtnElement.addEventListener('click', listAllRecords);

//fetching all elements and listing them
async function listAllRecords(){
    //remove existing li elements if any
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

addRecordBtnElement.addEventListener('click', async function(event){
    event.preventDefault();
    try {
        const postResponse = await fetch(recordsUrl, {
            method: 'POST',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({
                name: inputNameElement.value,
                steps: inputStepsElement.value,
                calories: inputCaloriesElement.value
            })
        })
        
        //the server basically creates it all even without proper headers and json
        if(!postResponse.ok){
            throw new Error('Error adding record!');
        }

        //refresh records and clear up inputs
        listAllRecords();
        inputNameElement.value = '',
        inputStepsElement.value = '',
        inputCaloriesElement.value = '';
    } catch(error){
        console.log(error);
    }
    
})

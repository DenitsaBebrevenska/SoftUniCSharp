let recordsUrl = 'http://localhost:3030/jsonstore/records/';

//target all needed elements from the html
let recordsListElement = document.querySelector('#list');
let loadRecordsBtnElement = document.getElementById('load-records');
let addRecordBtnElement = document.getElementById('add-record');
let editRecordBtnElement = document.getElementById('edit-record');
let inputNameElement = document.getElementById('p-name');
let inputStepsElement = document.getElementById('steps');
let inputCaloriesElement = document.getElementById('calories');

//remove existing sample li element in records list
recordsListElement.innerHTML = '';

//attach event listener to load btn
loadRecordsBtnElement.addEventListener('click', listAllRecords);

//a function to clear up inputs
function clearUpInputs(){
    inputNameElement.value = '',
    inputStepsElement.value = '',
    inputCaloriesElement.value = '';
}
//fetch all elements and list them
async function listAllRecords(){
    //remove existing li elements if any
    recordsListElement.innerHTML = '';  
    //get records
    try{
        const response = await fetch(recordsUrl);
        const responseData = await response.json();
        let fragment = document.createDocumentFragment();
        //for each record create needed html elements and append
        Object.values(responseData)
            .forEach(entry => {
                let recordItemElement = document.createElement('li');
                recordItemElement.classList.add('record');
                recordItemElement.id = entry._id;
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
                //once all is created attaching event listeners for the btns
                //click event for the change btn
                changeBtnElement.addEventListener('click', async function(){
                    //put text into the input elements
                    inputNameElement.value = entry.name,
                    inputStepsElement.value = entry.steps,
                    inputCaloriesElement.value = entry.calories;
                    //deactivate add record btn and active edit record
                    addRecordBtnElement.disabled = 'true';
                    editRecordBtnElement.removeAttribute('disabled');
                    //add the record unique id to the edit btn
                    editRecordBtnElement.setAttribute('data-id', entry._id);
                })
                //click event for delete btn
                deleteBtnElement.addEventListener('click', async function(){
                    const deleteResponse = await fetch(recordsUrl + entry._id, {
                        method: 'DELETE'
                    });

                    if(deleteResponse.ok){
                        listAllRecords();
                    }
                })
            });

        recordsListElement.appendChild(fragment);
        
    }catch(error){
        console.log(error);
    }
}

//add record btn functionality
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
        clearUpInputs();
       
    } catch(error){
        console.log(error);
    }
    
})

//add click event for the edit btn
editRecordBtnElement.addEventListener('click', async function(){
    try{
        console.log(editRecordBtnElement.getAttribute('data-id'));
        const putResponse = await fetch(recordsUrl + editRecordBtnElement.getAttribute('data-id'), {
            method: 'PUT',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({
                name: inputNameElement.value,
                steps: inputStepsElement.value,
                calories: inputCaloriesElement.value,
                _id: editRecordBtnElement.getAttribute('data-id')
            })
        });
        
        if(putResponse.ok){
            //refresh list
            listAllRecords();
            //remove id from the edit btn and disable it
            editRecordBtnElement.disabled = 'true';
            editRecordBtnElement.removeAttribute('data-id');
            //clear up inputs
           clearUpInputs();
            //enable add record btn
            addRecordBtnElement.removeAttribute('disabled');
        } else {
            throw new Error(putResponse.statusText);
        }
    }catch(error){
        console.log(error);
    }
})

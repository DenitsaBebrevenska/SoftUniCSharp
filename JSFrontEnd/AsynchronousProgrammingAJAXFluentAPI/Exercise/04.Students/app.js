function attachEvents() {
  let url = 'http://localhost:3030/jsonstore/collections/students';
  let tableBodyElement = document.querySelector('#results > tbody');

  fetch(url)
  .then((response) => response.json())
  .then((data) => {
    let fragment = document.createDocumentFragment();

    Object.values(data).forEach(entry => {
      let newTrElement = document.createElement('tr');
      let tdFirstName = document.createElement('td');
      let tdLastName = document.createElement('td');
      let tdNumber = document.createElement('td');
      let tdGrade = document.createElement('td');

      tdFirstName.textContent = entry.firstName;
      tdLastName.textContent = entry.lastName;
      tdNumber.textContent = entry.facultyNumber;
      tdGrade.textContent = entry.grade;

      newTrElement.appendChild(tdFirstName);
      newTrElement.appendChild(tdLastName);
      newTrElement.appendChild(tdNumber);
      newTrElement.appendChild(tdGrade);

      fragment.appendChild(newTrElement);
    })

    tableBodyElement.appendChild(fragment);
  })
  .catch((error) => console.log(error))

  let submitButtonElement = document.getElementById('submit');
  let inputFirstNameElement = document.querySelector('input[name=firstName]');
  let inputLastNameElement = document.querySelector('input[name=lastName]');
  let inputFacultyNumberElement = document.querySelector('input[name=facultyNumber]');
  let inputGradeElement = document.querySelector('input[name=grade]');

  submitButtonElement.addEventListener('click', async function(){
    try{
      let newEntry = JSON.stringify({
        firstName: inputFirstNameElement.value,
        lastName: inputLastNameElement.value,
        facultyNumber: inputFacultyNumberElement.value,
        grade: Number(inputGradeElement.value)
      });

      let tdFirstName = document.createElement('td');
      let tdLastName = document.createElement('td');
      let tdNumber = document.createElement('td');
      let tdGrade = document.createElement('td');

      tdFirstName.textContent = inputFirstNameElement.value;
      tdLastName.textContent = inputLastNameElement.value;
      tdNumber.textContent = inputFacultyNumberElement.value;
      tdGrade.textContent = Number(inputGradeElement.value);

      let trElement = document.createElement('tr');
      trElement.appendChild(tdFirstName);
      trElement.appendChild(tdLastName);
      trElement.appendChild(tdNumber);
      trElement.appendChild(tdGrade);

      tableBodyElement.appendChild(trElement);

      inputFirstNameElement.value = "";
      inputLastNameElement.value = "";
      inputFacultyNumberElement.value = "";
      inputGradeElement.value = "";

      const requestOptions = {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: newEntry,
      };

      const postResponse = await fetch(url, requestOptions);
      const postData = await postResponse.json();
    } catch (error){
      console.log(error);
    }})
}

attachEvents();
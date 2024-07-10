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

  fetch(url)
  .then((postResponse) => postResponse.json())
  .then()
}

attachEvents();
//todo logout started failing, adding new catch fails at seeming autorization

//urls
let allCatchesUrl = 'http://localhost:3030/data/catches';
//hide catches and add text
let catchesElement = document.getElementById('catches');
catchesElement.style.display = 'none';
let legendElement = document.querySelector('legend');
legendElement.style.display = 'none';
let mainElement = document.getElementById('main');
let mainInitialTextElement = document.createElement('p');
mainInitialTextElement.textContent = 'Click to load catches';
mainElement.appendChild(mainInitialTextElement);
mainElement.style.border = 'none';
let loadBtnElement = document.querySelector('button.load');
//add load event upon click
loadBtnElement.addEventListener('click', async function () {
  //display hidden elements and hide text
  mainInitialTextElement.style.display = 'none';
  legendElement.style.display = 'block';
  mainElement.style.border = '2px solid black';
  //load all catches
  try {
    const getResponse = await fetch(allCatchesUrl);
    const responseData = await getResponse.json();
    //copy sample catch div
    let sampleCatchDiv = document.querySelector('#catches > div.catch');
    //empty the catches
    catchesElement.innerHTML = '';
    //create divs for each catch object
    responseData.forEach((entry) => {
      let clonedCatchDiv = sampleCatchDiv.cloneNode(true);
      clonedCatchDiv.querySelector('input.angler').value = entry.angler;
      clonedCatchDiv.querySelector('input.weight').value = entry.weight;
      clonedCatchDiv.querySelector('input.species').value = entry.species;
      clonedCatchDiv.querySelector('input.location').value = entry.location;
      clonedCatchDiv.querySelector('input.bait').value = entry.bait;
      clonedCatchDiv.querySelector('input.captureTime').value =
        entry.captureTime;
      clonedCatchDiv.querySelector('button.update').value = entry._id;
      clonedCatchDiv.querySelector('button.delete').value = entry._id;
      catchesElement.appendChild(clonedCatchDiv);
    });
    catchesElement.style.display = 'inline-block';
  } catch (error) {
    throw new Error('Failed to load catches ' + error.message);
  }
});

//if user is logged in pressing logout will log them out and they have extra functionality on their catches
let token = localStorage.getItem('userToken');
let logoutBtnElement = document.getElementById('logout');
let usernameElement = document.querySelector('p.email > span');
//when user is log in
if (token) {
  //hide inappropriate buttons register and login for logged in users
  document.getElementById('register').style.display = 'none';
  document.getElementById('login').style.display = 'none';
  //set username in welcoming message
  let username = localStorage.getItem('userEmail');
  usernameElement.textContent = username.slice(1, username.length - 1);
  //add event listener for logout button
  logoutBtnElement.addEventListener('click', async function () {
    let logoutUrl = 'http://localhost:3030/users/logout';
    let userToken = localStorage.getItem('userToken').replace(/^"|"$/g, "");
    try {
      const getResponse = await fetch(logoutUrl, {
        method: 'GET',
        headers: {
          'X-Authorization': userToken
        },
      });

      if (!getResponse.ok) {
        const reponseData = await getResponse.json();
        throw new Error('Error logging out! ' + reponseData.message);
      }

      //remove user data, switch username to guest and redirect to home to reload the page
      localStorage.removeItem('userToken');
      localStorage.removeItem('userEmail');
      usernameElement.textContent = 'guest';
      window.location.href = 'index.html';
    } catch (error) {
      console.error('Logout failed:', error);
    }
  });
  //adding new catch for all logged users
  let addBtnElement = document.querySelector('form#addForm button.add');
  addBtnElement.removeAttribute('disabled');
  addBtnElement.addEventListener('click', async function (event) {
    event.preventDefault();
    let anglerName = document.querySelector('#addForm input.angler').value;
    let catchWeight = document.querySelector('#addForm input.weight').value;
    let catchSpecies = document.querySelector('#addForm input.species').value;
    let catchLocation = document.querySelector('#addForm input.location').value;
    let usedBait = document.querySelector('#addForm input.bait').value;
    let catchCaptureTime = document.querySelector(
      '#addForm input.captureTime'
    ).value;
    const addedCatch = {
      angler: anglerName,
      weight: Number(catchWeight),
      species: catchSpecies,
      location: catchLocation,
      bait: usedBait,
      captureTime: Number(catchCaptureTime),
    };

    try {
      const postResponse = await fetch(allCatchesUrl, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'X-Authorization': localStorage.getItem('userToken'),
        },
        body: JSON.stringify(addedCatch),
      });

      if (!postResponse.ok) {
        throw new Error('Adding new catch failed!');
      }

      const postResponseData = await postResponse.json();
      console.log('Successfully added catch!', postResponseData);
      window.location.href = 'index.html';
    } catch (error) {
      console.log(error);
    }
  });
} else {
  //when user is not logged in
  //remove logout
  logoutBtnElement.style.display = 'none';
  //disable all buttons a guest user cannot click
  document.querySelectorAll('.update').forEach((button) => {
    button.disabled = 'true';
  });
  document.querySelectorAll('.delete').forEach((button) => {
    button.disabled = 'true';
  });
}

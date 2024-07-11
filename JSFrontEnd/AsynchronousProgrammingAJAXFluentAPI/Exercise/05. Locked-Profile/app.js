function lockedProfile() {
    let mainElement = document.getElementById('main');
    //remove sample card
    mainElement.innerHTML = '';

    //make a get request and handle the data by creating cards for each entry
    let url = 'http://localhost:3030/jsonstore/advanced/profiles';
    
    fetch(url)
    .then(getResponse => getResponse.json())
    .then(data => {
        let fragment = document.createDocumentFragment();

        Object.values(data).forEach(entry => {
            //create div
            let divElement = document.createElement('div');
            divElement.classList.add('profile');
            //create img and append to div
            let imgElement = document.createElement('img');
            imgElement.src = "./iconProfile2.png";
            imgElement.classList.add('userIcon');
            divElement.appendChild(imgElement);
            //create label and lock and append to div
            let lockElement = document.createElement('label');
            lockElement.textContent = 'Lock'
            divElement.appendChild(lockElement);
            let inputRadioLockElement = document.createElement('input');
            inputRadioLockElement.type = 'radio';
            inputRadioLockElement.name = entry.username;
            inputRadioLockElement.value = 'lock';
            inputRadioLockElement.checked = true;
            divElement.appendChild(inputRadioLockElement);
            //create label and unlock and append to div
            let unlockElement = document.createElement('label');
            unlockElement.textContent = 'Unlock'
            divElement.appendChild(unlockElement);
            let inputRadioUnlockElement = document.createElement('input');
            inputRadioUnlockElement.type = 'radio';
            inputRadioUnlockElement.name = entry.username;
            inputRadioUnlockElement.value = 'unlock';
            divElement.appendChild(inputRadioUnlockElement);
            //append br and hr element
            let brElement = document.createElement('br');
            let firstHrElement = document.createElement('hr');
            divElement.appendChild(brElement);
            divElement.appendChild(firstHrElement);
            //create username element and append to div
            let usernameLabelElement = document.createElement('label');
            usernameLabelElement.textContent = 'Username';
            divElement.appendChild(usernameLabelElement);
            let usernameInputElement = document.createElement('input');
            usernameInputElement.type = 'text';
            usernameInputElement.name = entry.username;
            usernameInputElement.value = entry.username;
            usernameInputElement.disabled = true;
            usernameInputElement.readOnly = true;
            divElement.appendChild(usernameInputElement);
            //create div hidden elements
            let divHiddenElement = document.createElement('div');
            divHiddenElement.classList.add(entry.username);
            divHiddenElement.style.display = 'none';
            //create and append to div hidden the required children
            let secondHrElement = document.createElement('hr');
            divElement.appendChild(secondHrElement);
            let emailLabelElement = document.createElement('label');
            emailLabelElement.textContent = 'Email:';
            divHiddenElement.appendChild(emailLabelElement);
            let inputEmailElement = document.createElement('input');
            inputEmailElement.type = 'email';
            inputEmailElement.name = entry.username + 'Email';
            inputEmailElement.value = entry.email;
            inputEmailElement.disabled = true;
            inputEmailElement.readOnly = true;
            divHiddenElement.appendChild(inputEmailElement);
            let ageLabelElement = document.createElement('label');
            ageLabelElement.textContent = 'Age:';
            divHiddenElement.appendChild(ageLabelElement);
            let inputAgeElement = document.createElement('input');
            inputAgeElement.type = 'text';
            inputAgeElement.name = entry.username + 'Age';
            inputAgeElement.value = entry.age; // toString?
            inputAgeElement.disabled = true;
            inputAgeElement.readOnly = true;
            divHiddenElement.appendChild(inputAgeElement);
            //append hidden div to profile div
            divElement.appendChild(divHiddenElement);
            //create and append show more button
            let showMoreBtnElement = document.createElement('button');
            showMoreBtnElement.textContent = 'Show more';
            //add click event for show more btn
            showMoreBtnElement.addEventListener('click', function(e){
                if(inputRadioUnlockElement.checked === true){
                    showMoreBtnElement.style.display = 'none';
                    divHiddenElement.style.display = 'block';
                    let hideItBtnElement = document.createElement('button');
                    hideItBtnElement.textContent = 'Hide it';
                    divElement.appendChild(hideItBtnElement);
                    //add click event for hide it
                    hideItBtnElement.addEventListener('click', function(ev){
                        if(inputRadioUnlockElement.checked === true){
                            showMoreBtnElement.style.display = 'block';
                            divHiddenElement.style.display = 'none';
                            hideItBtnElement.style.display = 'none';
                        }
                    })
                }
            })
            divElement.appendChild(showMoreBtnElement);
            //add to fragment
            fragment.appendChild(divElement);
        })

        //append fragment to main
        mainElement.appendChild(fragment);
    })
    .catch(error => console.log(error));

}
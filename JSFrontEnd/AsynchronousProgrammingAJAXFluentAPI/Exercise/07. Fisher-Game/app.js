//CRUD base url
const crudUrl = 'http://localhost:3030/data/catches';
//target views and main window
let mainElement = document.querySelector('main');
let viewsElement = document.getElementById('views');
//views is always hidden
viewsElement.style.display = 'none';
//target different views
let registerViewElement = document.getElementById('register-view');
let loginViewElement = document.getElementById('login-view');
let homeViewElement = document.getElementById('home-view');
//target nav all btns
let homeBtnElement = document.getElementById('home');
let userBtnElements = document.getElementById('user');
let guestBtnElements = document.getElementById('guest');
let logoutBtnElement = document.getElementById('logout');
let loginBtnElement = document.getElementById('login');
let registerBtnElement = document.getElementById('register');
//At first the current active btn and active view is always home
let currentActiveBtn = homeBtnElement;
mainElement.appendChild(homeViewElement);
//add render catches event
renderCatches();
//target add catch btn
let addBtnElement = document.querySelector('#addForm > fieldset > button.add');
//all btns on click change the class active to the btn clicked and change active view accordingly
Array.from(document.querySelectorAll('nav a'))
    .forEach(btn => {
        btn.addEventListener('click', function(){
            currentActiveBtn.classList.remove('active');
            currentActiveBtn = btn;
            btn.classList.add('active');
            switchBetweenViews();
        })
    })

//is the user logged?
let isLoggedUser = localStorage.getItem('userToken');

//if the user is logged, hide guest butns and vice versa
if(isLoggedUser){
    guestBtnElements.style.display = 'none';
    userBtnElements.style.display = 'inline-block';
    //and display username
    let usernameSpanElement = document.querySelector('.email > span');
    usernameSpanElement.textContent = localStorage.getItem('username');
    //get logout function
    logout();
    //enable add catches
    addBtnElement.removeAttribute('disabled');
    addBtnElement.addEventListener('click', async function(event){
        event.preventDefault();
        try{
            const postResponse = await fetch(crudUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization' : localStorage.getItem('userToken')
                },
                body: JSON.stringify({
                    "angler": document.querySelector('#addForm input[name=angler]').value,
                    "weight": document.querySelector('#addForm input[name=weight]').value,
                    "species": document.querySelector('#addForm input[name=species]').value,
                    "location": document.querySelector('#addForm input[name=location]').value,
                    "bait": document.querySelector('#addForm input[name=bait]').value,
                    "captureTime": document.querySelector('#addForm input[name=captureTime]').value
                })
            });
            const responseData = await postResponse.json();

            if(!postResponse.ok){
                throw new Error(responseData.message);
            }

            localStorage.setItem('userId', responseData._ownerId);
            window.location.href = 'index.html';
        }catch(error){
            console.error(error);
        }
    })
} else {
    userBtnElements.style.display = 'none';
    guestBtnElements.style.display = 'inline-block';
    //switch to guest username
    userBtnElements.textContent = 'guest';
}

function switchBetweenViews(){
    if(currentActiveBtn === homeBtnElement){
        mainElement.innerHTML = '';
        mainElement.appendChild(homeViewElement);
    } else if (currentActiveBtn === loginBtnElement){
        mainElement.innerHTML = '';
        mainElement.appendChild(loginViewElement);
        login();
    } else if (currentActiveBtn === registerBtnElement){
        mainElement.innerHTML = '';
        mainElement.appendChild(registerViewElement);
        registerUser();
    }
}

function login(){
    document.querySelector('#login > button').addEventListener('click', async function(event){
        event.preventDefault();
        let emailInputElement = document.querySelector('#login input[name=email]');
        let passwordInputElement = document.querySelector('#login input[name=password]');
        const postUrl = 'http://localhost:3030/users/login';
    
        try{
            const postResponse = await fetch(postUrl, {
                method: 'POST',
                headers: {
                    'Content-Type' : 'application/json'
                },
                body: JSON.stringify({
                    email: emailInputElement.value,
                    password: passwordInputElement.value
                })
            })

            const repsonseData = await postResponse.json();

            if(!postResponse.ok){
                emailInputElement.value = '';
                passwordInputElement.value = '';
                throw new Error(repsonseData.message);
            }
                let username = repsonseData.username;
                let userToken = repsonseData.accessToken;
                
                localStorage.setItem('username', username);
                localStorage.setItem('userToken', userToken);
            
            window.location.href = 'index.html';

        }catch(error){
            document.querySelector('#login p.notification').textContent = error.message;
        }
        })
}

function registerUser(){
    document.querySelector('#register > button').addEventListener('click', async function(event){
        event.preventDefault();
        let emailInputElement = document.querySelector('#register input[name=email]');
        let passwordInputElement = document.querySelector('#register input[name=password]');
        let repeatedPasswordInputElement = document.querySelector('#register input[name=rePass]');
        let email = emailInputElement.value;
        let password = passwordInputElement.value;
        let repeatedPassword = repeatedPasswordInputElement.value;

        try{
        //check input front-end validations
        if(email.length === 0 || 
            password.length === 0 || 
            repeatedPassword.length === 0){
                throw new Error("All fields should be filled in!");
        }

        let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if(!emailPattern.test(email)){
            throw new Error("Invalid email format!");
        }

        if(password !== password){
            throw new Error("The passwords don`t match!");
        }

        let usernameSymbols = email.substring(0, email.indexOf('@'));
        let username = usernameSymbols[0].toUpperCase() + usernameSymbols.slice(1);
        const registerUrl = 'http://localhost:3030/users/register';
        const postResponse = await fetch(registerUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'email': email,
                'password': password,
                'username': username
            })
        })
        
        const responseData = await postResponse.json();

        if(!postResponse.ok){
            throw new Error(responseData.message);
        }

        localStorage.setItem('userToken', responseData.accessToken);
        localStorage.setItem('username', username);
        window.location.href = 'index.html';
    
    }catch(error){
        document.querySelector('#register p.notification').textContent = error.message;
        }
    })
}

function logout(){
    logoutBtnElement.addEventListener('click', async function(event){
        event.preventDefault();
        const logoutUrl = 'http://localhost:3030/users/logout';
        let userToken = localStorage.getItem('userToken');
        try{
            const getResponse  = await fetch(logoutUrl, {
                headers: {
                    'X-Authorization' : userToken
                }
            })

            if(!getResponse.ok){
                throw new Error(getResponse.status);
            } 

            localStorage.removeItem('userToken');
            localStorage.removeItem('username');
            localStorage.removeItem('userId');
            //disable add catch
            addBtnElement.removeAttribute('disabled');
            window.location.href = 'index.html';
        }catch(error){
            console.error('Logout failed: ' + error.message);
        }
    })
}

function renderCatches(){
    let sampleDisabledDiv = document.querySelector('#catches > .catch:nth-child(even)').cloneNode(true);
    //remove sample divs
    document.getElementById('catches').innerHTML = '';
    let loadBtnElement = document.querySelector('aside > button.load');
    loadBtnElement.addEventListener('click', async function(){
        try{
            const getResponse = await fetch(crudUrl);
            const responseData = await getResponse.json();
            let fragment = document.createDocumentFragment();
            responseData.forEach(entry => {
                //clone the sample
                let clonedDiv = sampleDisabledDiv.cloneNode(true);
                //fill in sample element
                clonedDiv.querySelector('input.angler').value = entry.angler;
                clonedDiv.querySelector('input.weight').value = entry.weight;
                clonedDiv.querySelector('input.species').value = entry.species;
                clonedDiv.querySelector('input.location').value = entry.location;
                clonedDiv.querySelector('input.bait').value = entry.bait;
                clonedDiv.querySelector('input.captureTime').value = entry.captureTime;
                clonedDiv.querySelector('button.update').setAttribute('data-id', entry._id);
                clonedDiv.querySelector('button.delete').setAttribute('data-id', entry._id);

                //enable the fields if the owner is logged
                if(localStorage.getItem('userId') === entry._ownerId){
                    clonedDiv.querySelectorAll(':scope > :not(label)')
                        .forEach(element => element.removeAttribute('disabled'));

                    //add click event for the now enabled buttons
                    clonedDiv.querySelector('button.update').addEventListener('click', async function(){
                        try{
                            const putResponse = await fetch(crudUrl + `/${entry._id}`, {
                                method: 'PUT',
                                headers:{
                                    'Content-Type': 'application/json',
                                    'X-Authorization': localStorage.getItem('userToken')
                                },
                                body: JSON.stringify({
                                    'angler': clonedDiv.querySelector('input.angler').value,
                                    'weight': clonedDiv.querySelector('input.weight').value,
                                    'species': clonedDiv.querySelector('input.species').value,
                                    'location': clonedDiv.querySelector('input.location').value,
                                    'bait': clonedDiv.querySelector('input.bait').value,
                                    'captureTime': clonedDiv.querySelector('input.captureTime').value
                                })
                            })

                            if(putResponse.ok){
                                window.location.href = 'index.html';
                            }
                        }catch(error){
                            console.error(error);
                        }
                    })

                    clonedDiv.querySelector('button.delete').addEventListener('click', async function(){
                        try{
                            const putResponse = await fetch(crudUrl + `/${entry._id}`, {
                                method: 'DELETE',
                                headers:{
                                    'Content-Type': 'application/json',
                                    'X-Authorization': localStorage.getItem('userToken')
                                }
                            })

                            if(putResponse.ok){
                                window.location.href = 'index.html';
                            }
                        }catch(error){
                            console.error(error);
                        }
                    })
                }

                fragment.appendChild(clonedDiv);
            });
            document.getElementById('catches').appendChild(fragment);
        }catch(error){
            console.error(error);
        }
    })
}



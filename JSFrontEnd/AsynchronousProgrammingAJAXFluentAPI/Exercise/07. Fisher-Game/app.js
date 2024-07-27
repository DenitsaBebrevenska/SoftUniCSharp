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
            window.location.href = 'index.html';
        }catch(error){
            console.error('Logout failed: ' + error.message);
        }
    })
}

function renderCatches(){
    //let sampleEnabledDiv = document.querySelector('#catches > .catch:first-child').cloneNode(true);
    let sampleDisabledDiv = document.querySelector('#catches > .catch:nth-child(even)').cloneNode(true);
    //remove sample divs
    document.getElementById('#catches').innerHTML = '';
    let loadBtnElement = document.querySelector('aside > button.load');
    loadBtnElement.addEventListener('click', async function(){
        let userToken = localStorage.getItem('userToken');
        const catchesUrl = 'http://localhost:3030/data/catches';
        try{
            const getResponse = await fetch(catchesUrl);
            const responseData = await getResponse.json();
            let fragment = document.createDocumentFragment();
            responseData.forEach(entry => {
                //fill in sample element
                sampleDisabledDiv.querySelector('input.angler').value = entry.angler;
                sampleDisabledDiv.querySelector('input.weight').value = entry.weight;
                sampleDisabledDiv.querySelector('input.species').value = entry.species;
                sampleDisabledDiv.querySelector('input.location').value = entry.location;
                sampleDisabledDiv.querySelector('input.bait').value = entry.bait;
                sampleDisabledDiv.querySelector('input.captureTime').value = entry.captureTime;
                sampleDisabledDiv.querySelector('button.update').setAttribute('data-id', entry._id);
                sampleDisabledDiv.querySelector('button.delete').setAttribute('data-id', entry._id);

                //enable the fields if the owner is logged
                if(userToken === entry._ownerId){
                    sampleDisabledDiv.querySelectorAll(':scope > :not(label)')
                        .forEach(element => element.removeAttribute('disabled'));
                }

                fragment.appendChild(sampleDisabledDiv);
            });
            document.getElementById('#catches').appendChild(fragment);
        }catch(error){
            console.error(error);
        }
    })
}


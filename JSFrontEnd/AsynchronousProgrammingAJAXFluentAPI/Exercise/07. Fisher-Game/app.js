//target views and main window
let mainElement = document.querySelector('main');
let viewsElement = document.getElementById('views');
//views is always hidden
viewsElement.style.display = 'none';
//target different views
let registerViewElement = document.getElementById('register-view');
let loginViewElement = document.getElementById('login-view');
let homeViewElement = document.getElementById('home-view');
//target all btns
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
            } else {
                let username = repsonseData.username;
                let userToken = repsonseData.accessToken;
                localStorage.setItem('username', username);
                localStorage.setItem('userToken', userToken);
            }

            window.location.href = 'index.html';

        }catch(error){
            document.querySelector('#login p.notification').textContent = error.message;
        }
        })
}

function registerUser(){
    document.querySelector('#register > button').addEventListener('click', async function(event){
        event.preventDefault();

    })
}

function logout(){
    logoutBtnElement.addEventListener('click', async function(event){
        event.preventDefault();
        const logoutUrl = 'http://localhost:3030/users/logout';
        let userToken = localStorage.getItem('userToken');
        try{
            const postResponse  = await fetch(logoutUrl, {
                method: 'POST',
                headers: {
                    'X-Authorization' : userToken
                }
            })

            if(!postResponse.ok){
                throw new Error(postResponse.status);
            }
        }catch(error){
            console.error('Logout failed: ' + error.message);
        }
    })
}


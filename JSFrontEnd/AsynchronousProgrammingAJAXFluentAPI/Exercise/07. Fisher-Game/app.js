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
    } else if (currentActiveBtn === registerBtnElement){
        mainElement.innerHTML = '';
        mainElement.appendChild(registerViewElement);
    }
}


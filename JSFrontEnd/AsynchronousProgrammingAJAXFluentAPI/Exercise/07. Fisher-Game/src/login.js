async function logIn(){
    //highlight the current element in use
    let homeElement = document.getElementById('home');
    homeElement.classList.remove('active');
    let loginElement = document.getElementById('login');
    loginElement.classList.add('active');

    const logInUrl = 'http://localhost:3030/users/login';
}

logIn();
async function logIn(event){
    event.preventDefault();
    //target needed elements
    const logInUrl = 'http://localhost:3030/users/login';
    let emailInputElememnt = document.querySelector('input[name=email]');
    let passwordInputElement = document.querySelector('input[name=password]');
    let wrongCredentialsElement = document.querySelector('.notification');
    //post reponse handling
        try{
            const credentials = {
                email: emailInputElememnt.value,
                password: passwordInputElement.value
            }
            const postResponse = await fetch(logInUrl,{
                method: 'POST',
                headers: {
                    'Content-Type':'application/json'
                },
                body: JSON.stringify(credentials)
            });

            if(!postResponse.ok){
                throw new Error('Login failed');
            }

            const responseData = await postResponse.json();
            //store the accessToken, never the user`s password in the storage
            localStorage.setItem('userToken', JSON.stringify(responseData.accessToken));
            localStorage.setItem('userEmail', JSON.stringify(responseData.email));
            window.location.href = 'index.html';

        } catch(error){
            wrongCredentialsElement.textContent = error.message + ' Wrong email and/or password!';
            //clear up fields
            emailInputElememnt.value = '';
            passwordInputElement.value = '';
        }
}

//highlight the current element in use, home is by default active
let homeElement = document.getElementById('home');
homeElement.classList.remove('active');
let loginElement = document.getElementById('login');
loginElement.classList.add('active');
let logoutElement = document.getElementById('logout');
logoutElement.style.display = 'none';
//add event listener for the submit button
document.querySelector('form#login > button').addEventListener('click', logIn);
async function register(event){
    event.preventDefault();
    const registertUrl = 'http://localhost:3030/users/register';
    //target needed elements
    let emailElement = document.querySelector('input[name=email]');
    let passwordElement = document.querySelector('input[name=password]');
    let repeatedPasswordElement = document.querySelector('input[name=rePass]');
    
    try{
        //validate if there is any input in the email and password fields
        if(passwordElement.value.length === 0 || emailElement.value.length === 0){
            throw new Error('Invalid email or password!');
        }
        //validate if passwords match
        if(passwordElement.value !== repeatedPasswordElement.value){
            throw new Error('The passwords are not the same!');
        }

        const postResponse = await fetch(registertUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'},
            body: JSON.stringify({
                email: emailElement.value,
                password: passwordElement.value
            })
        })

        const responseData = await postResponse.json();
        //return error message from server
        if(!postResponse.ok){
            throw new Error('Registration failed! ' + responseData.message);
        }

        //store session, just the token, never password as is
        localStorage.setItem('UserData', JSON.stringify(responseData.accessToken));

        window.location.href = 'index.html';
    
    } catch(error){
        document.querySelector('p.notification').textContent = error.message; 
        //clear up form
        emailElement.value = '';
        passwordElement.value = '';
        repeatedPasswordElement.value = '';
    }
}

//highlight the current element in use, home is by default active
let homeElement = document.getElementById('home');
homeElement.classList.remove('active');
let registerElement = document.getElementById('register');
registerElement.classList.add('active');
let logoutElement = document.getElementById('logout');
logoutElement.style.display = 'none';
//add event listener for the register button
document.querySelector('form#register > button').addEventListener('click', register);
const { use } = require("chai");

function solve() {
  let location = window.location.href;
  if (location === "login.html") {
    const baseUrl = " http://localhost:3030/users";
    //login btn functionality
    let loginBtn = document.querySelector('form[action="/login"] > button');
    loginBtn.addEventListener("click", async function (event) {
      event.preventDefault();
      let emailInputElement = document.querySelector(
        'form[action="/login"] input[name=email]'
      );
      let passwordInputElement = document.querySelector(
        'form[action="/login"] input[name=password]'
      );

      try {
        //validate inputs
        if (emailInputElement.value.length === 0 ||
            passwordInputElement.value.length === 0) {
          throw new Error("Password and username cannot be empty");
        }

        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(emailInputElement.value)) {
          throw new Error("Invalid email format!");
        }

        const postResponse = await fetch(baseUrl + "/login", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            email: emailInputElement.value,
            password: passwordInputElement.value,
          }),
        });

        const responseData = await postResponse.json();

        if (!postResponse.ok) {
          throw new Error(responseData.message);
        }

        localStorage.setItem("userToken", responseData.accessToken);
        localStorage.setItem("username", responseData.username);
        localStorage.setItem("userId", responseData._id);
        window.location.href = "homeLogged.html";
      } catch (error) {
        passwordInputElement.value = "";
        emailInputElement.value = "";
        console.error(error);
      }
    });
    //register btn functionality
    let registerBtn = document.querySelector('form[action="/register"] > button');
    registerBtn.addEventListener("click", async function(event){
      event.preventDefault();
      let emailInputElement = document.querySelector('form[action="/register"] input[name=email]');
      let passwordInputElement = document.querySelector('form[action="/register"] input[name=password]');
      let rePasswordInputElement = document.querySelector('form[action="/register"] input[name=rePass]');
      //validate inputs
      try{
        if (emailInputElement.value.length === 0 ||
           passwordInputElement.value.length === 0 ||
           rePasswordInputElement.value.length === 0) {
          throw new Error("All fields must be filled!");
        }

        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(emailInputElement.value)) {
          throw new Error("Invalid email format!");
        }

        if(passwordInputElement.value !== rePasswordInputElement.value){
          throw new Error("Passwords don`t match!");
        }

        let usernameSymbols = email.substring(0, email.indexOf('@'));
        let username = usernameSymbols[0].toUpperCase() + usernameSymbols.slice(1);

        const postResponse = await fetch(baseUrl + '/register', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            email: emailInputElement.value,
            password: passwordInputElement.value,
            username: username
          })
        });

        const responseData = await postResponse.json();

        if(!postResponse.ok){
          throw new Error(responseData.message);
        }

        localStorage.setItem("userToken", responseData.accessToken);
        localStorage.setItem("username", responseData.username);
        localStorage.setItem("userId", responseData._id);
        window.location.href = "homeLogged.html";
      }catch(error){
        emailInputElement.value = '';
        passwordInputElement.value = '';
        rePasswordInputElement.value = '';
        console.error(error);
      }
    });
  }
}

solve();

function solve() {
  let location = windows.location.href;
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
        if (
          emailInputElement.value.length === 0 ||
          passwordInputElement.value.length === 0
        ) {
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
  }
}

solve();

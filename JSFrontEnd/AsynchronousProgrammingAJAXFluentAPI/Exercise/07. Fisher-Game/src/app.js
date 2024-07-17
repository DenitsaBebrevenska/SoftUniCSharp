//hide catches and add text plus add click event to load btn
let catchesElement = document.getElementById("catches");
catchesElement.style.display = "none";
let legendElement = document.querySelector("legend");
legendElement.style.display = "none";
let mainElement = document.getElementById("main");
let mainInitialTextElement = document.createElement('p');
mainInitialTextElement.textContent = "Click to load catches";
mainElement.appendChild(mainInitialTextElement);
mainElement.style.border = "none";
let loadBtnElement = document.querySelector("button.load");

loadBtnElement.addEventListener("click", async function () {
    //display hidden elements
    mainInitialTextElement.style.display = "none";
    legendElement.style.display = "block";
    catchesElement.style.display = "inline-block";
    mainElement.style.border = "2px solid black";
});

//if user is logged in pressing logout will log them out
let token = localStorage.getItem("userToken");
let logoutBtnElement = document.getElementById("logout");
let usernameElement = document.querySelector("p.email > span");

if (token) {
  //hide inappropriate buttons register and login for logged in users
  document.getElementById("register").style.display = "none";
  document.getElementById("login").style.display = "none";
  //set username in welcoming message
  let username = localStorage.getItem("userEmail");
  usernameElement.textContent = username.slice(1, username.length - 1);
  //add event listener for logout button
  logoutBtnElement.addEventListener("click", async function () {
    let logoutUrl = "http://localhost:3030/users/logout";
    let userToken = localStorage.getItem("userToken");
    try {
      await fetch(logoutUrl, {
        method: "GET",
        headers: {
          "X-Authorization": userToken,
        },
      });
    } catch (error) {
      console.error("Logout failed:", error);
    }

    localStorage.removeItem("userToken");
    localStorage.removeItem("userEmail");
    usernameElement.textContent = "guest";
    window.location.href = "index.html";
  });
} else {
  logoutBtnElement.style.display = "none";
  //disable all buttons a guest user cannot click
  document.querySelectorAll(".update").forEach((button) => {
    button.disabled = "true";
  });
  document.querySelectorAll(".delete").forEach((button) => {
    button.disabled = "true";
  });
}

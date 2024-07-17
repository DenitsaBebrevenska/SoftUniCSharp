//urls
let allCatchesUrl = "http://localhost:3030/data/catches";
//hide catches and add text
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
//add load event upon click
loadBtnElement.addEventListener("click", async function () {
    //display hidden elements and hide text
    mainInitialTextElement.style.display = "none";
    legendElement.style.display = "block";
    mainElement.style.border = "2px solid black";
    //load all catches
    try{
      const getResponse = await fetch(allCatchesUrl);
      const responseData = await getResponse.json();
      //copy sample catch div
      let sampleCatchDiv = document.querySelector("#catches > div.catch");
      //empty the catches
      catchesElement.innerHTML = "";
      //create divs for each catch object
      responseData.forEach(entry =>{
        let clonedCatchDiv = sampleCatchDiv.cloneNode(true);
        clonedCatchDiv.querySelector('input.angler').value = entry.angler;
        clonedCatchDiv.querySelector('input.weight').value = entry.weight;
        clonedCatchDiv.querySelector('input.species').value = entry.species;
        clonedCatchDiv.querySelector('input.location').value = entry.location;
        clonedCatchDiv.querySelector('input.bait').value = entry.bait;
        clonedCatchDiv.querySelector('input.captureTime').value = entry.captureTime;
        clonedCatchDiv.querySelector('button.update').value = entry._id;
        clonedCatchDiv.querySelector('button.delete').value = entry._id;
        catchesElement.appendChild(clonedCatchDiv);   
      });
      catchesElement.style.display = "inline-block";
    }catch(error){
      throw new Error("Failed to load catches " + error.message);
    }
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
    //remove user data, switch username to guest and redirect to home to reload the page 
    localStorage.removeItem("userToken");
    localStorage.removeItem("userEmail");
    usernameElement.textContent = "guest";
    window.location.href = "index.html";
  });
} else {
  //remove logout
  logoutBtnElement.style.display = "none";
  //disable all buttons a guest user cannot click
  document.querySelectorAll(".update").forEach((button) => {
    button.disabled = "true";
  });
  document.querySelectorAll(".delete").forEach((button) => {
    button.disabled = "true";
  });
}

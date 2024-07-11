function lockedProfile() {
  let mainElement = document.getElementById("main");
  //hide sample card
  let sampleCardElement = document.querySelector("div.profile:first-of-type");
  sampleCardElement.style.display = "none";
  //make a get request and handle the data by creating cards for each entry
  let url = "http://localhost:3030/jsonstore/advanced/profiles";

  fetch(url)
    .then((getResponse) => getResponse.json())
    .then((data) => {
      let fragment = document.createDocumentFragment();

      Object.values(data).forEach((entry) => {
        let copyCard = sampleCardElement.cloneNode(true);
        copyCard.style.display = "inline-block";
        let lockInputElement = copyCard.querySelector('input[value=lock]');
        lockInputElement.name = 'user' + entry.username + 'Locked';
        let unlockInputElement = copyCard.querySelector('input[value=unlock]');
        unlockInputElement.name = 'user' + entry.username + 'Locked';
        let usernameInputElement = copyCard.querySelector(
          "input[name=user1Username]"
        );
        usernameInputElement.value = entry.username;
        let inputEmailElement = copyCard.querySelector(
          "input[name=user1Email]"
        );
        inputEmailElement.value = entry.email;
        let inputAgeElement = copyCard.querySelector("input[name=user1Age]");
        inputAgeElement.value = entry.age; // toString?
        //hide extra info
        let hiddenInfoElement = copyCard.querySelector('div.user1Username');
        hiddenInfoElement.style.display = 'none';
        let cardBtnElement = copyCard.querySelector("button");
        cardBtnElement.addEventListener("click", async function (e) {
          if (unlockInputElement.checked === true && cardBtnElement.textContent === 'Show more') {
            cardBtnElement.textContent = "Hide it";
            hiddenInfoElement.style.display = "block";
          } else if (unlockInputElement.checked === true && cardBtnElement.textContent === 'Hide it'){
            cardBtnElement.textContent = "Show more";
            hiddenInfoElement.style.display = "none";
          }
        });
        //add to fragment
        fragment.appendChild(copyCard);
      });

      //append fragment to main
      mainElement.appendChild(fragment);
    })
    .catch((error) => console.log(error));
}

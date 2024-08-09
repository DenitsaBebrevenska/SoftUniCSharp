const baseUrl = "http://localhost:3030/jsonstore/games/";
let gamesListElement = document.getElementById("games-list");

//clone the sample game list element and clear up the list
let sampleGameListElement = document
  .querySelector(".board-game")
  .cloneNode(true);
gamesListElement.innerHTML = "";

//add event listener for clicking the load btn
document
  .getElementById("load-games")
  .addEventListener("click", displayGamesList);

//add event listener for clicking the add btn
document
  .getElementById("add-game")
  .addEventListener("click", async function (event) {
    //no validation are required by task, neither the server does any
    event.preventDefault();
    let nameInputElement = document.getElementById("g-name");
    let typeInputElement = document.getElementById("type");
    let playerCountInputElement = document.getElementById("players");

    try {
      const postResponse = await fetch(baseUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          name: nameInputElement.value,
          type: typeInputElement.value,
          players: playerCountInputElement.value,
        }),
      });

      if (!postResponse.ok) {
        throw new Error(postResponse.status);
      }

      displayGamesList();
      nameInputElement.value = "";
      typeInputElement.value = "";
      playerCountInputElement.value = "";
    } catch (error) {
      console.error(error);
    }
  });
//define display Games list function
async function displayGamesList() {
  try {
    const response = await fetch(baseUrl);
    if (!response.ok) {
      throw new Error(response.status);
    }

    const data = await response.json();
    //clear up gamesList if anything is left there
    gamesListElement.innerHTML = "";
    //create frag
    let fragment = document.createDocumentFragment();
    //display all the elements of the response data
    Object.values(data).forEach((element) => {
      //let values = Object.values(element);
      let clonedSample = sampleGameListElement.cloneNode(true);
      clonedSample.querySelector("p:first-child").textContent = element.name;
      clonedSample.querySelector("p:nth-child(even)").textContent =
        element.players;
      clonedSample.querySelector("p:last-child").textContent = element.type;
      fragment.appendChild(clonedSample);
    });
    gamesListElement.appendChild(fragment);
  } catch (error) {
    console.error(error);
  }
}

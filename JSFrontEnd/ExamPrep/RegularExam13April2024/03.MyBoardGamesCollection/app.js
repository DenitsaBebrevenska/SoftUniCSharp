const baseUrl = "http://localhost:3030/jsonstore/games/";
let gamesListElement = document.getElementById("games-list");
let addGameBtnElement = document.getElementById("add-game");
let editGameBtnElement = document.getElementById("edit-game");
let nameInputElement = document.getElementById("g-name");
let typeInputElement = document.getElementById("type");
let playerCountInputElement = document.getElementById("players");

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
addGameBtnElement.addEventListener("click", async function (event) {
  //no validation are required by task, neither the server does any
  event.preventDefault();

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
    clearUpInputFields();
  } catch (error) {
    console.error(error);
  }
});

//add event listener for clicking the edit game btn
editGameBtnElement.addEventListener("click", async function (event) {
  event.preventDefault();
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
      let clonedSample = sampleGameListElement.cloneNode(true);
      clonedSample.querySelector("p:first-child").textContent = element.name;
      clonedSample.querySelector("p:nth-child(even)").textContent =
        element.players;
      clonedSample.querySelector("p:last-child").textContent = element.type;
      fragment.appendChild(clonedSample);
      //add event listeners for both btns
      clonedSample
        .querySelector(".change-btn")
        .addEventListener("click", async function () {
          nameInputElement.value = element.name;
          typeInputElement.value = element.type;
          playerCountInputElement.value = element.players;
          addGameBtnElement.disabled = true;
          editGameBtnElement.removeAttribute("disabled");
          editGameBtnElement.addEventListener("click", async function (event) {
            event.preventDefault();
            try {
              const putResponse = await fetch(baseUrl + element._id, {
                method: "PUT",
                headers: {
                  "Content-Type": "application/json",
                },
                body: JSON.stringify({
                  name: nameInputElement.value,
                  type: typeInputElement.value,
                  players: playerCountInputElement.value,
                  _id: element._id,
                }),
              });

              if (!putResponse.ok) {
                throw new Error(putResponse.status);
              }

              clearUpInputFields();
              displayGamesList();
              addGameBtnElement.removeAttribute("disabled");
              editGameBtnElement.disabled = true;
            } catch (error) {
              console.error(error);
            }
          });
        });
      clonedSample
        .querySelector(".delete-btn")
        .addEventListener("click", async function () {
          try {
            const deleteResponse = await fetch(baseUrl + element._id, {
              method: "DELETE",
            });

            if (!deleteResponse.ok) {
              throw new Error(deleteResponse.status);
            }

            displayGamesList();
          } catch (error) {
            console.error(error);
          }
        });
    });

    gamesListElement.appendChild(fragment);
  } catch (error) {
    console.error(error);
  }
}

function clearUpInputFields() {
  nameInputElement.value = "";
  typeInputElement.value = "";
  playerCountInputElement.value = "";
}

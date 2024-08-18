const baseUrl = "http://localhost:3030/jsonstore/matches";
//target needed elements
let formElement = document.querySelector("div#form > form");
let hostInputElement = document.getElementById("host");
let scoreInputElement = document.getElementById("score");
let guestInputElement = document.getElementById("guest");
let addBtnElement = document.getElementById("add-match");
let editBtnElement = document.getElementById("edit-match");
let loadBtnElement = document.getElementById("load-matches");
let matchesListElement = document.getElementById("list");
//clone sample match element
let sampleElement = document.querySelector("ul#list > li").cloneNode(true);
//clear up the list
matchesListElement.innerHTML = "";

loadBtnElement.addEventListener("click", loadMatches);
addBtnElement.addEventListener("click", function () {
  if (
    hostInputElement.value.length === 0 ||
    scoreInputElement.value.length === 0 ||
    guestInputElement.value.length === 0
  ) {
    console.error("All fields must be filled in!");
    return;
  }

  addMatch();
});
editBtnElement.addEventListener("click", updateMatch);
async function loadMatches() {
  matchesListElement.innerHTML = "";
  try {
    const getResponse = await fetch(baseUrl);

    if (!getResponse.ok) {
      throw new Error("Error loading matches", getResponse.statusText);
    }

    const reponseData = await getResponse.json();
    let fragment = document.createDocumentFragment();
    Object.values(reponseData).forEach((entry) => {
      let clonedMatchElement = sampleElement.cloneNode(true);
      clonedMatchElement.querySelector("p").textContent = entry.host;
      clonedMatchElement.querySelector("p:nth-child(even)").textContent =
        entry.score;
      clonedMatchElement.querySelector("p:last-of-type").textContent =
        entry.guest;

      let changeBtnElement = clonedMatchElement.querySelector(".change-btn");
      changeBtnElement.setAttribute("data-id", entry._id);
      changeBtnElement.addEventListener("click", function (event) {
        let currentMatch = event.target.parentNode.parentNode;
        hostInputElement.value = entry.host;
        scoreInputElement.value = entry.score;
        guestInputElement.value = entry.guest;
        matchesListElement.removeChild(currentMatch);
        editBtnElement.removeAttribute("disabled");
        editBtnElement.setAttribute("data-id", entry._id);
        addBtnElement.disabled = true;
      });

      let deleteBtnElement = clonedMatchElement.querySelector(".delete-btn");
      deleteBtnElement.setAttribute("data-id", entry._id);
      deleteBtnElement.addEventListener("click", deleteMatch);

      fragment.appendChild(clonedMatchElement);
    });

    matchesListElement.appendChild(fragment);
  } catch (err) {
    console.error(err);
  }
}

async function addMatch() {
  try {
    let host = hostInputElement.value;
    let score = scoreInputElement.value;
    let guest = guestInputElement.value;
    const postResponse = await fetch(baseUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        host,
        score,
        guest,
      }),
    });

    if (!postResponse.ok) {
      throw new Error("Error creating match!", postResponse.statusText);
    }

    formElement.reset();
    loadMatches();
  } catch (err) {
    console.error(err);
  }
}

async function updateMatch(event) {
  let dataId = event.target.getAttribute("data-id");
  let host = hostInputElement.value;
  let score = scoreInputElement.value;
  let guest = guestInputElement.value;
  try {
    const putResponse = await fetch(baseUrl + `/${dataId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        host,
        score,
        guest,
        _id: dataId,
      }),
    });

    if (!putResponse.ok) {
      throw new Error("Error updating match", putResponse.statusText);
    }

    editBtnElement.disabled = true;
    editBtnElement.removeAttribute("data-id");
    addBtnElement.removeAttribute("disabled");
    formElement.reset();
    loadMatches();
  } catch (err) {
    console.error(err);
  }
}

async function deleteMatch(event) {
  let dataId = event.target.getAttribute("data-id");

  try {
    const deleteResponse = await fetch(baseUrl + `/${dataId}`, {
      method: "DELETE",
    });

    if (!deleteResponse.ok) {
      throw new Error("Error deleting match", deleteResponse.statusText);
    }

    loadMatches();
  } catch (err) {
    console.error(err);
  }
}

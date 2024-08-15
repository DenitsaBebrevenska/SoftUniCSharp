const baseUrl = "http://localhost:3030/jsonstore/gifts";
let loadBtnElement = document.getElementById("load-presents");
let giftListElement = document.getElementById("gift-list");
let sampleGiftItemElement = document.querySelector(
  "#gift-list > div.gift-sock"
);
let formElement = document.querySelector("#form > form");
let giftInputElement = document.getElementById("gift");
let forInputElement = document.getElementById("for");
let priceInputElement = document.getElementById("price");
let addPresentBtnElement = document.getElementById("add-present");

//clear up sample element
giftListElement.innerHTML = "";

//load btn functionality
loadBtnElement.addEventListener("click", loadPresents);

//add present btn functionality
addPresentBtnElement.addEventListener("click", async function () {
  //no validations are needed per task description
  try {
    const postResponse = await fetch(baseUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        gift: giftInputElement.value,
        for: forInputElement.value,
        price: priceInputElement.value,
      }),
    });

    if (!postResponse.ok) {
      throw new Error("Error creating new present!");
    }

    formElement.reset();
    loadPresents();
  } catch (error) {
    console.error(error);
  }
});

function createGiftItem(obj) {
  let giftItem = sampleGiftItemElement.cloneNode(true);
  giftItem.querySelector(".content > p:first-of-type").textContent = obj.gift;
  giftItem.querySelector(".content > p:nth-child(even)").textContent = obj.for;
  giftItem.querySelector(".content > p:last-of-type").textContent = obj.price;

  let changeBtnElement = giftItem.querySelector("button.change-btn");
  changeBtnElement.setAttribute("data-id", obj._id);
  //add change btn functionality
  changeBtnElement.addEventListener("click", changePresent);
  let deleteBTtnElement = giftItem.querySelector("button.delete-btn");
  deleteBTtnElement.setAttribute("data-id", obj._id);
  //add delete btn functionality
  deleteBTtnElement.addEventListener("click", deletePresent);

  return giftItem;
}

async function loadPresents() {
  //clear up the gift list
  giftListElement.innerHTML = "";
  try {
    const response = await fetch(baseUrl);

    if (!response.ok) {
      throw new Error("Error loading gifts!");
    }

    const responseData = await response.json();
    let fragment = document.createDocumentFragment();

    Object.values(responseData).forEach((value) => {
      let currentGiftItem = createGiftItem(value);
      fragment.appendChild(currentGiftItem);
    });

    giftListElement.appendChild(fragment);
  } catch (error) {
    console.error(error);
  }
}

async function changePresent() {}

async function deletePresent(event) {
  let currrentDeleteBtn = event.currentTarget;

  try {
    const deleteResponse = await fetch(
      baseUrl + `/${currrentDeleteBtn.getAttribute("data-id")}`,
      {
        method: "DELETE",
      }
    );

    if (!deleteResponse.ok) {
      throw new Error("Error deleting the gift!");
    }

    giftListElement.removeChild(currrentDeleteBtn.parentElement.parentElement);
  } catch (error) {
    console.error(error);
  }
}

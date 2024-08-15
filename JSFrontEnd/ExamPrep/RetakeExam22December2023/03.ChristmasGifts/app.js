const baseUrl = "http://localhost:3030/jsonstore/gifts";
let loadBtnElement = document.getElementById("load-presents");
let giftListElement = document.getElementById("gift-list");
let sampleGiftItemElement = document.querySelector(
  "#gift-list > div.gift-sock"
);

//clear up sample element
giftListElement.innerHTML = "";

//load btn functionality
loadBtnElement.addEventListener("click", async function () {
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
});

function createGiftItem(obj) {
  let giftItem = sampleGiftItemElement.cloneNode(true);
  giftItem.querySelector(".content > p:first-of-type").textContent = obj.gift;
  giftItem.querySelector(".content > p:nth-child(even)").textContent = obj.for;
  giftItem.querySelector(".content > p:last-of-type").textContent = obj.price;
  giftItem.querySelector("button.change-btn").setAttribute("data-id", obj._id);
  giftItem.querySelector("button.delete-btn").setAttribute("data-id", obj._id);
  return giftItem;
}

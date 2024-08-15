window.addEventListener("load", solve);

function solve() {
  let taskListElement = document.getElementById("task-list");
  let formElement = document.querySelector("#add-task > form");
  let addBtnElement = document.getElementById("add-btn");
  let placeInputElement = document.getElementById("place");
  let actionInputElement = document.getElementById("action");
  let personInputElement = document.getElementById("person");

  addBtnElement.addEventListener("click", function (event) {
    event.preventDefault();
    //check input
    if (
      placeInputElement.value.length === 0 ||
      actionInputElement.value.length === 0 ||
      personInputElement.value.length === 0
    ) {
      return;
    }

    //create new items and append them accordingly
  });

  function createNewListItem() {
    let newLiElement = document.createElement("li");
    newLiElement.classList.add("clean-task");
    let newArticleElement = document.createElement("article");
    let newPlaceParagraphElement = document.createElement("p");
    newPlaceParagraphElement.textContent = `Place:${placeInputElement.value}`;
    let newActionParagraphElement = document.createElement("p");
    newActionParagraphElement.textContent = `Action:${actionInputElement.value}`;
    let newPersonParagraphElement = document.createElement("p");
    newPersonParagraphElement.textContent = `Peson:${personInputElement.value}`;
    newArticleElement.appendChild(newPlaceParagraphElement);
    newArticleElement.appendChild(newActionParagraphElement);
    newArticleElement.appendChild(newPersonParagraphElement);
    newLiElement.appendChild(newArticleElement);

    let newDivWrapperElement = document.createElement("div");
    newDivWrapperElement.classList.add("buttons");
    let newEditBtnElement = document.createElement("button");
    newEditBtnElement.classList.add("edit");
    newEditBtnElement.textContent = "Edit";
    //edit btn functionality
    newEditBtnElement.addEventListener("click", function () {});
    let newDoneBtnElement = document.createElement("button");
    newDoneBtnElement.classList.add("done");
    newDoneBtnElement.textContent = "Done";
    newDivWrapperElement.appendChild(newEditBtnElement);
    newDivWrapperElement.appendChild(newDoneBtnElement);
    newLiElement.appendChild(newDivWrapperElement);

    taskListElement.appendChild(newLiElement);
    //clear up the form
    formElement.reset();
  }
}

window.addEventListener("load", solve);

function solve() {
  let taskListElement = document.getElementById("task-list");
  let doneListElement = document.getElementById("done-list");
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

    createNewListItem();
  });

  function createNewListItem() {
    let place = placeInputElement.value;
    let person = personInputElement.value;
    let action = actionInputElement.value;
    let newLiElement = document.createElement("li");
    newLiElement.classList.add("clean-task");
    let newArticleElement = document.createElement("article");
    let newPlaceParagraphElement = document.createElement("p");
    newPlaceParagraphElement.textContent = `Place:${place}`;
    let newActionParagraphElement = document.createElement("p");
    newActionParagraphElement.textContent = `Action:${action}`;
    let newPersonParagraphElement = document.createElement("p");
    newPersonParagraphElement.textContent = `Peson:${person}`;
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
    newEditBtnElement.addEventListener("click", function () {
      placeInputElement.value = place;
      personInputElement.value = person;
      actionInputElement.value = action;
      taskListElement.removeChild(newLiElement);
    });
    let newDoneBtnElement = document.createElement("button");
    //done btn functionality
    newDoneBtnElement.addEventListener("click", function () {
      newLiElement.removeChild(newDivWrapperElement);
      let newDeleteBtnElement = document.createElement("button");
      newDeleteBtnElement.classList.add("delete");
      newDeleteBtnElement.textContent = "Delete";
      newLiElement.appendChild(newDeleteBtnElement);
      doneListElement.appendChild(newLiElement);
    });
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

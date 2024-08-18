window.addEventListener("load", solve);

function solve() {
  //target needed elements
  let formElement = document.querySelector("section#add-event > form");
  let nameInputElement = document.getElementById("name");
  let timeInputElement = document.getElementById("time");
  let descriptionTextElement = document.getElementById("description");
  let addBtnElement = document.getElementById("add-btn");
  let previewListElement = document.getElementById("preview-list");
  let archiveListElement = document.getElementById("archive-list");

  addBtnElement.addEventListener("click", function (event) {
    event.preventDefault();
    if (!checkInputs()) {
      return;
    }

    let newListElement = getPreviewListElement(
      nameInputElement.value,
      timeInputElement.value,
      descriptionTextElement.value
    );

    previewListElement.appendChild(newListElement);
    addBtnElement.disabled = "true";
    formElement.reset();
  });

  function getPreviewListElement(name, time, description) {
    let newLiElement = document.createElement("li");

    let newArticleElement = document.createElement("article");
    let newNameParagraphElement = document.createElement("p");
    newNameParagraphElement.textContent = name;
    let newTimeParagraphElement = document.createElement("p");
    newTimeParagraphElement.textContent = time;
    let newDescriptionParagraphElement = document.createElement("p");
    newDescriptionParagraphElement.textContent = description;

    newArticleElement.appendChild(newNameParagraphElement);
    newArticleElement.appendChild(newTimeParagraphElement);
    newArticleElement.appendChild(newDescriptionParagraphElement);
    newLiElement.appendChild(newArticleElement);

    let newDivBtnWrapperElement = document.createElement("div");
    newDivBtnWrapperElement.classList.add("buttons");

    let newEditBtnElement = document.createElement("button");
    newEditBtnElement.classList.add("edit-btn");
    newEditBtnElement.textContent = "Edit";
    newEditBtnElement.addEventListener("click", function () {
      nameInputElement.value = name;
      timeInputElement.value = time;
      descriptionTextElement.value = description;
      previewListElement.removeChild(newLiElement);
      addBtnElement.removeAttribute("disabled");
    });

    let newNextBtnElement = document.createElement("button");
    newNextBtnElement.classList.add("next-btn");
    newNextBtnElement.textContent = "Next";
    newNextBtnElement.addEventListener("click", function () {
      newLiElement.removeChild(newDivBtnWrapperElement);

      let newArchiveBtnElement = document.createElement("button");
      newArchiveBtnElement.classList.add("archive-btn");
      newArchiveBtnElement.textContent = "Archive";
      newLiElement.appendChild(newArchiveBtnElement);

      newArchiveBtnElement.addEventListener("click", function () {
        archiveListElement.removeChild(newLiElement);
        addBtnElement.removeAttribute("disabled");
      });

      archiveListElement.appendChild(newLiElement);
    });

    newDivBtnWrapperElement.appendChild(newEditBtnElement);
    newDivBtnWrapperElement.appendChild(newNextBtnElement);

    newLiElement.appendChild(newDivBtnWrapperElement);

    return newLiElement;
  }
  function checkInputs() {
    if (
      nameInputElement.value.length === 0 ||
      timeInputElement.value.length === 0 ||
      descriptionTextElement.value.length === 0
    ) {
      return false;
    }

    return true;
  }
}

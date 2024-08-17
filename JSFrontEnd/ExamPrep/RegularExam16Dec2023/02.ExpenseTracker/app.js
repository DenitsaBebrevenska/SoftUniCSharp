window.addEventListener("load", solve);

function solve() {
  //target all needed elements
  let formElement = document.querySelector(".expense-content");
  let typeInputElement = document.getElementById("expense");
  let amountInputElement = document.getElementById("amount");
  let dateInputElement = document.getElementById("date");
  let addBtnElement = document.getElementById("add-btn");
  let previewListElement = document.getElementById("preview-list");
  let expensesListElement = document.getElementById("expenses-list");
  let deleteBtnElement = document.querySelector("button.delete");

  //add add btn function
  addBtnElement.addEventListener("click", function () {
    if (
      typeInputElement.value.length === 0 ||
      amountInputElement.value.length === 0 ||
      dateInputElement.value.length === 0
    ) {
      return;
    }

    let newLiElement = document.createElement("li");
    newLiElement.classList.add("expense-item");
    let newArticleElement = document.createElement("article");
    let newTypeParagraph = document.createElement("p");
    newTypeParagraph.textContent = `Type: ${typeInputElement.value}`;
    let newAmountParagraph = document.createElement("p");
    newAmountParagraph.textContent = `Amount: ${amountInputElement.value}$`;
    let newDateParagraph = document.createElement("p");
    newDateParagraph.textContent = `Date: ${dateInputElement.value}`;
    newArticleElement.appendChild(newTypeParagraph);
    newArticleElement.appendChild(newAmountParagraph);
    newArticleElement.appendChild(newDateParagraph);
    newLiElement.appendChild(newArticleElement);

    let newDivBtnWrapper = document.createElement("div");
    newDivBtnWrapper.classList.add("buttons");
    let newEditBtnElement = document.createElement("button");
    newEditBtnElement.classList.add("btn");
    newEditBtnElement.classList.add("edit");
    newEditBtnElement.textContent = "edit";
    let newOkBtnElement = document.createElement("button");
    newOkBtnElement.classList.add("btn");
    newOkBtnElement.classList.add("ok");
    newOkBtnElement.textContent = "ok";
    newDivBtnWrapper.appendChild(newEditBtnElement);
    newDivBtnWrapper.appendChild(newOkBtnElement);
    newLiElement.appendChild(newDivBtnWrapper);

    previewListElement.appendChild(newLiElement);
    formElement.reset();
    addBtnElement.disabled = true;
  });
}

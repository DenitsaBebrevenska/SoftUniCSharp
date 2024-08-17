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
  addBtnElement.addEventListener("click", addExpense);

  function addExpense() {
    if (
      typeInputElement.value.length === 0 ||
      amountInputElement.value.length === 0 ||
      dateInputElement.value.length === 0
    ) {
      return;
    }

    let type = typeInputElement.value;
    let amount = amountInputElement.value;
    let date = dateInputElement.value;

    let newLiElement = document.createElement("li");
    newLiElement.classList.add("expense-item");
    let newArticleElement = document.createElement("article");
    let newTypeParagraph = document.createElement("p");
    newTypeParagraph.textContent = `Type: ${type}`;
    let newAmountParagraph = document.createElement("p");
    newAmountParagraph.textContent = `Amount: ${amount}$`;
    let newDateParagraph = document.createElement("p");
    newDateParagraph.textContent = `Date: ${date}`;
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
    newEditBtnElement.addEventListener("click", editExpense);

    let newOkBtnElement = document.createElement("button");
    newOkBtnElement.classList.add("btn");
    newOkBtnElement.classList.add("ok");
    newOkBtnElement.textContent = "ok";
    newOkBtnElement.addEventListener("click", moveToExpenses);

    newDivBtnWrapper.appendChild(newEditBtnElement);
    newDivBtnWrapper.appendChild(newOkBtnElement);
    newLiElement.appendChild(newDivBtnWrapper);

    previewListElement.appendChild(newLiElement);
    formElement.reset();
    addBtnElement.disabled = true;
  }

  function editExpense(event) {
    let currentExpenseElement = event.currentTarget.parentNode.parentNode;
    let type = currentExpenseElement
      .querySelector("p:first-of-type")
      .textContent.split(": ")[1];
    let amount = currentExpenseElement
      .querySelector("p:nth-child(even)")
      .textContent.split(": ")[1]
      .split("$")[0];
    let date = currentExpenseElement
      .querySelector("p:last-of-type")
      .textContent.split(": ")[1];
    typeInputElement.value = type;
    amountInputElement.value = amount;
    dateInputElement.value = date;
    addBtnElement.removeAttribute("disabled");
    previewListElement.innerHTML = "";
  }

  function moveToExpenses(event) {
    let currentBtnDivWrapper = event.currentTarget.parentNode;
    let currentExpense = event.currentTarget.parentNode.parentNode;
    currentExpense.removeChild(currentBtnDivWrapper);
    expensesListElement.appendChild(currentExpense);
  }
}

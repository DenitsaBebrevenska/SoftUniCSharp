const baseUrl = "http://localhost:3030/jsonstore/tasks";
//target needed elements
let mealListElement = document.getElementById("list");
let formElement = document.querySelector("div#form > form");
let foodInputElement = document.getElementById("food");
let timeInputElement = document.getElementById("time");
let caloriesInputElement = document.getElementById("calories");
let addMealBtnElement = document.getElementById("add-meal");
let editMealBtnElement = document.getElementById("edit-meal");
let loadBtnElement = document.getElementById("load-meals");

//clone sample meal
let sampleMeal = document.querySelector("div#list > div.meal").cloneNode(true);
//clear sample meal
mealListElement.innerHTML = "";

//load meals
loadBtnElement.addEventListener("click", loadMeals);

//add meal
addMealBtnElement.addEventListener("click", addMeal);

async function loadMeals() {
  //flush list
  mealListElement.innerHTML = "";

  try {
    const getResponse = await fetch(baseUrl);

    if (!getResponse.ok) {
      throw new Error("Error loading meals!");
    }

    const responseData = await getResponse.json();

    let fragment = document.createDocumentFragment();

    Object.values(responseData).forEach((value) => {
      let clonedMealElement = sampleMeal.cloneNode(true);
      clonedMealElement.querySelector("h2").textContent = value.food;
      clonedMealElement.querySelector("h3").textContent = value.time;
      clonedMealElement.querySelector("h3:last-of-type").textContent =
        value.calories;
      let currentChangeBtn =
        clonedMealElement.querySelector("button.change-meal");
      currentChangeBtn.setAttribute("data-id", value._id);
      currentChangeBtn.addEventListener("click", function (event) {
        let currentMeal = event.target.parentNode.parentNode;

        foodInputElement.value = currentMeal.querySelector("h2").textContent;
        timeInputElement.value = currentMeal.querySelector("h3").textContent;
        caloriesInputElement.value =
          currentMeal.querySelector("h3:last-of-type").textContent;
        mealListElement.removeChild(currentMeal);
        addMealBtnElement.disabled = true;
        editMealBtnElement.removeAttribute("disabled");
        4;
        editMealBtnElement.setAttribute(
          "data-id",
          event.target.getAttribute("data-id")
        );
        editMealBtnElement.addEventListener("click", updateMeal);
      });

      let currentDeleteBtn =
        clonedMealElement.querySelector("button.delete-meal");
      currentDeleteBtn.setAttribute("data-id", value._id);
      currentDeleteBtn.addEventListener("click", deleteMeal);

      fragment.appendChild(clonedMealElement);
    });

    mealListElement.appendChild(fragment);
  } catch (error) {
    console.error(error);
  }
}

async function addMeal() {
  if (
    !foodInputElement.value.length ||
    !timeInputElement.value.length ||
    !caloriesInputElement.value.length
  ) {
    throw new Error("All fields must be filled in!");
  }

  let food = foodInputElement.value;
  let time = timeInputElement.value;
  let calories = caloriesInputElement.value;

  try {
    const postResponse = await fetch(baseUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        food,
        calories,
        time,
      }),
    });

    if (!postResponse.ok) {
      throw new Error("Error creating meal!");
    }

    formElement.reset();
    loadMeals();
  } catch (error) {
    console.error(error);
  }
}

async function deleteMeal(event) {
  let currentMealId = event.target.getAttribute("data-id");

  try {
    const deleteResponse = await fetch(baseUrl + `/${currentMealId}`, {
      method: "DELETE",
    });

    if (!deleteResponse.ok) {
      throw new Error("Error deleting meal");
    }

    loadMeals();
  } catch (error) {
    console.error(error);
  }
}

async function updateMeal(event) {
  let dataId = event.target.getAttribute("data-id");
  try {
    const putResponse = await fetch(baseUrl + `/${dataId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        food: foodInputElement.value,
        calories: caloriesInputElement.value,
        time: timeInputElement.value,
        _id: dataId,
      }),
    });

    if (!putResponse.ok) {
      throw new Error("Error changing meal");
    }

    loadMeals();
    formElement.reset();
    editMealBtnElement.disabled = true;
    event.target.removeAttribute("data-id");
    addMealBtnElement.removeAttribute("disabled");
  } catch (error) {
    console.error(error);
  }
}

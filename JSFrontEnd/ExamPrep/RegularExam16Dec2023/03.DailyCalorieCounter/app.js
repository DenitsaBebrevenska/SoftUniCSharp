const baseUrl = "http://localhost:3030/jsonstore/tasks";
//target needed elements
let mealListElement = document.getElementById("list");
let formElement = document.querySelector("div#form > form");
let foodInputElement = document.getElementById("food");
let timeInputElement = document.getElementById("time");
let caloeriesInputElement = document.getElementById("calories");
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
      clonedMealElement
        .querySelector("button.change-meal")
        .setAttribute("data-id", value._id);
      clonedMealElement
        .querySelector("button.delete-meal")
        .setAttribute("data-id", value._id);

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
    !caloeriesInputElement.value.length
  ) {
    throw new Error("All fields must be filled in!");
  }

  let food = foodInputElement.value;
  let time = timeInputElement.value;
  let calories = caloeriesInputElement.value;

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

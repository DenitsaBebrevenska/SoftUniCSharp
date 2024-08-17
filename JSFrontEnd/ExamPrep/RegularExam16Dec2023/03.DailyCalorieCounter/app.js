const baseUrl = "http://localhost:3030/jsonstore/tasks";
let mealListElement = document.getElementById("list");
//clone sample meal
let sampleMeal = document.querySelector("div#list > div.meal").cloneNode(true);
//clear sample meal
mealListElement.innerHTML = "";

//load meals
let loadBtnElement = document.getElementById("load-meals");
loadBtnElement.addEventListener("click", loadMeals);

async function loadMeals() {
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

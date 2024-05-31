function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    let searchWordElement = document.getElementById("searchField");
    let searchWord = searchWordElement.value;
    let rowElements = document.querySelectorAll("tbody > tr ");

    //reset previous searches
    searchWordElement.value = '';
    for (const row of rowElements) {
      row.classList.remove("select");
    }

    for (const row of rowElements) {
      if (row.textContent.toLowerCase().includes(searchWord.toLowerCase())) {
        row.classList.add("select");
      }
    }
  }
}

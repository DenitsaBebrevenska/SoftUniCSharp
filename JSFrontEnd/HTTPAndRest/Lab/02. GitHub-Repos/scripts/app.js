function loadRepos() {
  let buttonElement = document.querySelector("button");
  let inputElement = document.getElementById("res");
  const url = "https://api.github.com/users/testnakov/repos";

  fetch(url)
    .then((response) => response.text())
    .then((text) => (inputElement.textContent = text))
    .catch((err) => console.log(err));
}

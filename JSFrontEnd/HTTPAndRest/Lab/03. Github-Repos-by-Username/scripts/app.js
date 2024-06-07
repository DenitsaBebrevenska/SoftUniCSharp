function loadRepos() {
  let reposElement = document.getElementById("repos");
  let usernameInputElement = document.getElementById("username");
  let firstLiElement = document.querySelector("#repos > li:first-of-type");
  let url = `https://api.github.com/users`;

  reposElement.innerHTML = "";

  fetch(url + `/${usernameInputElement.value}/repos`)
    .then((response) => {
		if(response.ok){
			return response.json();
		} else {
			throw new Error(response.status + ' ' + response.statusText);
		}
	})
    .then((data) => {
      let fragment = document.createDocumentFragment();
      data.forEach((obj) => {
        let newLiItem = document.createElement("li");
        let newAItem = document.createElement("a");
        newAItem.href = obj.html_url;
        newAItem.textContent = obj.full_name;
        newLiItem.appendChild(newAItem);
        fragment.appendChild(newLiItem);
      });

      reposElement.appendChild(fragment);
    })
    .catch((err) => {
      let newLiItem = document.createElement("li");
      newLiItem.textContent = err.message;
      reposElement.appendChild(newLiItem);
    });
}

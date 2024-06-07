function loadCommits() {
    let inputUsernameElement = document.getElementById('username');
    let repoNameElement = document.getElementById('repo');
    let comitListElement = document.getElementById('commits');
    let url =' https://api.github.com/repos';

    comitListElement.innerHTML = '';

    fetch(url + `/${inputUsernameElement.value}` + `/${repoNameElement.value}` + '/commits')
    .then((response) => {
        if(response.ok){
            return response.json();
        } 

        throw new Error(`Error: ${response.status} (Not Found)`);
        //the status text for the server`s 404 is not Not Found, added here to complete assignment as intended
    })
    .then((data) => {
        let fragment = document.createDocumentFragment();

        data.forEach(commitObj => {
            let newListElement = document.createElement('li');
            newListElement.textContent = `${commitObj.commit.author.name}: ${commitObj.commit.message}`;
            fragment.appendChild(newListElement);
        })

        comitListElement.appendChild(fragment);
    })
    .catch(error => {
        console.log(error);
        let errorListElement = document.createElement('li');
        errorListElement.textContent = error.message;
        comitListElement.appendChild(errorListElement);
    })
}
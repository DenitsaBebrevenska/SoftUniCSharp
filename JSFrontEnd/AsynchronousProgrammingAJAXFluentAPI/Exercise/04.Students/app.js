function attachEvents() {
  url = 'http://localhost:3030/jsonstore/collections/students';
  
  fetch(url)
  .then((response) => response.json())
  .catch((data) => {
    
  })
}

attachEvents();
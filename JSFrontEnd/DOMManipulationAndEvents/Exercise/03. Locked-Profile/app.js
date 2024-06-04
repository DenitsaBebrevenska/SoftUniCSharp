function lockedProfile() {
  //get profiles elements
  let profileElements = Array.from(document.querySelectorAll(".profile"));

  //define show more/hide it buttonHandler separately
  const profileButtonHandler = function(event){
    let buttonElement = event.currentTarget;
    let hiddenTextElement = buttonElement.previousElementSibling;
   
    if(buttonElement.textContent === 'Show more'){
        hiddenTextElement.style.display = 'block';
        buttonElement.textContent = 'Hide it';
    } else {
        hiddenTextElement.style.display = 'none';
        buttonElement.textContent = 'Show more';
    }
  }

  //change event for input radio toggling button click event
  profileElements.forEach((element) => {
    let lockElement = element.querySelector('input[value="lock"]');
    element.addEventListener('change', function(){
        let buttonElement = element.querySelector('button');
       if(!lockElement.checked){
        buttonElement.addEventListener('click', profileButtonHandler)
       } else{
         buttonElement.removeEventListener('click', profileButtonHandler)
       }
    })
    
  });
}

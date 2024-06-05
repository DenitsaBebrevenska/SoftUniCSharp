function solve() {
  //get all needed elements: all sections and result
  let sectionElements = Array.from(document.querySelectorAll('section'));
  let resultElement = document.querySelector('.results-inner > h1');
  const correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let playerAnswers = [];

  for(let i = 0; i < sectionElements.length; i++){
    let buttons = Array.from(sectionElements[i].querySelectorAll('.answer-text'));
    
    buttons.forEach(button => {
      button.addEventListener('click', function(){
        //add answer to answers player
        playerAnswers.push(button.textContent);
        //switch current section to display none if any
        //my first solution included adding class hidden to current section and removing it
        //from the next one, but that one is not ok with Judge
        sectionElements[i].style.display = 'none';

        if(i < sectionElements.length - 1){
          sectionElements[i + 1].style.display = 'block';
        } else {
          //if no more questions check answers and visualize result
          let playerCorrectAnswers = playerAnswers
              .filter(answer => correctAnswers.includes(answer)).length;
          //make parent visible
          document.getElementById('results').style.display = 'block';
          resultElement.textContent = playerCorrectAnswers === 3
          ? 'You are recognized as top JavaScript fan!'
          : `You have ${playerCorrectAnswers} right answers`;
        }
      })
    })
  }

}

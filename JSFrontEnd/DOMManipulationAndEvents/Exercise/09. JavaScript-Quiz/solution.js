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
        //switch current section class to hidden 
        //and remove hidden from next if any
        sectionElements[i].classList.add('hidden');
        if(i < sectionElements.length - 1){
          sectionElements[i + 1].classList.remove('hidden');
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

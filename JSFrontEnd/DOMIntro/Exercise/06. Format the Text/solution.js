function solve() {
  let textAreaElement = document.getElementById('input');
  let outputContainerElement = document.getElementById('output');
  let inputText = textAreaElement.value;

  //reset output
  while(outputContainerElement.firstChild){
    outputContainerElement.removeChild(outputContainerElement.firstChild);
  }

  let sentences = inputText.split('.').filter(sentence => {
    const regex = /[A-Za-z]+/g;
    return regex.test(sentence);
  });

  let paragraphText = [];
  for(let i = 0; i < sentences.length; i++){
    paragraphText.push(sentences[i]);

    if((i + 1) % 3 === 0 || i === sentences.length - 1){
      const newParagraph = document.createElement('p');
      newParagraph.textContent = paragraphText.join('. ') + '.';
      outputContainerElement.appendChild(newParagraph);
      paragraphText = []
    }
  }
}
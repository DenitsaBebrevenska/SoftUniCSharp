function create(words) {
   let contentContainerElement = document.getElementById('content');
   words.forEach(word => {
      let innerDiv = document.createElement('div');
      let paragraph = document.createElement('p')
      paragraph.textContent = word;
      paragraph.style.display = 'none';
      innerDiv.appendChild(paragraph);
      contentContainerElement.appendChild(innerDiv);
      
      innerDiv.addEventListener('click', function(){
         paragraph.style.display = 'block';
      })
   })
}
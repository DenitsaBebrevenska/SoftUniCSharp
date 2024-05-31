function search() {
   let listItemElements = document.querySelectorAll('li');
   //reset style upon new search
   for(const listItem of listItemElements){
         listItem.style.textDecoration = 'none';
         listItem.style.fontWeight = 'normal';
   }

   let searchTextElement = document.getElementById('searchText');
   let resultElement = document.getElementById('result');
   let searchWord = searchTextElement.value;
   let matchesCount = 0;
   
   for(const listItem of listItemElements){
      if(listItem.textContent.toLowerCase().includes(searchWord.toLowerCase())){ //case insensitive could be problematic for Judge
         listItem.style.textDecoration = 'underline';
         listItem.style.fontWeight = 'bold';
         matchesCount++;
      }
   }

   resultElement.textContent = `${matchesCount} matches found`;
}

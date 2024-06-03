function addItem() {
    let listItemsElement = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');

    //create li item
    let newListItem = document.createElement('li');
    newListItem.textContent = inputElement.value;

    //create anchor
    let anchorItem = document.createElement('a');
    anchorItem.setAttribute('href', '#');
    anchorItem.textContent = '[Delete]';

    //register event listener on clicking anchor tag
    anchorItem.addEventListener('click', function(){
        listItemsElement.removeChild(newListItem);
    })

    //append children
    newListItem.appendChild(anchorItem);
    listItemsElement.appendChild(newListItem);

    //reset input
    inputElement.value = '';
}
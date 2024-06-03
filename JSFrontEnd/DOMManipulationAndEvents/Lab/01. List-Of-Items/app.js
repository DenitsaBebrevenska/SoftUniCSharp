function addItem() {
    let itemsMenuElement = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');
    let newListItem = document.createElement('li');
    newListItem.textContent = inputElement.value;
    itemsMenuElement.appendChild(newListItem);
    inputElement.value = '';
}
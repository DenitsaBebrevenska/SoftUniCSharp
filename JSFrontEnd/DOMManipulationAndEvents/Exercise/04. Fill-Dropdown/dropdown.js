function addItem() {
    let menuElement = document.getElementById('menu');
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');
    let newOption = document.createElement('option');
    newOption.value = valueElement.value;
    newOption.textContent = textElement.value;
    menuElement.appendChild(newOption);
    textElement.value = '';
    valueElement.value = '';
}
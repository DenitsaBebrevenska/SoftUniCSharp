function deleteByEmail() {
    let tbodyElement = document.querySelector('table[id="customers"] tbody');
    let trElements = Array.from(document.querySelectorAll('tbody tr'));
    let inputElement = document.querySelector('label input[type="text"]');
    let resultElement = document.getElementById('result');
    let elementsToRemove = trElements
        .filter(element => element.textContent.includes(inputElement.value));
    resultElement.textContent = elementsToRemove.length === 0 ? 'Not found.' : 'Deleted.';
    console.log(resultElement.textContent);
    elementsToRemove.forEach(element => tbodyElement.removeChild(element));
}
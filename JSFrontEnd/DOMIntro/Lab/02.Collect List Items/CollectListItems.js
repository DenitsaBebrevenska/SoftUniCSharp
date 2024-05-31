function extractText() {
    let listElementsContents = document.getElementById('items').textContent;
    let textAreaElement = document.getElementById('result');
    textAreaElement.value = listElementsContents;
}
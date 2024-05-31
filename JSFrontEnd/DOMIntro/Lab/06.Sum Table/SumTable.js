function sumTable() {
    let priceElements = Array.from(document.querySelectorAll('td:nth-child(even):not(#sum)'));
    let sumElements = document.getElementById('sum');
    let sum = priceElements.map(element => Number(element.textContent))
        .reduce((sum, number) => sum + number, 0);
        sumElements.textContent = sum;
}
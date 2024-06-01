function generateReport() {
    let tableHeaderElements = document.querySelectorAll('thead > tr > th');
    let rowElements = document.querySelectorAll('tbody > tr');
    let objects = [];

    checkedHeaderColumns = Array.from(tableHeaderElements)
        .map((element, index) => {
        let inputElement = element.querySelector('input');
        return [element.textContent.trim(), inputElement.checked.toString(), index++];
    }).filter(element => element[1] === 'true');
    
    for(const row of rowElements){
        let rowValues = Array.from(row.querySelectorAll('td'))
        .map((element, index) => [element.textContent, index++])
        .filter(element => checkedHeaderColumns.some(column => column[2] === element[1]));

        let newObject = {};

        for(let i = 0; i < rowValues.length; i++){
            let value = rowValues[i][0];   
            let index = rowValues[i][1];
            let propertyName = checkedHeaderColumns.find(column => column[2] === index)[0].toLowerCase();
            newObject[propertyName] = value;
        }

        objects.push(newObject);
    }

    let outputElement = document.getElementById('output');
    outputElement.value = JSON.stringify(objects, null, 2);
}
function solve() {
    let trElements = Array.from(document.querySelectorAll('tbody > tr'));
    let checkButton = document.querySelector('tfoot > tr > td > button:first-of-type');
    let clearButton = document.querySelector('tfoot > tr > td > button:last-of-type');
    let tableElement = document.getElementById('exercise');
    let resultElement = document.querySelector('#check > p');

    //clear all inputs, borders too
    clearButton.addEventListener('click', function(){
        trElements
            .forEach(trElement => {
                Array.from(trElement.querySelectorAll('td > input')) 
                    .forEach(inputElement => inputElement.value = '');
            })

            resultElement.textContent = '';
            tableElement.style.border = 'none';
    })

    //function to check if all numbers in the array are unique by creating a set and comparing the size to the length of the array
    const areUnique = function(numbers){
        return new Set(numbers).size === numbers.length;
    }

    checkButton.addEventListener('click',function(){
        let isWon = true;
        //map all inputs to array of value for each row
        let values = trElements.map(element => {
            let elementInputs = element.querySelectorAll('td  input');
            return Array.from(elementInputs).map(input => Number(input.value));
        })

        //check each row
        for(const lineValues of values){    
            if(!areUnique(lineValues)){
                isWon = false;
                break;
            }
        }

        //check columns only if the row validations have passed
        for(let i = 0; i < 3; i++){
            if(!isWon){
                break;
            }
            let columnValues = [values[0][i], values[1][i], values[2][i]];

            if(!areUnique(columnValues)){
                isWon = false;
                break;
            }
        }

        //set border and output text according to result
        if(!isWon){
            tableElement.style.border = '2px solid red';
            resultElement.textContent = 'NOP! You are not done yet...';
            resultElement.style.color = 'red';
        } else {
            tableElement.style.border = '2px solid green';
            resultElement.textContent = 'You solve it! Congratulations!';
            resultElement.style.color = 'green';
        }
    })
}
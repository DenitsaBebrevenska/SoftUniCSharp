function solve() {
    function convertTOBinary(number){
        let result = '';
        while(number / 2 !== 0){
            result = result.concat(number % 2);
            number = Math.trunc(number / 2);
        }
        return result.split('')
        .reverse()
        .join('');
    }

    function convertToHexadecimal(number){
        let result = '';
        while(number / 16 !== 0){
            result = result.concat(number % 16 + ' ');
            number = Math.trunc(number / 16);    
        }

        result = result.split(' ').map(char =>{
            if(char === '10'){
                char ='A'
            } else if(char === '11'){
                char = 'B'
            } else if(char === '12'){
                char = 'C'
            } else if(char === '13'){
                char = 'D'
            } else if(char === '14'){
                char = 'E'
            } else if(char === '15'){
                char = 'F'
            } 
            return char
        })

        return result.reverse().join('');
    }

    //could have used Number.toString(radix), but found about it a bit too late....

    let buttonElement = document.querySelector('button');
    let toMenuElement = document.getElementById('selectMenuTo');
    let resultElement = document.getElementById('result');
    

    let binaryOptionElement = document.createElement('option');
    binaryOptionElement.value = 'binary';
    binaryOptionElement.textContent = 'Binary';
    toMenuElement.appendChild(binaryOptionElement);

    let hexadecimalOptionElement = document.createElement('option');
    hexadecimalOptionElement.value = 'hexadecimal';
    hexadecimalOptionElement.textContent = 'Hexadecimal';
    toMenuElement.appendChild(hexadecimalOptionElement);
    
    buttonElement.addEventListener('click', () => {
        const number = document.getElementById('input').value;
        if(toMenuElement.value === 'binary'){
            resultElement.value = convertTOBinary(number)
        } else if (toMenuElement.value === 'hexadecimal'){
            resultElement.value = convertToHexadecimal(number)
        }
    });
   
}
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

    let numberElementValue = document.getElementById('input').value;
    let toMenuElementValue = document.getElementById('selectMenuTo').value;
    let resultElement = document.getElementById('result');
    let result = '';

    if(toMenuElementValue === 'binary'){
        result = convertTOBinary(numberElementValue)
    } else if (toMenuElementValue === 'hexadecimal'){
        result = convertToHexadecimal(numberElementValue)
    }
   
    resultElement.value = result;
}
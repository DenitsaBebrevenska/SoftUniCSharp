//01. Ages
function printAgeCategory(age){
    let result;

    if(age >= 66){
        result = 'elder';
    } else if (age >= 20){
        result = 'adult';
    } else if (age >= 14){
        result = 'teenager';
    } else if (age >= 3){
        result = 'child';
    } else if (age >= 0){
        result = 'baby';
    } else {
        result = 'out of bounds';
    }

    console.log(result);
}

//printAgeCategory(-1);

//02. Vacation
function getPrice(amount, groupType, day){
    let price;

    if(groupType === 'Students'){
        if(day === 'Friday'){
            price = 8.45;
        } else if (day === 'Saturday'){
            price = 9.8;
        } else {
            price = 10.46;
        }
    } else if (groupType == 'Business'){
        if(day === 'Friday'){
            price = 10.9;
        } else if (day === 'Saturday'){
            price = 15.6;
        } else {
            price = 16;
        }
    } else{
        if(day === 'Friday'){
            price = 15;
        } else if (day === 'Saturday'){
            price = 20;
        } else {
            price = 22.5;
        }
    }

    if(amount >= 30 && groupType === 'Students'){
        price *= 0.85;
    } else if (amount >= 100 && groupType === 'Business'){
        amount -= 10;
    } else if (amount >= 10 && amount <= 20 && groupType === 'Regular'){
        price *= 0.95;
    }

    let finalPrice = amount * price;

    console.log(`Total price: ${finalPrice.toFixed(2)}`);
}

//getPrice(110,"Business","Saturday");

//03. Leap Year
function leapYearOrNot(year){
    let result = 'no';

    if((year % 4 === 0 && year % 100 !== 0)
        || (year % 400 === 0)){
            result = 'yes';
        }

    console.log(result);
}

//leapYearOrNot(2003);

//04. Print And Sum

function printNumbersAndSum(a, b){
    let biggerNumber = Math.max(a, b);
    let smallerNumber = Math.min(a, b);
    let resultString = '';
    let sum = 0;

    for(i = smallerNumber; i <= biggerNumber; i++){
        resultString += i + ' ';
        sum += i;
    }

    console.log(resultString.trimEnd());
    console.log(`Sum: ${sum}`);
}

//printNumbersAndSum(0, 26);

//05. Multiplication Table

function getMultiplicationTableOfANumber(number){
    
    for(i = 1; i <= 10; i++){
        console.log(`${number} X ${i} = ${number * i}`);
    }
}

//getMultiplicationTableOfANumber(100);
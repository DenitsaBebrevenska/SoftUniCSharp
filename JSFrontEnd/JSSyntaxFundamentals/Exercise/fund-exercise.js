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
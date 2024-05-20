//01. Validity Checker
function verifyCoordinates(x1, y1, x2, y2){
    let distance = Math.sqrt(x1 ** 2 + y1 ** 2);
    let status;

    if(Number.isInteger(distance)){
        status = 'valid';
    } else{
        status = 'invalid';
    }

    console.log(`{${x1}, ${y1}} to {0, 0} is ${status}`);

    distance = Math.sqrt(x2 ** 2 + y2 ** 2);

    if(Number.isInteger(distance)){
        status = 'valid';
    } else{
        status = 'invalid';
    }

    console.log(`{${x2}, ${y2}} to {0, 0} is ${status}`);

    distance = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);

    if(Number.isInteger(distance)){
        status = 'valid';
    } else{
        status = 'invalid';
    }

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status}`);
}

//verifyCoordinates(2, 1, 1, 1);

//02. Words Uppercase
function extractWordsToUpper(text){
    const regex = /\w+/gm;
    let result = text.match(regex);
    console.log(result.join(', ').toUpperCase());
}

//extractWordsToUpper('Hi, how are you?');

//03. Calculator
function calculate(a, operator, b){
    let result;

    switch(operator){
        case '+':
        result = a + b;
        break;
        case '-':
        result = a - b;
        break;
        case '/':
        result = a / b;
        break;
        case '*':
        result = a * b;
        break;
    }

    console.log(result.toFixed(2));
}

//calculate(25.5,'-',3);

//04. Gladiator Expenses

function solve(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice){
    let brokenHelmetExpenses = Math.trunc(lostFights / 2) * helmetPrice;
    let brokenSwordExpenses = Math.trunc(lostFights / 3) * swordPrice;
    let brokenShieldExpenses = Math.trunc(lostFights / 6) * shieldPrice;
    let brokenArmorExpenses = Math.trunc(lostFights / 12) * armorPrice;

    let expenses = brokenHelmetExpenses + brokenSwordExpenses + brokenShieldExpenses + brokenArmorExpenses;

    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}

//solve(23,12.50,21.50,40,200);

//05. Spice Must Flow

function spiceStatistics(startingYield){
    let harvestedSpice = 0;
    let dayCount = 0;
    const crewConsumption = 26;

    while(startingYield >= 100){
        harvestedSpice += startingYield;
        startingYield -= 10;
        harvestedSpice -= crewConsumption;
        dayCount++;
    }

    if(harvestedSpice >= crewConsumption){
        harvestedSpice -= crewConsumption;
    } else{
        harvestedSpice = 0;
    }

    console.log(dayCount);
    console.log(harvestedSpice);
}

//spiceStatistics(99);
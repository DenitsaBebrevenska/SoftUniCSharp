//1. Multiply the Number by 2
function multiplyByTwo(number){
    console.log(number * 2);
}

//multiplyByTwo(20);

//2.	Student Information
function print(name, age, grade){
    console.log(`Name: ${name}, Age: ${age}, Grade: ${grade.toFixed(2)}`);
}

//print('John', 15, 5.54678);

//3.	Excellent Grade
function printResult(grade){
    if(grade >= 5.5){
        console.log('Excellent');
    }else {
        console.log('Not excellent');
    }
}

//printResult(5.49);

//4.	Month Printer

function printMonth(number){
    let text;

    switch(number){
        case 1:
            text = 'January'
            break;
        case 2:
            text = 'February'
            break;
        case 3:
            text = 'March'
            break;
        case 4:
            text = 'April'
            break;
        case 5:
            text = 'May'
            break;
        case 6:
            text = 'June'
            break;
         case 7:
            text = 'July'
            break;
        case 8:
            text = 'August'
            break;
        case 9:
            text = 'September'
            break;
        case 10:
            text = 'October'
            break;
        case 11:
            text = 'November'
            break;
        case 12:
            text = 'December'
            break;
        default:
            text = 'Error!'
    }

    console.log(text);
}

//printMonth(20);

//05. Math Operations

function solve(a, b, operator){
    let result;

    switch(operator){
        case '+':
            result = a + b
            break;
        case '-':
            result = a - b
            break;
        case '*':
            result = a * b
            break;
        case '/':
            result = a / b
            break;
        case '%':
            result = a % b
            break;
        case '**':
            result = a ** b
            break;
    }

    console.log(result);
}

//solve(3, 5.5, '*')

//06. Largest Number

function solve(a, b, c){
    let largestNumber = Math.max(a, b, c);
    console.log(`The largest number is ${largestNumber}.`);
}

//solve(5, -3, 16);

//07. Theatre Promotions

function getTicketPrice(dayType, age){
    let ticketPrice;

    if((age >= 0 && age <= 18 && dayType === 'Weekday')
        || (age > 18 && age <= 64 && dayType === 'Holiday')
        || (age > 64 && age <= 122 && dayType === 'Weekday')){
            ticketPrice = '12$';
        } else if ((age >= 0 && age <= 18 && dayType === 'Weekend')
                    || (age > 64 && age <= 122 && dayType === 'Weekend') ){
            ticketPrice = '15$';
        } else if (age >= 0 && age <= 18 && dayType === 'Holiday'){
            ticketPrice = '5$';
        } else if (age > 18 && age <= 64 && dayType === 'Weekday'){
            ticketPrice = '18$';
        } else if (age > 18 && age <= 64 && dayType === 'Weekend'){
            ticketPrice = '20$';
        } else if (age > 64 && age <= 122 && dayType === 'Holiday'){
            ticketPrice = '10$';
        } else{
            ticketPrice = 'Error!';
        }

    console.log(ticketPrice);
}

//getTicketPrice('Holiday', 15);

//08. Circle Area
function solve(argument){
    let result;

    if(typeof(argument) === 'number'){
        result = (Math.PI * argument ** 2).toFixed(2);
    } else {
        result = `We can not calculate the circle area, because we receive a ${typeof(argument)}.`;
    }

    console.log(result);
}

//solve('5');

//09. Numbers from 1 to 5
function printNumbers(){

    for (i = 1; i <= 5; i++){
        console.log(i);
    }
}

//printNumbers();

//09. Numbers from 1 to 5
function printNumbersFromMToN(m, n){

    for(i = m; i >= n; i--){
        console.log(i);
    }
}

//printNumbersFromMToN(6,2);
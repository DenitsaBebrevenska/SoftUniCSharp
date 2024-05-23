//01. Format Grade
function printResult(grade) {
  function formatGrade(grade) {
    if (grade < 3) {
      return Math.trunc(grade);
    } else {
      return grade.toFixed(2);
    }
  }

  if (grade >= 5.5) {
    return console.log(`Excellent (${formatGrade(grade)})`);
  } else if (grade >= 4.5) {
    return console.log(`Very good (${formatGrade(grade)})`);
  } else if (grade >= 3.5) {
    return console.log(`Good (${formatGrade(grade)})`);
  } else if (grade >= 3) {
    return console.log(`Poor (${formatGrade(grade)})`);
  } else {
    return console.log(`Fail (${formatGrade(grade)})`);
  }
}

//printResult(2.99);

//02. Math Power

function solve(number, power) {
  function raiseToPower(number, power) {
    if (number === 0) {
      return 0;
    }

    if (power === 0) {
      return 1;
    }

    return number * raiseToPower(number, --power);
  }

  console.log(raiseToPower(number, power));
}

//solve(2,8);

//03. Repeat String

function repeat(text, repeatCount) {
  if (repeatCount === 1) {
    return text;
  }

  return text + repeat(text, --repeatCount);
}

//console.log(repeat("String", 2));

//04. Orders
function totalPriceCalculator(product, quantity) {
  function getPricePerItem(product) {
    switch (product) {
      case "coffee":
        return 1.5;
      case "water":
        return 1;
      case "coke":
        return 1.4;
      case "snacks":
        return 2;
    }
  }

  const priceProduct = getPricePerItem;

  console.log((priceProduct(product) * quantity).toFixed(2));
}

//totalPriceCalculator("coffee", 2);

//05. Simple Calculator

function calculate(a, b, operator) {

  function getOperation(operator) {
    switch (operator) {
      case "multiply":
        return (a, b) => a * b;
      case "divide":
        return (a, b) => a / b;
      case "add":
        return (a, b) => a + b;
      case "subtract":
        return (a, b) => a - b;
    }
  }
  const operation = getOperation(operator);
  const result = operation(a,b);
  console.log(result);
}

//bonus challenge : Solve this task without using any conditional statements 
// function objectSolve(a, b, operator) {
//     const operations = {
//         multiply: (a, b) => a * b,
//         divide: (a, b) => a / b,
//         add: (a, b) => a + b,
//         subtract: (a, b) => a - b
//     };

//     console.log(operations[operator](a, b));
// }

//calculate(5, 5, "multiply");
//objectSolve(5, 5, "multiply");

//06. Sign Check
//Write a function, that checks whether the result 
//of the multiplication numOne * numTwo * numThree is positive or negative.
//Try to do this WITHOUT multiplying the 3 numbers.

function solve(a, b, c){

    function negativeNumberCount(a, b, c){
        const array = [a, b, c];
        return array.filter(number => number < 0);
    }

    let countNegativeNumbers = negativeNumberCount(a, b, c);

    console.log(countNegativeNumbers.length % 2 === 0 ? 'Positive' : 'Negative');
}

//solve(-5, -12, -12);
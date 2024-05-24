//01. Smallest of Three Numbers

function printSmallestNumber(a, b, c) {
  function findSmallestNumber(a, b) {
    return a < b ? a : b;
  }

  console.log(findSmallestNumber(findSmallestNumber(a, b), c));
}

//printSmallestNumber(2, 5, 3);

//02. Add and Subtract

function calculate(a, b, c) {
  let addition = (a, b) => a + b;
  let subtraction = (a, b) => a - b;
  console.log(subtraction(addition(a, b), c));
}

//calculate(23, 6, 10);

//03. Characters in Range
function printCharsInRange(a, b) {
  let maxChar = Math.max(a.charCodeAt(0), b.charCodeAt(0));
  let minChar = Math.min(a.charCodeAt(0), b.charCodeAt(0));
  let chars = [];

  for (let i = minChar + 1; i < maxChar; i++) {
    chars.push(String.fromCharCode(i));
  }

  console.log(chars.join(" "));
}

//printCharsInRange('C','#');

//04. Odd And Even Sum
function printSums(number) {
  let evenFunction = (a) => a % 2 === 0;
  let oddFunction = (a) => a % 2 !== 0;

  function getSum(a, func) {
    let sum = 0;

    while (a > 0) {
      let currentDigit = a % 10;
      if (func(a)) {
        sum += currentDigit;
      }
      a = Math.trunc(a / 10);
    }

    return sum;
  }

  console.log(`Odd sum = ${getSum(number, oddFunction)}, Even sum = ${getSum(number, evenFunction)}`);
}

//printSums(3495892137259234);

//05. Palindrome Integers

function solve(numbers){
    numbers.forEach(number => console.log(checkPalindrome(number.toString())));
    
    function checkPalindrome(numberAsString){
        let areEqual = (a, b) => a === b;
        for(let i = 0; i < Math.trunc(numberAsString.length / 2); i++){
             if(!areEqual(numberAsString[i], numberAsString[numberAsString.length - i - 1])){
                return false;
             }
        }
        return true;
    }
}

//solve([123,323,421,121]);
//01. Smallest of Three Numbers

function printSmallestNumber(a, b, c) {
  console.log(Math.min(a, b, c));
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

  console.log(
    `Odd sum = ${getSum(number, oddFunction)}, Even sum = ${getSum(
      number,
      evenFunction
    )}`
  );
}

//printSums(3495892137259234);

//05. Palindrome Integers

function solve(numbers) {
  numbers.forEach((number) => console.log(checkPalindrome(number.toString())));

  function checkPalindrome(numberAsString) {
    let areEqual = (a, b) => a === b;
    for (let i = 0; i < Math.trunc(numberAsString.length / 2); i++) {
      if (
        !areEqual(
          numberAsString[i],
          numberAsString[numberAsString.length - i - 1]
        )
      ) {
        return false;
      }
    }
    return true;
  }
}

//solve([123,323,421,121]);

//06. Password Validator

function validatePassword(password) {
  const isDigit = (c) => c.charCodeAt(0) >= 48 && c.charCodeAt(0) <= 57;
  const isLetter = (c) =>
    (c.charCodeAt(0) >= 65 && c.charCodeAt(0) <= 90) ||
    (c.charCodeAt(0) >= 97 && c.charCodeAt(0) <= 122);
  const hasValidLength = (p) => p.length >= 6 && p.length <= 10;

  let hasValidSymbols = (p) => {
    for (const char of p) {
      if (!isDigit(char) && !isLetter(char)) {
        return false;
      }
    }

    return true;
  };

  let hasEnoughDigits = (p) => {
    let count = 0;

    for (const char of p) {
      if (isDigit(char)) {
        count++;
      }
    }

    return count >= 2;
  };

  let isValid = true;

  if (!hasValidLength(password)) {
    console.log("Password must be between 6 and 10 characters");
    isValid = false;
  }

  if (!hasValidSymbols(password)) {
    console.log("Password must consist only of letters and digits");
    isValid = false;
  }

  if (!hasEnoughDigits(password)) {
    console.log("Password must have at least 2 digits");
    isValid = false;
  }

  if (isValid) {
    console.log("Password is valid");
  }
}

//validatePassword('Pa$s$s');

//07. NxN Matrix
function solve(number) {
  function getLine(number) {
    let line = "";

    for (let i = 0; i < number; i++) {
      line += number + " ";
    }

    return line.trimEnd();
  }

  for (let i = 0; i < number; i++) {
    console.log(getLine(number));
  }
}

//solve(10);

//08. Perfect Number
function perfectNumber(number) {
  if (number <= 0) {
    return console.log("It's not so perfect.");
  }

  function sumOfDivisors(number) {
    let sum = 0;

    for (i = 1; i <= number / 2; i++) {
      if (number % i === 0) {
        sum += i;
      }
    }

    return sum;
  }

  let result = sumOfDivisors(number) === number ? 'We have a perfect number!' : 'It\'s not so perfect.';
  console.log(result);
}

//perfectNumber(1236498);

//09. Loading Bar
function loadingBar(number){

  function createBar(a){
    let loadedCount = 0;

    if(a > 0){
      loadedCount = a / 10;
    }

    let difference = 10 - loadedCount;

    return `${number}% [${'%'.repeat(loadedCount)}${'.'.repeat(difference)}]`;
  }

  if(number < 100){
    console.log(createBar(number));
    console.log('Still loading...');
  } else{
    console.log('100% Complete!');
    console.log('[%%%%%%%%%%]')
  }
}

//loadingBar(50);

// 10. Factorial Division
//safe int? = is fine, js safe max int is quite the large number, yay!
function factorialDivision(a, b){
  function getFactorial(number){
    if(number === 1){
      return 1;
    }

    let sum  = number * getFactorial(--number);
    return sum;
  }

  let factorialOfA = getFactorial(a);
  let factorialOfB = getFactorial(b);
  let division = factorialOfA / factorialOfB;

  console.log(division.toFixed(2));
}

//factorialDivision(6,2);

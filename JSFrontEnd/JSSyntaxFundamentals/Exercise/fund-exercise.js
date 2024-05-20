//01. Ages
function printAgeCategory(age) {
  let result;

  if (age >= 66) {
    result = "elder";
  } else if (age >= 20) {
    result = "adult";
  } else if (age >= 14) {
    result = "teenager";
  } else if (age >= 3) {
    result = "child";
  } else if (age >= 0) {
    result = "baby";
  } else {
    result = "out of bounds";
  }

  console.log(result);
}

//printAgeCategory(-1);

//02. Vacation
function getPrice(amount, groupType, day) {
  let price;

  if (groupType === "Students") {
    if (day === "Friday") {
      price = 8.45;
    } else if (day === "Saturday") {
      price = 9.8;
    } else {
      price = 10.46;
    }
  } else if (groupType == "Business") {
    if (day === "Friday") {
      price = 10.9;
    } else if (day === "Saturday") {
      price = 15.6;
    } else {
      price = 16;
    }
  } else {
    if (day === "Friday") {
      price = 15;
    } else if (day === "Saturday") {
      price = 20;
    } else {
      price = 22.5;
    }
  }

  if (amount >= 30 && groupType === "Students") {
    price *= 0.85;
  } else if (amount >= 100 && groupType === "Business") {
    amount -= 10;
  } else if (amount >= 10 && amount <= 20 && groupType === "Regular") {
    price *= 0.95;
  }

  let finalPrice = amount * price;

  console.log(`Total price: ${finalPrice.toFixed(2)}`);
}

//getPrice(110,"Business","Saturday");

//03. Leap Year
function leapYearOrNot(year) {
  let result = "no";

  if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
    result = "yes";
  }

  console.log(result);
}

//leapYearOrNot(2003);

//04. Print And Sum

function printNumbersAndSum(a, b) {
  let biggerNumber = Math.max(a, b);
  let smallerNumber = Math.min(a, b);
  let resultString = "";
  let sum = 0;

  for (i = smallerNumber; i <= biggerNumber; i++) {
    resultString += i + " ";
    sum += i;
  }

  console.log(resultString.trimEnd());
  console.log(`Sum: ${sum}`);
}

//printNumbersAndSum(0, 26);

//05. Multiplication Table

function getMultiplicationTableOfANumber(number) {
  for (i = 1; i <= 10; i++) {
    console.log(`${number} X ${i} = ${number * i}`);
  }
}

//getMultiplicationTableOfANumber(100);

//06. Sum Digits

function getDigitsSum(number) {
  let sum = 0;

  while (number > 0) {
    let currentDigit = number % 10;
    sum += currentDigit;
    number = Math.floor(number / 10);
  }

  console.log(sum);
}

//getDigitsSum(97561);

//07. Chars to String

function concatChars(a, b, c) {
  console.log(`${a}${b}${c}`);
}

//concatChars('1','5','p');

//08. Reversed Chars

function printReversedChars(a, b, c) {
  console.log(`${c} ${b} ${a}`);
}

//printReversedChars('A','B','C');

//09. Fruit

function getFruitPrice(fruit, weightGr, pricePerKg) {
  let weigthInKg = weightGr / 1000;
  console.log(
    `I need $${(pricePerKg * weigthInKg).toFixed(
      2
    )} to buy ${weigthInKg.toFixed(2)} kilograms ${fruit}.`
  );
}

//getFruitPrice('apple', 1563, 2.35);

//10. Same Numbers

function sameDigits(number) {
  let areSameDigits = true;
  let sum = 0;
  let lastDigit = number % 10;

  while (number > 0) {
    let currentDigit = number % 10;
    sum += currentDigit;
    number = Math.floor(number / 10);

    if (currentDigit !== lastDigit) {
      areSameDigits = false;
    }
    lastDigit = currentDigit;
  }
  console.log(areSameDigits);
  console.log(sum);
}

//sameDigits(1234);

//11. Road Radar

function roadRadar(speed, area) {
  let isWithinLimits = true;
  let speedLimit = 0;

  if (area === "motorway") {
    speedLimit = 130;
  } else if (area === "interstate") {
    speedLimit = 90;
  } else if (area === "city") {
    speedLimit = 50;
  } else {
    speedLimit = 20;
  }

  if (speedLimit < speed) {
    isWithinLimits = false;
  }

  let speedDifference = speed - speedLimit;

  if (isWithinLimits) {
    console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
  } else {
    let status;

    if (speedDifference <= 20) {
      status = "speeding";
    } else if (speedDifference <= 40) {
      status = "excessive speeding";
    } else {
      status = "reckless driving";
    }

    console.log(
      `The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`
    );
  }
}

//roadRadar(200, 'motorway');

//12. Cooking by Numbers

function cook(startingPoint, action1, action2, action3, action4, action5) {
  let result = Number(startingPoint);
  const actions = [action1, action2, action3, action4, action5];

  for (i = 0; i < actions.length; i++) {
    let currentAction = actions[i];

    switch (currentAction) {
      case "chop":
        result /= 2;
        break;
      case "dice":
        result = Math.sqrt(result);
        break;
      case "spice":
        result++;
        break;
      case "bake":
        result *= 3;
        break;
      default:
        result *= 0.8;
        break;
    }

    console.log(result);
  }
}

//cook("9", "dice", "spice", "chop", "bake", "fillet");

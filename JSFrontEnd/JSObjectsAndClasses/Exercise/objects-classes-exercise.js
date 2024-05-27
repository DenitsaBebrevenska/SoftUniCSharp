//01. Employees
function solve(employeesArray) {
  let employeeList = [];

  for (const employee of employeesArray) {
    employeeList.push({
      name: employee,
      personalNumber: employee.length,
    });
  }

  employeeList.forEach((entry) =>
    console.log(
      `Name: ${entry.name} -- Personal Number: ${entry.personalNumber}`
    )
  );
}

// solve([
//     'Silas Butler',
//     'Adnaan Buckley',
//     'Juan Peterson',
//     'Brendan Villarreal'
//     ]);

//02. Towns
function solve(townsArray) {
  let townObjects = [];
  let splitTokens = townsArray.map(
    (entry) => ([town, latitude, longitude] = entry.split(" | "))
  );

  splitTokens.forEach((token) =>
    townObjects.push({
      town: token[0],
      latitude: Number(token[1]).toFixed(2),
      longitude: Number(token[2]).toFixed(2),
    })
  );

  townObjects.forEach((town) => console.log(town));
}

//solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);

//03. Store Provision
function solve(stockInfo, deliveryInfo) {
  let products = {};

  function fillProductsWithProductInfo(productsInfo, products) {
    for (let i = 0; i < productsInfo.length; i += 2) {
      let productName = productsInfo[i];
      let productQuantity = Number(productsInfo[i + 1]);

      if (!products[productName]) {
        products[productName] = 0;
      }

      products[productName] += productQuantity;
    }

    return products;
  }

  products = fillProductsWithProductInfo(stockInfo, products);
  products = fillProductsWithProductInfo(deliveryInfo, products);

  for (const product in products) {
    console.log(`${product} -> ${products[product]}`);
  }
}

// solve([
//     'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
//     ],
//     [
//     'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
//     ]);

//04. Movies

function solve(input) {
  let movies = [];

  for (let i = 0; i < input.length; i++) {
    let currentLine = input[i];

    if (currentLine.includes("addMovie")) {
      let movieName = currentLine.split("addMovie ").join("");
      movies.push({ name: movieName });
    } else if (currentLine.includes("directedBy")) {
      let tokens = currentLine.split(" directedBy ");
      let movieName = tokens[0];
      let movieDirector = tokens[1];
      let movieIndex = movies.findIndex((movie) => movie.name === movieName);

      if (movieIndex >= 0) {
        movies[movieIndex].director = movieDirector;
      }
    } else {
      //meaning it includes 'onDate'
      let tokens = currentLine.split(" onDate ");
      let movieName = tokens[0];
      let movieDate = tokens[1];
      let movieIndex = movies.findIndex((movie) => movie.name === movieName);

      if (movieIndex >= 0) {
        movies[movieIndex].date = movieDate;
      }
    }
  }

  movies
    .filter(
      (movie) =>
        movie.hasOwnProperty("director") && movie.hasOwnProperty("date")
    )
    .forEach((movie) => console.log(JSON.stringify(movie)));
}

// solve([
//   "addMovie The Avengers",
//   "addMovie Superman",
//   "The Avengers directedBy Anthony Russo",
//   "The Avengers onDate 30.07.2010",
//   "Captain America onDate 30.07.2010",
//   "Captain America directedBy Joe Russo",
// ]);

//05. Inventory
function solve(input) {
  class Hero {
    constructor(name, level, items) {
      this.name = name;
      this.level = Number(level);
      this.items = items;
    }
  }

  let heroRegister = [];

  for (let i = 0; i < input.length; i++) {
    let [name, level, items] = input[i].split(" / ");
    heroRegister.push(new Hero(name, level, items));
  }

  heroRegister.sort((a, b) => {
    return a.level - b.level;
  });

  heroRegister.forEach((hero) => {
    console.log(`Hero: ${hero.name}`);
    console.log(`level => ${hero.level}`);
    console.log(`items => ${hero.items}`);
  });
}

// solve([
//     'Isacc / 25 / Apple, GravityGun',
//     'Derek / 102 / BarrelVest, DestructionSword',
//     'Hes / 1 / Desolator, Sentinel, Antara'
//     ]);

//06. Word Tracker

function solve(input) {
  let trackedWords = input.shift().split(" ");
  let wordTracker = {};

  trackedWords.forEach((word) => (wordTracker[word] = 0));

  for (const word of input.filter((word) => trackedWords.includes(word))) {
    wordTracker[word] += 1;
  }

  Object.entries(wordTracker)
    .sort((a, b) => b[1] - a[1])
    .forEach(([key, value]) => console.log(`${key} - ${value}`));
}

// solve([
//     'is the',
//     'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']);

//07. Odd Occurrences
function solve(input) {
  let wordOccurrences = [];
  let words = input.toLowerCase().split(" ");

  for (const word of words) {
    let indexWord = wordOccurrences.findIndex(
      (wordObj) => wordObj.value === word
    );

    if (indexWord < 0) {
      wordOccurrences.push({ value: word, count: 1 });
      continue;
    }

    wordOccurrences[indexWord].count += 1;
  }

  let oddOccurrences = Array.from(
    wordOccurrences
      .filter((word) => word.count % 2 !== 0)
      .map((word) => word.value)
  );
  console.log(oddOccurrences.join(" "));
}

//solve('Cake IS SWEET is Soft CAKE sweet Food');

//08. Piccolo
function solve(input) {
  let parkingLot = {};

  for (let i = 0; i < input.length; i++) {
    let tokens = input[i].split(", ");
    let direction = tokens[0];
    let carRegistrationNumber = tokens[1];

    if (direction === "IN") {
      parkingLot[carRegistrationNumber] = "IN";
    } else {
      if (parkingLot.hasOwnProperty(carRegistrationNumber)) {
        parkingLot[carRegistrationNumber] = "OUT";
      }
    }
  }

  let carsInLot = Object.entries(parkingLot)
    .filter(([key, value]) => value === "IN")
    .map(([key, value]) => key)
    .sort((a, b) => a.localeCompare(b));

  console.log(
    carsInLot.length === 0 ? "Parking Lot is Empty" : carsInLot.join("\n")
  );
}

// solve(['IN, CA2844AA',
// 'IN, CA1234TA',
// 'OUT, CA2844AA',
// 'OUT, CA1234TA']);

//09. Make a Dictionary

function solve(input) {
  let dictionary = {};

  for (const line of input) {
    let parsedObject = JSON.parse(line);
    let [key, value] = Object.entries(parsedObject)[0];
    dictionary[key] = value;
  }

  let sortedDictionaryKeys = Object.keys(dictionary).sort();

  sortedDictionaryKeys.forEach((word) =>
    console.log(`Term: ${word} => Definition: ${dictionary[word]}`)
  );
}

solve([
  '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
  '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
  '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
  '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
  '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}',
]);

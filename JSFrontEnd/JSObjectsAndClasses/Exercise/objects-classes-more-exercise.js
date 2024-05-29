//01. Class Storage
function solve() {
  class Storage {
    constructor(capacity) {
      this.capacity = capacity;
      this.storage = [];
      this.totalCost = 0;
    }

    addProduct(product) {
      this.storage.push(product);
      this.capacity -= product.quantity;
      this.totalCost += product.price * product.quantity;
    }

    getProducts() {
      let jsonArray = [];

      for (const product of this.storage) {
        jsonArray.push(JSON.stringify(product));
      }

      return jsonArray.join("\n");
    }
  }

  //   let productOne = { name: "Cucamber", price: 1.5, quantity: 15 };
  //   let productTwo = { name: "Tomato", price: 0.9, quantity: 25 };
  //   let productThree = { name: "Bread", price: 1.1, quantity: 8 };
  //   let storage = new Storage(50);
  //   storage.addProduct(productOne);
  //   storage.addProduct(productTwo);
  //   storage.addProduct(productThree);
  //   console.log(storage.getProducts());
  //   console.log(storage.capacity);
  //   console.log(storage.totalCost);
}

//02. Catalogue
function solve(products) {
  let productDictionary = {};

  for (const productInfo of products) {
    let [productName, price] = productInfo.split(" : ");

    if (!productDictionary[productName[0]]) {
      productDictionary[productName[0]] = [];
    }
    productDictionary[productName[0]].push({
      name: productName,
      price,
    });
  }

  let sortedDictionaryEntries = Object.entries(productDictionary).sort((a, b) =>
    a[0].localeCompare(b[0])
  );

  for (const [letterIndex, letterProducts] of sortedDictionaryEntries) {
    console.log(letterIndex);
    letterProducts
      .sort((a, b) => a.name.localeCompare(b.name))
      .forEach((product) => console.log(`  ${product.name}: ${product.price}`));
  }
}

//solve(["Omlet : 5.4", "Shirt : 15", "Cake : 59"]);

//03. Class Laptop
function solve() {
  class Laptop {
    constructor(info, quality) {
      this.info = {
        producer: info.producer,
        age: info.age,
        brand: info.brand,
      };
      this.isOn = false;
      this.quality = quality;
    }

    get price() {
      return 800 - this.info.age * 2 + this.quality * 0.5;
    }

    turnOn() {
      this.isOn = true;
      this.quality--;
    }

    turnOff() {
      this.isOn = false;
      this.quality--;
    }

    showInfo() {
      return JSON.stringify({
        producer: this.info.producer,
        age: this.info.age,
        brand: this.info.brand,
      });
    }
  }

  // let info = { producer: "Dell", age: 2, brand: "XPS" };
  // let laptop = new Laptop(info, 10);
  // laptop.turnOn();
  // console.log(laptop.showInfo());
  // laptop.turnOff();
  // console.log(laptop.quality);
  // laptop.turnOn();
  // console.log(laptop.isOn);
  // console.log(laptop.price);
}

//04. Flight Schedule
function solve(input) {
  let sectorFlights = input[0];
  let changingStatuses = input[1];
  let searchedStatus = input[2];

  let flights = [];

  for (const flight of sectorFlights) {
    let tokens = flight.split(" ");

    flights.push({
      identifier: tokens[0],
      destination: tokens[1],
      status: "Ready to fly",
    });
  }

  for (const status of changingStatuses) {
    let tokens = status.split(" ");
    let targetFlight = flights.find(
      (flight) => flight.identifier === tokens[0]
    );
    if (targetFlight) {
      targetFlight.status = tokens[1];
    }
  }

  flights
    .filter((flight) => flight.status === searchedStatus[0])
    .forEach((flight) =>
      console.log(
        `{ Destination: '${flight.destination}', Status: '${flight.status}' }`
      )
    );
}
// solve([
//   [
//     "WN269 Delaware",
//     "FL2269 Oregon",
//     "WN498 Las Vegas",
//     "WN3145 Ohio",
//     "WN612 Alabama",
//     "WN4010 New York",
//     "WN1173 California",
//     "DL2120 Texas",
//     "KL5744 Illinois",
//     "WN678 Pennsylvania",
//   ],
//   [
//     "DL2120 Cancelled",
//     "WN612 Cancelled",
//     "WN1173 Cancelled",
//     "SK430 Cancelled",
//   ],
//   ["Cancelled"],
// ]);

//05. School Register
function solve(input){
  class Grade{
    constructor(number){
      this.number = number;
      this.students = [];
      this.grades = [];
    }
  }

  let schoolRegister = [];

  for(const line of input){
    let tokens = line.split(', ')
      .map(token => token.split(': ')[1]);
    let studentName = tokens[0];
    let studentGrade = Number(tokens[1]);
    let studentAverageScore = Number(tokens[2]);

    if(studentAverageScore < 3){
      continue;
    }

    let targetGrade = schoolRegister.find(grade => grade.number == studentGrade + 1);

    if(!targetGrade){
      let grade = new Grade(studentGrade + 1);
      grade.students.push(studentName);
      grade.grades.push(studentAverageScore);
      schoolRegister.push(grade);
    } else { 
      targetGrade.students.push(studentName);
      targetGrade.grades.push(studentAverageScore);}
  }

  for(const grade of schoolRegister.sort((a, b) => a.number - b.number)){
    console.log(`${grade.number} Grade`);
    console.log(`List of students: ${grade.students.join(', ')}`);
    console.log(`Average annual score from last year: ${(grade.grades.reduce((acc, grade) => acc + grade, 0) / grade.grades.length)
      .toFixed(2)}\n`);
  }
}

// solve([
//   "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
//       "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
//       "Student name: George, Grade: 8, Graduated with an average score: 2.83",
//       "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
//       "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
//       "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
//       "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
//       "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
//       "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
//       "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
//       "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
//       "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
//   ]);


//06. Browser History
function solve(browserObj, actions){
  let parsedObj = Object.entries(browserObj);
  let browser = {
    name: parsedObj.shift()[1],
    openTabs: [],
    recentlyClosed: [],
    logs: []
  };

  let openedTabs = parsedObj.shift()[1];
  openedTabs.forEach(site => browser.openTabs.push(site));

  let closedTabs = parsedObj.shift()[1];
  closedTabs.forEach(site => browser.recentlyClosed.push(site));

  let logs = parsedObj.shift()[1];
  logs.forEach(log => browser.logs.push(log));

  for(const action of actions){
    if(action.includes('Open')){
      let siteName = action.split('Open ')[1];
      browser.openTabs.push(siteName);
      browser.logs.push(action);
    } else if(action.includes('Close')){
      let siteName = action.split('Close ')[1];
      let indexSite = browser.openTabs.findIndex(entry => entry === siteName);

      if(indexSite >= 0){
        browser.openTabs.splice(indexSite, 1);
        browser.logs.push(action);
        browser.recentlyClosed.push(siteName);
      }
    } else {
      browser.openTabs = [];
      browser.recentlyClosed = [];
      browser.logs = [];
    }
  }

  console.log(browser.name);
  console.log(`Open Tabs: ${browser.openTabs.join(', ')}`);
  console.log(`Recently Closed: ${browser.recentlyClosed.join(', ')}`);
  console.log(`Browser Logs: ${browser.logs.join(', ')}`)
}

// solve({"Browser Name":"Google Chrome","Open Tabs":["Facebook","YouTube","Google Translate"],
// "Recently Closed":["Yahoo","Gmail"],
// "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]},
// ["Close Facebook", "Open StackOverFlow", "Open Google"]);
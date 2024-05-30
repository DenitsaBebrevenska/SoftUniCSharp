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
function solve(input) {
  class Grade {
    constructor(number) {
      this.number = number;
      this.students = [];
      this.grades = [];
    }
  }

  let schoolRegister = [];

  for (const line of input) {
    let tokens = line.split(", ").map((token) => token.split(": ")[1]);
    let studentName = tokens[0];
    let studentGrade = Number(tokens[1]);
    let studentAverageScore = Number(tokens[2]);

    if (studentAverageScore < 3) {
      continue;
    }

    let targetGrade = schoolRegister.find(
      (grade) => grade.number == studentGrade + 1
    );

    if (!targetGrade) {
      let grade = new Grade(studentGrade + 1);
      grade.students.push(studentName);
      grade.grades.push(studentAverageScore);
      schoolRegister.push(grade);
    } else {
      targetGrade.students.push(studentName);
      targetGrade.grades.push(studentAverageScore);
    }
  }

  for (const grade of schoolRegister.sort((a, b) => a.number - b.number)) {
    console.log(`${grade.number} Grade`);
    console.log(`List of students: ${grade.students.join(", ")}`);
    console.log(
      `Average annual score from last year: ${(
        grade.grades.reduce((acc, grade) => acc + grade, 0) /
        grade.grades.length
      ).toFixed(2)}\n`
    );
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
function solve(browserObj, actions) {
  let parsedObj = Object.entries(browserObj);
  let browser = {
    name: parsedObj.shift()[1],
    openTabs: [],
    recentlyClosed: [],
    logs: [],
  };

  let openedTabs = parsedObj.shift()[1];
  openedTabs.forEach((site) => browser.openTabs.push(site));

  let closedTabs = parsedObj.shift()[1];
  closedTabs.forEach((site) => browser.recentlyClosed.push(site));

  let logs = parsedObj.shift()[1];
  logs.forEach((log) => browser.logs.push(log));

  for (const action of actions) {
    if (action.includes("Open")) {
      let siteName = action.split("Open ")[1];
      browser.openTabs.push(siteName);
      browser.logs.push(action);
    } else if (action.includes("Close")) {
      let siteName = action.split("Close ")[1];
      let indexSite = browser.openTabs.findIndex((entry) => entry === siteName);

      if (indexSite >= 0) {
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
  console.log(`Open Tabs: ${browser.openTabs.join(", ")}`);
  console.log(`Recently Closed: ${browser.recentlyClosed.join(", ")}`);
  console.log(`Browser Logs: ${browser.logs.join(", ")}`);
}

// solve({"Browser Name":"Google Chrome","Open Tabs":["Facebook","YouTube","Google Translate"],
// "Recently Closed":["Yahoo","Gmail"],
// "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]},
// ["Close Facebook", "Open StackOverFlow", "Open Google"]);

//07. Sequences

function solve(numbersArrays) {
  let arrayLibrary = [];

  for (const line of numbersArrays) {
    let currentArray = line
      .slice(1, line.length - 1)
      .split(", ")
      .map(Number)
      .sort((a, b) => b - a);

    if (!arrayLibrary.some((arr) => arr.length === currentArray.length)) {
      arrayLibrary.push(currentArray);
      continue;
    }

    let existingArray = arrayLibrary.find(
      (arr) =>
        arr.length === currentArray.length &&
        arr.toString() === currentArray.toString()
    );

    if (!existingArray) {
      arrayLibrary.push(currentArray);
    }
  }

  arrayLibrary
    .sort((a, b) => a.length - b.length)
    .forEach((arr) => console.log(`[${arr.join(", ")}]`));
}

// solve(["[7.14, 7.180, 7.339, 80.099]",
// "[7.339, 80.0990, 7.140000, 7.18]",
// "[7.339, 7.180, 7.14, 80.099]"]);

//08. Garage
function solve(input) {
  let garages = {};

  for (let line of input) {
    let garageTokens = line.split(" - ");
    let garageNumber = garageTokens[0];

    if (!garages[garageNumber]) {
      garages[garageNumber] = [];
    }

    let carTokens = garageTokens[1].split(", ");
    let carObj = {};
    for (const propertyInfo of carTokens) {
      let [key, value] = propertyInfo.split(": ");
      carObj[key] = value;
    }

    garages[garageNumber].push(carObj);
  }

  for (const garageNumber in garages) {
    console.log(`Garage № ${garageNumber}`);
    let cars = garages[garageNumber].map((car) =>
      Array.from(Object.entries(car))
    );

    for (const car of cars) {
      let properties = [];
      for (const [key, value] of car) {
        properties.push(`${key} - ${value}`);
      }

      console.log(`--- ${properties.join(", ")}`);
    }
  }
}

// solve(['1 - color: green, fuel type: petrol',
// '1 - color: dark red, manufacture: WV',
// '2 - fuel type: diesel',
// '3 - color: dark blue, fuel type: petrol']);

//09. Armies
function solve(input) {
  let leaders = [];

  for (const line of input) {
    if (line.includes("arrives")) {
      let leaderName = line.split(" arrives")[0];
      leaders.push({
        name: leaderName,
        armies: [],
        totalArmyCount: 0,
      });
    } else if (line.includes(":")) {
      let lineTokens = line.split(": ");
      let leaderName = lineTokens[0];
      let leaderIndex = leaders.findIndex(
        (leader) => leader.name === leaderName
      );

      if (leaderIndex >= 0) {
        let armyTokens = lineTokens[1].split(", ");
        let armyName = armyTokens[0];
        let count = Number(armyTokens[1]);

        leaders[leaderIndex].armies.push({
          armyName,
          count,
        });
        leaders[leaderIndex].totalArmyCount += count;
      }
    } else if (line.includes("+")) {
      let tokens = line.split(" + ");
      let armyName = tokens[0];
      let armyCount = Number(tokens[1]);

      for (const leader of leaders) {
        let armyIndex = leader.armies.findIndex(
          (army) => army.armyName === armyName
        );
        if (armyIndex >= 0) {
          leader.armies[armyIndex].count += armyCount;
          leader.totalArmyCount += armyCount;
          break;
        }
      }
    } else {
      let leaderName = line.split(" defeated")[0];
      if (leaders[leaderName]) {
        delete leaders[leaderName];
      }
    }
  }

  leaders
    .sort((a, b) => b.totalArmyCount - a.totalArmyCount)
    .forEach((leader) => {
      console.log(`${leader.name}: ${leader.totalArmyCount}`);
      leader.armies
        .sort((a, b) => b.count - a.count)
        .forEach((army) => console.log(`>>> ${army.armyName} - ${army.count}`));
    });
}

// solve(['Rick Burr arrives', 'Findlay arrives', 'Rick Burr: Juard, 1500', 'Wexamp arrives', 'Findlay: Wexamp, 34540', 'Wexamp + 340', 'Wexamp: Britox, 1155', 'Wexamp: Juard, 43423']);

//10. Comments
function solve(input) {
  let registeredUsers = [];
  let writtenArticles = [];
  let articlesComments = [];

  for (const line of input) {
    if (line.includes("user")) {
      let username = line.split("user ").filter((string) => string !== "");
      registeredUsers.push(username);
    } else if (line.includes("article")) {
      let articleName = line
        .split("article ")
        .filter((string) => string !== "");
      writtenArticles.push(articleName);
      articlesComments.push({
        name: articleName,
        comments: [],
      });
    } else {
      let tokens = line.split(" posts on ");
      let username = tokens[0];

      if (!registeredUsers.some((user) => user[0] === username)) {
        continue;
      }

      tokens = tokens[1].split(": ");
      let articleName = tokens[0];

      if (!writtenArticles.some((article) => article[0] === articleName)) {
        continue;
      }

      tokens = tokens[1].split(", ");
      let commentTitle = tokens[0];
      let commentBody = tokens[1];

      let targetArticle = articlesComments.find(
        (article) => article.name == articleName
      );
      targetArticle.comments.push({
        username,
        comment: `${commentTitle} - ${commentBody}`,
      });
    }
  }

  articlesComments
    .sort((a, b) => b.comments.length - a.comments.length)
    .forEach((article) => {
      console.log(`Comments on ${article.name}`);
      article.comments
        .sort((a, b) => a.username.localeCompare(b.username))
        .forEach((comment) =>
          console.log(`--- From user ${comment.username}: ${comment.comment}`)
        );
    });
}

// solve(['user Mark', 'Mark posts on someArticle: NoTitle, stupidComment', 'article Bobby', 'article Steven', 'user Liam', 'user Henry', 'Mark posts on Bobby: Is, I do really like them', 'Mark posts on Steven: title, Run', 'someUser posts on Movies: Like']);

//11. Book Shelf
function solve(input) {
  let shelves = [];

  for (const line of input) {
    if (line.includes("->")) {
      let tokens = line.split(" -> ").filter((string) => string !== "");
      let shelfId = Number(tokens[0]);

      if (shelves.some((shelf) => shelf.id == shelfId)) {
        continue;
      }

      let shelfGenre = tokens[1];
      shelves.push({
        id: shelfId,
        genre: shelfGenre,
        books: [],
      });
    } else {
      let tokens = line.split(": ");
      let bookTitle = tokens[0];
      tokens = tokens[1].split(", ");
      let bookAuthor = tokens[0];
      let bookGenre = tokens[1];

      let targetShelf = shelves.find((shelf) => shelf.genre == bookGenre);
      if (targetShelf) {
        targetShelf.books.push(`${bookTitle}: ${bookAuthor}`);
      }
    }
  }

  shelves
    .sort((a, b) => b.books.length - a.books.length)
    .forEach((shelf) => {
      console.log(`${shelf.id} ${shelf.genre}: ${shelf.books.length}`);
      shelf.books
        .sort((a, b) => a.localeCompare(b))
        .forEach((book) => console.log(`--> ${book}`));
    });
}

// solve(['1 -> history', '1 -> action', 'Death in Time: Criss Bell, mystery', '2 -> mystery', '3 -> sci-fi', 'Child of Silver: Bruce Rich, mystery', 'Hurting Secrets: Dustin Bolt, action', 'Future of Dawn: Aiden Rose, sci-fi', 'Lions and Rats: Gabe Roads, history', '2 -> romance', 'Effect of the Void: Shay B, romance', 'Losing Dreams: Gail Starr, sci-fi', 'Name of Earth: Jo Bell, sci-fi', 'Pilots of Stone: Brook Jay, history']);

//12. SoftUni Students
function solve(input) {
  //[courses] -> name, capacity, students[] -> student -> username, email, credits
  let courses = [];

  for (const line of input) {
    if (line.includes(":")) {
      let tokens = line.split(": ").filter((string) => string !== "");
      let courseName = tokens[0];
      let courseCapacity = Number(tokens[1]);

      let courseIndex = courses.findIndex(
        (course) => course.name === courseName
      );

      if (courseIndex >= 0) {
        courses[courseIndex].capacity += courseCapacity;
        continue;
      }

      courses.push({
        name: courseName,
        capacity: courseCapacity,
        students: [],
      });
    } else {
      let tokens = line.split('[');
      let username = tokens[0];
      tokens = tokens[1].split('] with email ');
      let creditCount = Number(tokens[0]);
      tokens = tokens[1].split(' ');
      let email = tokens[0];
      let courseName = tokens[2];

      let courseIndex = courses.findIndex(course => course.name === courseName);

      if(courseIndex < 0){
        continue;
      }

      if(courses[courseIndex].capacity === courses[courseIndex].students.length){
        continue;
      }

      courses[courseIndex].students.push({
        username,
        creditCount,
        email
      })
    }
  }

  courses.sort((a, b) => b.students.length - a.students.length)
    .forEach(course => {
      console.log(`${course.name}: ${course.capacity - course.students.length} places left`);
      course.students.sort((a, b) => b.creditCount - a.creditCount)
        .forEach(student => console.log(`--- ${student.creditCount}: ${student.username}, ${student.email}`))
    })
}

solve([
  "JavaBasics: 2",
  "user1[25] with email user1@user.com joins C#Basics",
  "C#Advanced: 3",
  "JSCore: 4",
  "user2[30] with email user2@user.com joins C#Basics",
  "user13[50] with email user13@user.com joins JSCore",
  "user1[25] with email user1@user.com joins JSCore",
  "user8[18] with email user8@user.com joins C#Advanced",
  "user6[85] with email user6@user.com joins JSCore",
  "JSCore: 2",
  "user11[3] with email user11@user.com joins JavaBasics",
  "user45[105] with email user45@user.com joins JSCore",
  "user007[20] with email user007@user.com joins JSCore",
  "user700[29] with email user700@user.com joins JSCore",
  "user900[88] with email user900@user.com joins JSCore",
]);

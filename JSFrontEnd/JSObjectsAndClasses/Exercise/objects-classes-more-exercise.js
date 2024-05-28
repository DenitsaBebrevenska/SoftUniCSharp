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
  class Laptop {}

  let info = { producer: "Dell", age: 2, brand: "XPS" };
  let laptop = new Laptop(info, 10);
  laptop.turnOn();
  console.log(laptop.showInfo());
  laptop.turnOff();
  console.log(laptop.quality);
  laptop.turnOn();
  console.log(laptop.isOn);
  console.log(laptop.price);
}

solve();

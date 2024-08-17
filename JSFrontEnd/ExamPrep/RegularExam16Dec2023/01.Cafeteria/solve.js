function solve(input) {
  const baristaCount = Number(input.shift());
  let baristas = getBaristas();

  let currentCommand;

  while ((currentCommand = input.shift()) !== "Closed" || input.length > 0) {
    let [action, baristaName, ...tokens] = currentCommand.split(" / ");

    if (action === "Prepare") {
      let shift = tokens[0];
      let drink = tokens[1];

      if (
        baristas[baristaName].shift !== shift ||
        !baristas[baristaName].drinks.includes(drink)
      ) {
        console.log(`${baristaName} is not available to prepare a ${drink}.`);
        continue;
      }

      console.log(`${baristaName} has prepared a ${drink} for you!`);
    } else if (action === "Change Shift") {
      let newShift = tokens[0];
      baristas[baristaName].shift = newShift;
      console.log(`${baristaName} has updated his shift to: ${newShift}`);
    } else {
      //Learn
      let newDrink = tokens[0];
      if (baristas[baristaName].drinks.includes(newDrink)) {
        console.log(`${baristaName} knows how to make ${newDrink}.`);
        continue;
      }

      baristas[baristaName].drinks.push(newDrink);
      console.log(`${baristaName} has learned a new coffee type: ${newDrink}.`);
    }
  }

  printBaristasStatus();

  function getBaristas() {
    let baristas = {};

    for (let i = 0; i < baristaCount; i++) {
      let currentLine = input.shift();
      let [name, shift, drinks] = currentLine.split(" ");
      baristas[name] = {
        shift,
        drinks: drinks.split(","),
      };
    }

    return baristas;
  }

  function printBaristasStatus() {
    for (const barista in baristas) {
      console.log(
        `Barista: ${barista}, Shift: ${
          baristas[barista].shift
        }, Drinks: ${baristas[barista].drinks.join(", ")}`
      );
    }
  }
}

solve([
  "4",
  "Alice day Espresso,Cappuccino",
  "Bob night Latte,Mocha",
  "Carol day Americano,Mocha",
  "David night Espresso",
  "Prepare / Alice / day / Espresso",
  "Change Shift / Bob / day",
  "Learn / Carol / Latte",
  "Prepare / Bob / night / Latte",
  "Learn / David / Cappuccino",
  "Prepare / Carol / day / Cappuccino",
  "Change Shift / Alice / night",
  "Learn / Bob / Mocha",
  "Prepare / David / night / Espresso",
  "Closed",
]);

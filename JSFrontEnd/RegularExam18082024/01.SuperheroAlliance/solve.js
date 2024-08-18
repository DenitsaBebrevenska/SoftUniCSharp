function solve(input) {
  const maxEnergy = 100;
  const heroCount = Number(input.shift());
  let heroes = extractHeroes();
  let currentCommand;

  while ((currentCommand = input.shift()) !== "Evil Defeated!") {
    let [action, heroName, ...tokens] = currentCommand.split(" * ");

    if (action === "Use Power") {
      let requiredSuperpower = tokens[0];
      let requiredEnergy = Number(tokens[1]);
      if (
        !heroes[heroName].superpowers.includes(requiredSuperpower) ||
        heroes[heroName].energy < requiredEnergy
      ) {
        console.log(
          `${heroName} is unable to use ${requiredSuperpower} or lacks energy!`
        );
        continue;
      }

      heroes[heroName].energy -= requiredEnergy;
      console.log(
        `${heroName} has used ${requiredSuperpower} and now has ${heroes[heroName].energy} energy!`
      );
    } else if (action === "Train") {
      let availableEnergy = Number(tokens[0]);
      let heroCurrentEnergy = heroes[heroName].energy;
      if (heroCurrentEnergy === maxEnergy) {
        console.log(`${heroName} is already at full energy!`);
        continue;
      }

      let totalEnergy = heroes[heroName].energy + availableEnergy;
      let rechargedEnergy = Math.min(totalEnergy, maxEnergy);
      heroes[heroName].energy = rechargedEnergy;
      let amountRecharged = heroes[heroName].energy - heroCurrentEnergy;
      console.log(
        `${heroName} has trained and gained ${amountRecharged} energy!`
      );
    } else {
      //Learn
      let newSuperpower = tokens[0];
      if (heroes[heroName].superpowers.includes(newSuperpower)) {
        console.log(`${heroName} already knows ${newSuperpower}.`);
        continue;
      }

      heroes[heroName].superpowers.push(newSuperpower);
      console.log(`${heroName} has learned ${newSuperpower}!`);
    }
  }

  printHeroes();

  function extractHeroes() {
    let extractedHeroes = {};
    for (let i = 0; i < heroCount; i++) {
      let tokens = input.shift().split("-");
      let heroName = tokens[0];
      let superpowers = tokens[1].split(",");
      let energy = Number(tokens[2]);
      extractedHeroes[heroName] = {
        superpowers,
        energy,
      };
    }

    return extractedHeroes;
  }

  function printHeroes() {
    for (const hero in heroes) {
      console.log(`Superhero: ${hero}`);
      console.log(`- Superpowers: ${heroes[hero].superpowers.join(", ")}`);
      console.log(`- Energy: ${heroes[hero].energy}`);
    }
  }
}

solve([
  "2",
  "Iron Man-Repulsor Beams,Flight-100",
  "Thor-Lightning Strike,Hammer Throw-50",
  "Train * Thor * 20",
  "Learn * Thor * Hammer Throw",
  "Use Power * Iron Man * Repulsor Beams * 30",
  "Evil Defeated!",
]);

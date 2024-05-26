//01. Car Wash
function solve(actions) {
  const useSoap = (a) => (a += 10);
  const useWater = (a) => (a *= 1.2);
  const useVacuum = (a) => (a *= 1.25);
  const getDirty = (a) => (a *= 0.9);

  let cleanliness = 0;

  for (let i = 0; i < actions.length; i++) {
    switch (actions[i]) {
      case "soap":
        cleanliness = useSoap(cleanliness);
        break;
      case "water":
        cleanliness = useWater(cleanliness);
        break;
      case "vacuum cleaner":
        cleanliness = useVacuum(cleanliness);
        break;
      case "mud":
        cleanliness = getDirty(cleanliness);
        break;
    }
  }

  console.log(`The car is ${cleanliness.toFixed(2)}% clean.`);
}

//solve(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);

//02. Number Modification
function getModifiedNumber(number){
    let digits = (number.toString()
        .split('')).map(Number);
    const getAverage = array => array.reduce((a,b) => a + b, 0) / array.length;
    const canBeModified = a => getAverage(a) <= 5;
    

    while(canBeModified(digits)){
      digits.push(9);
    }

    console.log(Number(digits.join('')));
}

//getModifiedNumber(101);

//03. Points Validation
function solve(points){
  const isValidDistanceToCenter = (x, y) => Number.isInteger(Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2)));
  const isValidDistanceBetweenPoints = arr => Number
    .isInteger(Math.sqrt(Math.pow(arr[2] - arr[0], 2) + Math.pow(arr[3] - arr[1], 2)));
  const getValidityStatus = func => func ? 'valid' : 'invalid';

  const x1 = points[0];
  const y1 = points[1];
  const x2 = points[2];
  const y2 = points[3];

  let firstPointStatus = getValidityStatus(isValidDistanceToCenter(x1, y1));
  let secondPointValidity = getValidityStatus(isValidDistanceToCenter(x2, y2));
  let bothPointsValidity = getValidityStatus(isValidDistanceBetweenPoints(points)); 

  console.log(`{${x1}, ${y1}} to {0, 0} is ${firstPointStatus}`);
  console.log(`{${x2}, ${y2}} to {0, 0} is ${secondPointValidity}`);
  console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${bothPointsValidity}`);
}

//solve([2, 1, 1, 1]);

//04. Radio Crystals
function solve(tokens){
  const desiredThickness = tokens[0];
  tokens.shift();

  const cutOre = a => a / 4;
  const lapOre = a => a * 0.8;
  const grindOre = a => a - 20;
  const etchOre = a => a - 2;
  const xrayOre = a => ++a;
  const transportAndWashOre = a => {
    console.log('Transporting and washing');
    return Math.trunc(a);
  }
  const printActionStatus = (action, counter) => console.log(`${action} x${counter}`);
  const processOre = (chunk, action, counter, currentAction) => {
    while(action(chunk) >= desiredThickness || action(chunk) + 1 === desiredThickness){
      counter++;
      chunk = action(chunk);
    }

    printActionStatus(currentAction, counter);
    return chunk;
  }

  for(let i = 0; i < tokens.length; i++){
    let currentChunk = tokens[i];
    console.log(`Processing chunk ${currentChunk} microns`);
    let xRayUsed  = false;

    if(cutOre(currentChunk) >= desiredThickness){
      currentChunk = processOre(currentChunk, cutOre, 0, 'Cut');
      currentChunk = transportAndWashOre(currentChunk);
    }

    if(lapOre(currentChunk) >= desiredThickness){
      currentChunk = processOre(currentChunk, lapOre, 0, 'Lap');
      currentChunk = transportAndWashOre(currentChunk);
    }

    if(grindOre(currentChunk) >= desiredThickness){
      currentChunk = processOre(currentChunk, grindOre, 0, 'Grind');
      currentChunk = transportAndWashOre(currentChunk);
    }

    if(etchOre(currentChunk) >= desiredThickness){
      currentChunk = processOre(currentChunk, etchOre, 0, 'Etch');
      currentChunk = transportAndWashOre(currentChunk);
    }

    if(!xRayUsed && xrayOre(currentChunk) === desiredThickness){
      currentChunk = xrayOre(currentChunk);
      console.log('X-ray x1');
      xRayUsed = true;
    }

    console.log(`Finished crystal ${currentChunk} microns`);
  }
}

//solve([1375, 50000]);

//

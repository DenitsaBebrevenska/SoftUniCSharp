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
function getModifiedNumber(...digits){
    const canBeModified = a => 
}

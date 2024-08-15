function solve(input) {
  let message = input.shift();
  let currentCommand = input.shift();

  while (currentCommand !== "Buy") {
    if (currentCommand === "TakeEven") {
      message = message.split("").reduce((acc, char, index) => {
        if (index % 2 === 0) {
          return acc + char;
        }
        return acc;
      }, "");
      console.log(message);
    } else if (currentCommand.includes("ChangeAll")) {
      currentCommand = currentCommand.split("?");
      let substring = currentCommand[1];
      let replacement = currentCommand[2];
      //replaceAll() doesn`t work for Judge
      while (true) {
        if (!message.includes(substring)) {
          break;
        }

        message = message.replace(substring, replacement);
      }

      console.log(message);
    } else {
      //Reverse
      currentCommand = currentCommand.split("?");
      let substring = currentCommand[1];
      if (message.includes(substring)) {
        //just the first occurrence
        let occurrenceIndex = message.indexOf(substring);
        let firstPart = message.slice(0, occurrenceIndex);
        let secondPart = message.slice(occurrenceIndex + substring.length);
        message = firstPart + secondPart;
        substring = substring.split("").reverse().join("");
        message += substring;
        console.log(message);
      } else {
        console.log("error");
      }
    }

    currentCommand = input.shift();
  }

  console.log(`The cryptocurrency is: ${message}`);
}

solve([
  "PZDfA2PkAsakhnefZ7aZ",
  "TakeEven",
  "TakeEven",
  "TakeEven",
  "ChangeAll?Z?X",
  "ChangeAll?A?R",
  "Reverse?PRX",
  "Buy",
]);

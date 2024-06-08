function solve() {
  let infoTextElement = document.querySelector("#info > span");
  let departButtonElement = document.getElementById("depart");
  let arrivalButtonElement = document.getElementById("arrive");
  let url = "http://localhost:3030/jsonstore/bus/schedule/";
  let currentStop = "";
  let nextStop = "depot";

  // first solution before knowing async await syntax
  //   function depart() {
  //     fetch(url + nextStop)
  //     .then((response) => response.json())
  //     .then((busStopData) => {
  //      currentStop = busStopData.name;
  //      infoTextElement.textContent = `Next stop ${currentStop}`;
  //      departButtonElement.disabled = true;
  //      arrivalButtonElement.disabled = false;
  //      nextStop = busStopData.next;
  //     })
  //     .catch(err => {
  //      infoTextElement.textContent = 'Error';
  //      departButtonElement.disabled = true;
  //      arrivalButtonElement.disabled = true;
  //     })
  //  }

  //second solution
  async function depart() {
    try {
      const response = await fetch(url + nextStop);
      const data = await response.json();

      currentStop = data.name;
      infoTextElement.textContent = `Next stop ${currentStop}`;
      departButtonElement.disabled = true;
      arrivalButtonElement.disabled = false;
      nextStop = data.next;
    } catch {
      infoTextElement.textContent = "Error";
      departButtonElement.disabled = true;
    }
  }

  async function arrive() {
    infoTextElement.textContent = `Arriving at ${currentStop}`;
    departButtonElement.disabled = false;
    arrivalButtonElement.disabled = true;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();

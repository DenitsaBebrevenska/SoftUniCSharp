function solve() {
    let infoTextElement = document.getElementById('info');
    let departButtonElement = document.getElementById('depart');
    let arrivalButtonElement = document.getElementById('arrive');
    let url = 'http://localhost:3030/jsonstore/bus/schedule/';
    let currentStop = '';
    let nextStop = 'depot';

    function depart() {
       fetch(url + nextStop)
       .then((response) => {
        if(response.ok){
           return response.json()}
           throw new Error;
    })
       .then((busStopData) => {
        currentStop = busStopData.name;
        infoTextElement.textContent = `Next stop ${currentStop}`;
        departButtonElement.disabled = true;
        arrivalButtonElement.disabled = false;
        nextStop = busStopData.next;
       })
       .catch(err => {
        infoTextElement.textContent = 'Error';
        departButtonElement.disabled = true;
        arrivalButtonElement.disabled = true;
       })
    }

    async function arrive() {
        infoTextElement.textContent = `Arriving at ${currentStop}`;
        departButtonElement.disabled = false;
        arrivalButtonElement.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
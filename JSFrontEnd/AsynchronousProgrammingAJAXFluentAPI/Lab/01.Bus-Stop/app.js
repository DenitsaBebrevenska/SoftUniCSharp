function getInfo() {
    const url = 'http://localhost:3030/jsonstore/bus/businfo/';
    let inputStopElement = document.getElementById('stopId');
    let stopNameResultElement = document.getElementById('stopName');
    let bussesListElement = document.getElementById('buses');
    let targetBusStop = inputStopElement.value;

    bussesListElement.innerHTML = '';
    
    fetch(url + targetBusStop)
    .then((response) => response.json())
    .then((data) => {
        stopNameResultElement.textContent = data.name;
        let fragment = document.createDocumentFragment();

        for (const bus in data.buses) {
           let newLiElement = document.createElement('li');
           newLiElement.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
           fragment.appendChild(newLiElement);
        }
        bussesListElement.appendChild(fragment);
    })
    .catch(err => stopNameResultElement.textContent = `Error`)

}
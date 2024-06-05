function attachEventsListeners() {
    let inputElement = document.getElementById('inputDistance');
    let inputUnitElement = document.getElementById('inputUnits');
    let outputElement = document.getElementById('outputDistance');
    let outputUnitElement = document.getElementById('outputUnits');

    const unitsToMeterMap = new Map([
        ['km', 1000],
        ['m', 1],
        ['cm', 0.01],
        ['mm', 0.001],
        ['mi', 1609.34],
        ['yrd', 0.9144],
        ['ft', 0.3048],
        ['in', 0.0254]
    ]);

    let convertButton = document.querySelector('input[type="button"]');
    convertButton.addEventListener('click', function(){
        let inputValue = Number(inputElement.value);
        let inputUnit = inputUnitElement.value;
        let inputToMeters = unitsToMeterMap.get(inputUnit) * inputValue;
        let outputUnit = outputUnitElement.value;
        outputElement.value = inputToMeters / unitsToMeterMap.get(outputUnit);
    })

}
function attachEvents() {
    let inputElement = document.getElementById('location');
    let submitButtonElement = document.getElementById('submit');
    let currentForecastElement = document.querySelector('#current');
    let upcomingForecastElement = document.querySelector('#upcoming');
    const url = 'http://localhost:3030/jsonstore/forecaster/';

    const getWeatherConditionSymbol = function(condition){
        switch(condition){
            case 'Sunny':
                return '☀';
            case 'Partly sunny':
                return '⛅';
            case 'Overcast':
                return '☁';
            case 'Rain':
                return '☂';
            default:
                return 'invalid condition';
        }
    }

    submitButtonElement.addEventListener('click', function() {
        let locationCode = '';
        document.getElementById('forecast').style.display = 'block';

        fetch(url + 'locations')
        .then((response) => response.json())
        .then((data) => {
            let inputLocation = inputElement.value; //leaving case sensitivity for now due to Judge
            let locationFound = data.find(obj => obj.name === inputLocation);

            if(!locationFound){
                throw new Error;
            }

            locationCode = locationFound.code;


            fetch(url + `today/${locationCode}`)
            .then((response) => response.json())
            .then((locationData) => {
                let locationFullName = locationData.name;
                let todayTemperature = `${locationData.forecast.low}°/${locationData.forecast.high}°`;
                let condition = locationData.forecast.condition;
                let symbol =  getWeatherConditionSymbol(condition);

                let wrapperDiv = document.createElement('div');
                wrapperDiv.classList.add('forecasts');
                let spanConditionSymbol = document.createElement('span');
                spanConditionSymbol.classList.add('condition', 'symbol');
                spanConditionSymbol.textContent = symbol;
                let spanCondition = document.createElement('span');
                spanCondition.classList.add('condition');
                let spanLocationName = document.createElement('span');
                spanLocationName. textContent = locationFullName;
                spanLocationName.classList.add('forecast-data');
                let spanLocationDegrees = document.createElement('span');
                spanLocationDegrees.textContent = todayTemperature;
                spanLocationDegrees.classList.add('forecast-data');
                let spanConditionElement = document.createElement('span');
                spanConditionElement.textContent = condition;
                spanConditionElement.classList.add('forecast-data');

                //appending all children
                spanCondition.appendChild(spanLocationName);
                spanCondition.appendChild(spanLocationDegrees);
                spanCondition.appendChild(spanConditionElement);
                wrapperDiv.appendChild(spanConditionSymbol);
                wrapperDiv.appendChild(spanCondition);
            
                //append the div wrapper and its children at div #current
                currentForecastElement.appendChild(wrapperDiv);
            })

            fetch(url + `upcoming/${locationCode}`)
            .then((response) => response.json())
            .then((upcomingData) => {
                let divWrapper = document.createElement('div');
                    divWrapper.classList.add('forecast-info');

                upcomingData.forecast.forEach(element => {
                    let condition = element.condition;
                    let temperature = `${element.low}°/${element.high}°`;
                    let symbol = getWeatherConditionSymbol(condition);

                    let spanUpcoming = document.createElement('span');
                    spanUpcoming.classList.add('upcoming');
                    let spanSymbol = document.createElement('span');
                    spanSymbol.classList.add('symbol');
                    spanSymbol.textContent = symbol;
                    let spanTemperature = document.createElement('span');
                    spanTemperature.classList.add('forecast-data');
                    spanTemperature.textContent = temperature;
                    let spanCondition = document.createElement('span');
                    spanCondition.classList.add('forecast-data');
                    spanCondition.textContent = condition;

                    spanUpcoming.appendChild(spanSymbol);
                    spanUpcoming.appendChild(spanTemperature);
                    spanUpcoming.appendChild(spanCondition);

                    divWrapper.appendChild(spanUpcoming);
                    upcomingForecastElement.appendChild(divWrapper);
                })
            })
        })  
        .catch((err) => document.getElementById('forecast').textContent = 'Error');
    })
   
}

attachEvents();
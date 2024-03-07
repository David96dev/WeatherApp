
// const timeEl = document.getElementById('time');
// const dateEl = document.getElementById('date');
// const currentWeatherItemsEl = document.getElementById('current-weather-items');
// const timezone = document.getElementById('time-zone');
// const countryEl = document.getElementById('country');
// const weatherForecastEl = document.getElementById('weather-forecast');
// const currentTempEl = document.querySelector('#current-temp');


// const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday']
// const months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
// const apiKey = 'b2d3ffa681763c6b3031bde24550a6b1';

// setInterval(() => {
//     const time = new Date();
//     const month = time.getMonth();
//     const date = time.getDate();
//     const day = time.getDay();
//     const hour = time.getHours();
//     const hoursIn12HrFormat = hour >= 13 ? hour %12: hour
//     const minutes = time.getMinutes();
//     const ampm = hour >=12 ? 'PM' : 'AM'

//     timeEl.innerHTML = (hoursIn12HrFormat < 10? '0'+hoursIn12HrFormat : hoursIn12HrFormat) + ':' + (minutes < 10? '0'+minutes: minutes)+ ' ' + `<span id="am-pm">${ampm}</span>`

//     dateEl.innerHTML = days[day] + ', ' + date+ ' ' + months[month]

// }, 1000);

getWeatherData()
function getWeatherData () {
    navigator.geolocation.getCurrentPosition((success) => {
        let {latitude, longitude } = success.coords;
        const url = (`https://api.openweathermap.org/data/2.5/forecast?lat=${latitude}&lon=${longitude}&units=metric&appid=${apiKey}`)
              
        fetch (url)
        .then(res => res.json())
        .then(data => {

        console.log(data)
        showWeatherData(data);
        showForecastData(data);
        showCurrentData(data);
        })
    })
};

function showWeatherData (data){
    
    let name = data.city.name;
    let country = data.city.country;
    let tempMax = data.list[0].main.temp_max;
    let tempMin = data.list[0].main.temp_min;
    const cityName = document.querySelectorAll('.city');

    cityName[0].innerHTML = `<div class="city">${name}</div>`
    
    currentWeatherItemsEl.innerHTML = 
    `
    <div class="others" id="countryOther">
        <div>Country</div>
        <div>${country}</div>
    </div>
    <div class="others" id="maxOther" >
    <div>Max</div>
    <div>${Math.round(tempMax)}°C</div>
    </div>
    <div class="others" id="minOther">
    <div>Min</div>
    <div>${Math.round(tempMin)}°C</div>
     </div>
    `
;
}
   
function showForecastData (data){
    let otherDayForecast = '';
    data.list.forEach((obj) => {
        if (window.moment(obj['dt_txt']).format('HH') === '12' && window.moment(obj['dt_txt']).format('DD/MM/YYYY') !== window.moment().format('DD/MM/YYYY'))
        {
            otherDayForecast += 
            `
            <div class="weather-forecast-item">
                <div class="day">${window.moment(obj['dt_txt']).format('ddd')}</div>
                <img src="https://openweathermap.org/img/wn/${
                    obj.weather[0].icon
                }@2x.png" alt="" class="w-icon" />
                <div class="temp">
                    <span class="temp">${Math.round(obj.main.temp)}°C</span>
                </div>
            </div>
            `;
            }
        });
        weatherForecastEl.innerHTML = otherDayForecast;
    };

function showCurrentData(data){
    let currentDayForecast = '';
    data.list.forEach((obj) => {
        if (window.moment(obj['dt_txt']).format('HH') === '12' && window.moment(obj['dt_txt']).format('DD/MM/YYYY') === window.moment().format('DD/MM/YYYY'))
        { currentDayForecast = 
                `<div class="today">${window.moment(obj['dt_txt']).format('ddd')}</div>
                <img src="http://openweathermap.org/img/wn/${
                    obj.weather[0].icon
                }@2x.png" alt="" class="w-icon" />
                <div class="temp">${Math.round(obj.main.temp)}°C</div>
            ;`
            }
        });
        currentTempEl.innerHTML = currentDayForecast;
};
//=======================================

const result = document.querySelector('.result');
const form = document.querySelector('.get-weather');
const nameCity = document.querySelector('#city');

form.addEventListener('submit', (e) => {
    e.preventDefault();

    if (nameCity.value === '') {
        showError('Sorry!! This field is required...');
        return;
    }

    callAPI(nameCity.value);
    console.log(nameCity.value);
    //console.log(nameCountry.value);
})

function callAPI(city, country){
    
    const url = `https://api.openweathermap.org/data/2.5/weather?q=${city},${country}&appid=${apiKey}`;

    fetch(url)
        .then(data => {
            return data.json();
        })
        .then(dataJSON => {
            if (dataJSON.cod === '404') {
                showError('City not found...');
            } else {
                clearHTML();
                showWeather(dataJSON);
            }
            //console.log(dataJSON);
        })
        .catch(error => {
            console.log(error);
        })
}

function showWeather(data){
    const {name, main:{temp, temp_min, temp_max}, weather:[arr]} = data;

    const degrees = kelvinToCelsius(temp);
    const min = kelvinToCelsius(temp_min);
    const max = kelvinToCelsius(temp_max);

    const content = document.createElement('div');
    content.innerHTML = `
        <h5>Weather in ${name}</h5>
        <img src="https://openweathermap.org/img/wn/${arr.icon}@2x.png" alt="icon">
        <h2>${degrees}°C</h2>
        <p>Max: ${max}°C</p>
        <p>Min: ${min}°C</p>
    `;

    result.appendChild(content);

    /* console.log(name);
    console.log(temp);
    console.log(temp_max);
    console.log(temp_min);
    console.log(arr.icon); */
}

function showError(message){
    //console.log(message);
    const alert = document.createElement('p');
    alert.classList.add('alert-message');
    alert.innerHTML = message;

    form.appendChild(alert);
    setTimeout(() => {
        alert.remove();
    }, 3000);
}

function kelvinToCelsius(temp){
    return parseInt(temp - 273.15);
}

function clearHTML(){
    result.innerHTML = '';
}



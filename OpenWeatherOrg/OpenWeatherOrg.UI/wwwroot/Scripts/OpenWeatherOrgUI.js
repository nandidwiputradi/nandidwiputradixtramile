function InitializeForm() {
    GetListCountry();
    //GetListCity('Japan');
}
function GetListCountry() {   
    callScript('Country', 'GetCountryList');
}
function GetListCity() {
    let data = {
        countryName: document.getElementById('countryInput').value
    };
    callScript('Country', 'GetCityList', data);
}
function GetWeather() {
    let data = {
        cityName: document.getElementById('cityInput').value
    };
    callScript('Country', 'GetWeather', data);
}
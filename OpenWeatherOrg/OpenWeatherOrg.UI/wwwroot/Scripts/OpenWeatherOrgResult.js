var CountryResult = {
    GetCountryList: function (result) {
        let ul, i, li;
        
        ul = document.getElementById("countryList");
        li = '';

        for (i = 0; i < result.length; i++) {
            li += "<li><a onclick=setCountryText('" + result[i] + "')>" + result[i] + '</a></li>';
        }
        ul.innerHTML = li;
    },
    GetCityList: function (result) {
        let ul, i, li;

        ul = document.getElementById("cityList");
        li = '';

        for (i = 0; i < result.length; i++) {
            li += "<li><a onclick=setCityText('" + result[i] + "')>" + result[i] + '</a></li>';
        }
        ul.innerHTML = li;        
    },
    GetWeather: function (result) {

        document.getElementById('weatherhtml').innerHTML = JSON.stringify(result);
    }
};

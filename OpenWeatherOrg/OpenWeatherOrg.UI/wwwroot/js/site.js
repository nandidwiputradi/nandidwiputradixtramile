// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function countryFunction() {
    let input, filter, ul, li, a, i, txtValue;
    input = document.getElementById("countryInput");
    filter = input.value.toUpperCase();
    ul = document.getElementById("countryList");
    li = ul.getElementsByTagName("li");
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}
function setCountryText(param) {
    let input = document.getElementById("countryInput");
    input.value = param;
    countryFunction();
}

function cityFunction() {
    let input, filter, ul, li, a, i, txtValue;
    input = document.getElementById("cityInput");
    filter = input.value.toUpperCase();
    ul = document.getElementById("cityList");
    li = ul.getElementsByTagName("li");
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}
function setCityText(param) {
    let input = document.getElementById("cityInput");
    input.value = param;
    cityFunction();
}
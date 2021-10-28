function callScript(controllerName, actionName, data) {
            
    let route = {
        controllerName: controllerName,
        actionName: actionName
    };

    let rawData = [];

    if (data != null) {
        //rawData = Object.assign(route, data);
        rawData = data;
    }

    const routeData = JSON.stringify(route);
    const paramData = JSON.stringify(rawData);
    let scriptResult = controllerName + 'Result.' + actionName;
    let scriptAction = controllerName + 'Action.' + actionName + '(' + scriptResult + ', ' + routeData + ', ' + paramData + ');';

    eval(scriptAction);
}

function CallServices(result, route, data) {
    OpenWeatherOrgServices.API(route, data).then(function (response) {
        result(response);
    });    
}

function OpenWeatherOrgServices() { };

OpenWeatherOrgServices.prototype.API = function (route, data) {
    return $.when(
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44307/' + route.controllerName + '/' + route.actionName,
            crossDomain: true,
            data: data,
            async: true,
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded',
            xhrFields: { withCredentials: true, cors: false },
            success: function (response) {
                return response;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                let result = {
                    xhr: xhr,
                    ajaxOptions: ajaxOptions,
                    thrownError: thrownError
                };
                console.log('OpenWeatherOrgRequest', result);
                return result;
            }
        })
    );
};
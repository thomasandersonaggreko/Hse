var ds_token = '';

$(document).ready(function () {
    getTokenSync();

    setInterval(getTokenSync, 20000);
});

function getTokenSync() {

    $.ajax({
        dataType: "json",
        url: '/api/token/gettoken'
    }).then(
        function (data) {
            //console.log('*** TOKEN REFRESHED: ' + data);
            ds_token = data;
        },
        function () {
            console.log('*** TOKEN REFRESH FAILED');
        }
    );
}

function clearToken() {
    $.ajax({
        dataType: "json",
        url: '/api/token/deletetoken',
        data: { token: ds_token }
    }).then(
        function (data) {
            console.log('*** TOKEN CLEARED: ' + data);
            window.location.href = data;
            window.close();
            deleteAllCookies();
            //ds_token = data;
        },
        function () {
            console.log('*** TOKEN CLEARED FAILED');
        }
    );
}

function deleteAllCookies() {
    var cookies = document.cookie.split(";");

    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        var eqPos = cookie.indexOf("=");
        var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}

function getToken() {
    return ds_token;
}
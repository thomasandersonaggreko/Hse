(function () {
    'use strict';

    angular.module('app', [
    
        'ui.router',                                // Routing
        'oc.lazyLoad',                              // ocLazyLoad
    ]);

})();

angular.module('app')
    .constant("apiUrl", "http://localhost:45487/api/")
    .constant("_odataUrl", "/rocservices/odata/")
    .constant("_refreshInterval", 60000)
    .constant("_maprefreshInterval", 600000)
    .constant("_lobUrl", "https://azneintlvvm01.aggrekonet.biz/api/") // URL of the data services - all requests starting with this will be token authenticated
    .constant("_quickServeUrl", "https://quickserve.cummins.com/info/index.html")
    .constant("_environmentName","Live")//wont actually be displayed in live
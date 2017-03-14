
var serviceId = 'reportsService';
angular.module('app').factory(serviceId, ['$http', '$q', 'apiUrl', reportsService]);

function reportsService($http, $q, apiUrl) {

    var service = {

        loadMonthlyHighPotentialIncidentsReport: loadMonthlyHighPotentialIncidentsReport
    };

    return service;

    function loadMonthlyHighPotentialIncidentsReport(date) {
        var url = apiUrl + 'MonthlyReports';
       // var url2 = 'http://localhost:45487/api/MonthlyReports?reportType=1&year=2017&month=3';
        //return $http.get(url2);
        return $http.get(url,
         {
             params: {reportType: 1, year: date.year, month: date.month},
             cache: false
         });
    }

    function buildOrangeRuleMessage(id, orangeRules) {

        return {
            "Id": id,
            "OrangeRules": orangeRules
        };
    }

    function loadAlertDescriptions() {

        var deferred = $q.defer();

        aggrekoOdataService.getMultiple("AlertDescriptions", "$expand=OrangeRules")
                .then(function (response) {
                    deferred.resolve(response.data.value);
                }, function (error) {
                    deferred.reject(error);
                    LogService.logError("Unable to get Alert Descriptions");
                });

        return deferred.promise;
    }

    function loadOrangeRules() {

        var deferred = $q.defer();

        aggrekoOdataService.getMultiple("OrangeRules", "$expand=Images")
                .then(function (response) {
                    deferred.resolve(response.data.value);
                }, function (error) {
                    deferred.reject(error);
                    LogService.logError("Unable to get Orange Rules");
                });

        return deferred.promise;
    }

    function getStandardResponseProcesses() {

        var deferred = $q.defer();

        aggrekoOdataService.getMultiple("SRPs", null)
                .then(function (response) {
                    deferred.resolve(response.data.value);
                }, function (error) {
                    deferred.reject(error);
                    LogService.logError("Unable to get SRPs");
                });

        return deferred.promise;
    }

    function addStandardResponseProcess(message) {

        var url = _apiUrl + 'SRPs/AddSRP';
        return $http.put(url, message);

    }

    function editStandardResponseProcess(message) {
        var url = _apiUrl + 'SRPs/UpdateSRP';
        return $http.put(url, message);
    }

    function deleteStandardResponseProcess(id) {
        var url = _apiUrl + 'SRPs/DeleteSRP';
        return $http.delete(url, { params: { Id: id } });
    }

    function buildAddSRPMessage(alarmMatchText, equipClass, description, url) {

        return {
            "AlarmMatchText": alarmMatchText,
            "EquipClass": equipClass,
            "Description": description,
            "Url": url,
        };
    }

    function buildUpdateSRPMessage(id, alarmMatchText, equipClass, description, url) {

        return {
            "Id": id,
            "AlarmMatchText": alarmMatchText,
            "EquipClass": equipClass,
            "Description": description,
            "Url": url,
        };
    }

    function updateServiceCentre(serviceCentre) {

        var msg = { "serviceCentreId": serviceCentre.Id, "languageId": serviceCentre.Language.Id };
        var url = _apiUrl + 'ServiceCentre/UpdateServiceCentre';
        return $http.put(url, msg);
    }

    function getLanguages() {

        var deferred = $q.defer();

        aggrekoOdataService.getMultiple("Languages", "$filter=Enabled eq true")
            .then(function (response) {
                var languages = response.data.value;
                deferred.resolve(languages);
            }, function (error) {
                deferred.reject(error);
                LogService.logError("Failed to load Languages.");
            });

        return deferred.promise;
    }

    //acknowledgement
    function getAcknowledgement() {

        var deferred = $q.defer();

        aggrekoOdataService.getSingle("AcknowledgementTimeFrames", 1)
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (error) {
                    deferred.reject(error);
                    LogService.logError("Unable to get AcknowledgementTimeFrame");
                });

        return deferred.promise;
    }

    function updateAcknowledgement(message) {
        var msg = { "id": message.Id, "expiry": message.Expiry };
        var url = _apiUrl + 'AcknowledgementTimeFrames/UpdateAcknowledgement';
        return $http.put(url, msg);
    }

    //region
    function getRegions() {

        var deferred = $q.defer();

        aggrekoOdataService.getMultiple("Regions", null)
                .then(function (response) {
                    deferred.resolve(response.data.value);
                }, function (error) {
                    deferred.reject(error);
                    LogService.logError("Unable to get Regions");
                });

        return deferred.promise;
    }

    function addRegion(message) {

        var url = _apiUrl + 'Regions/AddRegion';
        return $http.put(url, message);
    }

    function updateRegion(message) {

        var url = _apiUrl + 'Regions/UpdateRegion';
        return $http.put(url, message);
    }

    //Hazards
    function getHazards() {

        var deferred = $q.defer();

        aggrekoOdataService.getMultiple("Hazards", null)
            .then(function (response) {
                deferred.resolve(response.data.value);
            }, function (error) {
                deferred.reject(error);
                LogService.logError("Unable to get hazards.");
            });
        return deferred.promise;
    }

    function addHazard(message) {

        var url = _apiUrl + 'Hazards/AddHazard';
        return $http.put(url, message);

    }

    function editHazard(message) {

        var url = _apiUrl + 'Hazards/UpdateHazard';
        return $http.put(url, message);
    }

    function deleteHazard(id) {

        var url = _apiUrl + 'Hazards/DeleteHazard';
        return $http.delete(url, { params: { Id: id } });
    }

    function buildAddHazardMessage(alarmMatchText, equipClass, description, severity) {

        return {
            "AlarmMatchText": alarmMatchText,
            "EquipClass": equipClass,
            "Description": description,
            "Severity": severity,
        };
    }

    function buildUpdateHazardMessage(id, alarmMatchText, equipClass, description, severity) {

        return {
            "Id": id,
            "AlarmMatchText": alarmMatchText,
            "EquipClass": equipClass,
            "Description": description,
            "Severity": severity,
        };
    }

    //Roles
    function getRoles(query, enabledOnly) {

        var deferred = $q.defer();
        var filter = null;

        if (query != null) {
            var encodedQuery = window.encodeURIComponent(query)
            filter = "$filter=indexof(JobTitle, '" + encodedQuery + "') ne -1";


            if (enabledOnly) {
                filter = filter + "and Enabled eq true";
            }

            filter = filter + "&$expand=Regions&$top=15";
        }

        aggrekoOdataService.getMultiple("ContactTypeJobMappings", filter)
                .then(function (response) {
                    deferred.resolve(response.data.value);
                }, function (error) {
                    deferred.reject(error);
                    LogService.logError("Unable to get Roles");
                });

        return deferred.promise;
    }

    function updateRole(message) {

        var url = _apiUrl + 'ContactTypeJobMappings/Update';
        return $http.put(url, message);
    }


    //on call

    function getTimeZone(latitude, longitude) {
        var url = _apiUrl + 'TimeZone/Get';

        return $http.get(url,
         {
             params: {
                 latitude: latitude,
                 longitude: longitude
             },
             cache: false
         });
    }

    function getServiceCentres(query) {
        var deferred = $q.defer();
        var filter = null;

        if (query != null) {
            filter = "$filter=indexof(Name, '" + query + "') ne -1 and indexof(Name, 'DO NOT USE') eq -1 &$expand=Language&$top=10";
        }

        aggrekoOdataService.getMultiple("ServiceCentres", filter)
            .then(function (response) {
                deferred.resolve(response.data.value);

            }, function (error) {
                deferred.reject();
                LogService.logError("Failed to load Service Centres");
            });

        return deferred.promise;
    }

    function getOnCallRoles() {

        var roles = [{ "Name": "Service - Air" },
            { "Name": "Service - Power" },
            { "Name": "Service - Temperature" },
            { "Name": "Service" },
            { "Name": "Sales" },
            { "Name": "Manager" },
        { "Name": "Logistics" },
        { "Name": "EHS" },
        { "Name": "General" }]
        var deferred = $q.defer();
        deferred.resolve(roles);
        return deferred.promise;
    }

    function getRota(serviceCentreId, fromDate) {

        var date = moment.utc(fromDate).toISOString();
        var url = _apiUrl + 'ServiceCentreOnCallContacts/GetRota'

        return $http.get(url,
        {
            params: {
                serviceCentreId: serviceCentreId,
                searchDate: date
            },
            cache: false
        });
    }

    function saveRota(message) {
        var url = _apiUrl + 'ServiceCentreOnCallContacts/SaveRota';
        return $http.put(url, message);
    } groupByRole

    function deleteRotaEntry(id) {
        var url = _apiUrl + 'ServiceCentreOnCallContacts/DeleteEntry';
        return $http.delete(url, { params: { Id: id } });
    }

    function exportContacts(serviceCentre, region) {

        var url = _apiUrl + 'ServiceOrders/ExportServiceCentreContacts'
        var serviceCentreId = 0;

        if (serviceCentre !== undefined && serviceCentreId !== null) {
            serviceCentreId = serviceCentre.Id;
        }

        return $http.get(url,
        {
            params: {
                serviceCentreId: serviceCentreId,
                region: region,
            },
            cache: false
        });
    }

    function exportRota(serviceCentre, fromDate, region, serviceCentreUtcOffset, toDate) {

        var startDate = moment.utc(fromDate).toISOString();
        var endDate = moment.utc(toDate).toISOString();

        var localOffsetFromUtc = moment().utcOffset();
        var totalOffset = localOffsetFromUtc;

        if (serviceCentreUtcOffset != -999) {
            totalOffset = localOffsetFromUtc - (serviceCentreUtcOffset * 60);
        }


        var url = _apiUrl + 'ServiceCentreOnCallContacts/ExportRota'
        var serviceCentreId = 0;

        if (serviceCentre !== undefined && serviceCentreId !== null) {
            serviceCentreId = serviceCentre.Id;
        }

        return $http.get(url,
        {
            params: {
                serviceCentreId: serviceCentreId,
                searchStart: startDate,
                region: region,
                localOffsetFromUtc: totalOffset,
                searchEnd: endDate
            },
            cache: false
        });
    }
};

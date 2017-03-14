var controllerId = 'reportsCtrl';
angular.module('app').controller(controllerId, ['reportsService', reportsCtrl]);

function reportsCtrl(reportsService) {
    var vm = this;
   
    vm.reports = [];
    vm.dates = [];
    vm.selectedDate = null;
    vm.selectedReportType = null;

    vm.reportTypes = [
    { display: "Monthly High Potential Incidents", value: 1 }
    ];

    vm.dates = [
        { display: "Jan 2017", year: 2017, month: 01 },
        { display: "Feb 2017", year: 2017, month: 02 },
        { display: "Mar 2017", year: 2017, month: 03 }
    ];

    vm.loadMonthlyHighPotentialIncidentsReport = loadMonthlyHighPotentialIncidentsReport;
    vm.runReport = runReport;

   // loadMonthlyHighPotentialIncidentsReport({ reportType: 1, year: 2017, month: 3 });

    function runReport() {
        loadMonthlyHighPotentialIncidentsReport(vm.selectedDate);
    }

    function loadMonthlyHighPotentialIncidentsReport(date) {

        reportsService.loadMonthlyHighPotentialIncidentsReport(date)
            .then(function (response) {
                vm.reports = null;
                vm.reports = response.data.Daily;
            })
            .catch(function(error) {
                //TOOD log error occured
            });

    }
};
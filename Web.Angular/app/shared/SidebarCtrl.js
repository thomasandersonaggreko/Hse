/**
 * SidebarCtrl - controller
 * Determines the application routes and item count notifications where appropriate
 *
 */
function SidebarCtrl($q) {

    var vm = this;
    vm.getNavRoutes = getNavRoutes;

    activate();

    function activate() {
        var activationPromises = [vm.getNavRoutes()];
        return $q.all(activationPromises);
    }

    function getNavRoutes() {

        vm.navRoutes = [];
       
        vm.navRoutes = [
    { url: '/dashboard', label: 'Dashboard', icon: 'bell', count: function () { return vm.alarmCount; } },
    { url: '/incidents', label: 'New Incident', icon: 'truck' },
    { url: '/reports', label: 'Reports', icon: 'map-marker' }
  
        ];
    };
};

angular
    .module('app')
    .controller('SidebarCtrl', ['$q', SidebarCtrl]);
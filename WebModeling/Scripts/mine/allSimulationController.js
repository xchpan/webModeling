allSimulations.controller("AllSimulationController", function($scope, $http) {
    /*$('#all-simulation-form').dialog({ autoOpen: false, modal: true });*/
    var uri = 'api/simulations';
    $(document).ready(function() {
        $('#showsimulations').click(function() {
            $http.get(uri).success(function(data) {
                $scope.simulations = data;
                $('#all-simulation-form').dialog("open");
            });
        });

        $('#all-simulation-form').dialog({ autoOpen: false, modal: true, width: 'auto' });
    });
});
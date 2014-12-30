allPlantService.factory('allPlantService', ['$http',
  function ($http) {
      var uri = 'api/plants/';

      var doGetPlants = function() {
          return $http.get(uri);
      }

      var doDeletePlant = function(plantId) {
          var deleteUri = uri + plantId;
          return $http.delete(deleteUri);
      }

      var doCreatePlant = function() {
          return $http.post(uri);
      }

      var doUpdatePlant = function (plant) {
          var putUri = uri + plant.Id;
          return $http.put(putUri, plant);
      }

      return {
          getAllPlants: function() { return doGetPlants(); },
          deletePlant: function (plantId) { return doDeletePlant(plantId); },
          createPlant: function () { return doCreatePlant(); },
          updatePlant: function (plant) { return doUpdatePlant(plant); }
      };
  }]);
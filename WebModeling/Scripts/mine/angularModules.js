var allPlantService = angular.module('allPlantService', []);
var allPlants = angular.module("allPlants", ['allPlantService']);

var librariesFilter = angular.module('librariesFiler', []);
var librariesService = angular.module('librariesService', []);
var libraries = angular.module("libraries", ['librariesService', 'librariesFiler']);
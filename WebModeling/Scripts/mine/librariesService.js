librariesService.factory('librariesService', ['$http',
  function ($http) {
      var uri = 'api/libraries/';

      var doGetLibraries = function () {
          return $http.get(uri);
      }

      var doDeleteLibrary = function (libraryId) {
          var deleteUri = uri + libraryId;
          return $http.delete(deleteUri);
      }

      var doCreateLibrary = function () {
          return $http.post(uri);
      }

      var doCreateFluid = function (libraryId) {
          var creaetUri = uri + libraryId + "/fluid";
          return $http.post(creaetUri);
      }

      var doCreatePort = function (libraryId) {
          var creaetUri = uri + libraryId + "/port";
          return $http.post(creaetUri);
      }

      var doCreateModel = function (libraryId) {
          var creaetUri = uri + libraryId + "/model";
          return $http.post(creaetUri);
      }

      return {
          getAllLibraries: function () { return doGetLibraries(); },
          deleteLibrary: function (libraryId) { return doDeleteLibrary(libraryId); },
          createLibrary: function () { return doCreateLibrary(); },
          createFluid: function (libraryId) { return doCreateFluid(libraryId); },
          createPort: function (libraryId) { return doCreatePort(libraryId); },
          createModel: function (libraryId) { return doCreateModel(libraryId); }
      };
  }]);
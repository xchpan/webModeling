libraries.controller("librariesController", [
        '$scope', 'librariesService', function($scope, librariesService) {
            librariesService.getAllLibraries().success(function(data) {
                $scope.libraries = data;
                //$("#libraryList").accordion();
            });

            $scope.deleteLibrary = function(libraryId) {
                librariesService.deleteLibrary(libraryId).success(function() {
                    var index = findIndex($scope.libraries, libraryId);
                    $scope.libraries.splice(index, 1);
                }).error(function(data, status, headers, config) {
                    alert("error: " + data);
                });
            };

            $scope.createLibrary = function() {
                librariesService.createLibrary().success(function(data) {
                    $scope.libraries.push(data);
                });
            };
        }
    ])
    .directive('libraryAccordion', function($timeout) {
        return {
            scope: {
                myData: '=libraryAccordion'
            },
            template: '<h3 ng-repeat-start="library in myData">{{library.Name}}</h3><div ng-repeat-end class="librayContainer"><span ng-repeat="item in library.Items" class="libraryItem"><img src="{{item.Icon}}" class="modelTypeIcon"/><div>{{item.Name}}</div></span></div>',
            link: function(scope, element) {
                $timeout(function() {
                    $(element).accordion();
                }, 0);
            }
        }
    });
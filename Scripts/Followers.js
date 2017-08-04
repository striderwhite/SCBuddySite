/// <reference path="angular.js" />
var scURL = "https://api-v2.soundcloud.com/users/2751638/followers?offset=1501351687918&limit=200&client_id=JlZIsxg2hY5WnBgtn3jfS0UYCl0K8DOg";
//var scURL = "https://api-v2.soundcloud.com/users/270369011/followers?client_id=JlZIsxg2hY5WnBgtn3jfS0UYCl0K8DOg&limit=200&offset=0"
//CORS proxy
var proxy = 'https://cors-anywhere.herokuapp.com/';


//create module then register sc API as a safe source
//see https://stackoverflow.com/questions/41642646/angularjs-errors-blocked-loading-resource-from-url-not-allowed-by-scedelegate
var app = angular.module("followersApp", []).config(function ($sceDelegateProvider,$httpProvider) {
    $sceDelegateProvider.resourceUrlWhitelist([
        'self',
        'https://api-v2.soundcloud.com/**',
        'https://api.soundcloud.com/**'
    ]);
    $httpProvider.defaults.useXDomain = true;
});

app.controller("followersController", function ($scope, $http, $log) {


    $http.get(proxy + scURL, {
        method: 'GET'
    }).then(function successCallback(response) {
        $scope.users = response.data;
        $scope.next_href = response.data.next_href;

            //keep calling
        $scope.getNextFollowers = function () {
                if ($scope.next_href == null)
                    return;
                alert($scope.next_href);

                $http.get(proxy + scURL, {
                    method: 'GET'
                }).then(function successCallback(response) {
                    $scope.users.collection += response.data.collection;
                    $scope.next_href = response.data.next_href;
                }  
            )}

        //ERROR HANDLE
        }, function errorCallback(response) {
            $scope.users = response.data;
        });

  
});

function retrieveFollowers(nextHref, $http, $scope)
{

    if (nextHref == null)
        return;

    $http.get(proxy + scURL, {
        method: 'GET'
    }).then(function successCallback(response) {
        $scope.users += response.data;
        $scope.next_href = response.data.next_href;

        //keep calling
        retrieveFollowers(response.data.next_href,$http)

        //ERROR HANDLE
        }, function errorCallback(response) {
            $scope.users = response.data;
        });
}

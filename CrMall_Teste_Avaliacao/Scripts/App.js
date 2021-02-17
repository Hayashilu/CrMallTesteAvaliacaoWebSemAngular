
//define aplicação angular e o controller
var app = angular.module("clientesApp", []);
//registra o controller e cria a função para obter os dados do Controlador MVC
app.controller("clientesCtrl", function ($scope, $http) {
    $http.get('/clientes/Index/')
        .success(function (result) {
            $scope.produtos = result;
        })
        .error(function (data) {
            console.log(data);
        });
});
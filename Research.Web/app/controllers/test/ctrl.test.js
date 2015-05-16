function TestCtrl($scope, ajax, $location) {
    
    $scope.types = [];

    $scope.init = function () {
        GetTypes();
    }

    function GetTypes() {

        var method = { Name: 'Questions.GetTypes' };

        var types1 = [];

        ajax.send({
            Method: method,
            Callback: function (data) {

                var types = data[0].Result.Types;

                if (types !== undefined) {

                    for (var i = 0; i < types.length; i++) {
                        var type = types[i];
                        types1.push(type);
                    }

                    $scope.types = types1;

                }
            }
        });
    }

}
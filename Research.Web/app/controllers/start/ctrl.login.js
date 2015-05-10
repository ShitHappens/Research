function LoginCtrl($scope, ajax, $localStorage, $access) {

    $scope.init = function () {

    }

    $scope.login = function () {
        //if (!$scope.FormLogin.$invalid) {

        var email = angular.element('#email').val();
        var password = angular.element('#password').val();

        ajax.send({
            Method: {
                Name: 'Account.Login',
                Args: { Email: email, Password: password }
            },
            Callbacks: [{
                Params: ['Error', 'Data'],
                F: function (Error, Data) {

                    if (Error.Code === 0) {
                        $localStorage.SessionID(Data.SessionID);
                        $localStorage.Email($scope.email);
                        $localStorage.Item('UserID', Data.UserID);
                        $access.isLogin();
                    } 
                }
            }]

        });
        //}

    }

}
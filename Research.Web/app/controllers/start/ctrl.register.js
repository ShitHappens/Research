function RegisterCtrl($scope, ajax, $location, $access, $localStorage) {

    $scope.init = function () {
    }

    $scope.register = function () {

        var email = angular.element('#email').val();
        var password = angular.element('#password').val();
        var repeatPassword = angular.element('#repeatPassword').val();

        if (email !== '' && password !== '' && repeatPassword !== '') {
            ajax.send({
                Method: {
                    Name: 'Account.Registration', Args: { Email: email, Password: password, RepeatPassword: repeatPassword },
                },
                Callbacks: [{
                    Params: ['Error'],
                    F: function (Error) {
                        if (Error.Code === 0)
                            $location.path('/login');
                        else
                            alert('Error');
                    }
                }]

            });
        } else {
            alert('Please, fill fields properly!')
        }

    }
}
function ProfileCtrl($scope, ajax, $location) {
    
    $scope.email = '';
    $scope.rate = 'No marks yet';

    $scope.init = function () {
        $scope.GetAccount();
    }

    $scope.GetAccount = function () {

        ajax.send({
            Method: {
                Name: 'Account.Read'
            },
            Callback: function (data) {

                var account = data[0].Result.Account;

                $scope.email = account.Email;

                if (account.Rate !== '' && account.Rate != undefined)
                    $scope.rate = account.Rate;
            }
        });
    }
}
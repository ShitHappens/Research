function ProfileCtrl($scope, ajax, $location) {
    $scope.items = [];

    $scope.init = function () {
        $scope.GetItems();
    }

    $scope.GetItems = function () {

        ajax.send({
            Method: {
                Name: 'Questions.Get'
            },
            Callback: function (data) {

                var itemsarray = [];

                var items = data[0].Result.Questions;

                for (var i = 0; i < items.length; i++) {

                    var item = {
                        ID: parseInt(items[i].ID),
                        Text: items[i].Text,
                    };
                    itemsarray.push(item);
                }

                $scope.items = itemsarray;
            }
        });
    }
}
function StudentsCtrl($scope, ajax, $location) {

    $scope.students = [];
    $scope.addStudent = false;

    $scope.init = function () {
        GetStudents();
    }

    function GetStudents() {

        var method = { Name: 'Account.GetStudents' };

        ajax.send({
            Method: method,
            Callback: function (data) {
                $scope.students = data[0].Result.Students;
            }
        });
    }

    $scope.AddStudent = function () {
        var method = {
            Name: 'Account.SetStudent',
            Args: {
                Name:  $("#name").val(),
                Email: $("#email").val(),
                Mark:  $("#mark").val()
            }
        };

        ajax.send({
            Method: method,
            Callback: function () {
                $("#name").val('');
                $("#email").val('');
                $("#mark").val('');
                GetStudents();
            }
        });
    }
}
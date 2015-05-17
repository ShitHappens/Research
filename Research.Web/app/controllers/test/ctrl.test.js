function TestCtrl($scope, ajax, $location) {
    
    $scope.types = [];
    $scope.answers = [];
    $scope.questionIds = [];
    $scope.tryTest = false;
    $scope.question;

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

    $scope.passTest = function (typeID) {
        $scope.tryTest = true;

        var method = {
            Name: 'Questions.GetQuestionByType',
            Args: {
                TypeID: typeID
            }
        };

        ajax.send({
            Method: method,
            Callback: function (data) {

                $scope.question = data[0].Result.Question;
                var answers = data[0].Result.Answers;
                if (!$scope.questionIds.contains(data[0].Result.Question.ID))
                    $scope.questionIds.push(data[0].Result.Question.ID);
                var answers1 = [];

                for (var i = 0; i < answers.length; i++) {
                    answers1.push(answers[i]);
                }

                $scope.answers = answers1;

            }
        })
    }

    $scope.nextQuestion = function () {

        var answerId = $("input[type='radio']:checked").val();

        var method = {
            Name: 'Questions.GetNextQuestion',
            Args: {
                Answer: answerId,
                Questions: $scope.questionIds
            }
        }

        $scope.question = {};
        $scope.answers = [];
        ajax.send({
            Method: method,
            Callback: function (data) {
                if (data[0].Result.Error.Code === 0) {
                    $scope.question = data[0].Result.Question;
                    var answers = data[0].Result.Answers;

                    if (!$scope.questionIds.contains(data[0].Result.Question.ID))
                        $scope.questionIds.push(data[0].Result.Question.ID);
                    var answers1 = [];

                    for (var i = 0; i < answers.length; i++) {
                        answers1.push(answers[i]);
                    }

                    $scope.answers = answers1;
                }
                else
                {
                    alert(data[0].Result.Error.Message);
                    $scope.question = {};
                    $scope.answers = [];
                    $location.path('/profile');
                }
            }
        });
    }

    Array.prototype.contains = function (obj) {
        var i = this.length;
        while (i--) {
            if (this[i] === obj) {
                return true;
            }
        }
        return false;
    }
}
function QuestionCtrl($scope, ajax, $location, $element) {

    $scope.types = [];
    $scope.categories = [];

    $scope.init = function () {
        GetAllForQuestion();
    }

    function GetAllForQuestion() {
        var method = { Name: 'Questions.GetAllForQuestions' };
        ajax.send({
            Method: method,
            Callback: function (data) {
                $scope.types = data[0].Result.Types;
                $scope.categories = data[0].Result.Categories;
            }
        });
    }

    $scope.CreateQuestion = function()
    {
        var text = angular.element('#questionInput').val();
        var type = angular.element('#type option:selected').val();
        var category = angular.element('#category option:selected').val();
        var complexity = angular.element('#complexity').val();

        if (text !== '') {
            var method = {
                Name: 'Questions.SetQuestion',
                Args: {
                    Text: text,
                    Type: type,
                    Category: category,
                    Complexity: complexity
                }
            };

            ajax.send({
                Method: method,
                Callback: function(data){
                    if (data[0].Result.Error.Code === 0) {
                        angular.element('#questionInput').val('');
                        angular.element('#complexity').val('');
                    }
                }
            });
        }
    }
}
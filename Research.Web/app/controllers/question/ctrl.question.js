function QuestionCtrl($scope, ajax, $location, $element, $route) {

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

    $scope.CreateQuestion = function ()
    {
        var text = angular.element('#questionInput').val();
        var type = angular.element('#type option:selected').val();
        var category = angular.element('#category option:selected').val();
        var complexity = angular.element('#complexity').val();

        //var reader = new FileReader();
        if (text !== '') {
            var method = {
                Name: 'Questions.SetQuestion',
                Args: {
                    Text: text,
                    Type: type,
                    Category: category,
                    Complexity: complexity,
                }
            };

            ajax.send({
                Method: method,
                Callback: function(data){
                    if (data[0].Result.Error.Code === 0) {
                        angular.element('#questionInput').val('');
                        angular.element('#complexity').val('');
                        var id = data[0].Result.ID;
                        var file = $('#txtUploadFile')[0].files[0];
                        if (file != null && file != undefined && id > 0) {
                            var formData = new FormData();
                            formData.append('file', file);
                            formData.append('id', id);
                            $.ajax({
                                url: '../FileHandler.ashx',
                                type: "POST",
                                //cache: false,
                                data: formData, //{ data: postData },
                                contentType: false,
                                processData: false,
                                //dataType: "json",
                                //async: true,
                                error: function (jqXHR, textStatus, errorThrown) {
                                    console.log("Error- Status: " + textStatus + " jqXHR Status: " + jqXHR.status + " jqXHR Response Text:" + jqXHR.responseText)
                                },
                                success: function (msg) {
                                    //console.log(methodName);
                                    //console.log(msg.d);
                                    //success(msg.d);
                                }

                            });
                        }
                    }
                }
            });
        }
    }

    $scope.CreateSubject = function () {
        var text = angular.element('#subjectInput').val();

        if (text !== '') {
            var method = {
                Name: 'Questions.SetSubject',
                Args: {
                    Text: text,
                }
            };

            ajax.send({
                Method: method,
                Callback: function (data) {
                    if (data[0].Result.Error.Code === 0) {
                        angular.element('#subjectInput').val('');
                        $scope.init();
                    }
                }
            });
        }
    }
}
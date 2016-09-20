function TestCtrl($scope, ajax, $location) {
    
    $scope.types = [];
    $scope.subjects = [];
    $scope.answers = [];
    $scope.questionIds = [];
    $scope.tryTest = false;
    $scope.question;
    $scope.questions = [];

    $scope.init = function () {
        GetSubjects();
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

    function GetSubjects() {

        var method = { Name: 'Questions.GetSubjects' };

        var subjs = [];

        ajax.send({
            Method: method,
            Callback: function (data) {

                var subjects = data[0].Result.Subjects;

                if (subjects !== undefined) {

                    for (var i = 0; i < subjects.length; i++) {
                        var subj = subjects[i];
                        subjs.push(subj);
                    }

                    $scope.subjects = subjs;

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

    $scope.GetQuestions = function (ID) {
        var numberOfQuestions = $('#' + ID).val();
        var сomplexity = $('select option:selected').val();
        var id = ID;

        var method = {
            Name: 'Questions.GetQuestions',
            Args: {
                NumberOfQuestions: numberOfQuestions,
                Complexity: сomplexity,
                SubjectID: ID
            }
        }

        ajax.send({
            Method: method,
            Callback: function (data) {
                if (data[0].Result.Error.Code === 0) {
                    $scope.questions = data[0].Result.Questions;
                    $scope.answers = $scope.questions.Answers;

                    //if (!$scope.questionIds.contains(data[0].Result.Question.ID))
                    //    $scope.questionIds.push(data[0].Result.Question.ID);
                    //var answers1 = [];

                    //for (var i = 0; i < answers.length; i++) {
                    //    answers1.push(answers[i]);
                    //}

                    //$scope.answers = answers1;

                    $scope.tryTest = true;
                }
                else {
                    //alert(data[0].Result.Error.Message);
                    $scope.question = {};
                    $scope.answers = [];
                    $location.path('/profile');
                }
            }
        });


    }

    $scope.SubmitTest = function (ID) {
        var questions = $(".question");
        var totalScore = questions.length;

        var answersIds = [];

        var answers = $("input[type='radio']:checked");

        for (var i = 0; i < answers.length; i++) {
            var scoreId = answers[i].id;
            answersIds.push(scoreId);
        }

        var method = {
            Name: 'Test.Submit',
            Args: {
                UserID: localStorage['UserID'],
                AnswerIDs: answersIds,
                Score: totalScore
            }
        }

        ajax.send({
            Method: method,
            Callback: function (data) {
                if (data[0].Result.Error.Code === 0) {
                    var mark = data[0].Result.Mark;
                    var userName = data[0].Result.UserName;
                    var subject = data[0].Result.Subject;
                    var passed;
                    if (mark >= 60)
                        passed = userName + ' допущеный до екзамену з результатом' + mark + ' із 100.';
                    else
                        passed = userName + ' НЕ допущеный до екзамену з результатом ' + mark +' із 100.';

                    var doc = {
                        content: [
                          { text: 'Київський національний унівеситет імені Тараса Шевченка', fontSize: 15, style: { alignment: 'center' } },
                          { text: 'Факультет інформаційних технологій', fontSize: 15, style: { alignment: 'center' } },
                          { text: 'Результати тестування з предмету ' + subject, fontSize: 15, style: { alignment: 'center' } },
                          { text: ' ', fontSize: 15, style: { alignment: 'center' } },
                          {
                              text: passed, fontSize: 12, style: { alignment: 'center' }
                          },
                         { text: ' ', fontSize: 15, style: { alignment: 'center' } },
                         { text: 'Викладач дисципліни _________________ ', fontSize: 12, style: { alignment: 'right' } },
                        ]
                    };

                    pdfMake.createPdf(doc).download(userName + '_' + subject + '.pdf');
                    //alert('Your mark is: ' + mark);
                    $location.path('/dashboard');
                }
            }
        });
    }

    Array.prototype.contains = function (obj) {s
        var i = this.length;
        while (i--) {
            if (this[i] === obj) {
                return true;
            }
        }
        return false;
    }

    //$(function () {
    //    $("#dialog").dialog({
    //        autoOpen: false
    //    });

    //    $("#opener").click(function () {
    //        $("#dialog").dialog("open");
    //    });
    //});
}
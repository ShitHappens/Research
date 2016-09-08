<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Research.Web.Default" %>

<!DOCTYPE html>

<html lang="en" ng-app="app">
<head ng-controller="HeadCtrl" ng-init="init()">
    <title ng-bind="Page"></title>
    <link rel="icon" type="image/png" href="/img/favicon.png">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Style -->
    <link rel="stylesheet" href="/css/bootstrap.min.css" media="all" />
    <link rel="stylesheet" href="/css/font-awesome.min.css" media="all" />
    <link rel="stylesheet" href="/css/ionicons.min.css" media="all" />
    <link rel="stylesheet" href="/css/style.css" media="all" />
    <link rel="stylesheet" href="/css/custom.css" media="all" />
    <link rel="stylesheet" href="/css/small-business.css" media="all" />


</head>
<body>
    <div app-view-segment="0" style="height: 100%;"></div>

    <!-- Config -->
    <script src="/js/config.aspx"></script>

    <!-- jQuery -->
    <script src="/js/jquery/jquery.min.js"></script>
    <script src="/js/jquery/jquery-ui-1.10.3.min.js"></script>

    <!-- Bootstrap -->
    <script src="/js/bootstrap/bootstrap.min.js"></script>

    <!-- AngularJS -->
    <script src="/js/angularjs/angular.js"></script>
    <script src="/js/angularjs/angular-route.js"></script>
    <script src="/js/angularjs/angular-route-segment.js"></script>

    <!-- PDF -->
    <script src="/js/pdfmake.min.js"></script>
    <script src="/js/vfs_fonts.js"></script>
    <script src="/js/FileSaver.min.js"></script>

    <!-- AngularJS Modules -->
    <script src="/app/app.js"></script>
    <script src="/app/modules/storage.js"></script>
    <script src="/app/modules/ajax.js"></script>
    <script src="/app/modules/service.js"></script>
    <script src="/app/modules/urls.js"></script>
    <script src="/app/modules/access.js"></script>
    <script src="/app/modules/alert.js"></script>

    <!-- AngularJS Controllers -->
    <script src="/app/controllers/common/ctrl.head.js"></script>
    <script src="/app/controllers/common/ctrl.page.js"></script>
    <script src="/app/controllers/common/ctrl.side_menu.js"></script>

        <!-- Start -->
    <script src="/app/controllers/start/ctrl.login.js"></script>
    <script src="/app/controllers/start/ctrl.register.js"></script>
<%--    <script src="/app/controllers/start/ctrl.passwordRequest.js"></script>
    <script src="/app/controllers/start/ctrl.email.confirm.js"></script>--%>

        <!-- Site -->
    <script src="/app/controllers/site/ctrl.header.js"></script>
    <script src="/app/controllers/profile/ctrl.profile.js"></script>
    <script src="/app/controllers/test/ctrl.test.js"></script>
    <script src="/app/controllers/dashboard/ctrl.dashboard.js"></script>
    <script src="/app/controllers/question/ctrl.question.js"></script>
    <script src="/app/controllers/students/ctrl.students.js"></script>


</body>
</html>

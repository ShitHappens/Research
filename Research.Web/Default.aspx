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
    <link rel="stylesheet" href="/css/custom2.css" media="all" />
    <link rel="stylesheet" href="/css/bootstrap.css" media="all" />
    <link rel="stylesheet" href="/css/custom.css" media="all" />
    <link rel="stylesheet" href="/css/angular-csp.css" media="all" />
    <link rel="stylesheet" href="/css/elusive-webfont.css" media="all" />


</head>
<body>
    <div app-view-segment="0" style="height: 100%;"></div>

    <!-- Config -->
    <script src="/js/config.aspx"></script>

    <!-- AngularJS -->
    <script src="/js/angularjs/angular.min.js"></script>

</body>
</html>

angular.module("umbraco").controller("Unpublished.UnpublishedEditController",
    function ($scope, $routeParams, approvalResource, notificationsService, navigationService) {

        $scope.loaded = false;

        if ($routeParams.id == -1) {
            $scope.node = {};
            $scope.loaded = true;
        }
        else {
            approvalResource.getById($routeParams.id).then(function (response) {
                $scope.node = response.data;
                $scope.loaded = true;
                navigationService.syncTree({ tree: 'unpublishedTree', path: ["-1", $routeParams.id], forceReload: false });
            });

            approvalResource.getUserById($routeParams.id).then(function (response) {
                $scope.userName = response.data.replace(/"/g,'');
                $scope.loaded = true;
                navigationService.syncTree({ tree: 'unpublishedTree', path: ["-1", $routeParams.id], forceReload: false });
            });

        };


        $scope.publish = function (node) {
            approvalResource.publish(node.Id).then(function (response) {
                $scope.node = response.data;
                $scope.contentForm.$dirty = false;
                navigationService.syncTree({ tree: 'unpublishedTree', path: [-1, -1], forceReload: true });
                notificationsService.success("Success", node.Name + " has been published");
            });
        };

    });

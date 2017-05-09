angular.module("umbraco.resources")
    .factory("approvalResource", function ($http) {
        return {
            getById: function (id) {
                return $http.get("backoffice/MyOrgAdmin/UnpublishedApi/GetById?id=" + id);
            },
            getUserById: function (id) {
                return $http.get("backoffice/MyOrgAdmin/UnpublishedApi/GetUserById?id=" + id);
            },
            publish: function (id) {
                return $http.post("backoffice/MyOrgAdmin/UnpublishedApi/PostPublish?id=" + id);
            }
        };
    });

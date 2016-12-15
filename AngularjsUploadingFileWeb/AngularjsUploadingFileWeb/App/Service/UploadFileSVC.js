(function () {

    var appModule = angular.module("appModule");

    var UploadFileSVC = function ($http) {

        var uploadFile = function (file, description) {
            var formData = new FormData();
            formData.append("file", file);
            //We can send more data to server using append         
            formData.append("description", description);
            return $http.post("/FileStreaming/UploadImages", formData,
                                            {
                                                withCredentials: true,
                                                headers: { 'Content-Type': undefined },
                                                transformRequest: angular.identity
                                            })
                        .then(function (response) {
                            return response;
                        });
        };

        var getFileName = function () {
            return $http.get("/FileStreaming/GetFileName")
                        .then(function (response) {
                            return response;
                        });
        };

        var getFiles = function () {
            return $http.get("/FileStreaming/GetFiles")
                        .then(function (response) {
                            return response;
                        });
        };

        return {
            uploadFile: uploadFile,
            getFileName: getFileName,
            getFiles: getFiles
        }


    };

    appModule.factory("UploadFileSVC", UploadFileSVC);

}());
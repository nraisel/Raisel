(function () {

    var appModule = angular.module("appModule", []);

    var MainController = function ($scope, UploadFileSVC, $log) {

        $scope.Message = "";
        $scope.FileInvalidMessage = "";
        $scope.SelectedFileForUpload = null;
        $scope.FileDescription = "";
        $scope.IsFormSubmitted = false;
        $scope.IsFileValid = false;
        $scope.IsFormValid = false;

        //Form Validation
        $scope.$watch("f1.$valid", function (isValid) {
            $scope.IsFormValid = isValid;
        });


        // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
        // ------------------------------------------------------------------------------------
        //File Validation
        $scope.ChechFileValid = function (file) {
            var isValid = false;
            if ($scope.SelectedFileForUpload != null) {
                if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                    $scope.FileInvalidMessage = "";
                    isValid = true;
                }
                else {
                    $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
                }
            }
            else {
                $scope.FileInvalidMessage = "Image required!";
            }
            $scope.IsFileValid = isValid;
        };

        //File Select event 
        $scope.selectFileforUpload = function (file) {
            $scope.SelectedFileForUpload = file[0];
        }

        $scope.uploadFile = function () {
            
            UploadFileSVC.uploadFile($scope.SelectedFileForUpload, $scope.description)
                         .then(function (response) {
                             $log.info(response.data);
                             $scope.Message = response.data.Message;
                             ClearForm();
                         }, function (response) {
                             $log.info(response.data);
                             $scope.FileInvalidMessage = response.data;
                             ClearForm();
                         });
        };

        //Clear form 
        function ClearForm() {
            $scope.description = "";
            //as 2 way binding not support for File input Type so we have to clear in this way
            //you can select based on your requirement
            angular.forEach(angular.element("input[type='file']"), function (inputElem) {
                angular.element(inputElem).val(null);
            });

            $scope.f1.$setPristine();
            $scope.IsFormSubmitted = false;
        }

        $scope.GetFiles = function () {
            UploadFileSVC.getFiles()
                         .then(function (response) {
                             $log.info(response.data);
                             $scope.files = response.data;
                         }, function (response) {
                             $log.info(response.data.Message);
                             $scope.error = respo.statusText;
                         });
        };

        $scope.description = "";
        $scope.TestMessage = "This is a test message";

    };

    appModule.controller("MainController", MainController);

}());
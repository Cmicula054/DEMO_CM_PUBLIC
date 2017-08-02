var app = angular.module('myApp', [
    'jcs-autoValidate'
]);


//FORM VALIDATION MESSAGES
app.run(function (defaultErrorMessageResolver) {
    defaultErrorMessageResolver.getErrorMessages().then(function (errorMessages) {
        errorMessages['badPassword'] = "Password must be minimum 8 characters and contain lower-case letter, upper-case letter, number  symbol";
        errorMessages['badZipCode'] = "Please enter a Valid Zip Code"
        errorMessages['badPhone'] = "Please enter a Valid Phone Number"
    });
}
);

app.controller('MainCtrl', function ($scope, $http) {
    $scope.formModel = {};
    

    //RETRIEVE ACCOUNT TYPES
    $http.get('http://localhost:63480/API/GetValidAccountTypes', $scope.formModel.AccountTypeId)
    .success(function (response) {
        $scope.AccountData = response;
        console.log($scope.AccountData);
    }).error(function (response) {
        console.log('no accounts found');
    });


    // DETERMINE IF USERNAME IS AVAILABLE
       $('#Username').keyup(function () {
           var userName = $(this).val();

           if (userName.length >= 3) {
               $http.get('http://localhost:63480/API/CheckUserID?username=' + $scope.formModel.Username)
                    .success(function (myData) {
                        console.log("Its working");
                        var divElement = $('#divOutput');
                        if(myData) {
                            divElement.text(userName + ' is already in use');
                            divElement.css('color', 'red');
                            $scope.formModel.Username = $scope.formModel.Username.$invalid;
                        } else {
                            console.log(myData)
                            divElement.text("");
                        }
                     }).error(function (myData) {
                         console.log('Not Working');
                   });
                }
       });

    //ON SUBMIT POST REQUEST
       $scope.onSubmit = function () {
        $http.post('http://localhost:63480/API/RegisterUser/', $scope.formModel)
          .success(function (data) {
              console.log("Success");
          }).error(function (data) {
              console.log("Failure");
          });
    };
});
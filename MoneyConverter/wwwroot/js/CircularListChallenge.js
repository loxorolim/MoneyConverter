

var circularListChallengeViewModel = new function CircularListChallengeViewModel() {
    var self = this;

    self.inputtedValue = 0;
    self.inputtedList = [];
    self.response = ko.observable("");


    self.checkIfExists = function () {

        $.ajax({
            type: "post",
            data: {
                __RequestVerificationToken: getToken(),
                circularListString: self.inputtedList,
                numberToFind: self.inputtedValue
            },
            dataType: "json",
            async: false,
            success: function (result) {
                if (result == true)
                    self.response("Exists!");
                else if (result == false)
                    self.response("Not exists!");
                else
                    self.response("");

            },
            error: function () {
                self.response("Invalid input!");
            }
        });
    }

}

// Activates knockout.js
ko.applyBindings(circularListChallengeViewModel);
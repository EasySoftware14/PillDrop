var wizardService = new function () {
    this.submitStep = function (options) {
        $.ajax({
            type: "POST",
            url: options.url,
            data: JSON.stringify(options.data),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.applicationComplete)
                    window.location = response.redirectUrl;
                else
                    options.context.moveToStep(response);
            },
            error: function(response) {
                console.log(response);
            }
        });
    }
}
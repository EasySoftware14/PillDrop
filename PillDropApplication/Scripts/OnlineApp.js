$(document).ready(function() {

    $(".datepicker").each(function() {
        var el = $(this);
        if (el.attr('name').toLowerCase().indexOf('birth') === -1)
            el.datepicker("setDate", new Date());
        else
            el.datepicker();
    });
    var driverIndex = 0;
    var contactIndex = 0;
    $("#add_another_driver").click(function () {
        driverIndex++;
        if (driverIndex == 1) {
            $("#driversContainer").append($("#driverFormTemplate").tmpl({ index: driverIndex }));

            $("#DriverNumber1")
                .on("keypress", function (e) {
                    var thisEl = $(this);
                    return numberValidate(thisEl.attr("id"), thisEl.val().length, thisEl.val(), e);
                })
                .on("focusout", function () {
                     numberValidationCheck($(this));
                 });

            var current = new Date();
            $('#OnlineDrivers' + driverIndex + 'DateofBirth').datepicker();
            $('#OnlineDrivers' + driverIndex + 'DateOfIssue').datepicker();
            var todayDate = parseInt(current.getMonth() + 1) + "/" + current.getDate() + "/" + current.getFullYear();
            $('#OnlineDrivers' + driverIndex + 'DateofBirth').val(todayDate);
            $('#OnlineDrivers' + driverIndex + 'DateOfIssue').val(todayDate);
        }
        $(this).html("Remove Driver");
        if (driverIndex == 2) {
            $("#driver_1").remove();
            $(this).html("Add Driver");
            driverIndex = 0;
        }
        for (var i = 0; i <= driverIndex; i++) {
            $('#DriverNumber' + i).bind("blur", showDrivers(i));
        }
    });
});
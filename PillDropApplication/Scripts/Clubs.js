$(document).ready(function () {
    
    if ($("#issueOtherCountriesYes").is(":checked")) {
        $("#issuingAnother").show();
    } else {
        $("#issuingAnother").hide();
    }

    if ($("#outletsyes").is(':checked')) {
        $("#outlettype").show();
    }
    $("#Contacts[0].ContactNumberCode,#AltNumberCountryCode,#NumberCountryCode,#FaxNumberCode,#ContactNumberCode,#AdminNumberCode,#ClubClaimAdminNumberCode, #BorderPost.NumberCode,#BorderPost.FaxNumberCode").keypress(function (e) {

        var charCode = (e.which) ? e.which : e.keyCode;

        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            e.preventDefault();
        }

    });
   $("#issueOtherCountriesYes").click(function () {
        $("#issuingAnother").show();
        $("#agreementInPlace").show();
    });

    $("#issueOtherCountriesNo").click(function () {
        $("#issuingAnother").hide();
        $("#agreementInPlace").hide();
    });

    $("#apply_time_to_all").click(function (e) {
        e.preventDefault();
        $(".from").val($(".open_time").val());
        $(".to").val($(".close_time").val());
        $(".timepicker").prop("disabled", false);
        $(".close_day").prop("checked", false);
        $(".error").hide();
    });

    $(".close_day").click(function () {
        markClosedDaysAsClose.call(this);
    });

    $(".acceptance_type").click(function () {
        $(".acceptance_type_error").empty();
    });

    $(".dispatchMethodType").click(function () {
        $(".dispatchMethod_type_error").empty();
    });

    $("#outletsyes").click(function () {
        $("#outlettype").show();
    });

    $("#outletsno").click(function () {
        $("#outlettype").hide();
        $("#haveagents").attr("checked", false);
        $("#havebranches").attr("checked", false);
    });


});
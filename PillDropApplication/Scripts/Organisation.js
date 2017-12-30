$(document).ready(function() {
   $(".dispatchMethodType").click(function() {
        $(".dispatchMethod_type_error").empty();
    });
    $("#outletsyes").click(function() {
        $("#outlettype").show();
    });
    $("#outletsno").click(function() {
        $("#outlettype").hide();
        $('#haveagents').attr('checked', false);
        $('#havebranches').attr('checked', false);
    });
    $("#Admin_Number").focusout(function() {
        var cellNumberCount = stringReplaceChar($("#Admin_Number").val()).length;
        if (cellNumberCount < 10) {
            $('#Admin_Number').val("");
            $("#claims_cross").show();
            $("#claims_tick").hide();
        } else {
            $("#claims_cross").hide();
            $("#claims_tick").show();
        }
    });
   
    $("#apply_time_to_all").click(function(e) {
        e.preventDefault();
        $(".from").val($(".open_time").val());
        $(".to").val($(".close_time").val());
        $(".timepicker").prop("disabled", false);
        $(".close_day").prop("checked", false);
        $(".error").hide();
    });
    $(".close_day").click(function() {
        markClosedDaysAsClose.call(this);
       });
});
   
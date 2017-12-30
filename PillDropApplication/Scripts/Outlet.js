$(document).ready(function() {
   
    $("#apply_time_to_all").click(function (e) {
        e.preventDefault();
        $(".from").val($(".open_time").val());
        $(".to").val($(".close_time").val());
        $(".timepicker").prop("disabled", false);
        $(".close_day").prop("checked", false);
        $(".error").hide();
    });
    $(".close_day").click(function () {
        var day = $(this).attr("name");
        var input = stringFormat("input[day='{0}']", day);
        if ($(this).prop("checked")) {
            $(input).prop("disabled", true);
            $(input).val("Closed");
        } else {
            $(input).removeAttr("disabled");
            $(input).removeAttr("readonly");
            $(input).val("");
        }
    });

    $("#club select").multipleSelect({
        placeholder: "Club"
    });
});
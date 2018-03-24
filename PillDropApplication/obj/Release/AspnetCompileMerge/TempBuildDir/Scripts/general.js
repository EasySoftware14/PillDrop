$(document).ready(function () {

    $(".acceptance_type").click(function () {
        $(".acceptance_type_error").empty();
    });

    $("#ZipCode").keyup(function () {
        var zipcode = $("#ZipCode").val().length;
        if (zipcode === 12) {
            $("#zipError").removeAttr("style");
        } else {
            $("#zipError").hide();
        }
    });

    $("#addTrailer").click(function () {
        $("#trailerContainer").show();
    });

    $("#postal-same-as-physical").click(function () {
        if (!$(this).prop("checked")) {
            $('.postal').find("input:text").val("");
            $(".postal-address").removeAttr("readonly");
            return;
        } else
            $("#postal-same-as-physical").prop("value", true);

        var line1 = $("input[name='PhysicalAddress.Line1']").val();
        var line2 = $("input[name='PhysicalAddress.Line2']").val();
        var line3 = $("input[name='PhysicalAddress.Line3']").val();
        var line4 = $("input[name='PhysicalAddress.Line4']").val();
        var line5 = $("input[name='PhysicalAddress.Line5']").val();
        var province = $("input[name='PhysicalAddress.Province']").val();
        var city = $("input[name='PhysicalAddress.City']").val();
        var zipcode = $("input[name='PhysicalAddress.ZipCode']").val();

        $("input[name='PostalAddress.Line1']").val(line1);
        $("input[name='PostalAddress.Line2']").val(line2);
        $("input[name='PostalAddress.Line3']").val(line3);
        $("input[name='PostalAddress.Line4']").val(line4);
        $("input[name='PostalAddress.Line5']").val(line5);
        $("input[name='PostalAddress.Province']").val(province);
        $("input[name='PostalAddress.City']").val(city);
        $("input[name='PostalAddress.ZipCode']").val(zipcode);
        $(".postal-address").attr("readonly", true);
        removeFieldValidationErrorDisplay(".postal-address");
    });
    
});

function ConvertFormToJSON(form) {
    var array = jQuery(form).serializeArray();
    var json = {};

    jQuery.each(array, function () {
        json[this.name] = this.value || '';
    });

    return json;
}
function stringFormat() {
    var definedArguments = [];
    for (var i = 0, n = arguments.length; i < n; i++) {
        if (arguments[i] == undefined)
            definedArguments.push("");
        else
            definedArguments.push(arguments[i]);
    }
    return $.validator.format.apply({}, definedArguments);
}

function stringReplaceChar(value) {

    return value.toString().replace(/ /g, '').replace(/[^a-z0-9\s]/gi, '');
}

function canAccess(key, module) {
    var features = idp.features.split(",");
    key = key || "";
    var access = _.contains(features, module + key);
    return access;
}

function fnCanAccess(columns, module) {
    var returnColumns = [];
    _.each(columns, function (item) {
        if (canAccess(item.key, module)) {
            returnColumns.push(item);
        }
    });
    return returnColumns;
}

function getUserActions(actionButtons, module) {
    var html = "";
    actionButtons = fnCanAccess(actionButtons, module);
    _.each(actionButtons, function (x) {
        var buttonMarkup = $(x.html).clone().wrap('<div/>').parent().html();
        html += buttonMarkup;
    });
    return html;
}

function toggleButton(selector, caller) {
    $(selector).attr("disabled", !$(caller).prop("checked"));
}
function showHideButton(selector) {
    $(selector).toggle();
}
function removeFieldValidationErrorDisplay(selector) {
    var parent = $(selector).parent('.input-with-icon');
    parent.removeClass('error-control');
    parent.find('span').remove();
    parent.find('i').remove();
}

function timePeriodIsValid(startTime, endTime) {
    var stt = new Date("July 23, 1892 " + startTime);
    stt = stt.getTime();

    var endt = new Date("July 23, 1892 " + endTime);
    endt = endt.getTime();
    return stt != endt;
}

function setTimePickerCloseTimes() {
    $(".from").each(function () {
        var inputName = $(this).attr("name");
        var name = inputName.substring(0, (inputName.indexOf("From"))) + "To";
        var endTimeInput = $(stringFormat("input[name='{0}']", name));
        var startTime = $(this).val();
        var endTime = endTimeInput.val();
        if (!timePeriodIsValid(startTime, endTime)) {
            $(this).val("Closed");
            endTimeInput.val("Closed");
            $(this).attr("disabled", true);
            endTimeInput.attr("disabled", true);
            var checkbox = stringFormat("#{0}_close", $(this).attr("day"));
            $(checkbox).prop("checked", true);
        }
    });
}

function markClosedDaysAsClose() {
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
}

function initializeMessenger() {
    $.blockUI({ overlayCSS: { backgroundColor: '#000000' } });
    return Messenger({
        extraClasses: 'messenger-fixed messenger-on-top',
        theme: 'future',
        showCloseButton: false
    }).run({
        errorMessage: 'An error occured while processing Idp stock',
        successMessage: 'Idp Stock processed successfully',
        action: function (opts) {
            if (!idp.stockProcessed) {
                return opts.error({
                    status: 500,
                    readyState: 0,
                    responseText: 0
                });
            } else {
                $.unblockUI();
                return opts.success();
            }
        }
    });
}
function numberValidationCheck(el) {

    el.attr('minlength', "11");
    el.attr('maxlength', "27");

    var tickEl = el.siblings("i[id$='tick']");
    var crossEl = el.siblings("i[id$='cross']");
    var elCount = stringReplaceChar(el.val()).length;
    if (elCount < 11) {
        el.val(""); // this is needed so required field fails form submission.
        crossEl.show();
        tickEl.hide();
    } else {
        crossEl.hide();
        tickEl.show();
    }
}

function isValidEmailAddress(emailAddress) {
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
}

function showModal(modalSelector) {
    $(modalSelector).modal({ backdrop: "static", keyboard: false });
}
(function ($) {
    $.ajaxSetup({
        'beforeSend': function (xhr) {
            var securityToken = $('[name=__RequestVerificationToken]').val();
            securityToken && xhr.setRequestHeader('__RequestVerificationToken', securityToken);
        }
    });
}(jQuery));
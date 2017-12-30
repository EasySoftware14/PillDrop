var idp = {};

idp.features = idp.features || "";
idp.resources = idp.resources || {};
idp.IdpImportMessenger = undefined;
idp.stockProcessed = false;
idp.notificationHub = {
    hub: {},
    notificationCount: 0,
    init: function (model) {
        var context = this;
        // Declare a proxy to reference the hub.
        context.hub = $.connection.notificationHub;
        // Start the connection.
        $.connection.hub.start().done(function () {
            context.hub.server.joinGroup(model.group);
            var count = Number(model.notificationCount);
            if (count && count > 0) {
                localStorage.notificationCount = count;
                $("#chat-message-count").text(count);
                $("#chat-message-count").show();
            }
            $(".chat-menu-toggle").click(function () {
                if (!$(this).hasClass("open")) {
                   $(this).addClass("open");
                    $.ajax({
                        type: "GET",
                        url: "/user/getnotifications",
                        data: { id: model.userId },
                        success: function(result) {
                            $('.side-widget-content').empty();
                            localStorage.notificationCount = 0;
                            $("#chat-message-count").text(0);
                            _.each(result.Notifications, function (notificationModel) {
                                var div = "<a href='#' style=' z-index:1;' class='top' data-placement='top' data-toggle='tooltip' title='{0}{3} {2}'><div class='user-details-wrapper active'>" +
                                    "<div class='user-details'>" +
                                    "<div class='user-name'>{0}</div><div class='user-more'>{1}</div>" +
                                    "</div><div class='clearfix'></div></div></a>";
                                $('.side-widget-content').append(stringFormat(div, notificationModel.Title, notificationModel.Body, notificationModel.Date, notificationModel.Body.replace(/(<([^>]+)>)/ig, "")));
                                $('[data-toggle="tooltip"]').tooltip();
                            });
                        },
                        error: function(data) {
                            //show error message
                        }
                    });
                } else {
                   $(this).removeClass("open");
                }
            });
        });
        // Broadcast notifications.
        context.hub.client.broadcastNotification = function (model) {
            context.showNotification(model);
            // Only show notification if not a stock processing status update
            if (model.NotificationType != 2) {
                context.notificationCount = Number(localStorage.notificationCount) ? Number(localStorage.notificationCount) : 0;
                var count = Number(context.notificationCount) + 1;
                localStorage.notificationCount = count;
                $("#chat-message-count").text(count);
                $("#chat-message-count").show();
                $(".notification-hub-section").append();
            }
        };
    },
    showNotification: function (model) {
        switch (model.NotificationType) {
            case 0:
                toastr.info('New order requested by ' + model.Title);
                return;
            case 1:
                if (!idp.IdpImportMessenger) {
                   idp.IdpImportMessenger = initializeMessenger();
                }
                return;
            case 2:
                if (!idp.IdpImportMessenger)
                    idp.IdpImportMessenger = initializeMessenger();
                idp.IdpImportMessenger.update({
                    type: "error",
                    message: model.Title
                });
                return;
            case 3:
                if (idp.IdpImportMessenger)
                    idp.stockProcessed = true;
                else
                    toastr.info('IDP Stock replenished');
                return;
            case 4:
                toastr.info('RSS Feed ' + model.Title);
                return;
            case 5:
                toastr.info('IDP Void' + model.Title);
                return;
            case 6:
                toastr.info('IDP Issued by ' + model.Title);
                return;
            case 7:
                toastr.info('IDP Application by ' + model.Title);
                return;
            case 8:
                toastr.info('IDP Application edited by ' + model.Title);
                return;
            case 9:
                toastr.info('Club edited by ' + model.Title);
                return;
            case 10:
                toastr.info('Country edited by ' + model.Title);
                return;
            case 11:
                toastr.info('User edited by ' + model.Title);
                return;
            case 12:
                toastr.info('Country setup by ' + model.Title);
                return;
            case 13:
                toastr.info('NCA added by ' + model.Title);
                return;
            case 14:
                toastr.info('NCA edited by ' + model.Title);
                return;
            case 15:
                toastr.info('Role added by ' + model.Title);
                return;
            case 16:
                toastr.info('Role edited by ' + model.Title);
                return;
            case 17:
                toastr.info('Insurer added by ' + model.Title);
                return;
            case 18:
                toastr.info('Insurer edited by ' + model.Title);
                return;
            case 19:
                toastr.info('Outlet added by ' + model.Title);
                return;
            case 20:
                toastr.info('Outlet edited by ' + model.Title);
                return;
            case 23:
                toastr.info('Order confirmed by ' + model.Title);
                return;
            case 24:
                toastr.info('Order allocated to ' + model.Title);
                return;
            case 25:
                toastr.info('Order dispatched to ' + model.Title);
                return;
            case 26:
                toastr.info('Order received by ' + model.Title);
                return;
            default:
                return;
        }
    }
};
var hubInit = function() {
    (function($, _) {
        $.fn.fiaNotificationHub = function() {
            // Declare a proxy to reference the hub.
            var hub = $.connection.notificationHub;
            // Create a function that the hub can call to broadcast messages.
            hub.client.broadcastNotification = function(name, message) {
                // Html encode display name and message.
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page.
                $('#discussion').append('<li><strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };
            // Get the user name and store it to prepend to messages.
            $('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function() {
                $('#sendmessage').click(function() {
                    // Call the Send method on the hub.
                    hub.server.sendNotification($('#displayname').val(), $('#message').val());
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                });
            });
        };
    })(jQuery, _);
};
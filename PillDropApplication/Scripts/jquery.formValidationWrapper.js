(function ($, _) {
    $.fn.formValidationWrapper = function (options) {
        return this.validate({
            rules: options && options.rules && options.rules,
            messages: options && options.messages && options.messages,
            invalidHandler: function (event, validator) {
	            //display error alert on form submit
	        },
	        errorPlacement: function (label, element) { // render error placement for each input type
	            var icon = $(element).parent('.input-with-icon').children('i');
	            var parent = $(element).parent('.input-with-icon');
	            icon.removeClass('fa fa-check').addClass('fa fa-exclamation');
	            parent.removeClass('success-control').addClass('error-control');

	            $('<span class="error"></span>').insertAfter(element).append(label);
	            parent = $(element).parent('.input-with-icon');
	            parent.removeClass('success-control').addClass('error-control');
	        },
	        highlight: function (element) { // hightlight error inputs
	            var icon = $(element).parent('.input-with-icon').children('i');
	            var parent = $(element).parent('.input-with-icon');
	            icon.removeClass('fa fa-check').addClass('fa fa-exclamation');
	            parent.removeClass('success-control').addClass('error-control');
	        },
	        unhighlight: function (element) { // revert the change done by hightlight

	        },
	        success: function (label, element) {
	            var icon = $(element).parent('.input-with-icon').children('i');
	            var parent = $(element).parent('.input-with-icon');
	            icon.removeClass("fa fa-exclamation").addClass('fa fa-check');
	            parent.removeClass('error-control').addClass('success-control');
	        },
	        submitHandler: function (form) {
	            form.submit();
	            options && options.submitButton && options.submitButton.attr("disabled", true);
	        }
	    });
	};
})(jQuery, _);
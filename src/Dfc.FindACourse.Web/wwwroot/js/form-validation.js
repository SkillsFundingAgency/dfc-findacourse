/* eslint-disable no-console */
// Form validation

'use strict';

(function () {
    $(function () {

        var defaultOptions = {
            highlight: function (element, errorClass) {
                var formGroup = $(element).closest('.form-group');

                if (formGroup) {
                    if (!formGroup.hasClass(errorClass)) {
                        formGroup.addClass(errorClass);
                    }
                }
            },
            unhighlight: function (element, errorClass) {
                var formGroup = $(element).closest('.form-group');

                if (formGroup) {
                    if (formGroup.hasClass(errorClass)) {
                        formGroup.removeClass(errorClass);
                    }
                }
            }
        };

        $.validator.setDefaults(defaultOptions);

        $('#FindACourseForm input').on('focusout keyup', function () {
            if ($(this).hasClass('input-validation-error')) {
                $.validator.defaults.highlight($(this), $.validator.defaults.errorClass);
            } else {
                $.validator.defaults.unhighlight($(this), $.validator.defaults.errorClass);
            }
        });

    });
})();

/* eslint-disable no-console */
// Form validation

'use strict';

(function () {
    $(function () {

        var toggleFormGroupValidationError = function (formElement, inputElement) {
            var formGroup = $(inputElement).closest('.form-group');

            if (!$(formElement).valid()) {
                if (formGroup) {
                    if (!formGroup.hasClass('error')) {
                        formGroup.addClass('error');
                    }
                }
            } else {
                if (formGroup) {
                    if (formGroup.hasClass('error')) {
                        formGroup.removeClass('error');
                    }
                }
            }
        };

        //$('#Location').removeAttr('data-val');

        $('#FindACourseForm input:text[data-val=true]').on('focusout', function () {
            toggleFormGroupValidationError($('#FindACourseForm'), this);
        });

        $('#FindACourseForm').on('submit', function () {
            var formElement = this;
            $('#FindACourseForm .input-validation-error').each(function (index, element) {
                toggleFormGroupValidationError(formElement, element);
            });
        });

    });
})();

/* eslint-disable no-console */
// Form validation

'use strict';

(function () {
    $(function () {


        $('#FindACourseForm').addTriggersToJqueryValidate().triggerElementValidationsOnFormValidation();

        $('#SubjectKeyword').elementValidation(function (element, result) {
            console.log(['validation ran for element:', element, 'and the result was:', result]);

            var errorClass = 'error';
            var formGroup = $(element).closest('.form-group');

            if (formGroup) {
                if (!formGroup.hasClass(errorClass) && result === false) {
                    formGroup.addClass(errorClass);
                } else if (formGroup.hasClass(errorClass) && result === true) {
                    formGroup.removeClass(errorClass);
                }
            }
        });

        $('#Location').elementValidation(function (element, result) {
            console.log(['validation ran for element:', element, 'and the result was:', result]);

            var errorClass = 'error';
            var formGroup = $(element).closest('.form-group');

            if (formGroup) {
                if (!formGroup.hasClass(errorClass) && result === false) {
                    formGroup.addClass(errorClass);
                } else if (formGroup.hasClass(errorClass) && result === true) {
                    formGroup.removeClass(errorClass);
                }
            }
        });

        $('#Location').on('blur', function () {
            var errorClass = 'error';
            var formGroup = $(this).closest('.form-group');
            var validationMessage = $('span[data-valmsg-for="Location"]');
            var isEmpty = $(this).val().length === 0;

            console.log(validationMessage);

            if (isEmpty && formGroup) {
                if (formGroup.hasClass(errorClass)) {
                    formGroup.removeClass(errorClass);
                    validationMessage.removeClass('field-validation-error').html('');
                }
            }
        });

        $(function () {
            $("select").removeAttr("multiple");
        });
         
    });

})();

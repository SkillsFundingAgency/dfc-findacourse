/* eslint-disable no-console */
// Filters

'use strict';

(function () {
    $(function () {
        $('#LocationRadiusFilter').accordion();

        $('#StudyModeFilter').accordion();

        $('#AttendanceModeFilter').accordion();

        $('#AttendancePatternFilter').accordion();

        $('#QualificationLevelFilter').accordion();

        $('#Dfe1619FundedFilter').accordion();

        $('.form-group .multiple-choice .multiple-choice-all').change(function () {
            var itemCheckboxes = $(this).closest('.form-group').find('.multiple-choice .multiple-choice-item');
            itemCheckboxes.prop('checked', $(this).is(':checked'));
        });

        $('.form-group .multiple-choice .multiple-choice-item').change(function () {
            var subheading = $(this).nearest('.accordion-subheading');
            var formGroup = $(this).closest('.form-group');
            var allCheckboxes = formGroup.find('.multiple-choice .multiple-choice-all');
            var allItemCheckboxes = formGroup.find('.multiple-choice .multiple-choice-item');
            var checkedItemCheckboxes = formGroup.find('.multiple-choice .multiple-choice-item:checked');

            console.log(subheading);

            if (checkedItemCheckboxes.length === allItemCheckboxes.length) {
                allCheckboxes.prop('checked', $(this).is(':checked'));
            } else {
                allCheckboxes.prop('checked', '');
            }

            if (checkedItemCheckboxes.length === 0) {
                subheading.html('');
            } else {
                subheading.html(checkedItemCheckboxes.length + ' selected');
            }
        });
    });
})();

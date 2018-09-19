/* eslint-disable no-console */
// Filters

'use strict';

(function () {
    $(function () {
        $('#LocationRadiusFilter').accordion({
            startState: 'open'
        });

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
            var allCheckboxes = $(this).closest('.form-group').find('.multiple-choice .multiple-choice-all');
            var allItemCheckboxes = $(this).closest('.form-group').find('.multiple-choice .multiple-choice-item');
            var checkedItemCheckboxes = $(this).closest('.form-group').find('.multiple-choice .multiple-choice-item:checked');

            if (checkedItemCheckboxes.length === allItemCheckboxes.length) {
                allCheckboxes.prop('checked', $(this).is(':checked'));
            } else {
                allCheckboxes.prop('checked', '');
            }
        });
    });
})();

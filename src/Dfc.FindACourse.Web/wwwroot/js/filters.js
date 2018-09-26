/* eslint-disable no-console */
// Filters

'use strict';

(function () {
    $(function () {

        var allChangeHandler = function (subheadingSelector, event) {
            var text = '';

            if ($(event.allElement).is(':checked')) {
                text = event.itemElements.length + ' selected';
            }

            $(subheadingSelector).html(text);
            $('#FindACourseForm').submit();
        };

        var itemChangeHandler = function (subheadingSelector, event) {
            var numberChecked = $(event.itemElements).filter(':checked').length;
            var text = '';

            if (numberChecked > 0) {
                text = numberChecked + ' selected';
            }

            $(subheadingSelector).html(text);
            $('#AttendanceModeFilter').accordion('testy');

            $('#FindACourseForm').submit();
        }

        $('#LocationRadiusFilter').accordion();

        $("#LocationRadiusFilter input[name='LocationRadius']").on('click', function () {
            $('#FindACourseForm').submit();
        });

        $('#StudyModeFilter').accordion();

        $('#AttendanceModeFilter').accordion();

        $('#AttendancePatternFilter').accordion();

        $('#QualificationLevelFilter').accordion();

        $('#IsDfe1619FundedFilter').accordion();

        $('#StudyModeFilter .form-group').multipleChoice({
            allChange: function (event) { allChangeHandler('#StudyModeFilter .accordion-subheading', event); },
            itemChange: function (event) { itemChangeHandler('#StudyModeFilter .accordion-subheading', event); }
        });

        $('#AttendanceModeFilter .form-group').multipleChoice({
            allChange: function (event) { allChangeHandler('#AttendanceModeFilter .accordion-subheading', event); },
            itemChange: function (event) { itemChangeHandler('#AttendanceModeFilter .accordion-subheading', event); }
        });

        $('#AttendancePatternFilter .form-group').multipleChoice({
            allChange: function (event) { allChangeHandler('#AttendancePatternFilter .accordion-subheading', event); },
            itemChange: function (event) { itemChangeHandler('#AttendancePatternFilter .accordion-subheading', event); }
        });

        $('#QualificationLevelFilter .form-group').multipleChoice({
            allChange: function (event) { allChangeHandler('#QualificationLevelFilter .accordion-subheading', event); },
            itemChange: function (event) { itemChangeHandler('#QualificationLevelFilter .accordion-subheading', event); }
        });

        $("#IsDfe1619FundedFilter input[name='IsDfe1619Funded']").on('click', function () {
            $('#FindACourseForm').submit();
        });

        $('#ClearAlFilters').clearAllFilters({
            filters: [
                "input[name='LocationRadius']",
                "input[name='StudyModes']",
                "input[name='AttendanceModes']",
                "input[name='AttendancePatterns']",
                "input[name='QualificationLevels']",
                "input[name='IsDfe1619Funded']"
            ],
            defaultFilters: ['#LocationRadius10Miles', '#IsDfe1619FundedAll'],
            done: function () {
                $('.accordion-subheading').html('');
                $('#FindACourseForm').submit();
            }
        });

        $('#SortBy').on('change', function () {
            $('#FindACourseForm').submit();
        });
    });
})();

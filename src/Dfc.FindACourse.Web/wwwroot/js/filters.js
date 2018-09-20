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
        };

        var itemChangeHandler = function (subheadingSelector, event) {
            var numberChecked = $(event.itemElements).filter(':checked').length;
            var text = '';

            if (numberChecked > 0) {
                text = numberChecked + ' selected';
            }

            $(subheadingSelector).html(text);
        }

        $('#LocationRadiusFilter').accordion();

        $('#StudyModeFilter').accordion();

        $('#AttendanceModeFilter').accordion();

        $('#AttendancePatternFilter').accordion();

        $('#QualificationLevelFilter').accordion();

        $('#Dfe1619FundedFilter').accordion();

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

        $('#Dfe1619FundedFilter .form-group').multipleChoice({
            allChange: function (event) { allChangeHandler('#Dfe1619FundedFilter .accordion-subheading', event); },
            itemChange: function (event) { itemChangeHandler('#Dfe1619FundedFilter .accordion-subheading', event); }
        });

        $('#ClearAlFilters').clearAllFilters({
            filters: [
                "input[name='LocationRadius']",
                "input[name^='StudyMode']",
                "input[name^='AttendanceMode']",
                "input[name^='AttendancePattern']",
                "input[name^='QualificationLevel']",
                "input[name='Dfe1619Funded']"
            ],
            defaultFilters: ['#LocationRadius10Miles'],
            done: function () {
                $('.accordion-subheading').html('');
                $('#FindACourseForm').submit();
            }
        });
    });
})();

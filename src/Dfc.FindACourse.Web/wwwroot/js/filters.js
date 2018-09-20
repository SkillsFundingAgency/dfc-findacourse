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

        $('#StudyModeFilter .form-group').multipleChoice();

        $('#AttendanceModeFilter .form-group').multipleChoice();

        $('#AttendancePatternFilter .form-group').multipleChoice();

        $('#QualificationLevelFilter .form-group').multipleChoice();

        $('#Dfe1619FundedFilter .form-group').multipleChoice();

    });
})();

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
    });
})();

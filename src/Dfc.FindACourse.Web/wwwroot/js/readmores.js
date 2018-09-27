/* eslint-disable no-console */
// Read mores

'use strict';

(function () {
    $(function () {

        var options100 = {
            speed: 100,
            collapsedHeight: 100,
            heightMargin: 25,
            moreLink: '<a href="#" style="display:block;margin-bottom:20px;">... read more</a>',
            lessLink: '<a href="#" style="display:block;margin-bottom:20px;">read less</a>'
        };

        $('#EntryRequirements')
            .css('overflow', 'hidden')
            .readmore(options100);

        $('#PriceDescription')
            .css('overflow', 'hidden')
            .readmore(options100);

        $('#CourseSummary')
            .css('overflow', 'hidden')
            .readmore(options100);

        $('#EquipmentRequired')
            .css('overflow', 'hidden')
            .readmore(options100);

        $('#AssessmentMethod')
            .css('overflow', 'hidden')
            .readmore(options100);
    });
})();
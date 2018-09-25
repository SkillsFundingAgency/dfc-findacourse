/* eslint-disable no-console */
// Read mores

'use strict';

(function () {
    $(function () {

        var options50 = {
            speed: 100,
            collapsedHeight: 50,
            heightMargin: 20,
            moreLink: '<a href="#" style="display:block;">... read more</a>',
            lessLink: '<a href="#" style="display:block;">read less</a>'
        };

        var options100 = {
            speed: 100,
            collapsedHeight: 100,
            heightMargin: 20,
            moreLink: '<a href="#" style="display:block;margin-bottom:20px;">... read more</a>',
            lessLink: '<a href="#" style="display:block;margin-bottom:20px;">read less</a>'
        };

        $('#EntryRequirements')
            .css('overflow', 'hidden')
            .readmore(options50);

        $('#PriceDescription')
            .css('overflow', 'hidden')
            .readmore(options50);

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
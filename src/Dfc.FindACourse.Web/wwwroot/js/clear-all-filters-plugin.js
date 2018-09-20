/* eslint-disable no-console */
// Clear All Filters Plugin

'use strict';

(function () {

    $.fn.clearAllFilters = function (options) {

        var settings = $.extend({
            filters: [],
            defaultFilters: [],
            done: function () { }
        }, $.fn.clearAllFilters.defaults, options);

        return $(this).each(function () {

            if ($.isArray(settings.filters) && settings.filters.length > 0) {
                var filter = $(this);

                filter.on('click', function (event) {
                    event.preventDefault();

                    $(settings.filters).each(function (i) {
                        var element1 = $(settings.filters[i]);

                        if (element1.is(':checkbox') || element1.is(':radio')) {
                            element1.prop('checked', '');
                        }

                        if ($.isArray(settings.defaultFilters) && settings.defaultFilters.length > 0) {
                            $(settings.defaultFilters).each(function (j) {
                                var element2 = $(settings.defaultFilters[j]);

                                if (element2.is(':checkbox') || element2.is(':radio')) {
                                    element2.prop('checked', 'checked');
                                }
                            });
                        }
                    });

                    if ($.isFunction(settings.done)) {
                        settings.done.call(this, filter[0]);
                    }
                });
            }
        });
    }
})();

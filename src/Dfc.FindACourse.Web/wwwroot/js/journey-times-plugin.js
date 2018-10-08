/* eslint-disable no-console */
// Journey Time Plugin

'use strict';

(function ($) {

    var methods = {
        init: function (options) {
            var settings = $.extend({
                store: []
            }, $.fn.journeyTimes.defaults, options);

            return $(this).each(function () {
                var rows = methods.getTableRowElements(settings.store);
                var $table = $(document.createElement('table'));
                $table.addClass('govuk-table');
                $(this).html('');
                $(this).append($table);

                for (var i = 0; i < rows.length; i++) {
                    $table.append(rows[i]);
                }
            });
        },
        getTableRowElement: function (labelText, durationText) {
            var $trEl = $(document.createElement('tr'));
            var $tdEl1 = $(document.createElement('td'));
            var $tdEl2 = $(document.createElement('td'));

            $tdEl1.html(labelText).addClass('govuk-table__cell govuk-body-s');
            $tdEl2.html(durationText).addClass('govuk-table__cell govuk-body-s');

            $trEl.addClass('govuk-table__row');
            $trEl.append($tdEl1);
            $trEl.append($tdEl2);

            return $trEl[0];
        },
        getTableRowElements: function (store) {
            var els = [];

            if ($.isArray(store)) {
                for (var i = 0; i < store.length; i++) {
                    els.push(methods.getTableRowElement(store[i].mode, store[i].duration));
                }
            }

            return els;
        },
        onTrigger: function () {

        }
    };

    $.fn.journeyTimes = function (methodOrOptions) {
        if (typeof methodOrOptions === 'object' || !methodOrOptions) {
            methods.init.apply(this, arguments);
        } else if ($.isFunction(methods[methodOrOptions])) {
            return methods[methodOrOptions].apply(this, Array.prototype.slice.call(arguments, 1));
        }
    }

})(jQuery);
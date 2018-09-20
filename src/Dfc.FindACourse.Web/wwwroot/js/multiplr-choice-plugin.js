/* eslint-disable no-console */
// Multiple Choice Plugin

'use strict';

(function () {

    $.fn.multipleChoice = function (options) {

        var settings = $.extend({
            startState: 'unchecked', // 'unchecked' | 'checked'
            allChange: function () { },
            itemChange: function () {}
        }, $.fn.multipleChoice.defaults, options);

        return $(this).each(function () {
            var multipleChoice = $(this);
            var allCheckbox = multipleChoice.find('input:checkbox.multiple-choice-all');
            var itemCheckboxes = multipleChoice.find('input:checkbox.multiple-choice-item');

            if (settings.startState === 'unchecked') {
                allCheckbox.prop('checked', '');
                itemCheckboxes.prop('checked', '');
            } else if (settings.startState === 'checked') {
                allCheckbox.prop('checked', 'checked');
                itemCheckboxes.prop('checked', 'checked');
            }

            allCheckbox.on('change', function () {
                itemCheckboxes.prop('checked', $(this).is(':checked'));

                if ($.isFunction(settings.allChange)) {
                    settings.allChange.call(this, multipleChoice[0]);
                }
            });

            itemCheckboxes.on('change', function () {
                var currentlyChecked = multipleChoice.find('input:checkbox.multiple-choice-item:checked');

                if (currentlyChecked.length === itemCheckboxes.length) {
                    allCheckbox.prop('checked', 'checked');
                } else {
                    allCheckbox.prop('checked', '');
                }

                if ($.isFunction(settings.itemChange)) {
                    settings.itemChange.call(this, multipleChoice[0]);
                }
            });

         });
    }
})();

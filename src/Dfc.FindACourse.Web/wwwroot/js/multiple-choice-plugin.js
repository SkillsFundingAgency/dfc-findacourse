/* eslint-disable no-console */
// Multiple Choice Plugin

'use strict';

(function () {

    $.fn.multipleChoice = function (options) {

        var settings = $.extend({
            allChange: function () { },
            itemChange: function () {}
        }, $.fn.multipleChoice.defaults, options);

        return $(this).each(function () {
            var multipleChoice = $(this);
            var allCheckbox = multipleChoice.find('input:checkbox.multiple-choice-all');
            var itemCheckboxes = multipleChoice.find('input:checkbox.multiple-choice-item');

            allCheckbox.on('change', function () {
                itemCheckboxes.prop('checked', $(this).is(':checked'));

                if ($.isFunction(settings.allChange)) {
                    settings.allChange.call(this,
                        {
                            multipleChoiceElement: multipleChoice[0],
                            allElement: this,
                            itemElements: itemCheckboxes,
                            targetElement: this 
                        });
                }
            });

            itemCheckboxes.on('change', function () {
                var currentlyChecked = multipleChoice.find('input:checkbox.multiple-choice-item:checked');

                if (currentlyChecked.length === itemCheckboxes.length) {
                    allCheckbox.prop('checked', 'checked');
                } else {
                    allCheckbox.prop('checked', '');
                }


                ///QUAL LEVEL PERSIST
                //If Quallevel and only one checked, and current is checked then set to storage
                if ($(this).attr("id").match("^QualificationLevel")){
                    if (currentlyChecked.length === 1 && $(this).prop('checked')) {
                        sessionStorage.setItem('quallevel', $(this).val());
                    }
                    else if (currentlyChecked.length === 1) {
                        sessionStorage.setItem('quallevel', currentlyChecked.val());
                    }
                }
                

                if ($.isFunction(settings.itemChange)) {
                    settings.itemChange.call(this, {
                        multipleChoiceElement: multipleChoice[0],
                        allElement: allCheckbox,
                        itemElements: itemCheckboxes,
                        targetElement: this
                    });
                }
            });

         });
    }
})();

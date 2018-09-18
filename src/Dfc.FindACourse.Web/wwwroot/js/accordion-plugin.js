/* eslint-disable no-console */
// Accordion Plugin

'use strict';

(function () {

    $.fn.accordion = function (options) {

        var settings = $.extend({
            startState: 'close',
            openStateClass: 'accordion--state-open',
            closeStateClass: 'accordion--state-close',
            speed: 'slow',
            open: function () { },
            close: function () { },
            done: function () { }
        }, $.fn.accordion.defaults, options);

        return $(this).each(function () {
            var accordion = $(this);
            var header = accordion.children('.accordion-header');
            var panel = header.next('.accordion-panel');

            if (settings.startState === 'open') {
                accordion.addClass(settings.openStateClass);
                panel.show();
            }

            if (settings.startState === 'close') {
                accordion.addClass(settings.closeStateClass);
                panel.hide();
            }

            header.on('click', function () {
                panel.slideToggle(settings.speed, function () {
                    if (accordion.hasClass(settings.openStateClass)) {
                        accordion.removeClass(settings.openStateClass);
                        accordion.addClass(settings.closeStateClass);
                        if ($.isFunction(settings.close)) {
                            settings.close.call(this, accordion[0]);
                        }
                    } else if (accordion.hasClass(settings.closeStateClass)) {
                        accordion.removeClass(settings.closeStateClass);
                        accordion.addClass(settings.openStateClass);
                        if ($.isFunction(settings.open)) {
                            settings.open.call(this, accordion[0]);
                        }
                    }

                    if ($.isFunction(settings.done)) {
                        settings.done.call(this, accordion[0]);
                    }
                });
            });
        });
    }
})();

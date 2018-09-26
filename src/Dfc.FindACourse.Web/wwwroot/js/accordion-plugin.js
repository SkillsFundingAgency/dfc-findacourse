/* eslint-disable no-console */
// Accordion Plugin

'use strict';

(function () {

    var methods = {
        init: function (options) {
            var settings = $.extend({
                startState: 'close', // 'open' | 'close'
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
                accordion.removeClass([settings.openStateClass, settings.closeStateClass]);

                if (methods.getIsPostBack(accordion[0])) {
                    if (settings.startState === 'open') {
                        accordion.addClass(settings.openStateClass);
                    } else if (settings.startState === 'close') {
                        accordion.addClass(settings.closeStateClass);
                    }
                } else {
                    var stateCssClass = methods.getStateCssClass(accordion[0], settings);
                    accordion.addClass(stateCssClass);
                }

                header.on('click', function () {
                    panel.slideToggle(settings.speed, function () {
                        var toggleState = methods.getToggleState(accordion[0], settings);
                        accordion.removeClass(toggleState.removeCssClass);
                        accordion.addClass(toggleState.addCssClass);

                        if (toggleState.currentState === 'open') {
                            if ($.isFunction(settings.open)) {
                                settings.open.call(this, accordion[0]);
                            }
                        } else if (toggleState.currentState === 'close') {
                            if ($.isFunction(settings.close)) {
                                settings.open.call(this, accordion[0]);
                            }
                        }

                        if ($.isFunction(settings.done)) {
                            settings.done.call(this, accordion[0]);
                        }
                    });
                });
            });
        },
        getIsPostBack: function (el) {
            var attrId = $(el).attr('id');
            var val = window.sessionStorage.getItem(attrId + '::isPostBack') || null;

            if (val === null) {
                val = true;
            } else {
                val = false;
            }

            methods.setIsPostBack(el, val);

            return val;
        },
        setIsPostBack: function (el, val) {
            var attrId = $(el).attr('id');
            window.sessionStorage.setItem(attrId + '::isPostBack', val);
        },
        getStateCssClass: function (el, settings) {
            var attrId = $(el).attr('id');
            var val = window.sessionStorage.getItem(attrId + '::stateCssClass') || null;

            if (val === null) {

                if (settings.startState === 'open') {
                    val = settings.openStateClass;
                } else if (settings.startState === 'close') {
                    val = settings.closeStateClass;
                }

                methods.setStateCssClass(el, val);
            }

            console.log([attrId, 'getStateCssClass', val]);

            return val;
        },
        setStateCssClass: function (el, val) {
           var attrId = $(el).attr('id');
            window.sessionStorage.setItem(attrId + '::stateCssClass', val);

            console.log([attrId, 'setStateCssClass', val]);
        },
        getToggleState: function(el, settings) {
            var current = methods.getStateCssClass(el, settings);

            if (current === settings.openStateClass) {
                methods.setStateCssClass(el, settings.closeStateClass);
                return { currentState: 'close', previousState: 'open', removeCssClass: settings.openStateClass, addCssClass: settings.closeStateClass };
            } else {
                methods.setStateCssClass(el, settings.openStateClass);
                return { currentState: 'open', previousState: 'close', removeCssClass: settings.closeStateClass, addCssClass: settings.openStateClass };
            }
        }
    };

    $.fn.accordion = function (methodOrOptions) {
        if (typeof methodOrOptions === 'object' || !methodOrOptions) {
            methods.init.apply(this, arguments);
        } else if ($.isFunction(methods[methodOrOptions])) {
            return methods[methodOrOptions].apply(this, Array.prototype.slice.call(arguments, 1));
        }
    }
})();

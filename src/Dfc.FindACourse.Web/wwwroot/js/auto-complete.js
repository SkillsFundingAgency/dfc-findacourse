/* eslint-disable no-console */
// Auto-complete

'use strict';

(function () {
    $(function () {

        var autoCompleteSuggestions = function (term) {
            $.ajax({
                type: 'GET',
                url: '/coursedirectory/autocomplete',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: {
                    parm: term
                },
                success: function (data) {
                    $.each(data, function (i, value) {

                        var valueLow = value.toLowerCase();
                        var valueHigh = value.toUpperCase();
                        var termReplace = '<strong>' + term.toUpperCase() + '</strong>';
                        var formatted = '';

                        if (valueLow.indexOf(term.toLowerCase()) > -1) {
                            formatted = valueHigh.replace(term.toUpperCase(), termReplace);
                        } else {
                            formatted = valueHigh;
                        }

                        $('#course-list').append($('<li>', {
                            'data-value': value,
                            html: formatted
                        }));

                    });

                    var length = $('#course-list').children('li').length;

                    if (length > 0) {
                        $('#course-list').show();
                    } else {
                        $('#course-list').hide();
                    }
                },
                failure: function (data) {
                    console.log(data.responseText);
                },
                error: function (data) {
                    console.log(data.responseText);
                }
            }); 
        };

        var arrowNagivation = function (keyCode) {
            console.log(keyCode);
            var currentItem = $('#course-list li.item-hover');

            if (keyCode === 38) {
                if (currentItem.length) {
                    currentItem.removeClass('item-hover');

                    if (currentItem.prev()) {
                        currentItem.prev().addClass('item-hover');
                    }

                    scrollSuggestions('up');
                }
            }

            if (keyCode === 40) {
                if (currentItem.length) {
                    currentItem.removeClass('item-hover');

                    if (currentItem.next()) {
                        currentItem.next().addClass('item-hover');
                    }

                    scrollSuggestions('down');
                } else {
                    $('#course-list li').first().addClass('item-hover');
                    scrollSuggestions('down');
                }
            }

        };

        var scrollSuggestions = function (direction) {
            var scrollableList = $('#course-list');
            var currentItem = scrollableList.find('li.item-hover');
            var height = scrollableList.innerHeight();
            var currentVerticalScrollPos = scrollableList.scrollTop();
            var itemHeight = currentItem.outerHeight(true);
            var itemNumber = currentItem.index() + 1;

            if (direction === 'down') {
                if ((itemNumber * itemHeight) > height) {
                    scrollableList.scrollTop(currentVerticalScrollPos + itemHeight);
                }

                if (!itemHeight) {
                    scrollableList.scrollTop(0);
                }
            }

            if (direction === 'up') {
                scrollableList.scrollTop(currentVerticalScrollPos - itemHeight);

                if (!itemHeight) {
                    scrollableList.scrollTop(scrollableList[0].scrollHeight);
                    currentItem.removeClass('item-hover');
                    scrollableList.find('li:last-child').addClass('item-hover');
                }
            }
        };

        $('#SubjectKeyword').on('keyup', function (e) {
            var keyCode = e.keyCode || e.which;

            if (keyCode !== 38 && keyCode !== 40) {
                $('#course-list li').each(function () {
                    $(this).remove();
                });

                autoCompleteSuggestions($(this).val());
            }

            if (keyCode === 38 || keyCode === 40) {
                arrowNagivation(keyCode);
            }
        });

        $('#SubjectKeyword').on('keydown', function (e) {
            var keyCode = e.keyCode || e.which;

            if (keyCode === 13) {
                e.preventDefault();
                $('#SubjectKeyword').text($('#course-list li.item-hover').text());
                $('#course-list').hide();
            }

            if (keyCode === 9) {
                $('#course-list').hide();
            }
        });

        $('#SubjectKeyword').on('click', function () {
            $('#course-list').hide();
        });

        var timer;

        $('.select-editable').on('mouseover', function () {
            clearTimeout(timer);
        }).on('mouseleave', function () {
            timer = setTimeout(function () {
                $('#course-list').hide();
            }, 1500);
        });

        $('#course-list').on('click', function () {
            $('#SubjectKeyword').val($('li:hover').attr('data-value'));
            $(this).hide();
            $('#SubjectKeyword').focus();
        });

    });
})();

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
            var tmpValue = $('#SubjectKeyword').val();
            $('#SubjectKeyword').focus().val('').val(tmpValue);

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
            //Set the value in the search box
            setSubjectValue();
        };

        $('#SubjectKeyword').on('keyup', function (e) {
            var keyCode = e.keyCode || e.which;

            if (keyCode !== 38 && keyCode !== 40) {
                $('#course-list li').each(function () {
                    $(this).remove();
                });

                if (keyCode !== 13) {
                    autoCompleteSuggestions($(this).val());
                }
                if (keyCode === 13) {
                    //alert('Course List Enter');
                    $('#course-list').trigger('click');
                }
            }

            if (keyCode === 38 || keyCode === 40) {
                arrowNagivation(keyCode);
            }
        });

        $('#SubjectKeyword').on('keydown', function (e) {
            var keyCode = e.keyCode || e.which;

            if (keyCode === 13) {
                if ($('#course-list').is(':visible')) {
                    e.preventDefault();
                    $("#Search").focus().click();
                 
                }
            }

            if (keyCode === 9) {
                $('#course-list').hide();
            }
        });

        $('#SubjectKeyword').on('click', function () {
            $('#course-list').hide();
        });

        $(document).on('click', function () {
            $('#course-list').hide();
        });

        $('#course-list').on('click', function () {
            setSubjectValue();

            $(this).hide();
            $('#SubjectKeyword').focus();
        });

        var setSubjectValue = function () {
            var hoverValue = $('#course-list li:hover').attr('data-value');
            var selectedValue = $('#course-list li.item-hover').attr('data-value');

            if (selectedValue) {
                $('#SubjectKeyword').val(selectedValue);
            } else {
                $('#SubjectKeyword').val(hoverValue);
            }
        };
    });
})();

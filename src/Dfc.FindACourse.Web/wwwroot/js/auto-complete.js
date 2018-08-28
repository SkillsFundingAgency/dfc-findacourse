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

                        if (valueLow.indexOf(term) > -1) {
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

        $('#SubjectKeyword').keyup(function () {
            $('#course-list li').each(function () {
                $(this).remove();
            });

            autoCompleteSuggestions($(this).val());
        });

        $('#SubjectKeyword').click(function () {
            $('#course-list').hide();
        });

        $('#course-list').mouseleave(function () {
            $(this).hide();
            $('#SubjectKeyword').focus();
        });

        $('#course-list').click(function () {
            $('#SubjectKeyword').val($('li:hover').attr('data-value'));
            $(this).hide();
            $('#SubjectKeyword').focus();
        });

    });
})();

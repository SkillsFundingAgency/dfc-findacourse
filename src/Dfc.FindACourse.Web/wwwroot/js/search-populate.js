/* eslint-disable no-console */
// Auto-complete

'use strict';

(function () {
    $(function () {
        function GetURLParam(name) {
            name = name.replace(/[[]/, "\\[").replace(/[\]]/, "\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec($('#hidUrl').val());
            if (results == null)
                return "";
            else
                return results[1];
        }
        //get vars
        var subject = GetURLParam('SubjectKeyword');
        //var qualLevels = GetURLParam('QualificationLevels');
        //var radius = GetURLParam('LocationRadius');
        //var postcode = GetURLParam('Location');

        ////set inputs
        //$('#QualificationLevels').val(qualLevels);
        //$('#LocationRadius').val(radius);         if (subject.length > 0) $('#SubjectKeyword').val(decodeURIComponent(subject).replace(/\+/g, ' '));
        //if (postcode.length > 0) $('#Location').val(decodeURIComponent(postcode).replace(/\+/g, ' '));

        //pure javascript
        //var pathname = window.location.pathname;
        //alert('pathname' + pathname);
        //// to show it in an alert window
        //alert(window.location);
        if (window.location.href.indexOf("?") > -1) {
           /// alert("your url contains the name franky");
            $('#hidUrl').val(window.location.href);
        }
    });
})();

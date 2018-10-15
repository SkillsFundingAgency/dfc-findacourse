/* eslint-disable no-console */
// Auto-complete

'use strict';

(function () {
    $(function () {
       
        
        var subjectdata = sessionStorage.getItem('subjectkeyword');
        var quallevel = sessionStorage.getItem('quallevel');
        var locationpostcode = sessionStorage.getItem('locationpostcode');
        var locationradius = sessionStorage.getItem('locationradius');


        //This JS is used for both page 1 and page 2 so we need to set values for both
        if (checkValue(quallevel)) $('#QualificationLevels').val(quallevel);
        if (checkValue(locationradius)) $('#LocationRadius').val(locationradius);
        if (checkValue(subjectdata)) $('#SubjectKeyword').val(decodeURIComponent(subjectdata).replace(/\+/g, ' '));
        if (checkValue(locationpostcode)) $('#Location').val(decodeURIComponent(locationpostcode).replace(/\+/g, ' '));

        function checkValue(data) {
            if ((data !== undefined) && (data !== null)) {
                return true;
            }
            else {
                return false;
            }
        }


       
    });
})();

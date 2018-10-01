/* eslint-disable no-console */
// Social Media

'use strict';

(function () {
    $(function () {
        $('.twitter').attr('href', 'https://twitter.com/intent/tweet?original_referer&amp;url=' + window.location.href);
        $('.facebook').attr('href', 'https://www.facebook.com/sharer/sharer.php?u=' + window.location.href);
        $('.linkedin').attr('href', 'https://www.linkedin.com/shareArticle?url=' +window.location.href);
        $('.email').attr('href', 'mailto:?subject=National Careers Service&body=I wanted to share this post with you from the National Careers Service:%0D%0A' + window.location.href);
    });
})();
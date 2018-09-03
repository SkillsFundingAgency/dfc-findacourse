/* eslint-disable no-console */
// Google Maps Location Auto-complete

'use strict';

var Dfe = Dfe || {};
Dfe.FindACourse = Dfe.FindACourse || {};

Dfe.FindACourse.initGoogleMapsLocationAutoComplete = function () {
    var inputElement = $('#Location')[0];
    var hiddenElement = $('#LocationCoordinates');
    var autocomplete = new google.maps.places.Autocomplete(inputElement);

    autocomplete.setComponentRestrictions({ 'country': ['uk'] });
    autocomplete.setFields(['address_components', 'geometry', 'icon', 'name']);
    autocomplete.addListener('place_changed', function () {
        var place = autocomplete.getPlace();

        if (!place.geometry) {
            console.log('Error no location data returned for \'' + place.name + '\'');
            return;
        }

        hiddenElement.val('');
        hiddenElement.val(place.geometry.location.lat() + ',' + place.geometry.location.lng());
    });
};

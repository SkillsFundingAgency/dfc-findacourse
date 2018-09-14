/* eslint-disable no-console */
// Google Maps Location Auto-complete

'use strict';

//var Dfe = Dfe || {};
//Dfe.FindACourse = Dfe.FindACourse || {};

//Dfe.FindACourse.initGoogleMapsLocationAutoComplete = function () {
//    var inputElement = $('#LocationHidden')[0];
//    var hiddenElement = $('#LocationCoordinates');
//    var autocomplete = new google.maps.places.Autocomplete(inputElement);

//    autocomplete.setComponentRestrictions({ 'country': ['uk'] });
//    autocomplete.setFields(['address_components', 'geometry', 'name']);
//    autocomplete.addListener('place_changed', function () {
//        var place = autocomplete.getPlace();

//        if (!place.geometry) {
//            console.log('Error no location data returned for \'' + place.name + '\'');
//            return;
//        }

//        hiddenElement.val('');
//        hiddenElement.val(place.geometry.location.lat() + ',' + place.geometry.location.lng());

//        var foundPostcodes = place.address_components.filter(function (item) {
//            return $.inArray('postal_code', item.types) > -1;
//        });

//        var foundPostalTowns = place.address_components.filter(function (item) {
//            return $.inArray('postal_town', item.types) > -1;
//        });

//        if (foundPostcodes && foundPostcodes.length > 0) {
//            $(inputElement).val('').val(foundPostcodes[0].long_name);
//        } else if (foundPostalTowns && foundPostalTowns.length > 0) {
//            $(inputElement).val('').val(foundPostalTowns[0].long_name);
//        } 
//    });
//};

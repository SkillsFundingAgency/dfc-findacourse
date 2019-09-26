using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models.FindACourse
{
    public class FindACourseSearchResult: IFindACourseSearchResult
    {
        
        public string ODataContext { get; set; }
        public int? ODataCount { get; set; }
        public dynamic SearchFacets { get; set; } //FACSearchFacets SearchFacets { get; set; }
        public int? NoOfPages { get; set; }
        public int? PageNo { get; set; }

        public IEnumerable<FindACourseSearchItem> Value { get; set; }
       

        public FindACourseSearchResult(
           string oDataContext,
           int oDataCount,
           dynamic searchFacets,
           IEnumerable<FindACourseSearchItem> value)
        {
            //if (noOfPages < 0)
            //    throw new ArgumentOutOfRangeException(nameof(noOfPages));
            //if (noOfRecords < 0)
            //    throw new ArgumentOutOfRangeException(nameof(noOfRecords));
            //if (pageNo < 0)
            //    throw new ArgumentOutOfRangeException(nameof(pageNo));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            ODataContext = oDataContext;
            ODataCount = oDataCount;
            SearchFacets = searchFacets;
            //  var noOfPages = response.ResultInfo.NoOfPages.ToIntOrValue(0);
            
            //var pageNo = response.ResultInfo.PageNo.ToIntOrValue(0);
            

            Value = value;
        }
    }
}
/*
 {
    "oDataContext": "https://dfc-dev-prov-sch.search.windows.net/indexes('course')/$metadata#docs(*)",
    "oDataCount": 3,
    "searchFacets": {
        "Region": [],
        "ProviderName": [
            {
                "count": 2,
                "value": "WALSALL COLLEGE"
            },
            {
                "count": 1,
                "value": "PATHWAY FIRST LIMITED"
            }
        ],
        "VenueAttendancePattern": [
            {
                "count": 3,
                "value": "1"
            }
        ],
        "NotionalNVQLevelv2": [
            {
                "count": 3,
                "value": "2"
            }
        ]
    },
    "value": [
        {
            "searchScore": 0.2773501,
            "venueLocation": {
                "type": "Point",
                "coordinates": [
                    -1.982554,
                    52.589449
                ],
                "crs": {
                    "type": "name",
                    "properties": {
                        "name": "EPSG:4326"
                    }
                }
            },
            "geoSearchDistance": 0.0,
            "scoreBoost": null,
            "id": "df28547a-17e5-46c2-9e31-ac9e767436a9",
            "courseId": "a1e8095e-5a7c-49c7-b50c-9f38c301c553",
            "qualificationCourseTitle": "GCSE (9-1) in Biology",
            "learnAimRef": "60187529",
            "notionalNVQLevelv2": "2",
            "updatedOn": null,
            "venueName": "Wisemore Campus",
            "venueAddress": "Littleton Street West, WALSALL, West Midlands, WS2 8ES",
            "venueAttendancePattern": "1",
            "providerName": "WALSALL COLLEGE",
            "region": null,
            "status": 1
        },
        {
            "searchScore": 0.2773501,
            "venueLocation": {
                "type": "Point",
                "coordinates": [
                    -1.982554,
                    52.589449
                ],
                "crs": {
                    "type": "name",
                    "properties": {
                        "name": "EPSG:4326"
                    }
                }
            },
            "geoSearchDistance": 0.0,
            "scoreBoost": 1.0,
            "id": "524f44c9-0816-4bf9-bf1e-f76911a4ddd0",
            "courseId": "a1e8095e-5a7c-49c7-b50c-9f38c301c553",
            "qualificationCourseTitle": "GCSE (9-1) in Biology",
            "learnAimRef": "60187529",
            "notionalNVQLevelv2": "2",
            "updatedOn": null,
            "venueName": "Wisemore Campus",
            "venueAddress": "Littleton Street West, WALSALL, West Midlands, WS2 8ES",
            "venueAttendancePattern": "1",
            "providerName": "WALSALL COLLEGE",
            "region": null,
            "status": 1
        },
        {
            "searchScore": 0.2773501,
            "venueLocation": {
                "type": "Point",
                "coordinates": [
                    -1.977353,
                    52.587648
                ],
                "crs": {
                    "type": "name",
                    "properties": {
                        "name": "EPSG:4326"
                    }
                }
            },
            "geoSearchDistance": 0.25,
            "scoreBoost": null,
            "id": "92af6f66-fa6a-4159-a8a3-1a849e44f568",
            "courseId": "dc22c7a7-4477-47cb-bac1-955a48819168",
            "qualificationCourseTitle": "GCSE (9-1) in Biology B (Twenty First Century Science)",
            "learnAimRef": "60185065",
            "notionalNVQLevelv2": "2",
            "updatedOn": null,
            "venueName": "Care Training Partnership",
            "venueAddress": "18 Lichfield Street, Walsall, West Midlands, WS1 1TJ",
            "venueAttendancePattern": "1",
            "providerName": "PATHWAY FIRST LIMITED",
            "region": null,
            "status": 4
        }
    ]
}        */

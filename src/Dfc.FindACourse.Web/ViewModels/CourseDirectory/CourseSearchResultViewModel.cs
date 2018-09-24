﻿using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class CourseSearchResultViewModel
    {
        private const string _locationError = "Enter a full and valid postcode";

        public CourseSearchResultViewModel(IResult<CourseSearchResult> result)
        {
            NoOfRecords = result.Value.NoOfRecords;
            NoOfPages = result.Value.NoOfPages;
            PageNo = result.Value.PageNo;
            Items = result.Value.Items.Select(x => new CourseSearchResultItemViewModel(x)).ToList();
            LocationRadius = RadiusDistance.Miles10;
            StudyModes = new int[] { };
            AttendanceModes = new int[] { };
        }

        public string ShowingFrom()
        {
            if (PageNo == 1 && NoOfRecords == 0)
                return 0.ToString();

            if (PageNo == 1)
                return 1.ToString();

            var from = (PageNo - 1) * PerPage + 1;

            return from.ToString();
        }

        public string ShowingTo()
        {
            if (PageNo <= 1 && PerPage >= NoOfRecords)
                return NoOfRecords.ToString();

            if (PageNo <= 1 && PerPage < NoOfRecords)
                return PerPage.ToString();

            var to = ((PageNo - 1) * PerPage) + PerPage;

            to = to > NoOfRecords ? NoOfRecords : to;

            return to.ToString();
        }

        public string LocationRadiusChecked(int radius)
        {
            return (int)LocationRadius == radius ? "checked=\"checked\"" : string.Empty;
        }

        public string StudyModeAllChecked()
        {
            var allStudyModes = Enum.GetValues(typeof(StudyMode)).Cast<StudyMode>().Where(x => IsDisplayable(x)).Cast<int>();
            return StudyModes != null && Enumerable.SequenceEqual(allStudyModes, StudyModes) ? "checked=\"checked\"" : string.Empty;
        }

        public string StudyModeSelectedText()
        {
            return StudyModes == null || StudyModes.Length == 0 ? string.Empty : $"{StudyModes.Length} selected";
        }

        public string StudyModeChecked(int value)
        {
            return StudyModes != null && StudyModes.Contains(value) ? "checked=\"checked\"" : string.Empty;
        }

        internal static bool IsDisplayable(StudyMode studyMode)
        {
            switch (studyMode)
            {
                case StudyMode.FullTime:
                case StudyMode.PartTime:
                case StudyMode.Flexible:
                    return true;
                default:
                    return false;
            }
        }


        public string AttendanceModeAllChecked()
        {
            var allAttendanceModes = Enum.GetValues(typeof(AttendanceMode)).Cast<AttendanceMode>().Where(x => IsDisplayable(x) && IsSelectable(x)).Cast<int>();
            return AttendanceModes != null && Enumerable.SequenceEqual(allAttendanceModes, AttendanceModes) ? "checked=\"checked\"" : string.Empty;
        }

        public string AttendanceModeSelectedText()
        {
            return AttendanceModes == null || AttendanceModes.Length == 0 ? string.Empty : $"{AttendanceModes.Length} selected";
        }

        public string AttendanceModeChecked(int value)
        {
            return AttendanceModes != null && AttendanceModes.Contains(value) ? "checked=\"checked\"" : string.Empty;
        }

        internal static bool IsDisplayable(AttendanceMode attendanceMode)
        {
            switch (attendanceMode)
            {
                case AttendanceMode.FaceToFace:
                case AttendanceMode.MixedMode:
                case AttendanceMode.NotKnown:
                    return false;
                default:
                    return true;
            }
        }

        internal static bool IsSelectable(AttendanceMode attendanceMode)
        {
            switch (attendanceMode)
            {
                case AttendanceMode.LocationCampus:
                case AttendanceMode.WorkBased:
                case AttendanceMode.DistanceWithAttendance:
                    return true;
                default:
                    return false;
            }
        }

        public string AttendancePatternAllChecked()
        {
            var allAttendancePatterns = Enum.GetValues(typeof(AttendancePattern)).Cast<AttendancePattern>().Where(x => IsDisplayable(x) && IsSelectable(x)).Cast<int>();
            return AttendancePatterns != null && Enumerable.SequenceEqual(allAttendancePatterns, AttendancePatterns) ? "checked=\"checked\"" : string.Empty;
        }

        public string AttendancePatternSelectedText()
        {
            return AttendancePatterns == null || AttendancePatterns.Length == 0 ? string.Empty : $"{AttendancePatterns.Length} selected";
        }

        public string AttendancePatternChecked(int value)
        {
            return AttendancePatterns != null && AttendancePatterns.Contains(value) ? "checked=\"checked\"" : string.Empty;
        }

        internal static bool IsDisplayable(AttendancePattern attendancePattern)
        {
            switch (attendancePattern)
            {
                case AttendancePattern.Customised:
                case AttendancePattern.NotKnown:
                case AttendancePattern.NotApplicable:
                    return false;
                default:
                    return true;
            }
        }

        internal static bool IsSelectable(AttendancePattern attendancePattern)
        {
            switch (attendancePattern)
            {
                case AttendancePattern.DaytimeWorkHours:
                case AttendancePattern.DayBlockRelease:
                case AttendancePattern.Evening:
                    return true;
                default:
                    return false;
            }
        }

        [Display(Name = "Course name")]
        [Required(ErrorMessage = "Enter a course name")]
        public string SubjectKeyword { get; set; }
        [Display(Name = "Postcode")]
        [RegularExpression(@"([a-zA-Z][0-9]|[a-zA-Z][0-9][0-9]|[a-zA-Z][a-zA-Z][0-9]|[a-zA-Z][a-zA-Z][0-9][0-9]|[a-zA-Z][0-9][a-zA-Z]|[a-zA-Z][a-zA-Z][0-9][a-zA-Z]) ([0-9][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ])", ErrorMessage = _locationError)]
        public string Location { get; set; }
        public bool LocationHasError { get; set; }
        public string LocationError => _locationError;

        public RadiusDistance LocationRadius { get; set; }
        public string SortyBy { get; set; }
        public int StartNo { get; set; }
        public int EndNo { get; set; }
        public int NoOfRecords { get; set; }
        public int PageNo { get; set; }
        public int NoOfPages { get; set; }
        public int PerPage { get; set; }
        public List<CourseSearchResultItemViewModel> Items { get; set; }
        public int[] StudyModes { get; set; }
        public int[] AttendanceModes { get; set; }
        public int[] AttendancePatterns { get; set; }
    }
}

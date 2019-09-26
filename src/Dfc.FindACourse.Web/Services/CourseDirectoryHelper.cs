using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Web.Interfaces;

namespace Dfc.FindACourse.Web.Services
{
    public class CourseDirectoryHelper : ICourseDirectoryHelper
    {
        public IFileHelper FileHelper { get; }

        public CourseDirectoryHelper(IFileHelper fileHelper)
        {
            FileHelper = fileHelper;
        }

        public List<string> QualificationLevels(ICourseSearchRequestModel requestModel)
        {
            var qualificationLevels = new List<string>();

            if (!HasQualificationLevels(requestModel)) return qualificationLevels;

            var levelsFromFile = FileHelper.LoadQualificationLevels();

            requestModel.QualificationLevels.ToList()
                .ForEach(
                    x =>
                    {
                        var m = levelsFromFile.FirstOrDefault(y => y.Key.ToString() == x.ToString());
                        if (m != null)
                        {
                            qualificationLevels.Add(m.Key);
                        }
                    }
                );

            return qualificationLevels.Count() == 9 ? new List<string>() : qualificationLevels;
        }

        public bool HasQualificationLevels(ICourseSearchRequestModel requestModel)
        {
            return requestModel.QualificationLevels != null && requestModel.QualificationLevels.Length > 0;
        }

        public List<string> StudyModes (ICourseSearchRequestModel requestModel)
        {
            var paramStudyModes = new List<string>();
            
            //If we have study modes int array in the model then create the List<StudyModes> 
            if (requestModel.StudyModes == null || requestModel.StudyModes.Length <= 0) return paramStudyModes;

            var allStudyModes = new StudyModes().StudyModesList;

            requestModel.StudyModes.ToList()
                .ForEach(
                    x =>
                    {
                        var m = allStudyModes.FirstOrDefault(y => y.Key.ToString() == x.ToString());
                        if (m != null)
                        {
                            paramStudyModes.Add(m.Key.ToString());
                        }
                    }
                );

            return paramStudyModes.Count() == 3 ? new List<string>() : paramStudyModes;
        }

        public IEnumerable<string> GetMissSpellings(string search, XmlDocument searchTerms, XmlNodeList expansionNodes)
        {
            if (searchTerms == null)
                throw new ArgumentException($"{nameof(searchTerms)} cannot be null.");
            if (expansionNodes == null)
                throw new ArgumentException($"{nameof(expansionNodes)} cannot be null.");

            //now check for common misspellings
            foreach (XmlNode replacement in searchTerms.GetElementsByTagName("replacement"))
            {
                foreach (XmlNode pat in replacement.SelectNodes(".//pat"))
                {
                    //if the pat node has the search text return all sub nodes
                    if (pat.InnerText.Contains(search))
                    {
                        foreach (XmlNode replacementSub in replacement.SelectNodes(".//sub"))
                        {
                            yield return replacementSub.InnerText;
                            foreach (var p in GetMatches(replacementSub.InnerText, expansionNodes))
                                yield return p;

                           
                        }
                    }
                }
            }
        }

        public IEnumerable<string> GetMatches(string search, XmlNodeList expansionNodes)
        {
            if (expansionNodes == null)
                throw new ArgumentException($"{nameof(expansionNodes)} cannot be null.");

            foreach (XmlNode expansion in expansionNodes)
            {
                var subs = expansion.SelectNodes(".//sub");

                var found = false;
                foreach (XmlNode sub in subs)
                    //if the child node has the search text then break out and add all elements of the expansion to the results
                    if (sub.InnerText.Contains(search))
                        found = true;

                if (!found) continue;
                {
                    foreach (XmlNode sub in subs)
                        yield return sub.InnerText;
                }
            }
        }

        public List<string> AttendanceModes(ICourseSearchRequestModel requestModel)
        {
            var synonymousModes = new AttendanceMode[]
            {
                AttendanceMode.DistanceWithAttendance,
                AttendanceMode.DistanceWithoutAttendence,
                AttendanceMode.OnlineWithAttendance,
                AttendanceMode.OnlineWithoutAttendence
            };

            var attendanceModes = Enum.GetValues(typeof(AttendanceMode))
                .Cast<AttendanceMode>()
                .Where(x => IsAttendanceModeDisplayable(x))
                .Cast<int>()
                .Where(x => requestModel.AttendanceModes.Contains(x))
                .Cast<AttendanceMode>()
                .ToList();

            if (attendanceModes.Any(x => synonymousModes.Contains(x)))
            {
                foreach (var synonym in synonymousModes)
                {
                    if (!attendanceModes.Contains(synonym))
                    {
                        attendanceModes.Add(synonym);
                    }
                }
            }

            var list = new List<string>();

            foreach (var attendanceMode in attendanceModes)
            {
                list.Add(GetAttendanceModeSearchString(attendanceMode));
            }

            return list.Count() == 6 ? new List<string>() : list;
        }

        public bool IsAttendanceModeDisplayable(AttendanceMode attendanceMode)
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

        public string GetAttendanceModeSearchString(AttendanceMode attendanceMode)
        {
            var result = "AM9";

            switch (attendanceMode)
            {
                case AttendanceMode.LocationCampus: result = "AM1"; break;
                case AttendanceMode.FaceToFace: result = "AM2"; break;
                case AttendanceMode.WorkBased: result = "AM3"; break;
                case AttendanceMode.MixedMode: result = "AM4"; break;
                case AttendanceMode.DistanceWithAttendance: result = "AM5"; break;
                case AttendanceMode.DistanceWithoutAttendence: result = "AM6"; break;
                case AttendanceMode.OnlineWithAttendance: result = "AM7"; break;
                case AttendanceMode.OnlineWithoutAttendence: result = "AM8"; break;
                case AttendanceMode.NotKnown: result = "AM9"; break;
            }

            return result;
        }

        public List<string> AttendancePatterns(ICourseSearchRequestModel requestModel)
        {
            var synonymousModes = new AttendancePattern[]
            {
                AttendancePattern.Evening,
                AttendancePattern.Twilight,
                AttendancePattern.Weekend
            };

            var attendancePatterns = Enum.GetValues(typeof(AttendancePattern))
                .Cast<AttendancePattern>()
                .Where(x => IsAttendancePatternDisplayable(x))
                .Cast<int>()
                .Where(x => requestModel.AttendancePatterns.Contains(x))
                .Cast<AttendancePattern>()
                .ToList();

            if (attendancePatterns.Any(x => synonymousModes.Contains(x)))
            {
                foreach (var synonym in synonymousModes)
                {
                    if (!attendancePatterns.Contains(synonym))
                    {
                        attendancePatterns.Add(synonym);
                    }
                }
            }

            var list = new List<string>();

            foreach (var attendancePattern in attendancePatterns)
            {
                list.Add(GetAttendancePatternSearchString(attendancePattern));
            }

            return list.Count() == 5 ? new List<string>() : list;
        }

        public bool IsAttendancePatternDisplayable(AttendancePattern attendancePattern)
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

        public string GetAttendancePatternSearchString(AttendancePattern attendancePattern)
        {
            var result = "AP8";

            switch (attendancePattern)
            {
                case AttendancePattern.DaytimeWorkHours: result = "AP1"; break;
                case AttendancePattern.DayBlockRelease: result = "AP2"; break;
                case AttendancePattern.Evening: result = "AP3"; break;
                case AttendancePattern.Twilight: result = "AP4"; break;
                case AttendancePattern.Weekend: result = "AP5"; break;
                case AttendancePattern.Customised: result = "AP6"; break;
                case AttendancePattern.NotKnown: result = "AP7"; break;
                case AttendancePattern.NotApplicable: result = "AP8"; break;
            }

            return result;
        }

        public SortBy GetSortBy(int value)
        {
            if (value == 1) return SortBy.Distance;

            return SortBy.Relevance;
        }
    }
}
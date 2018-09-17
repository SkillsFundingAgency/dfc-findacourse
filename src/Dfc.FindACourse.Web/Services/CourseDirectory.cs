using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dfc.FindACourse.Web.Services
{
    public class CourseDirectory : ICourseDirectory
    {
        public IFileHelper FileHelper { get; }
        public ICourseDirectoryHelper CourseDirectoryHelper { get; }

        public CourseDirectory(IFileHelper fileHelper, ICourseDirectoryHelper courseDirectoryHelper)
        {
            FileHelper = fileHelper;
            CourseDirectoryHelper = courseDirectoryHelper;
        }

        public IEnumerable<SelectListItem> GetQualificationLevels()
        {
            var searchTerms = FileHelper.LoadQualificationLevels();
            var roles = searchTerms
                .Where(y => y.Display)
                .Select(x =>
                    new SelectListItem
                    {
                        Value = x.Key,
                        Text = x.Text
                    }
                );

            return new SelectList(roles, "Value", "Text");
        }

        /// <summary>
        /// Load the XML Document from a relative path and cache the serialized model for searching
        /// Match the search parm to those in the file
        /// Correct for common misspellings and re-apply search with those
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<string> AutoSuggestCourseName(string search)
        {
            var searchTerms = FileHelper.LoadSynonyms();
            var expansionNodes = searchTerms.GetElementsByTagName("expansion");

            foreach (var p in CourseDirectoryHelper.GetMatches(search, expansionNodes)) yield return p;

            if (search.Length <= 2) yield break;

            foreach (var p1 in CourseDirectoryHelper.GetMissSpellings(search, searchTerms, expansionNodes)) yield return p1;
        }


        public ICourseSearchCriteria CreateCourseSearchCriteria(ICourseSearchRequestModel requestModel)
        {
            return new CourseSearchCriteria (
                requestModel.SubjectKeyword,
                CourseDirectoryHelper.QualificationLevels(requestModel),
                requestModel.Location,
                requestModel.LocationRadius,
                requestModel.IsDfe1619Funded,
                CourseDirectoryHelper.StudyModes(requestModel)
            );
        }

        public bool IsSuccessfulResult<T>(IResult<T> result, ITelemetryClient telemetryClient,
            string methodName, string value, DateTime dtStart)
        {
            if (result.HasValue && result.IsSuccess && !result.IsFailure)
            {
                //ASB TODO This is never used? I am commenting it out.
                //var regionsOnly = result.Value.Items.Where(x => x.Opportunity.HasRegion);
                telemetryClient.TrackEvent(
                    $"{methodName} for: {value} took: {(DateTime.Now - dtStart).TotalMilliseconds.ToString()} ms.");
            }
            else
            {
                telemetryClient.TrackEvent($"{methodName}: Invalid.");
                return false;
            }

            return true;
        }

    }
}

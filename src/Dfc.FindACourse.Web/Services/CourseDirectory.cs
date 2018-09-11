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
        public IFileHelper Files { get; }

        public CourseDirectory(IFileHelper fileHelper)
        {
            Files = fileHelper;
        }

        public IEnumerable<SelectListItem> GetQualificationLevels()
        {
            var searchTerms = Files.LoadQualificationLevels();
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
            var searchTerms = Files.LoadSynonyms();
            var expansionNodes = searchTerms.GetElementsByTagName("expansion");

            foreach (var p in GetMatches(search, expansionNodes)) yield return p;

            if (search.Length <= 2) yield break;

            foreach (var p1 in GetMissSpellings(search, searchTerms, expansionNodes)) yield return p1;

        }

        private static IEnumerable<string> GetMissSpellings(string search, XmlDocument searchTerms, XmlNodeList expnData)
        {
            bool found;
//now check for common misspellings
            foreach (XmlNode nRepData in searchTerms.GetElementsByTagName("replacement"))
            {
                foreach (XmlNode nPatdata in nRepData.SelectNodes(".//pat"))
                {
                    //if the pat node has the search text return all sub nodes
                    if (nPatdata.InnerText.ToUpper().Contains(search))
                    {
                        foreach (XmlNode nSubRepdata in nRepData.SelectNodes(".//sub"))
                        {
                            yield return nSubRepdata.InnerText;
                            foreach (XmlNode nData in expnData)
                            {
                                XmlNodeList oNode = nData.SelectNodes(".//sub");

                                found = false;
                                foreach (XmlNode nChilddata in oNode)
                                    //if the child node has the search text then break out and add all elements of the expansion to the results too
                                    if (nChilddata.InnerText.Contains(nSubRepdata.InnerText))
                                        found = true;

                                if (found)
                                    foreach (XmlNode nChilddata in oNode)
                                        yield return nChilddata.InnerText;
                            }
                        }
                    }
                }
            }
        }

        private static IEnumerable<string> GetMatches(string search, XmlNodeList expnData)
        {
            bool found;
            foreach (XmlNode nData in expnData)
            {
                XmlNodeList oNode = nData.SelectNodes(".//sub");

                found = false;
                foreach (XmlNode nChilddata in oNode)
                    //if the child node has the search text then break out and add all elements of the expansion to the results
                    if (nChilddata.InnerText.Contains(search))
                        found = true;

                if (found)
                    foreach (XmlNode nChilddata in oNode)
                        yield return nChilddata.InnerText;
            }
        }


        public ICourseSearchCriteria CreateCourseSearchCriteria(ICourseSearchRequestModel requestModel, ICourseDirectoryHelper helper)
        {
            return new CourseSearchCriteria(
                requestModel.SubjectKeyword,
                helper.QualificationLevels(requestModel, Files),
                requestModel.Location,
                requestModel.LocationRadius,
                requestModel.IsDfe1619Funded,
                helper.StudyModes(requestModel)
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

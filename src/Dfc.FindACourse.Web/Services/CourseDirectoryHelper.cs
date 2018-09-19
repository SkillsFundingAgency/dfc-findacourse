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

        public List<QualLevel> QualificationLevels(ICourseSearchRequestModel requestModel)
        {
            var qualificationLevels = new List<QualLevel>();

            if (!HasQualificationLevels(requestModel)) return qualificationLevels;

            var levelsFromFile = FileHelper.LoadQualificationLevels();

            requestModel.QualificationLevels.ToList()
                .ForEach(
                    x =>
                    {
                        var m = levelsFromFile.FirstOrDefault(y => y.Key.ToString() == x.ToString());
                        if (m != null)
                        {
                            qualificationLevels.Add(m);
                        }
                    }
                );

            return qualificationLevels;
        }

        public bool HasQualificationLevels(ICourseSearchRequestModel requestModel)
        {
            return requestModel.QualificationLevels != null && requestModel.QualificationLevels.Length > 0;
        }

        public List<StudyModeExt> StudyModes (ICourseSearchRequestModel requestModel)
        {
            var paramStudyModes = new List<StudyModeExt>();
            
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
                            paramStudyModes.Add(m);
                        }
                    }
                );

            return paramStudyModes;
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

    }
}
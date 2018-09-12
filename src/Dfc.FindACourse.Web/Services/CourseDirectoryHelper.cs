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
        public List<QualLevel> QualificationLevels(ICourseSearchRequestModel requestModel, IFileHelper files)
        {
            var qualificationLevel = -1;
            var parmQualLevels = new List<QualLevel>();
            if (!string.IsNullOrEmpty(requestModel.QualificationLevel)) int.TryParse(requestModel.QualificationLevel, out qualificationLevel);
            //Pass in the Qual Level from Query on first page and check model from second page
            if (qualificationLevel > -1 ||
                (requestModel.QualificationLevels != null && requestModel.QualificationLevels.Length > 0))
            {
                var allQualLevels = files.LoadQualificationLevels();
                requestModel.QualificationLevels = new int[] { qualificationLevel };
                //Now Populate parmQualLevels values from int array
                requestModel.QualificationLevels.ToList().ForEach(
                    q => parmQualLevels.Add(
                        allQualLevels.Where(x => x.Key == q.ToString()).FirstOrDefault()));
            }

            return parmQualLevels;
        }

        public int GetQualificationLevel(string qualificationLevel)
        {
            var level = -1;
            if (!string.IsNullOrEmpty(qualificationLevel))
                int.TryParse(qualificationLevel, out level);
            return level;
        }

        public List<StudyModeExt> StudyModes (ICourseSearchRequestModel requestModel)
        {
            var paramStudyModes = new List<StudyModeExt>();
            
            //If we have study modes int array in the model then create the List<StudyModes> 
            if (requestModel.StudyModes != null && requestModel.StudyModes.Length > 0)
            {
                var allStudyModes = new StudyModes().StudyModesList;
                //Now Populate StudyModes values from int array
                requestModel.StudyModes.ToList().ForEach(
                    q => paramStudyModes.Add(allStudyModes.
                        Where(x => x.Key.ToString() == q.ToString()).FirstOrDefault()));
            }

            return paramStudyModes;
        }

        public IEnumerable<string> GetMissSpellings(string search, XmlDocument searchTerms, XmlNodeList expnData)
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

        public IEnumerable<string> GetMatches(string search, XmlNodeList expnData)
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

    }
}
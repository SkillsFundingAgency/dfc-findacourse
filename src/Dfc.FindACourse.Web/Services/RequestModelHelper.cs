using System.Collections.Generic;
using System.Linq;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.RequestModels;

namespace Dfc.FindACourse.Web.Services
{
    public class RequestModelHelper : IRequestModelHelper
    {
        //ASB TODO Move into an Interface/Class implementation and inject into CourseDirectory.
        public List<QualLevel> QualificationLevels(ICourseSearchRequestModel requestModel, IFileHelper files)
        {
            var qualificationLevel = -1;
            var parmQualLevels = new List<QualLevel>();
            if (!string.IsNullOrEmpty(requestModel.QualificationLevel)) int.TryParse(requestModel.QualificationLevel, out qualificationLevel);
            //Pass in the Qual Level from Query on first page and check model from second page
            if (qualificationLevel > -1 || (requestModel.QualificationLevels != null && requestModel.QualificationLevels.Length > 0))
            {
                var allQualLevels = files.LoadQualificationLevels();
                requestModel.QualificationLevels = new int[] { qualificationLevel };
                //Now Populate parmQualLevels values from int array
                requestModel.QualificationLevels.ToList().ForEach(
                    q => parmQualLevels.Add(
                        allQualLevels.
                            Where(x => x.Key == q.ToString()).FirstOrDefault()));
            }

            return parmQualLevels;
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

    }
}
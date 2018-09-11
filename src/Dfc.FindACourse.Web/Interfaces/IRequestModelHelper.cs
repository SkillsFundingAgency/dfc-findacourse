using System.Collections.Generic;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;

namespace Dfc.FindACourse.Web.Interfaces
{
    public interface IRequestModelHelper
    {
        List<QualLevel> QualificationLevels(ICourseSearchRequestModel requestModel, IFileHelper files);
        List<StudyModeExt> StudyModes(ICourseSearchRequestModel requestModel);
    }
}
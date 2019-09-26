using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IQualification
    {
        
        string LearnAimRef { get; }
        string LearnAimRefTitle { get; }
        string NotionalNVQLevelv2 { get; }
        string AwardOrgCode { get; }
        string LearnDirectClassSystemCode1 { get; }
        string LearnDirectClassSystemCode2 { get; }
        string GuidedLearningHours { get; }
        string TotalQualificationTime { get; }
        string UnitType { get; }
        string AwardOrgName { get; }
        string LearnAimRefTypeDesc { get; }
        DateTime? CertificationEndDate { get; }
        string SectorSubjectAreaTier1Desc { get; }
        string SectorSubjectAreaTier2Desc { get; }
        string AwardOrgAimRef { get; }
        
    }
}

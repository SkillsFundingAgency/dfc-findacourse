using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IFindACourseDetail
    {
        Guid Id { get; }
        int? CourseId { get; }
        string QualificationCourseTitle { get; }
        string LearnAimRef { get; }
        string NotionalNVQLevelv2 { get; }
        string AwardOrgCode { get; }
        string QualificationType { get; }
        int ProviderUKPRN { get; }
        string CourseDescription { get; }
        string EntryRequirements { get; }
        string WhatYoullLearn { get; }
        string HowYoullLearn { get; }
        string WhatYoullNeed { get; }
        string HowYoullBeAssessed { get; }
        string WhereNext { get; }
        bool AdultEducationBudget { get; set; }
        bool AdvancedLearnerLoan { get; }
        IEnumerable<IFindACourseRun> FindACourseRuns { get; }
        
    }
}

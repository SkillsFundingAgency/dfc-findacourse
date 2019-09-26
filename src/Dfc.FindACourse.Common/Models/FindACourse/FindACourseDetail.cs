using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models.FindACourse
{
    public class FindACourseDetail: IFindACourseDetail
    {
        public Guid Id { get; }
        public int? CourseId { get; }
        public string QualificationCourseTitle { get; }
        public string LearnAimRef { get; }
        public string NotionalNVQLevelv2 { get; }
        public string AwardOrgCode { get; }
        public string QualificationType { get; }
        public int ProviderUKPRN { get; }
        public string CourseDescription { get; }
        public string EntryRequirements { get; }
        public string WhatYoullLearn { get; }
        public string HowYoullLearn { get; }
        public string WhatYoullNeed { get; }
        public string HowYoullBeAssessed { get; }
        public string WhereNext { get; }
        public bool AdultEducationBudget { get; set; }
        public bool AdvancedLearnerLoan { get; }
        public IEnumerable<IFindACourseRun> FindACourseRuns { get; }

        public FindACourseDetail(Guid id, int? courseId, string qualificationCourseTitle, string learnAimRef, string notionalNVQLevelv2,
            string awardOrgCode, string qualificationType, int providerUKPRN, string courseDescription, string entryRequirements,
            string whatYoullLearn, string howYoullLearn, string whatYoullNeed, string howYoullBeAssessed, string whereNext, bool adultEducationBudget, bool advancedLearnerLoan,
            IEnumerable<IFindACourseRun> findACourseRuns)
        {
            Id = id;
            CourseId = courseId;
            QualificationCourseTitle = qualificationCourseTitle;
            LearnAimRef = learnAimRef;
            NotionalNVQLevelv2 = notionalNVQLevelv2;
            AwardOrgCode = awardOrgCode;
            QualificationType = qualificationType;
            ProviderUKPRN = providerUKPRN;
            CourseDescription = courseDescription;
            EntryRequirements = entryRequirements;
            WhatYoullLearn = whatYoullLearn;
            HowYoullBeAssessed = howYoullBeAssessed;
            WhereNext = whereNext;
            AdultEducationBudget = adultEducationBudget;
            AdvancedLearnerLoan = advancedLearnerLoan;
            FindACourseRuns = findACourseRuns;

        }
    }
}

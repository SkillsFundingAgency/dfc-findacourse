using Dfc.FindACourse.Common.Interfaces;
using System;

namespace Dfc.FindACourse.Common.Models
{
    public class Course : ICourse
    {
        public int Id { get; }
        public string Title { get; }
        public QualificationLevel QualificationLevel { get; }

        public Course(
            int id,
            string title,
            QualificationLevel qualificationLevel)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException($"{nameof(title)} cannot be null, empty or only whitespace.");
            if (!Enum.IsDefined(typeof(QualificationLevel), qualificationLevel))
                throw new ArgumentOutOfRangeException(nameof(qualificationLevel));

            Id = id;
            Title = title;
            QualificationLevel = qualificationLevel;
        }
    }
}
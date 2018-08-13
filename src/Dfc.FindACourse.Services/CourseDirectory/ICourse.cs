using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface ICourse
    {
        int Id { get; }
        string Title { get; }
        QualificationLevel QualificationLevel { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IDescriptionDate
    {
        DateTime? Date { get; }
        string Description { get; }
    }
}

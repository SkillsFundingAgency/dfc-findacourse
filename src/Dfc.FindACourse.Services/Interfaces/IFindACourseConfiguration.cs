using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.Interfaces
{
    public interface IFindACourseConfiguration
    {
        string ApiKey { get; }
        int PerPage { get; }
        string ApiAddress { get; }
        string UserName { get; }
        string Password { get; }
    }
}

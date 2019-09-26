using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    /// <summary>
    /// Interface to define the Course, Provider, Venue and Qualification details returned from a courseget request
    /// </summary>
    public interface IFindACourseItemDetail
    {
        IFindACourseDetail FindACourseDetail { get; }
        IProvider Provider { get; }
        IVenue Venue { get; }


    }
}

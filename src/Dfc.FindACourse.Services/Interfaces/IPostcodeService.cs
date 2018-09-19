using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Services.Interfaces
{
    public interface IPostcodeService : IDisposable
    {
        Task<IResult<bool>> IsValidAsync(string postcode);
    }
}

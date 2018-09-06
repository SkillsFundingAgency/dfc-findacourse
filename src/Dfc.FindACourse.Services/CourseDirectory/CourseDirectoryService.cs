﻿using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tribal;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class CourseDirectoryService : ICourseDirectoryService
    {
        private ICourseDirectoryServiceConfiguration _configuration;

        public CourseDirectoryService(ICourseDirectoryServiceConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IResult<CourseSearchResult> CourseSearch(ICourseSearchCriteria criteria, IPagingOptions options)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            try
            {
                var client = new ServiceInterfaceClient();

                var searchCriteria = new SearchCriteriaStructure()
                {
                    APIKey = _configuration.ApiKey,
                    SubjectKeyword = criteria.SubjectKeyword


                };
                //Set up Qual Levels
                if (criteria.QualificationLevels.Count > 0)
                        searchCriteria.QualificationLevels = criteria.QualificationLevels.Select(x => x.Level).ToArray();
                //Add Location
                if (!string.IsNullOrEmpty(criteria.TownOrPostcode))
                        searchCriteria.Location = criteria.TownOrPostcode;
                //And then distance (Always set so add check on TownOrPostcode)
                if (criteria.Distance.HasValue && !string.IsNullOrEmpty(criteria.TownOrPostcode))
                        searchCriteria.Distance = criteria.Distance.Value;
                //Add DFEFunded
                if (criteria.IsDfe1619Funded.HasValue)
                    searchCriteria.DFE1619Funded = criteria.IsDfe1619Funded.Value ? "Y": "N";
                //study modes
                //if (criteria.StudyModes.Count > 0)
                //    searchCriteria.StudyModes = criteria.StudyModes.Select(x => x.ToString)

                 var request = new CourseListRequestStructure()
                {
                    CourseSearchCriteria = searchCriteria,
                    SortBy = options.SortBy.ToSortType(),
                    SortBySpecified = true,
                    PageNo = options.PageNo.ToString(),
                    RecordsPerPage = _configuration.PerPage.ToString()
                };

                var task = client.CourseListAsync(request);
                Task.WaitAll(task);
                var taskResult = task.Result;

                int noOfPages = int.TryParse(taskResult.CourseListResponse.ResultInfo.NoOfPages, out noOfPages) ? noOfPages : 0;
                int noOfRecords = int.TryParse(taskResult.CourseListResponse.ResultInfo.NoOfRecords, out noOfRecords) ? noOfRecords : 0;
                int pageNo = int.TryParse(taskResult.CourseListResponse.ResultInfo.PageNo, out pageNo) ? pageNo : 0;

                if (taskResult.CourseListResponse.CourseDetails == null)
                {
                    var courseSearchResult = new CourseSearchResult(
                        noOfPages,
                        noOfRecords,
                        pageNo,
                        new CourseItem[] { });

                    return Result.Ok(courseSearchResult);
                }

                var courseItems = taskResult
                    .CourseListResponse
                    .CourseDetails
                    .Select(x => new CourseItem(
                        x.Course.ToCourse(),
                        x.Opportunity.ToOpportunity(),
                        x.Provider.ToProvider()));

                return Result.Ok(new CourseSearchResult(
                    noOfPages,
                    noOfRecords,
                    pageNo,
                    courseItems));
            }
            catch (Exception e)
            {
                return Result.Fail<CourseSearchResult>(e.Message);
            }
        }
    }
}
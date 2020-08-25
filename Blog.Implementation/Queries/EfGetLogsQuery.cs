using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Search;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetLogsQuery : IGetLogQuery
    {
        private readonly BlogContext _context;

        public EfGetLogsQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 32;

        public string Name => "Get Logs";

        public PagedResponse<LogsDto> Execute(LogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            #region Filters
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            if (search.MinDate != null)
            {
                query = query.Where(x => x.Date >= search.MinDate);
            }

            if (search.MaxDate != null)
            {
                query = query.Where(x => x.Date <= search.MaxDate);
            }

           
            #endregion

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<LogsDto>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Items = query.Skip(skipCount)
                             .Take(search.PerPage)
                             .Select(l => new LogsDto
                             {
                                 Id = l.Id,
                                 Date = l.Date,
                                 Name = l.Name,
                                 Actor = l.Actor,
                                 Data = l.Data
                             })
            };

            return response;
        }
    }
}

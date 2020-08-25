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
	public class EfGetCategoriesQuery : IGetCategoriesQuery
	{
		private readonly BlogContext _context;

		public EfGetCategoriesQuery(BlogContext context)
		{
			_context = context;
		}

		public int Id => 4;

		public string Name => "Categories search.";

		public PagedResponse<CategoriesDto> Execute(CategoriesSearch search)
		{
			var query = _context.Categories.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}

			query = query.Where(x => x.IsActive == true);

			var skipCount = search.PerPage * (search.Page - 1);

			var response = new PagedResponse<CategoriesDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoriesDto
				{
					Id   = x.Id,
					Name = x.Name
				}).ToList()
			};

			return response;
		}
	}
}

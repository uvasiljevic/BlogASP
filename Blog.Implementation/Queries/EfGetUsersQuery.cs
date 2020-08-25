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
	public class EfGetUsersQuery : IGetUsersQuery
	{
		private readonly BlogContext _context;

		public EfGetUsersQuery(BlogContext context)
		{
			_context = context;
		}

		public int Id => 8;

		public string Name => "Users search.";

		public PagedResponse<UsersDto> Execute(UsersSearch search)
		{
			var query = _context.Users.AsQueryable();

			if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
			{
				query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
			}

			if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
			{
				query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
			}

			query = query.Where(x => x.IsActive == true);

			var skipCount = search.PerPage * (search.Page - 1);

			var response = new PagedResponse<UsersDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UsersDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					LastName  = x.LastName,
					Email     = x.Email

				}).ToList()
			};

			return response;
		}
	}
}

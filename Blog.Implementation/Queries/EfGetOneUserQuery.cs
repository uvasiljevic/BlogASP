using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Application.Queries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Queries
{
	public class EfGetOneUserQuery : IGetOneUserQuery
	{
		protected readonly BlogContext _context;

		public EfGetOneUserQuery(BlogContext context)
		{
			_context = context;
		}

		public int Id => 9;

		public string Name => "Get one user";

		public UsersDto Execute(int search)
		{
			var category = _context.Users.Find(search);

			if (category == null)
			{
				throw new NotFoundEntityException(search, typeof(Users));
			}

			var result = new UsersDto
			{
				Id = category.Id,
				FirstName = category.FirstName,
				LastName = category.LastName,
				Email = category.Email

			};

			return result;
		}
	}
}

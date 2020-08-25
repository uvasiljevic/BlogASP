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
    public class EfGetOneCategoryQuery : IGetOneCategoryQuery
	{
		protected readonly BlogContext _context;

		public EfGetOneCategoryQuery(BlogContext context)
		{
			_context = context;
		}

		public int Id => 5;

		public string Name => "Get one category";

		public CategoriesDto Execute(int search)
		{
			var category = _context.Categories.Find(search);

			if (category == null)
			{
				throw new NotFoundEntityException(search, typeof(Categories));
			}

			var result = new CategoriesDto
			{
				Id = category.Id,
				Name = category.Name
			};

			return result;
		}
}
}

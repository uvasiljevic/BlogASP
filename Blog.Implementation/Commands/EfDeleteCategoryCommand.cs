using Blog.Application.Commands;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
		private readonly BlogContext _context;
		public EfDeleteCategoryCommand(BlogContext context)
		{
			_context = context;
			
		}
		public int Id => 3;

        public string Name => "Delete category";

		public void Execute(int id)
		{
			var category = _context.Categories.Find(id);

			if (category == null)
			{
				throw new NotFoundEntityException(id, typeof(Categories));
			}

			category.DeletedAt = DateTime.Now;
			category.IsActive = false;
			category.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}

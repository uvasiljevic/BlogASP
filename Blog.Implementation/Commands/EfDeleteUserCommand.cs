using Blog.Application.Commands;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
	{
		private readonly BlogContext _context;
		public EfDeleteUserCommand(BlogContext context)
		{
			_context = context;

		}
		public int Id => 7;

		public string Name => "Delete user";

		public void Execute(int id)
		{
			var category = _context.Users.Find(id);

			if (category == null)
			{
				throw new NotFoundEntityException(id, typeof(Users));
			}

			category.DeletedAt = DateTime.Now;
			category.IsActive = false;
			category.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}

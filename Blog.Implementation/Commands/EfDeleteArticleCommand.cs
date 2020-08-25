using Blog.Application.Commands;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteArticleCommand : IDeleteArticleCommand
    {
		private readonly BlogContext _context;
		public EfDeleteArticleCommand(BlogContext context)
		{
			_context = context;

		}
		public int Id => 12;

		public string Name => "Delete article";

		public void Execute(int id)
		{
			var article = _context.Articles.Find(id);

			if (article == null)
			{
				throw new NotFoundEntityException(id, typeof(Articles));
			}

			article.DeletedAt = DateTime.Now;
			article.IsActive = false;
			article.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}

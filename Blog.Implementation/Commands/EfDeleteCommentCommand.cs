using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
	{
		private readonly BlogContext _context;
		private readonly IApplicationActor _actor;
        public EfDeleteCommentCommand(BlogContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 15;

		public string Name => "Delete comment";

		public void Execute(int id)
		{
			var comment = _context.Comments.Find(id);
			if (comment.UserId != _actor.Id)
			{
				throw new UnauthorizedUseCaseException(this, _actor);
			}
			if (comment == null)
			{
				throw new NotFoundEntityException(id, typeof(Comments));
			}

			comment.DeletedAt = DateTime.Now;
			comment.IsActive = false;
			comment.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}

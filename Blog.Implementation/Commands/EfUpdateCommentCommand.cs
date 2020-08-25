using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly BlogContext _context;
        private readonly UpdateCommentValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateCommentCommand(BlogContext context, UpdateCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 14;

        public string Name => "Update Comment";

        public void Execute(UpdateCommentsDto request, int id)
        {
            _validator.ValidateAndThrow(request);

            var comment = _context.Comments.Find(id);
            if (comment.UserId != _actor.Id)
            {
                throw new UnauthorizedUseCaseException(this, _actor);
            }
            if (comment == null)
            {
                throw new NotFoundEntityException(id, typeof(Comments));
            }
            comment.Subject = request.Subject;
            comment.Text = request.Text;
            comment.ArticleId = request.ArticleId;
            comment.UserId = _actor.Id;

            _context.SaveChanges();
        }
    }
}

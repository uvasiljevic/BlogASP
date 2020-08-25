using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly BlogContext _context;
        private readonly CreateCommentValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateCommentCommand(BlogContext context, CreateCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 20;

        public string Name => "Create Comment";

        public void Execute(CommentsDto request)
        {

            _validator.ValidateAndThrow(request);

            var comment = new Comments
            {
                Subject = request.Subject,
                Text = request.Text,
                ArticleId = request.ArticleId,
                UserId = _actor.Id
            };

            

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}

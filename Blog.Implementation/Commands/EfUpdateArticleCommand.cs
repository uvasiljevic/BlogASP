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
    public class EfUpdateArticleCommand : IUpdateArticleCommand
    {
        private readonly BlogContext _context;
        private readonly UpdateArticleValidator _validator;

        public EfUpdateArticleCommand(BlogContext context, UpdateArticleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Update Article";

        public void Execute(ArticlesDto request, int id)
        {
            _validator.ValidateAndThrow(request);

            var article = _context.Articles.Find(id);
            if (article == null)
            {
                throw new NotFoundEntityException(id, typeof(Articles));
            }
            article.Subject     = request.Subject;
            article.Text        = request.Text;
            article.Description = request.Description;

            _context.SaveChanges();
        }
    }
}

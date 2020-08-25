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
    public class EfCreateArticleCommand : ICreateArticleCommand
    {
        private readonly BlogContext _context;
        private readonly CreateArticleValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateArticleCommand(BlogContext context, CreateArticleValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 10;

        public string Name => "Create Article";

        public void Execute(CreateArticleDto request)
        {

            _validator.ValidateAndThrow(request);

            var article = new Articles
            {
                Subject = request.Subject,
                Description = request.Description,
                Text = request.Text,
                UserId = _actor.Id
            };

            //ArticlesCategories
            foreach (var item in request.ArticleCategories)
            {
                article.ArticleCategories.Add(new ArticleCategories
                {
                    ArticleId = article.Id,
                    CategoryId = item.CategoryId
                });
            }

            _context.Articles.Add(article);
            _context.SaveChanges();
        }
    }
}

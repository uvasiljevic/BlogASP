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
    public class EfCreateArticlesRatesCommand : ICreateAriclesRatesCommand
    {
        private readonly BlogContext _context;
        private readonly CreateArticlesRatesValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateArticlesRatesCommand(BlogContext context, CreateArticlesRatesValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 13;

        public string Name => "Add Article Rate";

        public void Execute(CreateArticlesRatesDto request)
        {

            _validator.ValidateAndThrow(request);

            var articleRate = new ArticlesRates
            {
                ArticleId = request.ArticleId,
                RateId = request.RateId,
                UserId = _actor.Id
            };

         

            _context.ArticlesRates.Add(articleRate);
            _context.SaveChanges();
        }
    }
}

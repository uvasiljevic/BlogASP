using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreateArticleValidator : AbstractValidator<CreateArticleDto>
    {
        
        public CreateArticleValidator(BlogContext context)
        {
            RuleFor(x => x.Subject)
               .NotEmpty()
               .WithMessage("Subject cannot be empty");

            RuleFor(x => x.Text)
               .NotEmpty()
               .WithMessage("Text cannot be empty");

            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("Description cannot be empty");

            RuleFor(x => x.UserId)
                .Must(userId => context.Users.Any(x => x.Id == userId))
                .WithMessage("User with an id of {PropertyValue} does not exists in db");

            RuleFor(x => x.ArticleCategories)
                .NotEmpty()
                .WithMessage("There must be at least 1 article category")
                .Must(i => i.Select(x => x.CategoryId).Distinct().Count() == i.Count())
                .WithMessage("Duplicate categories are not allowed")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.ArticleCategories)
                    .SetValidator(new CreateArticleCatregoriesValidator(context));
                }); ;
        }


    }
}
    


using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class UpdateArticleValidator : AbstractValidator<ArticlesDto>
    {

        public UpdateArticleValidator(BlogContext context)
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

           
        }
    }
}

using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentsDto>
    {

        public UpdateCommentValidator(BlogContext context)
        {
            RuleFor(x => x.Subject)
               .NotEmpty()
               .WithMessage("Subject cannot be empty");

            RuleFor(x => x.Text)
               .NotEmpty()
               .WithMessage("Text cannot be empty");

            RuleFor(x => x.UserId)
                .Must(userId => context.Users.Any(x => x.Id == userId))
                .WithMessage("User with an id of {PropertyValue} does not exists in db");

            RuleFor(x => x.ArticleId)
                .Must(articleId => context.Articles.Any(x => x.Id == articleId))
                .WithMessage("Article with an id of {PropertyValue} does not exists in db");


        }
    }
}

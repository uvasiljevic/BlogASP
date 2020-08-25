using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoriesDto>
    {
        public CreateCategoryValidator(BlogContext context)
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .MaximumLength(30)
                 .Must(name => !context.Categories.Any(c => c.Name==name))
                 .WithMessage("Name cannot be empty and category name can have maximum 30 caracters, or category already exists..");
        }
    }

}
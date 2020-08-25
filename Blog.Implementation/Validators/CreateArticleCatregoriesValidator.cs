using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreateArticleCatregoriesValidator : AbstractValidator<CreateArticleCategoriesDto>
    {
        private readonly BlogContext _context;

        public CreateArticleCatregoriesValidator(BlogContext context)
        {
            _context = context;

            RuleFor(x => x.CategoryId)
                .Must(CategoryExists)
                .WithMessage("Category with an id of {PropertyValue} does not exists");
                
        }

        private bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(x => x.Id == categoryId);
        }
    }
}

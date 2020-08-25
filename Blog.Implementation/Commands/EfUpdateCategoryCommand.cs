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
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly CreateCategoryValidator _validator;

        public EfUpdateCategoryCommand(BlogContext context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Update Category";

        public void Execute(CategoriesDto request, int id)
        {
            _validator.ValidateAndThrow(request);

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                throw new NotFoundEntityException(id, typeof(Categories));
            }
            category.Name = request.Name;

            _context.SaveChanges();
        }
    }
}

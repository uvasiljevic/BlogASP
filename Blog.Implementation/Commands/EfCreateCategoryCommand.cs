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
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {

        private readonly BlogContext _context;
        private readonly CreateCategoryValidator _validator;

        public EfCreateCategoryCommand(BlogContext context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create Category";

        public void Execute(CategoriesDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = new Categories
            {
                Name = request.Name,
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}

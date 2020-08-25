using Blog.Application;
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
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly BlogContext _context;
        private readonly UpdateUserValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserCommand(BlogContext context, UpdateUserValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 18;

        public string Name => "Update User";

        public void Execute(UsersDto request, int id)
        {
            _validator.ValidateAndThrow(request);

            var user = _context.Users.Find(id);
            if (user.Id != _actor.Id)
            {
                throw new UnauthorizedUseCaseException(this, _actor);
            }
            if (user == null)
            {
                throw new NotFoundEntityException(id, typeof(Users));
            }
            user.FirstName = request.FirstName;
            user.LastName  = request.LastName;
            user.Email     = request.Email;
            

            _context.SaveChanges();
        }
    }
}

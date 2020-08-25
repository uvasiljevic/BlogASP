using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Email;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly BlogContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfCreateUserCommand(BlogContext context, CreateUserValidator validator, IEmailSender sender)//
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 6;

        public string Name => "User Registration";

        public void Execute(CreateUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new Users
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email
            };

            _context.Users.Add(user);

            var useCases = new List<UserUseCases>();
            var newUseCases = new List<int> { 4,13,20,15,18,14, 4, 9, 8, 30,31 }; //ono sta sme ulogovani
            //hard kod kreiranje admina var adminUseCases = Enumerable.Range(1, 50);

            foreach (var useCase in newUseCases)
            {
                var userUseCases = new UserUseCases
                {
                    UserId = user.Id,
                    UseCaseId = useCase
                };
                useCases.Add(userUseCases);
            }

            user.UserUseCases = useCases;

            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Subject = "Registration",
                Content = "<h1>Successfull registration, you can use your email and password to log in</h1>",
                SendTo = request.Email
            });
        }
    }
}

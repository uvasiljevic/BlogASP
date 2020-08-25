using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(BlogContext context)
        {
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .EmailAddress()
                 .Must(email => !context.Users.Any(c => c.Email == email))
                 .WithMessage("Email cannot be empty or user with same email already exists...");

            RuleFor(x => x.FirstName)
                 .NotEmpty()
                 .MaximumLength(30)
                 .WithMessage("First name cannot be empty and maximum length is 30 characters...");

            RuleFor(x => x.LastName)
                 .NotEmpty()
                 .MaximumLength(30)
                 .WithMessage("Last name cannot be empty and maximum length is 30 characters...");
            RuleFor(x => x.Password)
                 .NotEmpty()
                 .WithMessage("Password is required...");

        }
    }

}

using FluentValidation;

namespace Kodlama.io.Application.Features.Users.Commands.Update
{
    public  class UpdateUserValidator :AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(c => c.FirstName).MinimumLength(4);
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).MinimumLength(5);
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).NotEmpty();
            RuleFor(c => c.Password).MinimumLength(8);


        }
    }
}

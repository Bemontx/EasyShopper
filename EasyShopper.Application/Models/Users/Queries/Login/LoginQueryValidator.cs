using EasyShopper.Application.Models.User.Queries.Login;
using FluentValidation;

public class LoginQueryValidator
    : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}

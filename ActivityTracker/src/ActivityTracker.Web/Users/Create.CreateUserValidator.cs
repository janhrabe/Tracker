using ActivityTracker.Infrastructure.Data.Config;
using FluentValidation;

namespace ActivityTracker.Web.Users;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateUserValidator : Validator<CreateUserRequest>
{
  public CreateUserValidator()
  {
    RuleFor(x => x.FullName)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}

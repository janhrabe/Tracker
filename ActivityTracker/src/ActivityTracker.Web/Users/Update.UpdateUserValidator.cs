using ActivityTracker.Infrastructure.Data.Config;
using FluentValidation;

namespace ActivityTracker.Web.Users;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateUserValidator : Validator<UpdateUserRequest>
{
  public UpdateUserValidator()
  {
    RuleFor(x => x.FullName)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.UserId)
      .Must((args, userId) => args.UserId == userId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}

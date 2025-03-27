using FluentValidation;

namespace ActivityTracker.Web.Activities;

public class UpdateActivityValidator : Validator<UpdateActivityRequest>
{
  public UpdateActivityValidator()
  {
    RuleFor(x => x.ActivityId)
       .Must((args, activityId) => args.ActivityId == activityId)
       .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
    RuleFor(x => x.Category)
      .NotEmpty()
      .WithMessage("Category is required.");
    RuleFor(x => x.Description)
      .NotEmpty()
      .WithMessage("Description is required");
  }

}


namespace ActivityTracker.Web.Activities
{
    public class DeleteActivityValidator : Validator<DeleteActivityRequest>
    {
        public DeleteActvityValidator()
        {
            RuleFor(x => x.ActivityId);

        }
    }
}


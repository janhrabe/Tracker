using ActivityTracker.UseCases.Activities;

namespace ActivityTracker.Web.Activities;

public record GetActivitiesByUserResponse(List<ActivityByUserIdDTO> Activities);


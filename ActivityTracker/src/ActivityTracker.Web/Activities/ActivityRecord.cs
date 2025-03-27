namespace ActivityTracker.Web.Activities;

public record ActivityRecord(Guid activityId, Guid projectId, Guid userId, DateTime startDate, DateTime? endDate, string category, string description);


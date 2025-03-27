namespace ActivityTracker.UseCases.Activities;
public record ActivityDTO(Guid activtiyId, Guid projectId, Guid userId, DateTime startDate, DateTime? endDate, string category, string description);

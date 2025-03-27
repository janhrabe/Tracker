namespace ActivityTracker.UseCases.Activities;

public record ActivityByUserIdDTO(Guid id, Guid projectId, DateTime startDate, DateTime? endDate, string category, string description);


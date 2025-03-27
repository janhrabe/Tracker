namespace ActivityTracker.UseCases.Activities;

public record ActivityByProjectIdDTO(Guid id, Guid userId, DateTime startDate, DateTime? endDate, string category, string description);

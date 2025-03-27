namespace ActivityTracker.Core.Entities;
public abstract class BaseEntity : IAggregateRoot
{
  public Guid Id { get; set; }

}




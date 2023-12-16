using MediatR;

namespace Bookify.Domain.Abstractions;

/// <summary>
/// This will represent all the domain events in our system.
/// </summary>
public interface IDomainEvent : INotification
{
    
}
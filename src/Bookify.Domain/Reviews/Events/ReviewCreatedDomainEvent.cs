using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
// TODO: Implement logic of the side effect/event when a Review is created
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid bookingId) : IDomainEvent;
// TODO: Implement logic of the side effect/event for Reserving a Booking
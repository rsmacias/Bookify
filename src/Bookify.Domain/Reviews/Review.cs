using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews;

public sealed class Review : Entity
{
    public Review(Guid id) : base(id)
    {
        
    }

    public Guid ApartmentId { get; private set; }
    public Guid BookingId { get; private set; }
    public Guid UserId { get; private set; }
    public Rating Rating { get; private set; }
    public Comment Comment { get; private set; }
    public DateTime CreateOnUtc { get; private set; }
}
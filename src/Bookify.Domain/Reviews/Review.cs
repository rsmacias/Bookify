using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;

namespace Bookify.Domain.Reviews;

public sealed class Review : Entity
{
    private Review(
        Guid id,
        Guid apartmentId,
        Guid bookingId,
        Guid userId,
        Rating rating,
        Comment comment,
        DateTime createOnUtc
    ) : base(id)
    {
        ApartmentId = apartmentId;
        BookingId = bookingId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreateOnUtc = createOnUtc;
    }

    public Guid ApartmentId { get; private set; }
    public Guid BookingId { get; private set; }
    public Guid UserId { get; private set; }
    public Rating Rating { get; private set; }
    public Comment Comment { get; private set; }
    public DateTime CreateOnUtc { get; private set; }

    public static Review Create(Booking booking, Guid userId, Rating rating, Comment comment, DateTime utcNow)
    {
        if (booking.Status != BookingStatus.Completed)
        {
            throw new ApplicationException("Uncompleted bookings can not be reviewed.");
        }

        var review = new Review(Guid.NewGuid(), booking.ApartmentId, booking.Id, userId, rating, comment, utcNow);

        // TODO: Raise a new Domain Event

        return  review;
    }
}
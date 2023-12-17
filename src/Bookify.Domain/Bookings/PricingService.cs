using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public class PricingService
{
    /// <summary>
    /// Calculate the price for the hosting in a particular apartment according to multiple factors like
    /// the amenities and some extra fees.
    /// </summary>
    /// <param name="apartment">Apartment booked</param>
    /// <param name="period">Duration of the hosting</param>
    /// <returns>Details of the </returns>
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        // 1.- Base price calculation
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(apartment.Price.Amount * period.LengthInDays, currency);

        // 2.- Amenities calculation
        decimal percentageUpCharge = 0;
        foreach (var amenity in apartment.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m,
                Amenity.AirConditioning => 0.01m,
                Amenity.Parking => 0.01m,
                _ => 0
            };
        }

        var amenitiesUpCharge = Money.Zero();
        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(priceForPeriod.Amount * percentageUpCharge, currency);
        }

        var totalPrice = Money.Zero(currency);

        totalPrice += priceForPeriod;

        // 3.- Cleaning fee calculation
        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpCharge;

        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}
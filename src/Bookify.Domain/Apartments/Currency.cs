namespace Bookify.Domain.Apartments;

/// <summary>
/// Value Object: Currency:
/// - Define the list of the allowed currencies to the domain.
/// - Define validation/constraints attached to the currency concept.
/// - Expose specific utility/helper akin to the currency concept.
/// </summary>
public record Currency
{
    internal static readonly Currency None = new Currency("");
    public static readonly Currency Usd = new Currency("USD");
    public static readonly Currency Eur = new Currency("EUR");

    /// <summary>
    /// This is private therefore the currency values could only be obtained from the static readonly properties.
    /// So, the allowed currencies are defined here in this record class.
    /// </summary>
    /// <param name="code"></param>
    private Currency(string code) => Code = code;

    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return  All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("The currency code is invalid");
    }

    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        Eur,
    };
}
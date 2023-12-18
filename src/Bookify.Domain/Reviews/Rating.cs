using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews;

public sealed record Rating
{
    public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");

    private Rating(int value)
    {
        Value = value;
    }

    public int Value { get; init; }
    private const int MinLimit = 1;
    private const int MaxLimit = 5;

    public static Result<Rating> Create(int value)
    {
        if (value < MinLimit || value > MaxLimit)
            return Result.Failure<Rating>(Invalid);

        return new Rating(value);
    }

    public Result<Rating> Increase() => Create(this.Value + 1);

    public Result<Rating> Decrease() => Create(this.Value - 1);
}
namespace Bookify.Domain.Reviews;

public record Comment(string Value)
{
    public static Comment NoComment => new(string.Empty);
}
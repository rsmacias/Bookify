namespace Bookify.Domain.Reviews;

public record Rating(int Value)
{
    public Rating Up() => new(this.Value + 1);

    public Rating Down() => this.Value == 0? this : new(this.Value - 1);
}
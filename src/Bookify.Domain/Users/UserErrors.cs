using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new(
        "User.NotFound",
        "The provided user does not exist.");
}
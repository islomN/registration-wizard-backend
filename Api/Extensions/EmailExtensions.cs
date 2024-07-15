using System.ComponentModel.DataAnnotations;

namespace Api.Extensions;

internal static class EmailExtensions
{
    public static bool IsEmail(this string input)
    {
        return new EmailAddressAttribute().IsValid(input);
    }
}
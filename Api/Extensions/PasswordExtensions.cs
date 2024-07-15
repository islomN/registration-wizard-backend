using Api.Helpers;

namespace Api.Extensions;

internal static class PasswordExtensions
{
    public static bool IsValidPassword(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        return input.Any(char.IsDigit) && input.Any(char.IsLetter);
    }

    public static string ToPasswordHash(this string input)
    {
        return CryptoHelper.ComputeSha256Hash(input);
    }
}
using System.Text.RegularExpressions;

public static class WordValidator
{
    public static bool IsValid(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        return Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }
}
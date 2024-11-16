namespace ReverseStringBenchmarks.StringReverseners;

public sealed class ArrayReversener : IStringReversener
{
    public string? Reverse(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var charArray = input.ToCharArray();
        Array.Reverse(charArray);

        return new string(charArray);
    }
}

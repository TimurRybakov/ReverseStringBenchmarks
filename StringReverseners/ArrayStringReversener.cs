namespace ReverseStringBenchmarks.StringReverseners;

public sealed class ArrayStringReversener : IStringReversener
{
    public string? Reverse(string? input)
    {
        if (input == null)
        {
            return null;
        }

        var charArray = input.ToCharArray();
        Array.Reverse(charArray);

        return new string(charArray);
    }
}

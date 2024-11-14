namespace ReverseStringBenchmarks.StringReverseners;

public sealed class LinqStringReversener : IStringReversener
{
    public string? Reverse(string? input)
    {
        if (input == null)
        {
            return input;
        }

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

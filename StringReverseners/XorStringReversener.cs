namespace ReverseStringBenchmarks.StringReverseners;

public sealed class XorStringReversener : IStringReversener
{
    public string? Reverse(string? input)
    {
        if (input == null)
        {
            return null;
        }

        char[] charArray = input.ToCharArray();
        int len = input.Length - 1;

        for (int i = 0; i < len; i++, len--)
        {
            charArray[i] ^= charArray[len];
            charArray[len] ^= charArray[i];
            charArray[i] ^= charArray[len];
        }

        return new string(charArray);
    }
}

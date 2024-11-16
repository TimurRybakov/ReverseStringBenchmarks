using System.Text;

namespace ReverseStringBenchmarks.StringReverseners;

internal class StringBuilderReversener : IStringReversener
{
    public string? Reverse(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        StringBuilder sb = new (input.Length);

        for (int i = input.Length; i-- != 0;)
        {
            sb.Append(input[i]);
        }

        return sb.ToString();
    }
}

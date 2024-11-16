namespace ReverseStringBenchmarks.StringReverseners;

public sealed class StackSpanReversener : IStringReversener
{
    public string? Reverse(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var len = input.Length;
        Span<char> buffer = stackalloc char[len];
        input.AsSpan().CopyTo(buffer);

        for (var i = 0; i < len / 2; i++)
        {
            (buffer[i], buffer[^(i + 1)]) = (buffer[^(i + 1)], buffer[i]);
        }

        return buffer.ToString();
    }
}

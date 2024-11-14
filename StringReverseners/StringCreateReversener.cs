namespace ReverseStringBenchmarks.StringReverseners;

public sealed class StringCreateReversener : IStringReversener
{
    public string? Reverse(string? input)
    {
        if (input == null)
        {
            return null;
        }

        return string.Create(input.Length, input, static (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars.Reverse();
        });
    }
}

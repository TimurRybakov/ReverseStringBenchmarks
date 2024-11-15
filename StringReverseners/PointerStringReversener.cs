namespace ReverseStringBenchmarks.StringReverseners;

/// <summary>
/// Warning! This method modifies input string! This violates string immutability!
/// </summary>
public sealed class PointerStringReversener : IStringReversener
{
    public unsafe string? Reverse(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        int len = input.Length;

        fixed (char* inputPtr = input)
        {
            for (int i = 0; i < len / 2; i++)
            {
                (*(inputPtr + i), *(inputPtr + len - 1 - i)) = (*(inputPtr + len - 1 - i), *(inputPtr + i));
            }
        }

        return input;
    }
}

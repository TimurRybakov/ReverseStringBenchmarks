namespace ReverseStringBenchmarks.StringReverseners;

internal class PointerStringCopyReversener : IStringReversener
{
    [Obsolete]
    public unsafe string? Reverse(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        char tmp;
        string copy = string.Copy(input);

        fixed (char* buf = copy)
        {
            char* p = buf;
            char* q = buf + input.Length - 1;

            while (p < q)
            {
                tmp = *p;
                *p = *q;
                *q = tmp;

                p++; q--;
            }
        }

        return copy;
    }
}

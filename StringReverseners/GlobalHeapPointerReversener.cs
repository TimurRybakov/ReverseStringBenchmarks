using System.Runtime.InteropServices;

namespace ReverseStringBenchmarks.StringReverseners;

internal class GlobalHeapPointerReversener : IStringReversener
{
    /// <summary>
    /// This algorithm is from https://learn.microsoft.com//dotnet/api/system.intptr example
    /// </summary>
    public string? Reverse(string? input)
    {
        int copylen = input?.Length ?? 0;

        // Allocate HGlobal memory for source and destination strings
        IntPtr sptr = Marshal.StringToHGlobalAnsi(input);
        IntPtr dptr = Marshal.AllocHGlobal(copylen + 1);

        // The unsafe section where byte pointers are used.
        unsafe
        {
            byte* src = (byte*)sptr.ToPointer();
            byte* dst = (byte*)dptr.ToPointer();

            if (copylen > 0)
            {
                // set the source pointer to the end of the string
                // to do a reverse copy.
                src += copylen - 1;

                while (copylen-- > 0)
                {
                    *dst++ = *src--;
                }
                *dst = 0;
            }
        }

        return Marshal.PtrToStringAnsi(dptr);
    }
}

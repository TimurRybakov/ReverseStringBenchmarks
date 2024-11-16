using BenchmarkDotNet.Attributes;
using System.Reflection;

using BenchmarkDotNet.Running;

using ReverseStringBenchmarks;
using System.Diagnostics;

#if DEBUG
using ReverseStringBenchmarks.StringReverseners;

var benchmarks = new Benchmarks();
benchmarks.InputLength = 100;
benchmarks.SetInput();

// All public instance methods of Benchmarks class
MethodInfo[] methods = benchmarks.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);

var sw = new Stopwatch();
foreach (var method in methods)
{
    // If a method has Benchmark attribute...
    if (method.GetCustomAttributes(typeof(BenchmarkAttribute), false).Any())
    {
        // ...and returns a string...
        if (method.ReturnType == typeof(string))
        {
            // ...invoke it and write the output to console
            sw.Restart();
            var result = method.Invoke(benchmarks, null);
            sw.Stop();
            Console.WriteLine($"{method.Name}{new string(' ', 30 - method.Name.Length)}{sw.ElapsedTicks} ticks, results: {result}");
        }
    }
}
Console.ReadLine();

#else
BenchmarkRunner.Run<Benchmarks>();
#endif


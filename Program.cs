using BenchmarkDotNet.Attributes;
using System.Reflection;

using BenchmarkDotNet.Running;

using ReverseStringBenchmarks;
#if DEBUG
using ReverseStringBenchmarks.StringReverseners;

var benchmarks = new Benchmarks();
benchmarks.InputLength = 100;
benchmarks.SetInput();

// All public instance methods of Benchmarks class
MethodInfo[] methods = benchmarks.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);

foreach (var method in methods)
{
    // If a method has Benchmark attribute...
    if (method.GetCustomAttributes(typeof(BenchmarkAttribute), false).Any())
    {
        // ...and returns a string...
        if (method.ReturnType == typeof(string))
        {
            // ...invoke it and write the output to console
            var result = method.Invoke(benchmarks, null);
            Console.WriteLine($"Results of method {method.Name}: {result}");
        }
    }
}
Console.ReadLine();

#else
BenchmarkRunner.Run<Benchmarks>();
#endif


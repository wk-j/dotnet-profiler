#! "netcoreapp2.0"
#r "nuget:System.Memory, 4.5.0-preview1-26216-02"
#r "nuget:BenchmarkDotNet, 0.10.12"

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Test>();

[InProcess]
public class Test {
    int[] values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    [Benchmark]
    public void Take() {
        var a = values.Skip(5);
    }

    [Benchmark]
    public void Slice() {
        var span = new Span<int>(values, 0, values.Length);
        var a = span.Slice(5, span.Length - 5);
    }
}
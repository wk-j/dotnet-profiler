#! "netcoreapp2.1"
#r "nuget:BenchmarkDotNet,0.10.14"

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ATest>();

class Empty {

}

struct Struct {
}

// [MemoryDiagnoser]
[InProcess]
// [SimpleJob(runStrategy: RunStrategy.Monitoring, warmupCount: 1, targetCount: 1, invocationCount: 1)]
public class ATest {

    [Benchmark]
    public void Class() {
        new Empty();
    }

    [Benchmark]
    public void Struct() {
        new Struct();
    }
}


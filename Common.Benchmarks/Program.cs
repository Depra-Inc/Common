﻿using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using BenchmarkDotNet.Validators;

namespace Depra.Common.Benchmarks;

public static class Program
{
    private static void Main()
    {
        BenchmarkRunner.Run(typeof(Program).Assembly, DefaultConfig.Instance
            .AddValidator(JitOptimizationsValidator.FailOnError)
            .AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance))
            .AddDiagnoser(MemoryDiagnoser.Default)
            .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest)));
    }
}
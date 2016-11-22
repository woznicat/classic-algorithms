using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    using NBench.Util;
    using NBench;

    /// <summary>
    /// Test to see if we can achieve max throughput on a <see cref="AtomicCounter"/>
    /// </summary>
    public class CounterPerfSpecs
    {
        int[] array = SortingHelper.GetRandomArray(10000);

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            array = SortingHelper.GetRandomArray(10000);
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 3, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
      //  [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void Benchmark()
        {
          //  array.СountingSortAsc();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }
    }
}

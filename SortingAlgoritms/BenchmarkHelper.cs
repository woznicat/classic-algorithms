using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;

namespace SortingAlgorithms
{
  //  [MinColumn, MaxColumn]
    public class BenchmarkHelper
    {
        private int[] array = SortingHelper.GetRandomArray(10000);

        [Benchmark]
        public void Run()
        {
            //Distribution
            SortingTimer.Go(ar => ar.СountingSortAsc(), SortingHelper.GetRandomArray(10000, 0, 255), "Counting Sort");

            //Exchange
            SortingTimer.Go(ar => ar.QuickSortAsc(), array.CloneArray(), "Quick Sort");
        }
    }
}
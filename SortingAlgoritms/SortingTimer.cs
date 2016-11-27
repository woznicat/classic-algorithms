using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    public static class SortingTimer
    {
        public static void Go(Action<int[]> sort, int[] array, string displayName)
        {
            Stopwatch _stopwatch = new Stopwatch();
            _stopwatch.Start();
            Console.WriteLine("Start sorting: {0}", displayName);
            sort(array);

            _stopwatch.Stop();

            TimeSpan ts = _stopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            Console.WriteLine("End sorting:{0} - {2} ({1} elements)", displayName, array.Length, elapsedTime);
        }
    }
}
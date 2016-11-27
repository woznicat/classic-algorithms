using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    internal class Program
    {
        private static void Main()
        {
            //var summary = BenchmarkRunner.Run<СountingSortAsc>();
            for (int i = 0; i < 1; i++)
            {
                NormalExec();
            }
            Console.WriteLine("\n-----END-----");
            Console.Read();
        }

        private static void NormalExec()
        {
            Stopwatch _stopwatch = new Stopwatch();
            _stopwatch.Start();

            BenchmarkHelper c = new BenchmarkHelper();
            c.Run();
            _stopwatch.Stop();

            TimeSpan ts = _stopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            Console.WriteLine("Elapsed {0}\r\n", elapsedTime);
        }
    }
}
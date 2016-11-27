using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Formatters;
using sorters;

namespace SortingAlgorithms
{
    //https://msdn.microsoft.com/pl-pl/library/dn775006.aspx ETW images
    // https://github.com/mspnp/semantic-logging strona projektu
    // dokument https://msdn.microsoft.com/pl-pl/library/dn775006.aspx  https://msdn.microsoft.com/en-us/library/dd673617.aspx
    internal class Program
    {
        private static void Main()
        {
            var listener = new ObservableEventListener();
            //listener.LogToConsole(formatter: new TextFormatter(), colorMapper: new DefaultConsoleColorMapper());
            listener.LogToConsole();
            listener.EnableEvents(PerfEventSource.Log, EventLevel.LogAlways);
            listener.EnableEvents(SortEventSource.Log, EventLevel.Informational);
            listener.EnableEvents(СountingSortEventSource.Log, EventLevel.Verbose);
            listener.EnableEvents(QuickSortEventSource.Log, EventLevel.Verbose);

            //log4net.Config.XmlConfigurator.Configure();
            //var summary = BenchmarkRunner.Run<СountingSortAsc>();
            for (int i = 0; i < 1; i++)
            {
                NormalExec();
            }
            //SortingHelper.log.Info("\n-----END-----");
            Console.Read();
            listener.Dispose();
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

            PerfEventSource.Log.SummaryExecution(elapsedTime);
        }
    }
}
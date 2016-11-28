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
    //why use https://blogs.msdn.microsoft.com/vancem/2012/08/13/windows-high-speed-logging-etw-in-c-net-using-system-diagnostics-tracing-eventsource/
    //http://blogs.msmvps.com/kathleen/2013/05/03/eventsource-a-new-way-to-trace/
    //ConsoleEventListener.exe "PerfEventSource-MainSource;SortEventSource-MainSource;QuickSortEventSource-MainSource;СountingSortEventSource-MainSource"
    internal class Program
    {
        private static void Main()
        {
            var listener = new ObservableEventListener();
            listener.LogToConsole(formatter: new TextFormatter(), colorMapper: new DefaultConsoleColorMapper());
            //listener.LogToConsole();
            listener.EnableEvents(PerfEventSource.Log, EventLevel.LogAlways);
            //listener.EnableEvents(SortEventSource.Log, EventLevel.Informational);
            //listener.EnableEvents(СountingSortEventSource.Log, EventLevel.Verbose);
            //listener.EnableEvents(QuickSortEventSource.Log, EventLevel.Verbose);

            //log4net.Config.XmlConfigurator.Configure();
            //var summary = BenchmarkRunner.Run<СountingSortAsc>();

            while (true)
            {
                for (int i = 0; i < 1; i++)
                {
                    NormalExec();
                }
                //SortingHelper.log.Info("\n-----END-----");
                Console.WriteLine("Hit key to continue");
                Console.Read();
            }
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

        #region Console CtrlC handling

        private static bool s_bCtrlCExecuted;
        private static ConsoleCancelEventHandler s_CtrlCHandler;

        /// <summary>
        /// This implementation allows one to call this function multiple times during the
        /// execution of a console application. The CtrlC handling is disabled when Ctrl-C
        /// is typed, one will need to call this method again to re-enable it.
        /// </summary>
        /// <param name="action"></param>
        private static void SetupCtrlCHandler(Action action)
        {
            s_bCtrlCExecuted = false;
            // uninstall previous handler
            if (s_CtrlCHandler != null)
                Console.CancelKeyPress -= s_CtrlCHandler;

            s_CtrlCHandler =
                (object sender, ConsoleCancelEventArgs cancelArgs) =>
                {
                    if (!s_bCtrlCExecuted)
                    {
                        s_bCtrlCExecuted = true;    // ensure not reentrant

                        Console.WriteLine("Stopping");

                        action();                   // execute custom action

                        // terminate normally (i.e. when the monitoring tasks complete b/c we've stopped the sessions)
                        cancelArgs.Cancel = true;
                    }
                };
            Console.CancelKeyPress += s_CtrlCHandler;
        }

        #endregion Console CtrlC handling
    }
}
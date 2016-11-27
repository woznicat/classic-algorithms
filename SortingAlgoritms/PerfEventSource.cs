using System.Diagnostics.Tracing;

namespace SortingAlgorithms
{
    [EventSource(Name = "PerfEventSource-MainSource")]
    internal class PerfEventSource : EventSource
    {
        public static PerfEventSource Log = new PerfEventSource();

        [Event(1, Message = "Elapsed {0}\r\n", Level = EventLevel.Informational)]
        internal void SummaryExecution(string elapsedTime)
        {
            if (IsEnabled())
            {
                WriteEvent(1, elapsedTime);
            }
        }

        [Event(2, Message = "Start sorting: {0}", Level = EventLevel.Informational)]
        internal void StartSorting(string displayName)
        {
            if (IsEnabled())
            {
                WriteEvent(2, displayName);
            }
        }

        [Event(3, Message = "End sorting:{0} - {2} ({1} elements)", Level = EventLevel.Informational)]
        internal void StopSorting(string displayName, int length, string elapsedTime)
        {
            if (IsEnabled())
            {
                WriteEvent(3, displayName, length, elapsedTime);
            }
        }
    }
}
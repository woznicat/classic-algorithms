using System.Diagnostics.Tracing;

namespace sorters
{
    [EventSource(Name = "SortEventSource-MainSource")]
    public class SortEventSource : EventSource
    {
        [Event(1, Message = "{0} - entering main method", Level = EventLevel.Informational)]
        public void MethodCallEnter(string methodname)
        {
            if (IsEnabled())
            {
                WriteEvent(1, methodname);
            }
        }

        [Event(2, Message = "{0} - leavig main method", Level = EventLevel.Informational)]
        public void MethodCallLeave(string methodname)
        {
            if (IsEnabled())
            {
                WriteEvent(2, methodname);
            }
        }

        public static SortEventSource Log = new SortEventSource();
    }
}
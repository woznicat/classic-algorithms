using System.Diagnostics.Tracing;

namespace sorters
{
    [EventSource(Name = "СountingSortEventSource-MainSource")]
    public class СountingSortEventSource : EventSource
    {
        [Event(1, Message = "No elements to sort", Level = EventLevel.Verbose)]
        public void NoElementsToSort()
        {
            if (IsEnabled())
            {
                WriteEvent(1);
            }
        }

        public static СountingSortEventSource Log = new СountingSortEventSource();

        [Event(2, Message = "Estimating max and min element loop", Level = EventLevel.Verbose)]
        internal void EstimateBoundaries()
        {
            if (IsEnabled())
            {
                WriteEvent(2);
            }
        }

        [Event(3, Message = "minValue:{0}, maxValue:{1}", Level = EventLevel.Verbose)]
        internal void CalculatedBoudaries(int minValue, int maxValue)
        {
            if (IsEnabled())
            {
                WriteEvent(2, minValue, maxValue);
            }
        }

        [Event(4, Message = "Setting element by index", Level = EventLevel.Verbose)]
        internal void SettingElementByIndex()
        {
            if (IsEnabled())
            {
                WriteEvent(4);
            }
        }

        [Event(5, Message = "Final sort", Level = EventLevel.Verbose)]
        internal void FinalSort()
        {
            if (IsEnabled())
            {
                WriteEvent(5);
            }
        }
    }
}
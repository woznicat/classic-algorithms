using System.Diagnostics.Tracing;

namespace sorters
{
    [EventSource(Name = "QuickSortEventSource-MainSource")]
    public class QuickSortEventSource : EventSource
    {
        [Event(1, Message = "No elements to sort", Level = EventLevel.Verbose)]
        public void NoElementsToSort()
        {
            if (IsEnabled())
            {
                WriteEvent(1);
            }
        }

        public static QuickSortEventSource Log = new QuickSortEventSource();

        [Event(2, Message = "must go deeper left", Level = EventLevel.Verbose)]
        internal void LeftRecurencyCall()
        {
            if (IsEnabled())
            {
                WriteEvent(2);
            }
        }

        [Event(3, Message = "must go deeper right", Level = EventLevel.Verbose)]
        internal void RightRecurencyCall()
        {
            if (IsEnabled())
            {
                WriteEvent(3);
            }
        }

        [Event(4, Message = "Dividing collection {0} / {1} = {2}", Level = EventLevel.Verbose)]
        internal void QuickSort(int leftIndex, int rightIndex, int separateItem)
        {
            if (IsEnabled())
            {
                WriteEvent(4, leftIndex, rightIndex, separateItem);
            }
        }
    }
}
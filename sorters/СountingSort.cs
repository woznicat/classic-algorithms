using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    public static class СountingSort
    {
        private const string sortname = "CountingSort";

        public static void СountingSortAsc(this int[] array)
        {
            Trace.TraceInformation("{0} - entering main method", sortname);
            if (array.Length <= 1)
            {
                Trace.WriteLineIf(SortingHelper.appSwitch.Level == TraceLevel.Verbose, String.Format("{0} - no elements to sort", sortname));
                return;
            }

            int maxValue = array[0];
            int minValue = array[0];

            Trace.WriteLineIf(SortingHelper.appSwitch.Level == TraceLevel.Verbose, String.Format("{0} - estimating max and min element loop", sortname));
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] > maxValue)
                {
                    maxValue = array[i + 1];
                }
                else if (array[i + 1] < minValue)
                {
                    minValue = array[i + 1];
                }
            }
            Trace.WriteLineIf(SortingHelper.appSwitch.Level == TraceLevel.Verbose, String.Format("{0} - minValue:{1}, maxValue:{2}", sortname, minValue, maxValue));
            var countsArray = new int[maxValue - minValue + 1];

            Trace.WriteLineIf(SortingHelper.appSwitch.Level == TraceLevel.Verbose, String.Format("{0} - setting element by index", sortname));
            foreach (int item in array)
            {
                countsArray[item - minValue]++;
            }

            var currentIndex = 0;

            Trace.WriteLineIf(SortingHelper.appSwitch.Level == TraceLevel.Verbose, String.Format("{0} - final sort", sortname));
            for (var i = 0; i < countsArray.Length; i++)
            {
                for (var j = 0; j < countsArray[i]; j++)
                {
                    array[currentIndex++] = i + minValue;
                }
            }
            Trace.TraceInformation("{0} - leavig main method", sortname);
        }
    }
}
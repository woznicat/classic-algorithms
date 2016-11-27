using System;

namespace SortingAlgorithms
{
    public static class СountingSort
    {
        private const string sortname = "CountingSort";

        public static void СountingSortAsc(this int[] array)
        {
            SortingHelper.log.InfoFormat("{0} - entering main method", sortname);
            if (array.Length <= 1)
            {
                SortingHelper.log.Logger.Log(null, log4net.Core.Level.Verbose, String.Format("{0} - no elements to sort", sortname), null);
                return;
            }

            int maxValue = array[0];
            int minValue = array[0];

            SortingHelper.log.Logger.Log(null, log4net.Core.Level.Verbose, String.Format("{0} - estimating max and min element loop", sortname), null);
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
            SortingHelper.log.Logger.Log(null, log4net.Core.Level.Verbose, String.Format("{0} - minValue:{1}, maxValue:{2}", sortname, minValue, maxValue), null);
            var countsArray = new int[maxValue - minValue + 1];

            SortingHelper.log.Logger.Log(null, log4net.Core.Level.Verbose, String.Format("{0} - setting element by index", sortname), null);
            foreach (int item in array)
            {
                countsArray[item - minValue]++;
            }

            var currentIndex = 0;

            SortingHelper.log.Logger.Log(null, log4net.Core.Level.Verbose, String.Format("{0} - final sort", sortname), null);
            for (var i = 0; i < countsArray.Length; i++)
            {
                for (var j = 0; j < countsArray[i]; j++)
                {
                    array[currentIndex++] = i + minValue;
                }
            }
            SortingHelper.log.InfoFormat("{0} - leavig main method", sortname);
        }
    }
}
using sorters;

namespace SortingAlgorithms
{
    public static class СountingSort
    {
        private const string sortname = "CountingSort";

        public static void СountingSortAsc(this int[] array)
        {
            SortEventSource.Log.MethodCallEnter(sortname);
            if (array.Length <= 1)
            {
                СountingSortEventSource.Log.NoElementsToSort();
                return;
            }

            int maxValue = array[0];
            int minValue = array[0];

            СountingSortEventSource.Log.EstimateBoundaries();
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

            СountingSortEventSource.Log.CalculatedBoudaries(minValue, maxValue);
            var countsArray = new int[maxValue - minValue + 1];

            СountingSortEventSource.Log.SettingElementByIndex();
            foreach (int item in array)
            {
                countsArray[item - minValue]++;
            }

            var currentIndex = 0;

            СountingSortEventSource.Log.FinalSort();
            for (var i = 0; i < countsArray.Length; i++)
            {
                for (var j = 0; j < countsArray[i]; j++)
                {
                    array[currentIndex++] = i + minValue;
                }
            }
            SortEventSource.Log.MethodCallEnter(sortname);
        }
    }
}
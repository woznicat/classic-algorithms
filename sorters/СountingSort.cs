using System;
using BenchmarkDotNet.Attributes;

namespace SortingAlgorithms
{
    public static class СountingSort
    {
        const string sortname = "CountingSort";
        public static void СountingSortAsc(this int[] array)
        {
            Console.WriteLine("{0} - entering main method", sortname);
            if (array.Length <= 1)
            {
                Console.WriteLine("{0} - no elements to sort", sortname);
                return;
            }

            int maxValue = array[0];
            int minValue = array[0];

            Console.WriteLine("{0} - estimating max and min element loop", sortname);
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
            Console.WriteLine("{0} - minValue:{1}, maxValue:{2}", sortname, minValue, maxValue);
            var countsArray = new int[maxValue - minValue + 1];

            Console.WriteLine("{0} - setting element by index", sortname);
            foreach (int item in array)
            {
                countsArray[item - minValue]++;
            }

            var currentIndex = 0;

            Console.WriteLine("{0} - final sort", sortname);
            for (var i = 0; i < countsArray.Length; i++)
            {
                for (var j = 0; j < countsArray[i]; j++)
                {
                    array[currentIndex++] = i + minValue;
                }
            }
            Console.WriteLine("{0} - leavig main method", sortname);
        }
    }
}
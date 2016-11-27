using System;

namespace SortingAlgorithms
{
    public static class QuickSort
    {
        private const string sortname = "QuickSort";

        public static void QuickSortAsc(this int[] array)
        {
            Console.WriteLine("{0} - entering main method", sortname);
            if (array.Length <= 1)
            {
                Console.WriteLine("{0} - no elements to sort", sortname);
                return;
            }

            QuickSortTemp(array, 0, array.Length - 1);
            Console.WriteLine("{0} - leavig main method", sortname);
        }

        private static void QuickSortTemp(int[] collection, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var separateItem = collection[((leftIndex + rightIndex) / 2)];
            Console.WriteLine("{0} - dividing collection {1} / {2} = {3}", sortname, leftIndex, rightIndex, separateItem);
            do
            {
                while (collection[i] < separateItem)
                {
                    i++;
                }

                while (collection[j] > separateItem)
                {
                    j--;
                }

                if (i <= j)
                {
                    if (i < j)
                    {
                        collection.Swap(i, j);
                    }

                    i++; j--;
                }
            } while (i < j);

            if (leftIndex < j)
            {
                Console.WriteLine("{0} - must go deeper left", sortname);
                QuickSortTemp(collection, leftIndex, j);
            }

            if (i < rightIndex)
            {
                Console.WriteLine("{0} - must go deeper right", sortname);
                QuickSortTemp(collection, i, rightIndex);
            }
        }
    }
}
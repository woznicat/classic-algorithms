using sorters;

namespace SortingAlgorithms
{
    public static class QuickSort
    {
        private const string sortname = "QuickSort";

        public static void QuickSortAsc(this int[] array)
        {
            SortEventSource.Log.MethodCallEnter(sortname);
            if (array.Length <= 1)
            {
                QuickSortEventSource.Log.NoElementsToSort();
                return;
            }
            QuickSortTemp(array, 0, array.Length - 1);
            SortEventSource.Log.MethodCallLeave(sortname);
        }

        private static void QuickSortTemp(int[] collection, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var separateItem = collection[((leftIndex + rightIndex) / 2)];
            QuickSortEventSource.Log.QuickSort(leftIndex, rightIndex, separateItem);
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
                QuickSortEventSource.Log.LeftRecurencyCall();
                QuickSortTemp(collection, leftIndex, j);
            }

            if (i < rightIndex)
            {
                QuickSortEventSource.Log.RightRecurencyCall();
                QuickSortTemp(collection, i, rightIndex);
            }
        }
    }
}
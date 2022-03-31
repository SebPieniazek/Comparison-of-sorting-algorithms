namespace AlgorithmComparisonEngine.SortAlgorithms
{
    internal class SelectionSort : SortAlgorithmBase
    {
        public SelectionSort()
        {
            alghoritmName = "Selection Sort";
            alghoritmInformation = "In-Stable in-place Alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(1)\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n^2)\n" +
                                   " Best - O(n^2)\n" +
                                   " Worst - O(n^2)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Small data sets - This alghoritm is easy to implement, but it has the worst time complexity\n";

            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            int min;
            int index = 0;

            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                min = arrayToSort[i];
                for (int j = i; j < arrayToSort.Length; j++)
                {
                    if (ascending)
                    {
                        if (min > arrayToSort[j])
                        {
                            min = arrayToSort[j];
                            index = j;
                        }
                    }
                    else
                    {
                        if (min < arrayToSort[j])
                        {
                            min = arrayToSort[j];
                            index = j;
                        }
                    }
                }
                Swap(ref arrayToSort[i], ref arrayToSort[index]);
            }

            stopWatch.Stop();
            PrintData(arrayToSort);
        }
    }
}

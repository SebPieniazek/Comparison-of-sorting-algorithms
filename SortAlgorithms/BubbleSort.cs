namespace AlgorithmComparisonEngine.SortAlgorithms
{
    internal class BubbleSort : SortAlgorithmBase
    {
        public BubbleSort()
        {
            alghoritmName = "Bubble Sort";
            alghoritmInformation = "Stable in-place Alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(1)\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n^2)\n" +
                                   " Best - O(n)\n" +
                                   " Worst - O(n^2)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Small data sets - This alghoritm is easy to implement\n";

            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            bool swap;

            stopWatch.Reset();
            stopWatch.Start();
            do
            {
                swap = false;
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    if (ascending)
                    {
                        if (arrayToSort[i] > arrayToSort[i + 1])
                        {
                            Swap(ref arrayToSort[i + 1], ref arrayToSort[i]);
                            swap = true;
                        }
                    }
                    else
                    {
                        if (arrayToSort[i] < arrayToSort[i + 1])
                        {
                            Swap(ref arrayToSort[i + 1], ref arrayToSort[i]);
                            swap = true;
                        }
                    }
                }
            } while (swap);

            stopWatch.Stop();
            PrintData(arrayToSort);
        }
    }
}

namespace AlgorithmComparisonEngine.SortAlgorithms
{
    class InsertSort : SortAlgorithmBase
    {
        public InsertSort()
        {
            alghoritmName = "Insert Sort";
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
            stopWatch.Reset();
            stopWatch.Start();
            int singleValue;
            int temp;
            for (int i = 1; i < arrayToSort.Length; i++)
            {
                temp = i;
                singleValue = arrayToSort[i];
                while (i != 0)
                {
                    if (ascending)
                    {
                        if (arrayToSort[i] < arrayToSort[i - 1])
                        {
                            arrayToSort[i] = arrayToSort[i - 1];
                            arrayToSort[i - 1] = singleValue;
                            i--;
                        }
                        else break;
                    }
                    else
                    {
                        if (arrayToSort[i] > arrayToSort[i - 1])
                        {
                            arrayToSort[i] = arrayToSort[i - 1];
                            arrayToSort[i - 1] = singleValue;
                            i--;
                        }
                        else break;
                    }

                }
                i = temp;
            }
            stopWatch.Stop();
            PrintData(arrayToSort);
        }

    }
}

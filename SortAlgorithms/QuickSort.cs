namespace AlgorithmComparisonEngine.SortAlgorithms
{
    internal class QuickSort : SortAlgorithmBase
    {
        public QuickSort()
        {
            alghoritmName = "Quick Sort";
            alghoritmInformation = "In-Stable in-place Alghoritm - Uses divide-and-conquern alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(n) or O(log n) - Depends on implementation\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n log n)\n" +
                                   " Best - O(n log n)\n" +
                                   " Worst - O(n^2)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Medium/Large data sets - This alghoritm uses recursion and it's moderately difficult to implement.\n" +
                                   " It's one of the best sort alghoritms and is used in many libraries\n";

            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSortMethod(0, arrayToSort.Length, arrayToSort);

            stopWatch.Stop();
            PrintData(arrayToSort);
        }

        private void QuickSortMethod(int lowestElement, int highestElement, int[] tab)
        {
            int min = lowestElement;
            int max = highestElement - 1;
            int size = highestElement - lowestElement;

            if (size > 1)
            {
                int comparentElement = tab[max];

                if (ascending)
                {
                    while (min < max)
                    {
                        while (tab[max] > comparentElement && max > min)
                        {
                            max--;
                        }
                        while (tab[min] < comparentElement && min <= max)
                        {
                            min++;
                        }
                        if (min < max)
                        {
                            Swap(ref tab[min], ref tab[max]);
                            min++;
                        }
                    }

                    QuickSortMethod(lowestElement, min, tab);
                    QuickSortMethod(max, highestElement, tab);
                }
                else
                {
                    while (min < max)
                    {
                        while (tab[max] < comparentElement && max > min)
                        {
                            max--;
                        }
                        while (tab[min] > comparentElement && min <= max)
                        {
                            min++;
                        }
                        if (min < max)
                        {
                            Swap(ref tab[min], ref tab[max]);
                            min++;
                        }
                    }

                    QuickSortMethod(lowestElement, min, tab);
                    QuickSortMethod(max, highestElement, tab);
                }
            }
        }
    }
}

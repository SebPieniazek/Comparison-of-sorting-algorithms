namespace AlgorithmComparisonEngine.SortAlgorithms
{
    internal class MergeSort : SortAlgorithmBase
    {
        public MergeSort()
        {
            alghoritmName = "Merge Sort";
            alghoritmInformation = "Stable(in most implementations) non-in-place Alghoritm - Uses divide-and-conquern alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(n)\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n log n)\n" +
                                   " Best - O(n log n)\n" +
                                   " Worst - O(n log n)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Medium/Large data sets - This alghoritm uses recursion and it's moderately difficult to implement.\n";

            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();

            MergeSortMethod(0, arrayToSort.Length - 1, arrayToSort);

            stopWatch.Stop();
            PrintData(arrayToSort);
        }

        private void MergeSortMethod(int leftPoint, int rightPoint, int[] tab)
        {
            if (rightPoint - leftPoint > 0)
            {
                int middlePoint = (leftPoint + rightPoint) / 2;
                MergeSortMethod(leftPoint, middlePoint, tab);
                MergeSortMethod(middlePoint + 1, rightPoint, tab);
                Merge(leftPoint, middlePoint, rightPoint, tab);
            }
        }
        private void Merge(int leftPoint, int middlePoint, int rightPoint, int[] tab)
        {
            int[] temp = new int[(middlePoint - leftPoint + 1) + (rightPoint - middlePoint + 1 + 1)];

            int index = 0;
            int startIndex = leftPoint;
            int secondStartIndex = middlePoint + 1;

            while (startIndex <= middlePoint || secondStartIndex <= rightPoint)
            {
                if (startIndex <= middlePoint && secondStartIndex <= rightPoint)
                {
                    if (ascending)
                    {
                        if (tab[startIndex] <= tab[secondStartIndex])
                        {
                            temp[index++] = tab[startIndex++];
                        }
                        else
                        {
                            temp[index++] = tab[secondStartIndex++];
                        }
                    }
                    else
                    {
                        if (tab[startIndex] >= tab[secondStartIndex])
                        {
                            temp[index++] = tab[startIndex++];
                        }
                        else
                        {
                            temp[index++] = tab[secondStartIndex++];
                        }
                    }
                }
                else if (startIndex <= middlePoint && secondStartIndex > rightPoint)
                {
                    temp[index++] = tab[startIndex++];
                }
                else if (startIndex > middlePoint && secondStartIndex <= rightPoint)
                {
                    temp[index++] = tab[secondStartIndex++];
                }
            }

            index = 0;
            startIndex = leftPoint;
            secondStartIndex = middlePoint + 1;

            FillMainTable(ref startIndex, middlePoint, tab, temp, ref index );
            FillMainTable(ref secondStartIndex, rightPoint, tab, temp, ref index);
        }

        private void FillMainTable(ref int startIndex, int endIndex, int[] tab, int[] temp, ref int index)
        {
            for (int i = startIndex; startIndex <= endIndex; startIndex++, i++)
            {
                tab[i] = temp[index++];
            }
        }
    }
}

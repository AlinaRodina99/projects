using System.Diagnostics;
using System.Threading.Tasks;

namespace Test6
{
    public class QuickSort
    {
        /// <summary>
        /// Method to find support element in array to make one-threaded quick sort.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="end">Index of the end of the array.</param>
        /// <returns>support element.</returns>
        private int FindSupprotMemberOneThread(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }

            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        /// <summary>
        /// Method for algorithm of one-threaded quick sort.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="end">Index of the end.</param>
        /// <returns>Sorted array.</returns>
        public int[] QuickSortOneThread(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return array;
            }

            int supportMember = FindSupprotMemberOneThread(array, start, end);
            QuickSortOneThread(array, start, supportMember - 1);
            QuickSortOneThread(array, supportMember + 1, end);
            return array;
        }

        /// <summary>
        /// Method to find support element in array to make multi-threaded quick sort.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="end">Index of the end of the array.</param>
        /// <returns>support element.</returns>
        private async Task<int> FindSupportMemberMultiThread(int[] array, int start, int end)
        {
            var marker = start;

            await Task.Run(() =>
            {
                int temp;
                for (int i = start; i <= end; i++)
                {
                    if (array[i] < array[end])
                    {
                        temp = array[marker];
                        array[marker] = array[i];
                        array[i] = temp;
                        marker += 1;
                    }
                }

                temp = array[marker];
                array[marker] = array[end];
                array[end] = temp;
            });

            return marker;
        }

        /// <summary>
        /// Method for algorithm of multi-threaded quick sort.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="end">Index of the end.</param>
        /// <returns>Sorted array.</returns>
        public async Task<int[]> QuickSortMultiThread(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return array;
            }

            int supportMember = await FindSupportMemberMultiThread(array, start, end);
            await QuickSortMultiThread(array, start, supportMember - 1);
            await QuickSortMultiThread(array, supportMember + 1, end);
            return array;
        }

        /// <summary>
        /// Method to compare two methods of quick sort.
        /// </summary>
        /// <param name="array">Input array</param>
        /// <returns>1 if one-threaded sort is faster, -1 if multi-threaded is faster, 0 otherwise.</returns>
        public int Compare(int[] array)
        {
            var stopWatchSingle = new Stopwatch();
            stopWatchSingle.Start();
            QuickSortOneThread(array, 0, array.Length - 1);
            stopWatchSingle.Stop();

            var stopWatchMultiple = new Stopwatch();
            stopWatchMultiple.Start();
            var task = QuickSortMultiThread(array, 0, array.Length - 1);
            Task.WaitAll(task);
            stopWatchMultiple.Stop();

            return (stopWatchSingle.Elapsed > stopWatchMultiple.Elapsed ? 1 : (stopWatchSingle.Elapsed < stopWatchMultiple.Elapsed ? -1 : 0));
        }
    }
}

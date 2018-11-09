using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInversionsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] Array_Pasortuar = new int[] { 1, 5, 8, 3, 2 };
       
            Console.Write("Array i pasortuar: ");
            Console.Write("[ ");
            foreach (var item in Array_Pasortuar)
            {
                Console.Write(item.ToString()+" ");
            }
            Console.Write("]\n");
            Console.Write("\n");
            //int[] Array_Sortuar = new int[] { 5 };
            int inversionet;
            int[] Array_Sortuar = MergeSort(Array_Pasortuar, out inversionet );
            Console.Write("Array i sortuar:    ");
            Console.Write("[ ");
            foreach (var item in Array_Sortuar)
            {
                Console.Write(item.ToString()+" ");
            }
            Console.Write("]");
            Console.Write("\n");
            Console.Write("Numri i inversioneve: ");
            Console.Write(inversionet);
            Console.Write("\n");
            Console.Write("Inversionet =");
            PrintInversionet(Array_Sortuar);
            Console.Read();
            
        }


        public static void PrintInversionet(int[] array_hyres)
        {
           for(int i = 1; i < 5; i++)
            {
                for (int ii = i + 1; ii < 5; ii++)
                {
                    if (array_hyres[i] > array_hyres[ii])
                        Console.Write(array_hyres[i]);
                }
            }
                
        }

        public static int[] MergeSort(int[] A, out int inversionsCount)
        {
            inversionsCount = 0;

            int[] sortedArray;
            if (A.Length == 1)
                sortedArray = A;
            //If the length of input array is greater than one
            else
            {
                int lowerArrayInversionsCount = 0, upperArrayInversionsCount = 0;

                int lowerArrayIndex = 0, upperArrayIndex = 0;

                //Split the array into lower half
                int[] lowerArray = new int[A.Length / 2];
                Array.Copy(A, lowerArray, lowerArray.Length);

                //Which will be sorted recursively
                lowerArray = MergeSort(lowerArray, out lowerArrayInversionsCount);

                //And upper half
                int[] upperArray = new int[A.Length - lowerArray.Length];
                Array.Copy(A, lowerArray.Length, upperArray, 0, upperArray.Length);

                //Which also will be sorted recursively
                upperArray = MergeSort(upperArray, out upperArrayInversionsCount);
                inversionsCount = lowerArrayInversionsCount + upperArrayInversionsCount;

                //The sorted array is a result of proper merging of the lower and upper half
                sortedArray = new int[A.Length];
                lowerArrayIndex = 0;
                upperArrayIndex = 0;

                //For all the elements
                for (int sortedArrayIndex = 0; sortedArrayIndex < sortedArray.Length; sortedArrayIndex++)
                {
                    //If all the elements from lower half has been copied
                    if (lowerArrayIndex == lowerArray.Length)

                        //Copy the element from upper half
                        sortedArray[sortedArrayIndex] = upperArray[upperArrayIndex++];

                    //If all the elements from upper half has been copied
                    else if (upperArrayIndex == upperArray.Length)

                        //Copy the element from lower half
                        sortedArray[sortedArrayIndex] = lowerArray[lowerArrayIndex++];

                    //If the current element in lower half is less or equal than current element in upper half
                    else if (lowerArray[lowerArrayIndex] <= upperArray[upperArrayIndex])

                        //Copy the element from lower half
                        sortedArray[sortedArrayIndex] = lowerArray[lowerArrayIndex++];

                    //In any other case
                    else
                    {
                        //Copy the element from upper half
                        sortedArray[sortedArrayIndex] = upperArray[upperArrayIndex++];

                        //And count the inversions
                        inversionsCount += lowerArray.Length - lowerArrayIndex;
                    }
                }
            }

            return sortedArray;

        }


    }
}




    // Kerkesa ne projekt -  
    // duhet krijuar teknika Sundo dhe Percaj permes se ciles gjinden inverzionet e arrayit te dhene
    //public class CountingInversions
    //{
    //    public Tuple<int, List<int>> SortAndCount(List<int> list)
    //    {
    //        if (list.Count <= 1)
    //            return new Tuple<int, List<int>>(0, list);

    //        // divide
    //        int middle = list.Count / 2;
    //        var leftList = list.GetRange(0, middle);
    //        var rightList = list.GetRange(middle, list.Count - leftList.Count);

    //        // process recursively
    //        Tuple<int, List<int>> leftResult = SortAndCount(leftList);
    //        Tuple<int, List<int>> rightResult = SortAndCount(rightList);

    //        // merge
    //        Tuple<int, List<int>> mergeResult = MergeAndCount(leftResult.Item2, rightResult.Item2);

    //        return new Tuple<int, List<int>>(leftResult.Item1 + rightResult.Item1 + mergeResult.Item1,
    //            mergeResult.Item2);
    //    }

    //    private Tuple<int, List<int>> MergeAndCount(List<int> leftList, List<int> rightList)
    //    {
    //        int inversions = 0;
    //        var outputList = new List<int>();
    //        int i = 0, j = 0;

    //        while (i < leftList.Count && j < rightList.Count)
    //        {
    //            if (leftList[i] < rightList[j])
    //            {
    //                outputList.Add(leftList[i]);
    //                i++;
    //            }
    //            else
    //            {
    //                outputList.Add(rightList[j]);
    //                j++;
    //                inversions += leftList.Count - i;
    //            }
    //        }

    //        // we still have values in one of lists 
    //        if (i < leftList.Count)
    //            outputList.AddRange(leftList.GetRange(i, leftList.Count - i));
    //        else if (j < rightList.Count)
    //            outputList.AddRange(rightList.GetRange(j, rightList.Count - j));

    //        return new Tuple<int, List<int>>(inversions, outputList);
    //    }
    //}
    // klasa inversion





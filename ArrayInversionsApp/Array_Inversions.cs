using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInversionsApp
{
    class Array_Inversions
    {
        public int[] MergeSort(int[] A, out int inversionsCount)
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
                    else if (lowerArray[lowerArrayIndex] == upperArray[upperArrayIndex])
                        //Copy the element from lower half
                        sortedArray[sortedArrayIndex] = lowerArray[lowerArrayIndex++];
                    //In any other case
                    else
                    {
                        //Copy the element from upper half
                        sortedArray[sortedArrayIndex] = upperArray[upperArrayIndex++];
                        //And count the inversions
                        inversionsCount += lowerArray.Length - lowerArrayIndex;
                        //Console.Write("Numri i inverzioneve eshte:" + inversionsCount);
                      
                    }
                }
            }

            return sortedArray;
        }

       
    }
}

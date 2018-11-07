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
            Console.Read();
        }
        // Kerkesa ne projekt -  
        // duhet krijuar teknika Sundo dhe Percaj permes se ciles gjinden inverzionet e arrayit te dhene
        public class CountingInversions
        {
            public Tuple<int, List<int>> SortAndCount(List<int> list)
            {
                if (list.Count <= 1)
                    return new Tuple<int, List<int>>(0, list);

                // divide
                int middle = list.Count / 2;
                var leftList = list.GetRange(0, middle);
                var rightList = list.GetRange(middle, list.Count - leftList.Count);

                // process recursively
                Tuple<int, List<int>> leftResult = SortAndCount(leftList);
                Tuple<int, List<int>> rightResult = SortAndCount(rightList);

                // merge
                Tuple<int, List<int>> mergeResult = MergeAndCount(leftResult.Item2, rightResult.Item2);

                return new Tuple<int, List<int>>(leftResult.Item1 + rightResult.Item1 + mergeResult.Item1,
                    mergeResult.Item2);
            }

            private Tuple<int, List<int>> MergeAndCount(List<int> leftList, List<int> rightList)
            {
                int inversions = 0;
                var outputList = new List<int>();
                int i = 0, j = 0;

                while (i < leftList.Count && j < rightList.Count)
                {
                    if (leftList[i] < rightList[j])
                    {
                        outputList.Add(leftList[i]);
                        i++;
                    }
                    else
                    {
                        outputList.Add(rightList[j]);
                        j++;
                        inversions += leftList.Count - i;
                    }
                }

                // we still have values in one of lists 
                if (i < leftList.Count)
                    outputList.AddRange(leftList.GetRange(i, leftList.Count - i));
                else if (j < rightList.Count)
                    outputList.AddRange(rightList.GetRange(j, rightList.Count - j));

                return new Tuple<int, List<int>>(inversions, outputList);
            }
        }
        // klasa inversion



    }

}
   


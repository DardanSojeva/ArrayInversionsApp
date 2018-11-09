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
            //Fillimi:   
            Console.WriteLine("Sheno numrin e anetareve te array-it: ");
            int NumriAnetareveArray = int.Parse(Console.ReadLine());
            int[] Array_Pasortuar = new int[NumriAnetareveArray];
            for(int i=0;i<NumriAnetareveArray; i++)
            {
                Console.Write("Anetari ["+i+"]:");
                Array_Pasortuar[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("====================================");
            Console.Write("\nArray i pasortuar:");
            Console.Write("[");
            foreach (var item in Array_Pasortuar)
            {
                Console.Write(item.ToString() + " ");
            }

            Console.Write("]\n\n");
            int inversionet;
            int[] Array_Sortuar = MergeSort(Array_Pasortuar, out inversionet );
            Console.Write("Array i sortuar:  ");
            Console.Write("[");
            foreach (var item in Array_Sortuar)
            {
                Console.Write(item.ToString()+" ");
            }
            Console.Write("]");
            Console.Write("\n\n");
            Console.WriteLine("====================================");
            Console.Write("Në array-in e dhënë kemi " + inversionet+" inverzione");
            Console.Write("\n");
            Console.ReadLine();
            //int perfundo = int.Parse(Console.ReadLine());
            //Console.WriteLine("Shtypni numrin 0 per te perseritur, 1- per dalje nga programi");
            //if(perfundo != 0)
            //{
            //    goto Fillimi;
            //} 
            //else
            //{
            //    Console.WriteLine("Ju keni zgjedhur daljen!");
            //}
        }

        //public static void PrintInversionet(int[] array_hyres)
        //{
        //   for(int i = 1; i < 5; i++)
        //    {
        //        for (int ii = i + 1; ii < 5; ii++)
        //        {
        //            if (array_hyres[i] > array_hyres[ii])
        //                Console.Write(array_hyres[i]);
        //        }
        //    }
                
        //}
        public static int[] MergeSort(int[] A, out int NumroInversionet)
        {
            NumroInversionet = 0;

            int[] ArrayiSortuar;
            if (A.Length == 1)
                ArrayiSortuar = A;
            //Nese numri i anetareve te array-it hyres eshte me i madhe se 1
            else
            {
                int GjysmaPareNumroInversionet = 0;
                int GjysmaDyteNumroInversionet = 0;

                int ArrayPareIndex = 0, ArrayDyteIndex = 0;

                //Ndaj arrayin ne dy gjysma / gjysma e pare - Divide
                int[] GjysmaPareArrayit = new int[A.Length / 2];
                Array.Copy(A, GjysmaPareArrayit, GjysmaPareArrayit.Length);

                //Gjysma e pare do te sortohet ne menyre rekursive
                GjysmaPareArrayit = MergeSort(GjysmaPareArrayit, out GjysmaPareNumroInversionet);

                //Ndaj arrayin ne dy gjysma / gjysma e dyte 
                int[] GjysmaDyteArrayit = new int[A.Length - GjysmaPareArrayit.Length];
                Array.Copy(A, GjysmaPareArrayit.Length, GjysmaDyteArrayit, 0, GjysmaDyteArrayit.Length);

                //Gjysma e dyte do te sortohet gjithashtu ne menyre rekursive
                GjysmaDyteArrayit = MergeSort(GjysmaDyteArrayit, out GjysmaDyteNumroInversionet);

                // Numero te gjitha inversionet ne arrayin e dhene ( nga dy gjysmat )
                NumroInversionet = GjysmaPareNumroInversionet + GjysmaDyteNumroInversionet;

                // Arrayi sortuar eshte rezultat i MergeSorting adekuat te dy gjysmave
                ArrayiSortuar = new int[A.Length];
                ArrayPareIndex = 0;
                ArrayDyteIndex = 0;

                //Per te gjitha elementet
                for (int ArrayiSortuarIndex = 0; ArrayiSortuarIndex < ArrayiSortuar.Length; ArrayiSortuarIndex++)
                {
                    //Nese elementet e gjyses se pare nuk jane kopjuar
                    if (ArrayPareIndex == GjysmaPareArrayit.Length)

                        //Kopjo elementet prej gjysmes se dyte
                        ArrayiSortuar[ArrayiSortuarIndex] = GjysmaDyteArrayit[ArrayDyteIndex++];

                    //Ne qofte se elementet nga gjysma e dyte e arrayit nuk jane kopjuar
                    else if (ArrayDyteIndex == GjysmaDyteArrayit.Length)

                        //Kopjo elementet prej gjysmes se pare
                        ArrayiSortuar[ArrayiSortuarIndex] = GjysmaPareArrayit[ArrayPareIndex++];
                    // Nese elementi aktual ne gjysem e pare eshte me i vogel apo barazi me elementin aktual (homolog) ne gjysmes e dyte
                    else if (GjysmaPareArrayit[ArrayPareIndex] <= GjysmaDyteArrayit[ArrayDyteIndex])

                        //Kopjo elementet nga gjysma e pare
                        ArrayiSortuar[ArrayiSortuarIndex] = GjysmaPareArrayit[ArrayPareIndex++];

                    //Ne raste te tjera
                    else
                    {
                        //Kopjo elementet prej gjysmes se dyte
                        ArrayiSortuar[ArrayiSortuarIndex] = GjysmaDyteArrayit[ArrayDyteIndex++];

                        //Numro inversionet
                        NumroInversionet += GjysmaPareArrayit.Length - ArrayPareIndex;
                    }
                }
            }
            // Kthe numrin e inversioneve
            return ArrayiSortuar;

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





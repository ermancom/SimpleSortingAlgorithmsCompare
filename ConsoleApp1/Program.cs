using SortingLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{GapFormatted("n=10")}  {GapFormatted("n=100")}  {GapFormatted("n=1000")}  {GapFormatted("n=10000")}  {GapFormatted("n=100000")}  ");
            Console.WriteLine("Elapsed Ticks");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                TakeAReport();
                Console.WriteLine("=========================================================================");
            }
           
            Console.ReadKey();
        }

        static void TakeAReport()
        {
            List<int> nlist = new List<int>() { 10, 100, 1000, 10000, 100000 };

            Dictionary<int, int[]> arrayDic = new Dictionary<int, int[]>();
            Dictionary<int, int[]> arrayDicB = new Dictionary<int, int[]>();
            Dictionary<int, int[]> arrayDicM = new Dictionary<int, int[]>();
            Dictionary<int, int[]> arrayDicI = new Dictionary<int, int[]>();
            Dictionary<int, int[]> arrayDicQ = new Dictionary<int, int[]>();
            Dictionary<int, int[]> arrayDicH = new Dictionary<int, int[]>();
            Dictionary<int, int[]> arrayDicS = new Dictionary<int, int[]>();



            Random random = new Random();

            for (int i = 0; i < nlist.Count; i++)
            {
                arrayDic[i] = new int[nlist[i]];
                arrayDicB[i] = new int[nlist[i]];
                arrayDicM[i] = new int[nlist[i]];
                arrayDicI[i] = new int[nlist[i]];
                arrayDicQ[i] = new int[nlist[i]];
                arrayDicH[i] = new int[nlist[i]];
                arrayDicS[i] = new int[nlist[i]];

                for (int k = 0; k < nlist[i]; k++)
                    arrayDic[i][k] = random.Next(0, nlist[i]);

                arrayDic[i].CopyTo(arrayDicB[i], 0);
                arrayDic[i].CopyTo(arrayDicM[i], 0);
                arrayDic[i].CopyTo(arrayDicI[i], 0);
                arrayDic[i].CopyTo(arrayDicQ[i], 0);
                arrayDic[i].CopyTo(arrayDicH[i], 0);
                arrayDic[i].CopyTo(arrayDicS[i], 0);
            }

            SortReport("Quick Sort", new QuickSort<int>(), arrayDicQ);
            SortReport("Heap Sort", new HeapSort<int>(), arrayDicH);
            SortReport("Insertion Sort", new InsertionSort<int>(), arrayDicI);
            SortReport("Selection Sort", new SelectionSort<int>(), arrayDicS);
            SortReport("Merge Sort", new MergeSort<int>(), arrayDicM);
            SortReport("Bubble Sort", new BubbleSort<int>(), arrayDicB);

            Console.WriteLine();
        }


        static string GapFormatted(string strValue)
        {
            for (int i = strValue.Length-1; i<=10; i++)
            {
                strValue += " ";
            }

            return strValue;
        }

        static void SortReport(string SortingName, ISorting<int> sortingAlgorithm, Dictionary<int, int[]> arrayDic)
        {
            long n0Time = GetMilliSeconds(arrayDic[0], sortingAlgorithm);
            long n1Time = GetMilliSeconds(arrayDic[1], sortingAlgorithm);
            long n2Time = GetMilliSeconds(arrayDic[2], sortingAlgorithm);
            long n3Time = GetMilliSeconds(arrayDic[3], sortingAlgorithm);
            long n4Time = GetMilliSeconds(arrayDic[4], sortingAlgorithm);
            Console.WriteLine($"{GapFormatted(n0Time.ToString())}  {GapFormatted(n1Time.ToString())}  {GapFormatted(n2Time.ToString())}  {GapFormatted(n3Time.ToString())}  {GapFormatted(n4Time.ToString())}  {GapFormatted(SortingName)}");       
        }

        static long GetMilliSeconds(int[] array, ISorting<int> sortingAlgorithm)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sortingAlgorithm.Sort(array);
            stopwatch.Stop();
            long nTime = stopwatch.ElapsedTicks;
            stopwatch.Reset();
            return nTime;
        }
    }
}

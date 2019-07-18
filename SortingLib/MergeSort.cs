using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLib
{
    public class MergeSort<T> : ISorting<T> where T : IComparable, IComparable<T>
    {
        public void Sort(T[] array)
        {
            var result = mergeSort(new List<T>(array));
            result.CopyTo(array, 0);
        }

        /* For example
         
          12,25,15,14,8,5,24,13 
          
          12,25,15,14  |  8,5,24,13

          12,25  |  15,14  | 8,5  |  24,13

          12  |  25  |  15 |  14  |  8  |  5  |  24  |  13

          12,25  |  14,15  | 5,8  |  13,24

          12,14,15,25      |      5,8,13,24 

          5,8,12,13,14,15,24,25
            
        */

        private List<T> mergeSort(List<T> array)
        {
            if (array.Count == 1)
                return array;

            int nleft  = (array.Count / 2);
            int nright = array.Count - nleft;

            // we are trying to divide the array to two part until every array has one element. 

            List<T> leftArray  = new List<T>();
            List<T> rightArray = new List<T>();

            for (int i = 0; i < nleft; i++)
                leftArray.Add(array[i]);

            for (int i = nleft; i < array.Count; i++)
                rightArray.Add(array[i]);

            leftArray  = mergeSort(leftArray);  //Every part knows which main part belongs to.Division continues until array has one element.   
            rightArray = mergeSort(rightArray); 

            return merge(leftArray, rightArray); // Every binary part is compared with each other. if it needs to swap according to comparing, They are swapped and merged
                                                 // This process continues by recursively until all items merged again. 
        }

        private List<T> merge(List<T> left, List<T> right)
        {
            List<T> merged = new List<T>(left.Count + right.Count);

            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0].CompareTo(right[0]) < 0)  // if left[0] < right[0] 
                {
                    merged.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    merged.Add(right[0]);
                    right.RemoveAt(0);
                }
             }

            while (left.Count > 0)
            {
                merged.Add(left[0]);
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                merged.Add(right[0]);
                right.RemoveAt(0);
            }

            return merged;
        }



    }
}

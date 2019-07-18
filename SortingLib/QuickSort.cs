using System;
using System.Collections.Generic;

namespace SortingLib
{
    public class QuickSort<T> : ISorting<T> where T : IComparable, IComparable<T>
    {
        public void Sort(T[] array) 
        {
            int start = 0;
            int end   = array.Length - 1;
            this.quickSort(array, start, end);
        }

        private void quickSort(T[] array,int start,int end) 
        {
            int i = start;         // i = this is the pointer which moves left to right.
            int j = end;           // j = this is the pointer which moves right to left.
            T temp;                // temp is for swaping

            T pivot = array[(start + end) / 2]; // this is a pivot element. We choose pivot element from middle of the array.
                                                // The pivot may be chosen from a different position in the array as well.
            do
            {
                while (array[i].CompareTo(pivot) < 0)   // if array[i] < pivot, we move the "i" pointer to right until the condition is false value.
                    i++;
                while (array[j].CompareTo(pivot) > 0) // if array[j] > pivot, we move the "j" pointer to left until the condition is false value.
                    j--;

                if (i <= j)               // if there is an element is greater than pivot at the left side of the pivot                                                                  
                {                         // if there is an element is less than pivot at the right side of the pivot  
                    temp = array[i];      // we are swaping them.   All of the items which are the  greater than the pivot should be right side of the pivot
                    array[i] = array[j];                        //  All of the items which are the less than the pivot should be left side of the pivot
                    array[j] = temp;
                    i++;  // we move the pointers to right and left.
                    j--;
                }
            } while (i <= j);

            // When it exited the "while" loop, this means that all elements had been compared to the pivot 

            //Partition
            if (start < j)      // if it is true, this means that there is a part at the left side of the "j" which will be evaluated and may be sorted    
                quickSort(array, start, j);

            if (i < end)        // if it is true, this means that there is a part at the right side of the "i" which will be evaluated and may be sorted    
                quickSort(array, i, end);
        }

     


    }
}

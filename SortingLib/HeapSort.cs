using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLib
{
    public class HeapSort<T> : ISorting<T> where T : IComparable, IComparable<T>
    {
        public void Sort(T[] array)
        {
            heapSort(array);
        }

        private void heapSort(T[] array)
        {
            int n = array.Length;

            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(array, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end 
                T temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // call max heapify on the reduced heap 
                heapify(array, i, 0);
            }
        }

        // To heapify a subtree rooted with node i which is 
        // an index in arr[]. n is size of heap 
        void heapify( T[] array, int n, int i)
        {
            int largest = i;  // Initialize largest as root 
            int left = 2 * i + 1;  // left = 2*i + 1 
            int right = 2 * i + 2;  // right = 2*i + 2 

            // If left child is larger than root 
            if (left < n && array[left].CompareTo( array[largest]) > 0)
                largest = left;

            // If right child is larger than largest so far 
            if (right < n && array[right].CompareTo(array[largest]) >0 )
                largest = right;

            // If largest is not root 
            if (largest != i)
            {
                T swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                // Recursively heapify the affected sub-tree 
                heapify(array, n, largest);
            }
        }

    }
}

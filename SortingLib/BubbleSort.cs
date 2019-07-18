using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLib
{
    public class BubbleSort<T> : ISorting<T> where T : IComparable, IComparable<T>
    {
        public void Sort(T[] array)
        {
            bubbleSort(array);
        }

        private void bubbleSort(T[] array)
        {
            T temp;
            bool swapped = false;

            for (int i = 0; i < array.Length-1; i++)
            {
                swapped = false;

                for (int j = 0; j < array.Length-1 ; j++)
                {
                    if (array[j].CompareTo(array[j + 1])>0)  // if array[j] > array[j + 1]
                    {
                        temp = array[j];
                        array[j] = array[j+1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) // if swapped is false, all items are just sorted
                    break;
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLib
{
    public class SelectionSort<T> : ISorting<T> where T : IComparable, IComparable<T>
    {
        public void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i+1 ; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                        minIndex = j;
                }

                T temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLib
{
    public class InsertionSort<T> : ISorting<T> where T: IComparable,IComparable<T>
    {
        public void Sort(T[] array)
        {
            var result = insertionSort(array);
            result.CopyTo(array);
        }

        private List<T> insertionSort(T[] array)
        {
            var unsortedList = new List<T>(array);
            var sortedList   = new List<T>();

            T value;
            while (unsortedList.Count > 0)  // all elements in unsortedList evaluate and insert into sortedList by comparing with sortedList
            {
                value = unsortedList[0];

                if (sortedList.Count == 0)
                {
                    sortedList.Add(value);
                    unsortedList.RemoveAt(0);
                    continue;
                }

                int j = 0;
                for (int i = 0; i < sortedList.Count; i++)
                {
                    if (value.CompareTo(sortedList[i]) > 0)
                        j++;
                    else
                        break;
                }

                if (j == sortedList.Count -1 && sortedList.Count > 1 )
                    sortedList.Add(value);
                else
                    sortedList.Insert(j, value);

                unsortedList.RemoveAt(0);
            }

            return sortedList;
        }
    }
}

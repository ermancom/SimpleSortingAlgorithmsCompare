using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLib
{
    public interface ISorting<T> 
    {
        void Sort(T[] array);
    }
}

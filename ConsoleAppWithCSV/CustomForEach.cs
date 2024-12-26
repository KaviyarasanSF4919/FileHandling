using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppWithCSV
{
    /// <summary>
    /// <see cref="CustomList"/> is a partial class to handle foreach struchture
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public partial class CustomList<Type>:IEnumerable, IEnumerator
    {
        int position;
        //Get
        public IEnumerator GetEnumerator()
        {
            position=-1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position=-1;
        }
        public Object Current{get{return _array[position];}}
    }
}
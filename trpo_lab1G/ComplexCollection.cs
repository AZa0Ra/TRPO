using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo_lab1
{
    internal class ComplexCollection<T> : ComplexNum, ICollection<T>
    {
        Stack<T> compCol1 = new Stack<T>();

        Stack compCol2 = new Stack();

        public int Count => compCol1.Count + compCol2.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            compCol1.Push(item);
            compCol2.Push(item);

        }

        public void Clear()
        {
            compCol1.Clear();
            compCol2.Clear();
        }

        public bool Contains(T item)
        {
            return compCol1.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            compCol1.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ComplexNum> GetEnumerator()
        {
            return compCol1 as IEnumerator<ComplexNum>;
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
            // help
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return compCol2.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return compCol1.GetEnumerator();
        }

        public Stack<T> GetStack() 
        {
            return compCol1;
        }

        public Stack GetArrayStack()
        {
            return compCol2;
        }



    }
}

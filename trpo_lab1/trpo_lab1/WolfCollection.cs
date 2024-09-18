using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo_lab1
{
    internal class WolfCollection : ICollection<Wolf>
    {
        ArrayList arrayList;
        List<Wolf> list;
        public WolfCollection()
        {
            arrayList = new ArrayList();
            list = new List<Wolf>();
        }

        public int Count => arrayList.Count;

        public bool IsReadOnly => false;

        public void Add(Wolf item)
        {
            arrayList.Add(item);
            list.Add(item);
        }

        public void Clear()
        {
            arrayList.Clear();
            list.Clear();
        }

        public bool Contains(Wolf item)
        {
            return list.Contains(item);
        }

        public void CopyTo(Wolf[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Wolf> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public bool Remove(Wolf item)
        {
            if (list.Contains(item))
            {
                arrayList.Remove(item);
                list.Remove(item);
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arrayList.GetEnumerator();
        }

        public ArrayList GetArrayList()
        {
            return arrayList;
        }

        public List<Wolf> GetList()
        {
            return list;
        }
    }
}

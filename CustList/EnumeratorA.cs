using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustList
{
    internal class EnumeratorA<T> : IEnumerator<T>
    {
        int currentIndex = 0;
        public object Current => this.datas.current;

        T IEnumerator<T>.Current => this.datas.current.Data;

        CustomList<T> datas;
        public EnumeratorA(CustomList<T> datas)
        {
            this.datas = datas;
        }

        public bool MoveNext()
        {
            if (currentIndex + 1 >= this.datas.GetLength())
                return false;

            currentIndex++;
            this.datas.current = this.datas.current.Next;
            return true;
        }


        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {

        }
    }
}

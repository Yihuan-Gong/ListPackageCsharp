using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollection
{
    internal class Enumerator : IEnumerator
    {
        Students students = null;
        int index = -1;
        public object Current => students[index];

        public Enumerator(Students students)
        {
            this.students = students;
        }

        public bool MoveNext()
        {
            index++;
            return index < students.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}

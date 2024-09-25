using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollection
{
    internal class Students
    {
        public String Name1 { get; set; }
        public String Name2 { get; set; }
        public String Name3 { get; set; }
        public String Name4 { get; set; }
        public String Name5 { get; set; }

        public int Count = 5;
        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Name1;
                    case 1: return Name2;
                    case 2: return Name3;
                    case 3: return Name4;
                    case 4: return Name5;
                }

                return "";
            }

        }

        private int index = -1;
        public void Add(string name)
        {
            index++;
            switch (index)
            {
                case 0:
                    Name1 = name;
                    break;
                case 1:
                    Name2 = name;
                    break;
                case 2:
                    Name3 = name;
                    break;
                case 3:
                    Name4 = name;
                    break;
                case 4:
                    Name5 = name;
                    break;
            }

        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}

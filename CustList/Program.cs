using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var list = new CustomList<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //foreach (var item in list)
            //{
            //    Console.WriteLine(((Node<int>)item).Data);
            //}

            Console.ReadKey();
        }
    }
}

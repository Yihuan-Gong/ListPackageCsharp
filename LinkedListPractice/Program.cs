using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // any contains
            // first, firstOrDefault
            // last , lastOrDefault
            // forEach
            // skip(2) take(3) => 假設take的筆數不滿足三筆，要能回傳所有筆數
            // orderBy orderByDesc


            LinkList<int> list1 = new LinkList<int>();

            list1.Add(3);
            list1.Add(4);
            list1.Add(9);
            list1.Add(6);
            list1.Add(2);

            foreach (var data in list1)
            {
                Console.WriteLine(data);
            }

            foreach (var data in list1)
            {
                Console.WriteLine(data);
            }




            //Console.WriteLine("--");
            //Console.WriteLine(list1.Any(x => x % 2 == 0));
            //Console.WriteLine(list1.Contains(6));
            //Console.WriteLine(list1.First());
            //Console.WriteLine(list1.First(x => x == 4));
            //Console.WriteLine(list1.Last());

            ////Console.WriteLine("--");
            ////list1.Take(-1).ForEach(x => Console.WriteLine(x));
            ////Console.WriteLine("--");
            ////list1.Take(0).ForEach(x => Console.WriteLine(x));
            ////Console.WriteLine("--");
            ////list1.Take(2).ForEach(x => Console.WriteLine(x));
            ////Console.WriteLine("--");
            ////list1.Take(5).ForEach(x => Console.WriteLine(x));
            ////Console.WriteLine("--");
            ////list1.Take(7).ForEach(x => Console.WriteLine(x));
            //Console.WriteLine("--");
            //list1.OrderBy(x => -x).ForEach(x => Console.WriteLine(x));
            //Console.WriteLine("--");
            //list1.OrderByDescending(x => x).ForEach(x => Console.WriteLine(x));





            //Console.WriteLine("--");
            List<int> list = new List<int>() { 1, 8, 3, 5 };
            //list.Take(6).ToList().ForEach(x => Console.WriteLine(x));
            //Console.WriteLine("--");
            //list.OrderBy(x => -x).ToList().ForEach(x => Console.WriteLine(x));






            Console.ReadKey();



        }
    }
}

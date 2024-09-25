using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Students students = new Students();
            #region 建立學生資料
            students.Add("Leo");
            students.Add("Alex");
            students.Add("Alice");
            students.Add("Bob");
            students.Add("Kelly");

            #endregion

            Stack<int> stack = new Stack<int>();



            //for (int i = 0; i < students.Count; i++)
            //{
            //    Console.WriteLine(students[i]);
            //}


            foreach (var data in students)
            {
                Console.WriteLine(data);
            }

            Console.ReadKey();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListYieldReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkList<int> list1 = new LinkList<int>();

            list1.Add(3);
            list1.Add(4);
            list1.Add(9);
            list1.Add(6);
            list1.Add(2);

            //foreach (var data in list1.GetMembers())
            //{
            //    Console.WriteLine(data);
            //}

            //foreach (var data in list1)
            //{
            //    Console.WriteLine(data);
            //}

            var studensList = new LinkList<Student>()
            {
                new Student {StudentId = 9},
                new Student {StudentId = 2},
                new Student {StudentId = 3},
                new Student {StudentId = 14},
                new Student {StudentId = 5},
            };
            var sortedStudentList = studensList.OrderBy(s => s.StudentId);
            foreach (var student in sortedStudentList)
            {
                Console.WriteLine(student.StudentId);
            }

            Console.ReadKey();
        }
    }
}

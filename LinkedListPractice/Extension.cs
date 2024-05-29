using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPractice
{
    internal static class Extension
    {
        public static LinkList<T> Where<T>(this LinkList<T> list, Func<T, bool> expression)
        {
            LinkList<T> results = new LinkList<T>();
            Node<T> current = list.GetHead();

            while (current != null)
            {
                if (expression.Invoke(current.Data))
                {
                    results.Add(current.Data);
                }

                current = current.Next;
            }

            return results;
        }

        public static List<Tout> Select<Tin, Tout>(this LinkList<Tin> list, Func<Tin, Tout> expression)
        {
            List<Tout> results = new List<Tout>();
            Node<Tin> current = list.GetHead();

            while (current != null)
            {
                results.Add(expression.Invoke(current.Data));
                current = current.Next;
            }

            return results;
        }

        public static bool Any<T>(this LinkList<T> list, Func<T, bool> expression)
        {
            Node<T> current = list.GetHead();

            while (current != null)
            {
                if (expression.Invoke(current.Data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public static bool Contains<T>(this LinkList<T> list, int data)
        {
            Node<T> current = list.GetHead();

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public static T First<T>(this LinkList<T> list)
        {
            if (list.GetLength() == 0)
                throw new ArgumentNullException();

            return list.GetHead().Data;
        }

        public static T First<T>(this LinkList<T> list, Func<T, bool> expression)
        {
            if (list.GetLength() == 0)
                throw new ArgumentNullException();

            Node<T> current = list.GetHead();
            while (current != null)
            {
                if (expression.Invoke(current.Data))
                    return current.Data;

                current = current.Next;
            }

            throw new InvalidOperationException();
        }

        public static T FirstOrDefault<T>(this LinkList<T> list)
        {
            if (list.GetLength() == 0)
                return default(T);

            return list.GetHead().Data;
        }

        public static T FirstOrDefault<T>(this LinkList<T> list, Func<T, bool> expression)
        {
            if (list.GetLength() == 0)
                return default(T);

            Node<T> current = list.GetHead();
            while (current != null)
            {
                if (expression.Invoke(current.Data))
                    return current.Data;

                current = current.Next;
            }

            return default(T);
        }

        public static T Last<T>(this LinkList<T> list)
        {
            if (list.GetLength() == 0)
                throw new ArgumentNullException();

            Node<T> current = list.GetHead();
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public static T LastOrDefault<T>(this LinkList<T> list)
        {
            if (list.GetLength() == 0)
                return default(T);

            Node<T> current = list.GetHead();
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public static void ForEach<T>(this LinkList<T> list, Action<T> action)
        {
            if (list.GetLength() == 0)
                return;

            Node<T> current = list.GetHead();
            while (current != null)
            {
                action.Invoke(current.Data);
                current = current.Next;
            }
        }

        public static LinkList<T> Skip<T>(this LinkList<T> list, int count)
        {
            if (count < 0)
                count = 0;

            if (list.GetLength() == 0 || count >= list.GetLength())
                return new LinkList<T>();

            LinkList<T> result = new LinkList<T>();
            Node<T> current = list.GetHead();

            for (int i = 0; i < list.GetLength(); i++)
            {
                if (i >= count)
                    result.Add(current.Data);

                current = current.Next;
            }

            return result;
        }

        public static LinkList<T> Take<T>(this LinkList<T> list, int count)
        {
            if (count < 0)
                count = 0;

            if (count >= list.GetLength())
                return list;

            LinkList<T> result = new LinkList<T>();
            Node<T> current = list.GetHead();

            for (int i = 0; i < count; i++)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result;
        }

        //public static List<int> OrderBy(this LinkList list, Func<int, int> keySelector)
        //{
        //    if (list.GetLength() == 0)
        //        return new List<int>();

        //    List<int> result = new List<int>();
        //    list.ForEach(x =>
        //    {
        //        result.Add(keySelector.Invoke(x));
        //    });

        //    result.Sort((x, y) => x.CompareTo(y));
        //    return result;
        //}

        //public static List<int> OrderByDescending(this LinkList list, Func<int, int> keySelector)
        //{
        //    if (list.GetLength() == 0)
        //        return new List<int>();

        //    List<int> result = new List<int>();
        //    list.ForEach(x =>
        //    {
        //        result.Add(keySelector.Invoke(x));
        //    });

        //    result.Sort((x, y) => y.CompareTo(x));
        //    return result;
        //}
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace LinkedListYieldReturn
{
    public class LinkList<T> : IEnumerable<T>
    {
        Node<T> head;
        int length;

        public LinkList()
        {
            head = null;
            length = 0;
        }

        public Node<T> GetHead()
        {
            return head;
        }

        public int GetLength()
        {
            return length;
        }

        public void Add(T data)
        {
            length++;

            if (head == null)
            {
                head = new Node<T>(data);
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(data);
            }
        }

        public void AddRange(LinkList<T> collection)
        {
            // Find the tail
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Append collection to the end of the list
            current.Next = collection.head;
            length += collection.length;
        }

        public void Insert(int index, T data)
        {
            if (index < 0) return;

            Node<T> newNode = new Node<T>(data);

            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
                length++;
            }
            else if (index > 0 && index < length)
            {
                Node<T> current = MoveTo(index - 1);

                newNode.Next = current.Next;
                current.Next = newNode;
                length++;
            }
            else
            {
                Add(data);
            }
        }

        public void Remove(T data)
        {
            if (head == null) return;

            length--;

            // Check if head need to be removed

            if (head.Data.Equals(data))
            {
                head = head.Next;
                return;
            }

            // Check if middle or tail need to be removed
            Node<T> current = head.Next;
            Node<T> prev = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    prev.Next = current.Next;
                    return;
                }

                prev = current;
                current = current.Next;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0) return;
            if (index > length - 1) return;

            length--;

            // Remove head
            if (index == 0)
            {
                head = head.Next;
                return;
            }

            // Remove middle or tail
            Node<T> current = head;
            Node<T> prev = null;
            for (int i = 0; i < index; i++)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = current.Next;
        }

        public void RemoveRange(int index, int count)
        {
            if (count <= 0) return;
            if (index < 0) return;
            if (index + (count - 1) > length - 1) return;

            if (index == 0)
            {
                head = MoveTo(count);
            }
            else
            {
                Node<T> current = MoveTo(index - 1);
                Node<T> next = MoveTo(index + count);
                current.Next = next;
            }

            length -= count;
        }

        public T[] ToArray()
        {
            T[] array = new T[length];
            Node<T> current = head;

            for (int i = 0; i < length; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }

            return array;
        }

        public void Print()
        {
            if (head == null) return;

            Node<T> current = head;
            while (true)
            {
                Console.WriteLine($" {current.Data} ");
                if (current.Next != null)
                    current = current.Next;
                else
                    break;
            }
        }



        Node<T> MoveTo(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }


        // 任何可以迭代的物件(IEnumerable<T>)
        // 都需要一個迭代器(IEnumerator<T>)
        // 所以我們需要在這裡實作迭代器
        public IEnumerator<T> GetEnumerator()
        {
            Console.WriteLine("a");

            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;

            }
        }

        //用return this來實作迭代器會出錯
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return (IEnumerator<T>)this;
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        // 如果不想實作迭代器，也可以封裝一個function
        // 來回傳可迭代物件(IEnumerable<T>)
        public IEnumerable<T> GetMembers()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // 這邊一樣不可以return this
        //public IEnumerable<T> GetMembers()
        //{
        //    return this;
        //}
    }
}

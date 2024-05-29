using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace LinkedListPractice
{
    public class LinkList<T> : IEnumerable<T>, IEnumerator<T>
    {
        Node<T> head;
        int length;
        int index;

        public T Current
        {
            get
            {
                T temp = MoveTo(index).Data;
                return temp;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                T temp = MoveTo(index).Data;
                return temp;
            }
        }

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
            }
            else if (index > 0 && index < length)
            {
                Node<T> current = MoveTo(index - 1);

                newNode.Next = current.Next;
                current.Next = newNode;
            }
            else
            {
                Add(data);
            }

            length++;
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


        public bool MoveNext()
        {
            index++;
            return index < length;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Reset();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine("b");

            Reset();
            return this;
        }

        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    Console.WriteLine("a");

        //    Node<T> current = head;
        //    while (current != null)
        //    {
        //        yield return current.Data;
        //        current = current.Next;
        //    }
        //}
    }
}

using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class SortedList<T> where T : IComparable<T>
    {
        private ListItem<T> _head;

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new ListItem<T>(value, null);
                return;
            }

            if (value.CompareTo(_head.Value) < 0)
            {
                _head = new ListItem<T>(value, _head);
                return;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (value.CompareTo(current.Next.Value) < 0)
                {
                    current.Next = new ListItem<T>(value, current.Next);
                    return;
                }

                current = current.Next;
            }

            current.Next = new ListItem<T>(value, null);
        }
    }

    class ListItem<T>
    {
        public T Value;
        public ListItem<T> Next;

        public ListItem(T value, ListItem<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
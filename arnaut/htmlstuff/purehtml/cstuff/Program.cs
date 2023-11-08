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
        public ListItem<T> Head {get; private set;}

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new ListItem<T>(value, null);
                return;
            }

            if (value.CompareTo(Head.Value) < 0)
            {
                Head = new ListItem<T>(value, Head);
                return;
            }

            var current = Head;
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
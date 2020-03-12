using System;

namespace BaseHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.AddAll(new int[] { 1, 2, 3, 4, 5 });

            list.Reverse();

            list.PrintList();
        }
    }
}



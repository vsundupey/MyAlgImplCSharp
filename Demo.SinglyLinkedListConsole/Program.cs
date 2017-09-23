using System;
using LinkedList.SinglyImpl;

namespace Demo.SinglyLinkedListConsole
{
    public class MyObj
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList<string>();
            
            list.Add("Jack1");
            list.Add("Jack2");
            list.Add("Jack3");
            list.Add("Jack4");
            
            list.PrintList();

            Console.WriteLine("Press 'Enter' for exit");
            Console.ReadLine();
        }
    }
}
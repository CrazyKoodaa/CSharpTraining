using System;
using System.Collections.Generic;

namespace stackLastInFirstOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Generate a stack with 4 items
            Stack<string> myStack = new Stack<string>();
            myStack.Push("first in line");
            myStack.Push("second in line");
            myStack.Push("third in line");
            myStack.Push("last in line");

            // Peek with a stack works just like it does with a queue
            Console.WriteLine($"Peek(): {myStack.Peek()}");

            // Pop pulls the next item from the Buttom of the stack
            Console.WriteLine($"Pop(): {myStack.Pop()}");
            Console.WriteLine($"Pop(): {myStack.Pop()}");

            Console.WriteLine($"Count: {myStack.Count}");
            myStack.Clear();
            Console.WriteLine($"Count after clear(): {myStack.Count}");
        }
    }
}

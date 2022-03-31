using System;
using System.Collections.Generic;

namespace queueVSstackVSlist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stack<string> myStack = new Stack<string>();
            myStack.Push("first");
            myStack.Push("second");
            myStack.Push("third");
            myStack.Push("last");

            Queue<string> myQueue = new Queue<string>(myStack);
            List<string> myList = new List<string>(myQueue);
            Stack<string> myStack2 = new Stack<string>(myList);

            Console.WriteLine($@"myQueue has {myQueue.Count} items
myList has {myList.Count} items
anotherStack has {myStack2.Count} items");
        }
    }
}

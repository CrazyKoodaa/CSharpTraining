using System;
using System.Collections.Generic;

namespace queueFirstInFirstOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create a Queue and add four strings to it
            Queue<string> myQueue = new Queue<string>();
            myQueue.Enqueue("first in line");
            myQueue.Enqueue("second in line");
            myQueue.Enqueue("third in line");
            myQueue.Enqueue("last in line");

            // Peek "looks" at the first item in the queue without removing it
            Console.WriteLine($"Peek() returned: {myQueue.Peek()}");

            // Dequeue pulls the next item from the FRONT of the queue
            Console.WriteLine($"The first Dequeue() returned: {myQueue.Dequeue()}");
            Console.WriteLine($"The second Dequeue() returned: {myQueue.Dequeue()}");
            
            // check how many items are in the queue
            Console.WriteLine($"Items in queue: {myQueue.Count}");
            foreach (var item in myQueue)
            {
                Console.WriteLine($"This is in the queue: {item}");
            }

            // Clear queue
            myQueue.Clear();
            Console.WriteLine($"Items in queue: {myQueue.Count}");
        }
    }
}

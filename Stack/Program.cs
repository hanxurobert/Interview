using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            var queue = new Queue();
            string[] values = new string[]{"1", "2", "3", "4", "5", "6"};

            foreach(var value in values) {
                stack.Add(value);
                queue.Add(value);
            }
            Console.WriteLine("Print stack values:");
            while(!stack.IsEmpty()) {
                var node = stack.Pop();
                Console.WriteLine(node.Data);
            }

            Console.WriteLine("Print queue values:");
            while(!queue.IsEmpty()) {
                var node = queue.Pick();
                Console.WriteLine(node.Data);
            }
        }
    }
}

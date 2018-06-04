using System;

namespace TripleStep
{
    class Program
    {
        static void Main(string[] args)
        {
            var tripleStep = new TripleStep();
            int n = 4;
            Console.WriteLine("The possiblity for {0} steps stair is {1}.", n, tripleStep.CountPossiblity(n));
        }
    }
}

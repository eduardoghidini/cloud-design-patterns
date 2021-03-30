using AvailabilityAndResiliencePatterns.CircuitBreaker;
using System;

namespace AvailabilityAndResiliencePatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var caller = new CircuitBreakCaller();
            caller.Execute();
        }
    }
}

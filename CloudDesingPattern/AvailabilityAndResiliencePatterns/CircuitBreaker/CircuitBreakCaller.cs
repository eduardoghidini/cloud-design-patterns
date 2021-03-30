using AvailabilityAndResiliencePatterns.ExternalServices;
using System;

namespace AvailabilityAndResiliencePatterns.CircuitBreaker
{
    public class CircuitBreakCaller
    {
        public void Execute()
        {
            var breaker = new CircuitBreaker();
            var service = new ExternalService();

            do
            {
                try
                {
                    breaker.ExecuteAction(() =>
                    {
                        int result = service.CallMe();
                        Console.WriteLine($"The result is {result}");
                    });
                }
                catch (CircuitBreakerOpenException ex)
                {
                    Console.WriteLine("Method not called");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generic error");
                }
                Console.ReadLine();

            } while (true);

        }
    }
}

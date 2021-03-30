using System;

namespace AvailabilityAndResiliencePatterns.CircuitBreaker
{
    public class CircuitBreakerOpenException : Exception
    {
        public CircuitBreakerOpenException(Exception lastException)
             : base("Method not called", lastException)
        {

        }
    }
}

using System;

namespace AvailabilityAndResiliencePatterns.CircuitBreaker
{
    public class CircuitBreakerStore : ICircuitBreakerStateStore
    {
        public CircuitBreakerStore()
        {
            State = CircuitBreakerStateEnum.Closed;
        }

        public CircuitBreakerStateEnum State { get; set; }

        public Exception LastException { get; set; }

        public DateTime LastChangeDateUtc { get; set; }

        public bool IsClosed
        {
            get
            {
                return State == CircuitBreakerStateEnum.Closed;
            }
        }

        public void HalfOpen()
        {
            State = CircuitBreakerStateEnum.HalfOpen;
        }

        public void Reset()
        {
            State = CircuitBreakerStateEnum.Closed;
        }

        public void Trip(Exception ex)
        {
            State = CircuitBreakerStateEnum.Open;
            LastException = ex;
            LastChangeDateUtc = DateTime.UtcNow;
        }
    }
}

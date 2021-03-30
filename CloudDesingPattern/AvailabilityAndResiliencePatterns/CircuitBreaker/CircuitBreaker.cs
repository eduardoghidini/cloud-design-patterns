using System;

namespace AvailabilityAndResiliencePatterns.CircuitBreaker
{
    public class CircuitBreaker
    {
        private readonly ICircuitBreakerStateStore stateStore
            = new CircuitBreakerStore();

        private readonly TimeSpan OpenTimeOutTime = new TimeSpan(0, 0, 10);

        public void ExecuteAction(Action action)
        {
            if (!stateStore.IsClosed)
            {
                if (stateStore.LastChangeDateUtc + OpenTimeOutTime < DateTime.UtcNow)
                {
                    try
                    {
                        stateStore.HalfOpen();
                        action();
                        stateStore.Reset();
                        return;
                    }
                    catch (Exception ex)
                    {
                        stateStore.Trip(ex);
                        throw;
                    }

                }

                throw new CircuitBreakerOpenException(stateStore.LastException);
            }

            try
            {
                action();
            }
            catch (Exception ex)
            {

                stateStore.Trip(ex);
                throw;
            }
        }

    }
}

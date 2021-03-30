using System;

namespace AvailabilityAndResiliencePatterns.ExternalServices
{
    public class ExternalService
    {
        private static Random random = new Random();

        private static int failureCount = 0;

        public int CallMe()
        {
            int randomNumber = random.Next();

            if (randomNumber % 2 == 0 && failureCount < 5)
            {
                failureCount++;
                throw new Exception("Non-transient Exception");
            }

            failureCount = 0;
            return randomNumber;
        }
    }
}

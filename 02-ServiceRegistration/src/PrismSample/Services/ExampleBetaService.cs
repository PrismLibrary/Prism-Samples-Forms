using System;

namespace PrismSample.Services
{
    public class ExampleBetaService : IExampleBetaService
    {
        public int NumberValue { get; set; }

        public ExampleBetaService()
        {
            Random rnd = new Random();
            NumberValue = rnd.Next(1, 1000);
        }
    }
}

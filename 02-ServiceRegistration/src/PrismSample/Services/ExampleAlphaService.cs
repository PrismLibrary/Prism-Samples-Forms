using System;

namespace PrismSample.Services
{
    public class ExampleAlphaService : IExampleAlphaService
    {
        public int NumberValue { get; set; }

        public ExampleAlphaService()
        {
            Random rnd = new Random();
            NumberValue = rnd.Next(1, 1000);
        }
    }
}

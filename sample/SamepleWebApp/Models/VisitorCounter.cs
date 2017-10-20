using System.Threading;

namespace SampleWebApp.Models
{
    public class VisitorCounter
    {
        private int counter;

        public int Get => counter;

        public int Increment() => Interlocked.Increment(ref counter);
    }
}
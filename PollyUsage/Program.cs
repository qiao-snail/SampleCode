using Polly;
using System;

namespace PollyUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            PolicyUnlity.Retry2().Execute(() => { ThrowFooException(); });
            Console.ReadKey();
        }

        static void ThrowFooException()
        {
            Console.WriteLine("ThrowFooException");
            throw new FooException();
        }
    }
    public static class PolicyUnlity
    {
        public static Policy Retry()
        {
            return Policy.Handle<FooException>().Retry(3);
        }
        public static Policy Retry1()
        {
            return Policy.Handle<FooException>().WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public static Policy Retry2()
        {
            return Policy.Handle<FooException>().WaitAndRetry(new[]{
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                });
        }
    }


    public class FooException : Exception
    {

    }
}

using Polly;
using System;

namespace PollyUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var poliy = PolicyDemo.RegisterPolicyBuilder();
            poliy.Execute(() => { ThrowFooException(); });
            Console.ReadKey();
        }

        static void ThrowFooException()
        {

            Console.WriteLine("ThrowFooException");
            throw new FooException();
        }
    }
    public class PolicyDemo
    {
        public static Policy RegisterPolicyBuilder()
        {
            return Policy.Handle<FooException>().Retry(3);
        }
    }


    public class FooException : Exception
    {

    }
}

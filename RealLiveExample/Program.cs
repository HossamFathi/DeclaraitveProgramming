using System;
using System.Linq;
using RealLiveExample.Demo;

namespace RealLiveExample
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderDiscounds.GetOrdersAfterDiscound().ToList().ForEach(order => Console.WriteLine("Discound is {0}", order.Discound));
        }
    }
}

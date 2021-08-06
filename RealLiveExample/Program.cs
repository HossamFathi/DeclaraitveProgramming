using System;
using System.Linq;
using RealLiveExample.CostOfShopping;
using RealLiveExample.CostOfShopping.Process;
using RealLiveExample.Data;
using RealLiveExample.Demo;

namespace RealLiveExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // calculate Discounds
            OrderDiscounds.GetOrdersAfterDiscound().ToList().ForEach(order => Console.WriteLine("Discound is {0}", order.Discound));

            // Calculate Cost Of Shipping 
            CostOfShopingAnOrder CalculationCost = new CostOfShopingAnOrder(); /// generate Object 
            // get function Of Calculate Cost 
            Func<Order , double>  CalculateCost =  CalculationCost.ClacAdjustCostOfOrder(CalculationCost.processConfiguration, CalculationCost.ShippingPath, CalculationCost.AvailabilityPath);
            // claculate cost and Print 
            Console.WriteLine(CalculateCost(CalculationCost.order).ToString());
        }


     

    }
}

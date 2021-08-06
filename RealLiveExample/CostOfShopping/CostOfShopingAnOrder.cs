using RealLiveExample.Data;
using System;
using RealLiveExample.ExtantionMethods;
using System.Collections.Generic;
using RealLiveExample.CostOfShopping.Process;
using RealLiveExample.CostOfShopping.Path;
using System.Linq;
using static RealLiveExample.CostOfShopping.Helper.Enumes;

namespace RealLiveExample.CostOfShopping
{
    public class CostOfShopingAnOrder
    {
        #region variavbels

        public ProcessConfig processConfiguration;
        public Order order;
        public AvailabilityPath AvailabilityPath;
        public ShippingPath ShippingPath; 
        #endregion

        /// <summary>
        /// defult constructor  to call setConfiguration function
        /// </summary>
        public CostOfShopingAnOrder()
        {
            setConfiguration();
        }


        #region Composition
        /// <summary>
        /// use configuraiton to choise path of calcaulate Freight for Order 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="shippingPath"></param>
        /// <returns></returns>
        private Func<Order, Freight> ShippingPathFunc(ProcessConfig config, ShippingPath shippingPath)
        {



            return shippingPath.InvoiceFunction.Where(path => path.invoiceChoice == config.InvoiceChoice).Select(func => func.CalcInvoice).FirstOrDefault()
                 .Composit(shippingPath.ShippingFunction.Where(path => path.shippingchoice == config.ShippingChoice).Select(func => func.CalcShipping).FirstOrDefault()).Composit(shippingPath.FreightFunction.Where(path => path.freightChoice == config.FreightChoice).Select(func => func.CalcShipping).FirstOrDefault());


        }
        /// <summary>
        /// use configuraiton to choise path of calcaulate Shipping date for Order  
        /// </summary>
        /// <param name="config"></param>
        /// <param name="availabilityPath"></param>
        /// <returns></returns>
        private Func<Order, ShippingDate> AviliabilityPathFunc(ProcessConfig config, AvailabilityPath availabilityPath)
        {


            return availabilityPath.AviliabilityFunction.Where(path => path.availabilityChoice == config.AvailabilityChoice).Select(func => func.CalcAvailiability).FirstOrDefault()
                .Composit(availabilityPath.ShippingDateFunction.Where(path => path.shippingDateChoice == config.ShippingDateChoice).Select(func => func.CalcShippingDate).FirstOrDefault());

        }

        #endregion


        private   double AdjustCost(Func<Order, Freight> CalcFreight, Func<Order, ShippingDate> CalcShippingDate, Order order)
        {

            var Fright = CalcFreight(order);
            var ShippingDate = CalcShippingDate(order);
            Console.WriteLine("Day OF Shipping is {0}", ShippingDate.date.DayOfWeek.ToString());

            double Cost = ShippingDate.date.DayOfWeek.ToString() == "Monday" ? Fright.cost + 10000 : Fright.cost + 50000;
            return Cost;

        }

        /// <summary>
        /// 
        /// use configuration  and  all functions in shipping path  and  Availability Path to determin any path  and calc  cost 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="shippingPath"></param>
        /// <param name="availabilityPath"></param>
        /// <returns></returns>
        public Func<Order, double> ClacAdjustCostOfOrder(ProcessConfig config, ShippingPath shippingPath, AvailabilityPath availabilityPath)
        {

            return (order) => AdjustCost(ShippingPathFunc(config, shippingPath), AviliabilityPathFunc(config, availabilityPath), order);
        }


        /// <summary>
        /// set  defult  Configuration for Testing 
        /// </summary>
        private  void setConfiguration()
        {
            this.processConfiguration = new ProcessConfig();
            this.order = new Order();
            this.AvailabilityPath = new AvailabilityPath();
            this.ShippingPath = new ShippingPath();

            processConfiguration.InvoiceChoice = InvoiceChoice.Inv3;
            processConfiguration.ShippingChoice = ShippingChoice.Sh2;
            processConfiguration.FreightChoice = FreightChoice.fr2;
            processConfiguration.AvailabilityChoice = AvailabilityChoice.AV2;
            processConfiguration.ShippingDateChoice = ShippingDateChoice.SD3;


          
        }
    }
}

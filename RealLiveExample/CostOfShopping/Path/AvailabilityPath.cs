using RealLiveExample.Data;
using System;
using System.Collections.Generic;
using static RealLiveExample.CostOfShopping.Helper.Enumes;

namespace RealLiveExample.CostOfShopping.Path
{
    public class AvailabilityPath
    {
        public List<(ShippingDateChoice shippingDateChoice, Func<Availiablity, ShippingDate> CalcShippingDate)> ShippingDateFunction;
        public List<(AvailabilityChoice availabilityChoice, Func<Order, Availiablity> CalcAvailiability)> AviliabilityFunction;

        /// <summary>
        /// default Constractor Full Data 
        /// </summary>
        public AvailabilityPath()
        {
            AviliabilityFunction = new List<(AvailabilityChoice availabilityChoice, Func<Order, Availiablity> CalcAvailiability)> 
            {
                (AvailabilityChoice.AV1 , CalcAvaliablityFromOrder),
                (AvailabilityChoice.AV2 , CalcAvaliablityFromOrder1),
                (AvailabilityChoice.AV3 , CalcAvaliablityFromOrder2),
            };
            ShippingDateFunction = new List<(ShippingDateChoice shippingDateChoice, Func<Availiablity, ShippingDate> CalcShippingDate)> 
            { 
                (ShippingDateChoice.SD1 ,CalcShippingDateFromAvailiability) ,
                (ShippingDateChoice.SD2 ,CalcShippingDateFromAvailiability1) ,
                (ShippingDateChoice.SD3 ,CalcShippingDateFromAvailiability2) ,

            };


        }
        // Function have diffreent implemanteition 

        #region Shipping Date
        public  ShippingDate CalcShippingDateFromAvailiability(Availiablity availiablity)
        {

            return new ShippingDate { date = DateTime.Now.AddDays(1) };

        }
        public  ShippingDate CalcShippingDateFromAvailiability1(Availiablity availiablity)
        {

            return new ShippingDate { date = DateTime.Now.AddDays(2) };

        }
        public  ShippingDate CalcShippingDateFromAvailiability2(Availiablity availiablity)
        {

            return new ShippingDate { date =  DateTime.Now.AddDays(3) };

        }
        #endregion
        #region Availiabilty
        public  Availiablity CalcAvaliablityFromOrder(Order order)
        {

            return new Availiablity { };

        }
        public  Availiablity CalcAvaliablityFromOrder1(Order order)
        {

            return new Availiablity { };

        }
        public  Availiablity CalcAvaliablityFromOrder2(Order order)
        {

            return new Availiablity { };

        }
        #endregion
    }
}

using RealLiveExample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealLiveExample.CostOfShopping.Helper.Enumes;

namespace RealLiveExample.CostOfShopping.Path
{
   public class ShippingPath
    {
        public List<(InvoiceChoice invoiceChoice, Func<Order, Invoice> CalcInvoice)> InvoiceFunction;
        public  List<(ShippingChoice shippingchoice, Func<Invoice , Shipping> CalcShipping)> ShippingFunction;
        public  List<(FreightChoice freightChoice, Func<Shipping , Freight> CalcShipping)> FreightFunction;

        /// <summary>
        /// default Constractor Full Data 
        /// </summary>
        public ShippingPath()
        {

            InvoiceFunction = new List<(InvoiceChoice invoiceChoice, Func<Order, Invoice> CalcInvoice)>
            {
                (InvoiceChoice.Inv1 , CalcInvoiceFromOrder),
                (InvoiceChoice.Inv2 , CalcInvoiceFromOrder1),
                (InvoiceChoice.Inv3 , CalcInvoiceFromOrder2),


            };
            ShippingFunction = new List<(ShippingChoice shippingchoice, Func<Invoice, Shipping> CalcShipping)> {

                (ShippingChoice.Sh1 , ClacShippingFromInvoice),
                (ShippingChoice.Sh2 , ClacShippingFromInvoice1),
                (ShippingChoice.Sh3 , ClacShippingFromInvoice2),


            };
            FreightFunction = new List<(FreightChoice freightChoice, Func<Shipping, Freight> CalcShipping)>
            {

                (FreightChoice.fr1 , CalcFreightFromShiping) ,
                (FreightChoice.fr2 , CalcFreightFromShiping1) ,
                (FreightChoice.fr3 , CalcFreightFromShiping2) ,
            };
        }


        // Function have diffreent implemanteition 
        #region Shipping
        private Shipping ClacShippingFromInvoice(Invoice invoice)
        {

            return new Shipping {  };
        }
        private Shipping ClacShippingFromInvoice1(Invoice invoice)
        {

            return new Shipping { };
        }
        private Shipping ClacShippingFromInvoice2(Invoice invoice)
        {

            return new Shipping { };
        }
        #endregion

        #region Invoice
        private Invoice CalcInvoiceFromOrder(Order order)
        {

            return new Invoice {  };
           
        }
        private Invoice CalcInvoiceFromOrder1(Order order)
        {

            return new Invoice { };
           
        }
        private Invoice CalcInvoiceFromOrder2(Order order)
        {

            return new Invoice { };
          

        }
        #endregion

        #region Freight
        private Freight CalcFreightFromShiping(Shipping shipping)
        {


            return new Freight { cost=10 };

        }
        private Freight CalcFreightFromShiping1(Shipping shipping)
        {


            return new Freight { cost=20 };

        }
        private Freight CalcFreightFromShiping2(Shipping shipping)
        {


            return new Freight { cost=30 };

        }
        #endregion
     
    }
}

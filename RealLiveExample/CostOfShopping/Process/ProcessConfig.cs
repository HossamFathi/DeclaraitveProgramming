
using static RealLiveExample.CostOfShopping.Helper.Enumes;

namespace RealLiveExample.CostOfShopping.Process
{
    public class ProcessConfig
    {

        public InvoiceChoice InvoiceChoice { get; set; }
        public ShippingChoice ShippingChoice { get; set; }
        public FreightChoice FreightChoice { get; set; }
        public AvailabilityChoice AvailabilityChoice { get; set; }
        public ShippingDateChoice ShippingDateChoice { get; set; }
    }
}

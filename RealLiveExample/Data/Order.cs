using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealLiveExample.Data
{
    public class Order
    {
        public int ID { get; set; }
        public int ProductIndex { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discound { get; set; }


    }
}

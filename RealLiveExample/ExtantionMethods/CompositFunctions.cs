using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealLiveExample.ExtantionMethods
{
   public static class CompositFunctions
    {

        public static Func<T1, T3> Composit<T1, T2, T3>(this Func<T1, T2> func1, Func<T2, T3> func2) {

            return (x) => func2(func1(x));
        
        }
    }
}

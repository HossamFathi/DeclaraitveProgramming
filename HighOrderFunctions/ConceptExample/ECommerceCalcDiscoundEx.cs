using System;
using System.Collections.Generic;
using System.Linq;
using HighOrderFunctions.Data;

namespace HighOrderFunctions.ConceptExample
{
   public class ECommerceCalcDiscoundEx
    {
        #region Decleration 


        #region DelegateDecleration

        Func<int, (double, double)> ProductFoodDelg = CalcProductParameterFood;
        Func<int, (double, double)> ProductBeverageDelg = CalcProductParameterBeverage;
        Func<int, (double, double)> ProductRawMaterialDelg = CalcProductParameterRawMaterial;

        #endregion

        Order Order = new Order { ID = 1, ProductIndex = 100, Quantity = 20, UnitPrice = 4 };

        #endregion

        #region Helper 

        private static (double x1, double x2) CalcProductParameterRawMaterial(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 400), x2: ProductIndex / (double)(ProductIndex + 700));
        }
        private static (double x1, double x2) CalcProductParameterBeverage(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 300), x2: ProductIndex / (double)(ProductIndex + 400));
        }
        private static (double x1, double x2) CalcProductParameterFood(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 100), x2: ProductIndex / (double)(ProductIndex + 300));
        }

        #endregion

        public static double CalcDescound(Func<int , (double , double)> F , Order order) {

            (double Pa1, double Pa2) parameter = F(order.ProductIndex);
            return parameter.Pa1 * order.Quantity + parameter.Pa2 * order.UnitPrice; 
        
        }

        public ECommerceCalcDiscoundEx(ProductType product) 
        {

            Func<int, (double, double)> discoundFunc = product == ProductType.Food ? ProductFoodDelg : (product == ProductType.Beverage ? ProductBeverageDelg : ProductRawMaterialDelg);
            Console.WriteLine(CalcDescound(discoundFunc, Order).ToString());
        }
    }
}

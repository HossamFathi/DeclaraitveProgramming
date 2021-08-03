using System;
using System.Collections.Generic;
using System.Linq;
using RealLiveExample.Data;

namespace RealLiveExample.Demo
{
   public class OrderDiscounds
    {
        #region data
        private static List<Order> Orders = new List<Order>()
        {

            new Order() ,
            new Order(),
            new Order()

        };
        #endregion

        /// <summary>
        /// Get All Orders after Calc Discound For each 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Order> GetOrdersAfterDiscound() {

         var OrdersAfterDiscound =  Orders.Select((order) => GetOrderWithDisound(order, GetDiscoundRules()));
            return OrdersAfterDiscound;


        }
        /// <summary>
        /// Get all Disounds Ruls 
        /// </summary>
        /// <returns></returns>
        private static List<(Func<Order , bool> IsQualifyRule, Func<Order,double> RuleCondition)> GetDiscoundRules()
        {
            List<(Func<Order, bool> IsQualifyRule, Func<Order, double> RuleCondition)> DiscoundsRules = new List<(Func<Order, bool>, Func<Order, double>)>
            {
                (IsQualifiedRoleA , A),
                (IsQualifiedRoleB , B) ,
                (IsQualifiedRoleC , C),
                (IsQualifiedRoleD , D)

            };

            return DiscoundsRules;
        }

        /// <summary>
        /// Get order After calc Discound according to rule conditions 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="Roles"></param>
        /// <returns></returns>
        private static Order GetOrderWithDisound(Order order, List<(Func<Order, bool> IsQualifyRule, Func<Order, double> RuleCondition)> Roles)
        {
            var Discound = Roles.Where(role => role.IsQualifyRule(order)).Select(rol => rol.RuleCondition(order)).OrderBy(discound => discound).Take(3).Average();
            order.Discound = Discound;
            return order;
        }

        #region Rules
        private static bool IsQualifiedRoleA(Order order)
        {
            
            return true;
        }
        private static double A(Order order)
        {
            return 1;

        }
        private static bool IsQualifiedRoleB(Order order)
        {
            return true;
        }
        private static double B(Order order)
        {
            return 2;

        }

        private static bool IsQualifiedRoleC(Order order)
        {
            return true;
        }
        private static double C(Order order)
        {
            return 3;

        }
        private static bool IsQualifiedRoleD(Order order)
        {
            return true;
        }
        private static double D(Order order)
        {
            return 4;

        } 
        #endregion
    }
}

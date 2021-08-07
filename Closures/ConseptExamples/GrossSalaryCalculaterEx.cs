using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures.ConseptExamples
{
   public enum EmployeeCategory
    {

        first,
        second,
        third

    }
    public class GrossSalaryCalculaterEx
    {

        #region Decluration
        private List<(EmployeeCategory category, Func<double, double> GrossSalaryCalcFunc)> GrossSalaryFunctions; 
        #endregion
        public GrossSalaryCalculaterEx()
        {
            setdata();
        }
        private void setdata()
        {
            GrossSalaryFunctions = new List<(EmployeeCategory category, Func<double, double> GrossSalaryCalcFunc)>
            {
                (EmployeeCategory.first , GrossSalaryCalculaterFunction(1000)) ,
                (EmployeeCategory.second , GrossSalaryCalculaterFunction(2000)) ,
                (EmployeeCategory.third , GrossSalaryCalculaterFunction(3000)) ,


            };
        }

        /// <summary>
        /// get category and Bouns and clac Gross Salary 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="Bouns"></param>
        /// <returns></returns>
        public double CalcGrossSalary(EmployeeCategory category , double Bouns) {

            return GrossSalaryFunctions.Where((emp) => emp.category == category).Select((emp) => emp.GrossSalaryCalcFunc(Bouns)).First();
        }
        
        /// <summary>
        /// Clouser  Function 
        /// </summary>
        /// <param name="BasicSalary"></param>
        /// <returns></returns>
        private static Func<double, double> GrossSalaryCalculaterFunction(double BasicSalary)
        {

            var Tax = BasicSalary * 0.2;
            return (Bouns) =>
            {

                return Bouns * Tax * BasicSalary;

            };

        }
    }
}

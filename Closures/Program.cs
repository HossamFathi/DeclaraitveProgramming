using Closures.ConseptExamples;
using System;

namespace Closures
{
    class Program
    {
        static void Main(string[] args)
        {
            GrossSalaryCalculaterEx calculater = new GrossSalaryCalculaterEx();
            Console.WriteLine( "First categ {0}" ,  calculater.CalcGrossSalary(EmployeeCategory.Employee, 1000));
            Console.WriteLine( "Second Categ {0}" , calculater.CalcGrossSalary(EmployeeCategory.Saler, 600));
            Console.WriteLine( "Third Categ {0}" ,  calculater.CalcGrossSalary(EmployeeCategory.Manger, 400));
        }
    }
}

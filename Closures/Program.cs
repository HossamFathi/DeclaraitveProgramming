using Closures.ConseptExamples;
using System;

namespace Closures
{
    class Program
    {
        static void Main(string[] args)
        {
            GrossSalaryCalculaterEx calculater = new GrossSalaryCalculaterEx();
            Console.WriteLine( "First categ {0}" ,  calculater.CalcGrossSalary(EmployeeCategory.first, 1000));
            Console.WriteLine( "Second Categ {0}" , calculater.CalcGrossSalary(EmployeeCategory.second, 600));
            Console.WriteLine( "Third Categ {0}" ,  calculater.CalcGrossSalary(EmployeeCategory.third, 400));
        }
    }
}

using FunctionComposition.ExtantionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionComposition.ConceptExamples
{
    public class CompositFunctionsEX
    {


        #region decleration

        
        private static List<double> MyData = new List<double>() { 7, 4, 5, 6, 3, 8, 10 };

        #region Delegates

       private static Func<double, double> SpecificTypeCompositFunctions = Compoisite(AddOne , Square , subtractTen);

        
        #endregion

        #endregion

        private static void Pipline()
        {


            MyData.Select(AddOne).Select(Square).Select(subtractTen).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }
        private static void ShorterPipline() {
           
            MyData.Select(x=> subtractTen(Square(AddOne(x)))).ToList().ForEach(x => Console.WriteLine(x.ToString()));

        }
        private static void SpecificCompositPipline() {


            MyData.Select(SpecificTypeCompositFunctions).ToList().ForEach(x => Console.WriteLine(x.ToString()));

        }
        private static void GenericCompositPipline()
        {


            MyData.Select(AddOneSquareSubtractTen()).ToList().ForEach(x => Console.WriteLine(x.ToString()));

        }

        public static void RunPiplines()
        {
            Console.WriteLine("Pipline");
            Pipline();
            Console.WriteLine("Shorter Pipline");
            ShorterPipline();
            Console.WriteLine("Specific Composit Pipline");
            SpecificCompositPipline();
            Console.WriteLine("Generic Composit Pipline");
            GenericCompositPipline();
        }


        #region functins 
        private static double AddOne(double PiorData)
        {

            return PiorData + 1;
        }
        private static double Square(double dataPlusOne)
        {

            return dataPlusOne * dataPlusOne;

        }
        private static double subtractTen(double squaerdData)
        {

            return squaerdData - 10;

        }


        private static Func<double, double> Compoisite(Func<double , double> F1 , Func<double, double> F2 , Func<double, double> F3)
        {
            return (x) =>  F3(F2(F1(x)));

       
        }


        private static Func<double, double> AddOneSquareSubtractTen() {

            Func<double, double> AddOneDelg = AddOne;
            Func<double, double> SquareDelg = Square;
            Func<double, double> SubTEnDelg = subtractTen;

            return AddOneDelg.Composit(Square).Composit(subtractTen);
        
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplineConcept.ConceptExample
{
    public class EX1
    {
        private static List<double> MyData = new List<double>() { 7, 4, 5, 6, 3, 8, 10 };


        public static void Imparive()
        {
            var newdata = new List<double>();
            foreach (var item in MyData)
            {
                //Console.WriteLine(item.ToString()); //  first Condition 

                // less than 70 go to three phase 
                double newItem = Square(AddOne(item));
                if (newItem < 70)

                    newdata.Add(subtractTen(newItem));

            }

            // maintains condition 

            //print  leatest  two values
            newdata = newdata.OrderBy(x => x).ToList();
            int count = 0;
            foreach (var item in newdata)
            {
                if (count > 1)
                    break;
                Console.WriteLine(item.ToString());
                count++;
            }

        }


        public static void Declarative()
        {


            MyData.Select(AddOne).Select(Square).Where(x => x < 70).OrderBy(x => x).Take(2).Select(subtractTen).ToList().ForEach(x => Console.WriteLine(x.ToString()));
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
        #endregion


    }
}

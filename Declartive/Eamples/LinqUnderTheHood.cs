using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Declartive.LikeLinq;

namespace Declartive.Eamples
{
   public class LinqUnderTheHood
    {
        private static List<double> MyData = new List<double>() { 2, 1, 3, 6, 9, 10, 11 , 13 , 18 };
        public LinqUnderTheHood()
        {
            DoTake().ToList().ForEach(d => Console.WriteLine(d.ToString())); // Custom Linq

            // genaric Linq
            MyData.NSelect(AddOne).NSelect(Square).NSelect(subtractTen).NWhere((x) => x < 5).NTake(2).ToList().ForEach(d => Console.WriteLine(d.ToString()));
        }
        public IEnumerable<double> DoAddOne() {

            foreach (var data in MyData)
            {
                yield return AddOne(data);
            }
        
        }
        public IEnumerable<double> DoSquare()
        {

            foreach (var data in DoAddOne())
            {
                yield return Square(data);
            }

        }
        public IEnumerable<double> DoSubtractTen()
        {

            foreach (var data in DoSquare())
            {
                yield return subtractTen(data);
            }

        }
        public IEnumerable<double> DoWhile()
        {
            Func<double, bool> Condition = (x) => x > 5;

            foreach (var data in DoSubtractTen())
            {
                if (Condition(data)) {

                    yield return data;
                }
              
            }

        }
        public IEnumerable<double> DoTake()
        {
            int number = 2, counter = 0;
            IEnumerator<double> data = DoWhile().GetEnumerator();
            do
            {

                if (counter != number) { data.MoveNext(); };
                if(counter < number){
                    var CurrentData = data.Current;
                    yield return (int)CurrentData;
                    counter++;
                }
               else yield break;

            } while (true);

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

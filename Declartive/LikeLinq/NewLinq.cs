using System;
using System.Collections.Generic;

namespace Declartive.LikeLinq
{
    public static class NewLinq
    {
        public static IEnumerable<T> NSelect<T>(this IEnumerable<T> Source , Func<T , T> Function ) {

            foreach (var item in Source)
            {
                yield return Function(item);
            }
       
        }
        public static IEnumerable<T> NTake<T>(this IEnumerable<T> Source , int number) {

            int counter = 0;
            IEnumerator<T> data = Source.GetEnumerator();
            
            do {
                if (counter != number) { data.MoveNext(); }
                if (counter < number) {
                    var currentdata = data.Current;
                    yield return currentdata;
                    counter++;
                
                }
              else yield break;
            
            } while (true);
      
        }

        public static IEnumerable<T> NWhere<T>(this IEnumerable<T> Source, Func<T, bool> Condition) {


            foreach (var data in Source)
            {
                if (Condition(data))
                    yield return data;

            }
        
        }

        public static int NSum<T>(this IEnumerable<int> Source)   {


            int Sum = 0; 
            foreach (var item in Source)
            {
                Sum += item;
            }
            return Sum;
        
        }
        public static double NSum<T>(this IEnumerable<double> Source)
        {


            double Sum = 0;
            foreach (var item in Source)
            {
                Sum += item;
            }
            return Sum;

        }



    }
}

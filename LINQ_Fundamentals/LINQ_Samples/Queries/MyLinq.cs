using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    public static class MyLinq
    {
        //extending the IEnumerate method to emulate a linq Where method
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            //the usual way to emulate this kind of method 
            /*
            var result = new List<T>();

            foreach (var item in source)
            {
                if(predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
            */

            //the way linq create the method
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    //yield is used to return an iteration result
                    //this way you don't need a collection to return and the results is returned one by one, not just in the end of the method
                    //it's called deferred execution - the minimum amount of work necessary to perform the expected result, so thwe query just run when it's called
                    yield return item;
                }
            }

        }

    }
}

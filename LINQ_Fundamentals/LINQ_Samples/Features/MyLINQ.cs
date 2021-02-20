using System;
using System.Collections.Generic;
using System.Text;

namespace Features
{
    //it'll imitate the Linq queries using extension methods
    public static class MyLinq
    {
        //return an int and receive any IEnumerable from any type
        //this is used to extend the method
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            var count = 0;

            foreach (var item in sequence)
            {
                count++;
            }

            return count;
        }
    }
}

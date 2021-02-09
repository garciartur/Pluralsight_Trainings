using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//library composed by reusable methods
namespace CM_Common
{
    //a static class can be directly called
    //it's used in support classes like this
    //the methods need to be static too
    public static class StringHandler
    {
        //"this" is used to extend the type string 
        //now it's a extended method and it can be called directly by de string and it's showed in intellisense
        //insert a space before upper case char
        public static string InsertSpace(this string source)
        {
            var result = string.Empty;

            //validate the parameter
            if (!string.IsNullOrWhiteSpace(source))
            {
                foreach (var letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        //it cleans all the white space to the right and to the left 
                        //prevents space before the word
                        result = result.Trim();
                        result += " ";
                    }

                    result += letter;
                }
            }

            //prevents double space between words 
            result = result.Trim();
            return result;
        }
    }
}

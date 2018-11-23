using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novice.LINQ
{
    public class join_1
    {
        public static string GetInnerCharacters(string str1, string str2)
        {
            IEnumerable<char> result = from el1 in str1 join el2 in str2 on el1 equals el2 select el1;
            return new string(result.ToArray());
        }
    }
}

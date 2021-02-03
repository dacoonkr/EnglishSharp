using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishSharp.filesys
{
    class BasicData
    {
        static HashSet<char> operators = new HashSet<char> {
            '(', ')', '+', '*', '/', ',', '|', '{', '}' 
        };

        public static Dictionary<string, string> templates = new Dictionary<string, string>
        {
            { "main_class", @"
namespace EnglishSharp
{
    class Program
    {
        {{render}}
    }
}"
            },
            { "main_method", @"
static void Main(string[] args) {
    {{render}}
}
"
            },
            { "block_if", @"
if ({{render0}}) {
    {{render1}}
}
" }
        };

        public static bool isOperator(char c)
        {
            return operators.Contains(c);
        }
    }
}
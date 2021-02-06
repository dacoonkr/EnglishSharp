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
}"          },
            { "main_method", @"
static void Main(string[] args) {
    {{render}}
}"          },
            { "block_if", @"
if ({{render0}}) {
    {{render1}}
}"          }, { "repeat", @"
for (int {{render0}} = 0; {{render0}} < {{render1}}; {{render0}}++) {
    {{render2}}
}"          }, { "while", @"
while ({{render0}}) {
    {{render1}}
}"          }, { "return", @"
return {{render}};"
            }
        };

        public static bool isOperator(char c)
        {
            return operators.Contains(c);
        }
    }
}
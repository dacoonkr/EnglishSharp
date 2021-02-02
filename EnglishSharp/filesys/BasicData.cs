using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishSharp.filesys
{
    class BasicData
    {
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
            }
        };
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishSharp.utils
{
    class Filter
    {
        public static bool isEmpty(string s)
        {
            return s.Trim() == string.Empty;
        }

        public static int countIndent(string s)
        {
            int indent_count = 0;
            for (; s[indent_count] == ' ' || s[indent_count] == '\t'; indent_count++);

            return indent_count;
        }

        public static string refactor(string s)
        {
            string ret = string.Empty;

            return ret;
        }
    }
}
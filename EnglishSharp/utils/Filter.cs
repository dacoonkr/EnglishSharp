using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            for (; s[indent_count] == ' ' || s[indent_count] == '\t'; indent_count++) ;

            return indent_count;
        }

        public static string refactor(string s)
        {
            string ret = string.Empty;

            bool isInString = false;
            bool escaped = false;

            foreach (char i in s)
            {
                if (filesys.BasicData.isOperator(i))
                {
                    if (!isInString)
                        ret += $" {i} ";
                    else
                        ret += i;
                }
                else if (i == ':')
                {
                    if (!isInString)
                        ret += $"{i} ";
                    else
                        ret += i;
                }
                else if (i == '"')
                {
                    if (!escaped)
                        isInString = !isInString;
                    escaped = false;
                    ret += i;
                }
                else if (i == '\\')
                {
                    escaped = (isInString && !escaped);
                    ret += i;
                }
                else if (i == ';')
                {
                    if (isInString)
                        ret += i;
                    else return ret;
                }
                else
                {
                    ret += i;
                    escaped = false;
                }
            }

            return ret;
        }

        public static bool match(string regex, string content)
        {
            Match match = new Regex(regex).Match(content.ToLower());

            if (match.Success)
                return true;
            return false;
        }
    }
}
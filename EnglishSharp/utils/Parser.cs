using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EnglishSharp.utils
{
    class Parser
    {
        public static string[] splitIntoToken(string s)
        {
            var pattern = "[\\s\\t\\r\\n]+";
            string[] result = Regex.Split(s, pattern);

            return result;
        }

        public static ResultStatus parse_value(string s)
        {
            return new ResultStatus(Status.Success, s.Trim());
        }

        public static ResultStatus parse_sentence(string s)
        {
            return new ResultStatus(Status.Success, s.Trim());
        }
    }
}
﻿using System;
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

        public static List<string> splitCollection(string s)
        {
            List<string> ret = new List<string>();

            string tmp = string.Empty;
            bool isInString = false;
            bool escaped = false;

            foreach (char i in s)
            {
                if (i == ',')
                {
                    if (!isInString)
                    {
                        ret.Add(tmp.Trim());
                        tmp = string.Empty;
                    }
                    else
                        tmp += i;
                }
                else if (i == '"')
                {
                    if (!escaped)
                        isInString = !isInString;
                    escaped = false;
                    tmp += i;
                }
                else if (i == '\\')
                {
                    escaped = (isInString && !escaped);
                    tmp += i;
                }
                else
                {
                    tmp += i;
                    escaped = false;
                }
            }
            if (tmp != string.Empty) ret.Add(tmp.Trim());

            return ret;
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
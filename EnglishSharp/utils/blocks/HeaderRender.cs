using System;
using System.Collections.Generic;
using System.Text;

using EnglishSharp.transpile;
using EnglishSharp.filesys;
using EnglishSharp.utils;

namespace EnglishSharp.utils.blocks
{
    class HeaderRender
    {
        public static ResultStatus renderWithHeader(Header header, List<CodeTree> mem, int origin)
        {
            List<string> args_given = Parser.splitCollection(mem[origin].code);

            if (args_given.Count != header.arguments.Count)
                return new ResultStatus(Status.TransfileError, TranspileError.MacroDoesNotMatch.ToString());

            Dictionary<string, string> args = new Dictionary<string, string>();

            for (int i = 0; i < header.arguments.Count; i++)
            {
                if (header.arguments[i].argumentType == ArgumentType.Match)
                {
                    if (args_given[i] != header.arguments[i].name)
                        return new ResultStatus(Status.TransfileError, TranspileError.MacroDoesNotMatch.ToString());
                }
                else if (header.arguments[i].argumentType == ArgumentType.Identifier)
                {
                    args.Add(header.arguments[i].name, args_given[i]);
                }
                else if (header.arguments[i].argumentType == ArgumentType.Value)
                {
                    ResultStatus res = Parser.parse_value(args_given[i]);

                    if (res.status != Status.Success)
                        return res;

                    args.Add(header.arguments[i].name, res.content);
                }
            }


        }
    }
}
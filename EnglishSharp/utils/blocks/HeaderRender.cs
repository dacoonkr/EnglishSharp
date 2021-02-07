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
            List<string> args_given = Parser.splitCollection(mem[origin].code.Substring(header.name.Length + 1));

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

            for (int i = 0; i < header.requires.Count; i++)
            {
                if (header.requires[i].requireType == RequireType.TempIdentifier)
                {
                    args.Add(header.requires[i].name, Program.getUnusedVar());
                }
            }

            if (header.macroType == MacroType.Block)
            {
                ResultStatus res = Transpile.transpile(mem, origin);
                if (res.status != Status.Success)
                    return res;

                args.Add("innerContent", res.content);
            }

            string ret = header.template;
            foreach (var key in args.Keys)
                ret = ret.Replace($"&{key}", args[key]);

            return new ResultStatus(Status.Success, ret);
        }
    }
}
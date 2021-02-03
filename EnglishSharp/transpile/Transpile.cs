using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using EnglishSharp.utils;
using EnglishSharp.filesys;

namespace EnglishSharp.transpile
{
    class Transpile
    {
        public static ResultStatus transpile(List<CodeTree> mem, int origin)
        {
            string ret = string.Empty;

            for (int i = 0; i < mem[origin].children.Count; i++)
            {
                int parent = mem[origin].children[i];
                var elem = mem[parent];
                string code = elem.code.Trim();
                string[] code_splited = Parser.splitIntoToken(code);
                var keyword = code_splited[0];

                ResultStatus parsed;

                if (Filter.match("^(repeat)$", keyword))
                    parsed = utils.blocks.Blocks.parse_repeat(mem, parent);
                else
                    parsed = Parser.parse_sentence(code);

                if (parsed.status != Status.Success)
                    return parsed;

                ret += parsed.content + "\n";
            }

            return new ResultStatus(Status.Success, ret);
        }
    }
}
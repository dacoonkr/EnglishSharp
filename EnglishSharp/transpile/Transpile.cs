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
            Dictionary<string, Header> headers = new Dictionary<string, Header>();
            string ret = string.Empty;

            for (int i = 0; i < mem[origin].children.Count; i++)
            {
                int parent = mem[origin].children[i];
                var elem = mem[parent];
                string code = elem.code.Trim();
                string[] code_splited = Parser.splitIntoToken(code);
                var keyword = code_splited[0];

                ResultStatus parsed = new ResultStatus(Status.Success, string.Empty);

                if (Filter.match("^(import)$", keyword))
                {
                    utils.blocks.Blocks.parse_import(mem, parent);
                }
                else if (Filter.match("^(using)$", keyword))
                {
                    foreach (var header in HEPP.loadFromSource(code.Substring(6)))
                    {
                        headers.Add(header.name, header);
                    }
                }
                else
                {
                    parsed = Parser.parse_sentence(code);
                }

                if (parsed.status != Status.Success)
                    return parsed;

                ret += parsed.content + "\n";
            }

            return new ResultStatus(Status.Success, ret);
        }
    }
}
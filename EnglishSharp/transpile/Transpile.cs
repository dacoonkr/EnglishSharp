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

                string parsed = string.Empty;

                if (Filter.match("^(unless|if|else)$", keyword))
                {

                }
            }

            string mainClass = Renderer.render_mono(BasicData.templates["main_class"], ret);
            return new ResultStatus(Status.Success, mainClass);
        }
    }
}
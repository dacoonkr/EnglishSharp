using System;
using System.Collections.Generic;
using System.Text;

using EnglishSharp.transpile;

namespace EnglishSharp.utils.blocks
{
    class Blocks
    {
        public static ResultStatus parse_repeat(List<CodeTree> mem, int origin)
        {
            const string keyword = "repeat";

            ResultStatus count = utils.Parser.parse_value(mem[origin].code.Substring(keyword.Length + 1));
            ResultStatus block = Transpile.transpile(mem, origin);

            if (count.status != Status.Success) return count;
            if (block.status != Status.Success) return block;

            return new ResultStatus(Status.Success, utils.Renderer.render(filesys.BasicData.templates[keyword], new List<string> {
                Program.getUnusedVar(), count.content, block.content
            }));
        }

        /*
        public static string parse_if(List<CodeTree> mem, int iter, int origin)
        {

        }

        public static string parse_while(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_for(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_allocation(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_when(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_import(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_return(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_using(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_set(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_class(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_use(List<CodeTree> mem, int origin)
        {

        }

        public static string parse_about(List<CodeTree> mem, int origin)
        {

        }

        */
    }
}
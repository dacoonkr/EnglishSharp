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

            return new ResultStatus(Status.Success, Renderer.render(filesys.BasicData.templates[keyword], new List<string> {
                Program.getUnusedVar(), count.content, block.content
            }));
        }

        public static ResultStatus parse_ongArg(List<CodeTree> mem, int origin, string keyword)
        {
            ResultStatus arg = utils.Parser.parse_value(mem[origin].code.Substring(keyword.Length + 1));
            ResultStatus block = Transpile.transpile(mem, origin);

            if (arg.status != Status.Success) return arg;
            if (block.status != Status.Success) return block;

            return new ResultStatus(Status.Success, Renderer.render(filesys.BasicData.templates[keyword], new List<string> {
                arg.content, block.content
            }));
        }

        public static ResultStatus parse_oneLine(List<CodeTree> mem, int origin, string keyword)
        {
            ResultStatus arg = utils.Parser.parse_value(mem[origin].code.Substring(keyword.Length + 1));

            if (arg.status != Status.Success) return arg;

            return new ResultStatus(Status.Success, Renderer.render_mono(filesys.BasicData.templates[keyword], arg.content));
        }

        public static void parse_import(List<CodeTree> mem, int origin)
        {
            const string keyword = "import";

            filesys.ConvertToCS.RequirePackage(mem[origin].code.Substring(keyword.Length + 1));
        }

        /*
        public static string parse_if(List<CodeTree> mem, int iter, int origin)
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
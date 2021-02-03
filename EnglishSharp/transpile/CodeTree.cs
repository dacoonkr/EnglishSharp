using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishSharp.transpile
{
    class CodeTree
    {
        public string code;
        public int line;
        public List<int> children;

        CodeTree(string code, int line)
        {
            this.code = code;
            this.line = line;
        }

        public static List<CodeTree> treeify(string source)
        {
            var ret = new List<CodeTree> { new CodeTree("root", 0) };

            var stack = new Stack<int>();
            stack.Push(0);

            int before_indent = 0;
            string[] lines = source.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (utils.Filter.isEmpty(line)) continue;

                int indent = utils.Filter.countIndent(line);
                if (indent > before_indent)
                {
                    var last = ret[stack.Peek()].children.Count - 1;
                    stack.Push(ret[stack.Peek()].children[last]);
                }
                else if (indent < before_indent)
                {
                    for(int j = 0; j < (indent - before_indent); j++)
                        stack.Pop();
                }

                
                string code = utils.Filter.refactor(line);
                ret.Add(new CodeTree(code, i + 1));
                ret[stack.Peek()].children.Add(ret.Count - 1);

                before_indent = indent;
            }

            return ret;
        }
    }
}
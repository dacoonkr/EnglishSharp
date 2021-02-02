using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishSharp.utils
{
    class Renderer
    {
        public static string render_mono(string template, string content)
        {
            string result = template;
            result = result.Replace("{{render}}", content);

            return result;
        }

        public static string render(string template, List<string> content)
        {
            string result = template;
            for (int i = 0; i < content.Count; i++)
                result = result.Replace($"{{render{i}}}", content[i]);

            return result;
        }

        public static string add_indent(string template, int count)
        {
            string[] lines = template.Split('\n');
            string result = string.Empty;

            string indent = string.Empty;
            for (int i = 0; i < count; i++) indent += " ";

            foreach(string line in lines)
                result += indent + lines + "\n";

            return result;
        }
    }
}
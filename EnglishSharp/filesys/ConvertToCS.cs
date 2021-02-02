using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using EnglishSharp.utils;

namespace EnglishSharp.filesys
{
    class ConvertToCS
    {
        //C#코드로 변환
        public static ResultStatus convert(string source_file)
        {
            string target_file = $"target\\Program.cs";
            string source = string.Empty;



            string mainClass = Renderer.render_mono(BasicData.templates["main_class"], source);
            return new ResultStatus(Status.Success, mainClass);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

using EnglishSharp.utils;
using EnglishSharp.filesys;

namespace EnglishSharp.transpile
{
    class Transfile
    {
        public static ResultStatus transpile(string source)
        {
            string ret = string.Empty;



            string mainClass = Renderer.render_mono(BasicData.templates["main_class"], ret);
            return new ResultStatus(Status.Success, mainClass);
        }
    }
}
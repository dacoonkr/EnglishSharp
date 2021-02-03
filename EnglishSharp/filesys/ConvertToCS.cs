using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using EnglishSharp.utils;
using EnglishSharp.transpile;

namespace EnglishSharp.filesys
{
    class ConvertToCS
    {
        //C#코드로 변환 후 저장
        public static ResultStatus convert(string source_file)
        {
            string target_file = $"target\\Program.cs";
            string source = File.ReadAllText(source_file, Encoding.UTF8);


            ResultStatus ret = Transpile.transpile(source);

            if (ret.status == Status.Success)
            {
                if (!File.Exists(target_file))
                {
                    Directory.CreateDirectory("target");
                    File.Create(target_file);
                }
                File.WriteAllText(target_file, ret.content);

                return new ResultStatus(Status.Success, string.Empty);
            }
            else if (ret.status == Status.TransfileError)
            {
                return new ResultStatus(Status.TransfileError, ret.content);
            }

            return new ResultStatus(Status.Unknown, string.Empty);
        }
    }
}